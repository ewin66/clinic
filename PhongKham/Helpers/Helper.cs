

namespace Clinic.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
using System.Data.SqlClient;
    using System.Security.Cryptography;
    using System.IO;
    using System.Security.Permissions;
    using PhongKham;
    using MySql.Data.MySqlClient;
    using Clinic.Database;
    using System.Data;
    using System.Data.Common;
    using Clinic.Models;
    using System.Drawing;

    /// <summary>
    /// Comment for the class
    /// </summary>
    public class Helper
    {
        #region Fields
        private static readonly byte[] _key = { 0xA1, 0xF1, 0xA6, 0xBB, 0xA2, 0x5A, 0x37, 0x6F, 0x81, 0x2E, 0x17, 0x41, 0x72, 0x2C, 0x43, 0x27 };
        private static readonly byte[] _initVector = { 0xE1, 0xF1, 0xA6, 0xBB, 0xA9, 0x5B, 0x31, 0x2F, 0x81, 0x2E, 0x17, 0x4C, 0xA2, 0x81, 0x53, 0x61 };
        #endregion

        #region ctors

        #endregion

        #region Properties

        #endregion

        #region Methods


        public static string ChangePositionOfDayAndYear(string datetime)
        {
            string[] temp = datetime.Split('-');
            return temp[2] + '-' + temp[1] + '-' + temp[0];
        }


        public static string Decrypt(string Value)
        {
            SymmetricAlgorithm mCSP;
            ICryptoTransform ct = null;
            MemoryStream ms = null;
            CryptoStream cs = null;
            byte[] byt;
            byte[] _result;

            mCSP = new RijndaelManaged();

            try
            {
                mCSP.Key = _key;
                mCSP.IV = _initVector;
                ct = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);


                byt = Convert.FromBase64String(Value);

                ms = new MemoryStream();
                cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();

                cs.Close();
                _result = ms.ToArray();
            }
            catch
            {
                _result = null;
            }
            finally
            {
                if (ct != null)
                    ct.Dispose();
                if (ms != null)
                    ms.Dispose();
                if (cs != null)
                    cs.Dispose();
            }

            return ASCIIEncoding.UTF8.GetString(_result);
        }

        public static string Encrypt(string Password)
        {
            if (string.IsNullOrEmpty(Password))
                return string.Empty;

            byte[] Value = Encoding.UTF8.GetBytes(Password);
            SymmetricAlgorithm mCSP = new RijndaelManaged();
            mCSP.Key = _key;
            mCSP.IV = _initVector;
            using (ICryptoTransform ct = mCSP.CreateEncryptor(mCSP.Key, mCSP.IV))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, ct, CryptoStreamMode.Write))
                    {
                        cs.Write(Value, 0, Value.Length);
                        cs.FlushFinalBlock();
                        cs.Close();
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }


        public static bool checkId(string Id)
        {
            if (Id.Length < 6)
            {
                return false;
            }
            return true;
        }
        #endregion
        public static string ConvertToSqlString(string str)
        {
            return "'" + str + "'";
        }
        //public static void InsertRowToTable( string nameOfTable, List<string>nameOfColumns,List<string> values)
        //{

        //    for (int i = 0; i < values.Count; i++)
        //    {
        //        values[i] = ConvertToSqlString(values[i]);
        //    }

        //    string columns = "Insert Into " +nameOfTable+" (";
        //    foreach (string name in nameOfColumns)
        //    {
        //        columns += name + ",";
        //    }
        //    columns = columns.Remove(columns.Length - 1);
        //    columns += ")"; 
        //    string vals = " VALUES (";
        //    foreach (string value in values)
        //    {
        //        vals += value + ",";
        //    }
        //    vals= vals.Remove(vals.Length -1 );
        //    vals += ")";

        //    string strCommand = columns + vals;

        //    SqlCommand comm = new SqlCommand(strCommand, conn);
        //    comm.ExecuteNonQuery();

        //}

        //public static void InsertRowToTable(MySqlConnection conn, string nameOfTable, List<string> nameOfColumns, List<string> values)
        //{

        //    for (int i = 0; i < values.Count; i++)
        //    {
        //        values[i] = ConvertToSqlString(values[i]);
        //    }

        //    string columns = "Insert Into " + nameOfTable + " (";
        //    foreach (string name in nameOfColumns)
        //    {
        //        columns += name + ",";
        //    }
        //    columns = columns.Remove(columns.Length - 1);
        //    columns += ")";
        //    string vals = " VALUES (";
        //    foreach (string value in values)
        //    {
        //        vals += value + ",";
        //    }
        //    vals = vals.Remove(vals.Length - 1);
        //    vals += ")";

        //    string strCommand = columns + vals;

        //    MySqlCommand comm = new MySqlCommand(strCommand, conn);
        //    comm.ExecuteNonQuery();

        //}

        private static string BuildFirstPartUpdateQuery(string nameOfTable, List<string> nameOfColumns, List<string> values)
        {
            string strCommand = "Update " + nameOfTable + " Set ";
            for (int i = 0; i < nameOfColumns.Count; i++)
            {
                if (nameOfColumns[i] != "Id")
                {
                    strCommand += nameOfColumns[i] + "='" + values[i] + "',";
                }
            }
            strCommand = strCommand.Remove(strCommand.Length - 1);
            return strCommand;
        }

        public static void UpdateRowToTable(IDatabase db, string nameOfTable, List<string> nameOfColumns,
            List<string> values, string id)
        {
            string strCommand = BuildFirstPartUpdateQuery(nameOfTable, nameOfColumns, values);

            strCommand += " Where Id='" + id +"';";

            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            db.ExecuteNonQuery(strCommand,null);            
        }

        public static void UpdateRowToTable(IDatabase db, string nameOfTable, List<string> nameOfColumns,
            List<string> values, string id, string visitDate)
        {
            string strCommand = BuildFirstPartUpdateQuery(nameOfTable, nameOfColumns, values);

            strCommand += " Where Id='" + id + "' AND Day='" + visitDate + "';";

            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            db.ExecuteNonQuery(strCommand,null);
        }

        public static void UpdateRowToTableCalendar(IDatabase db, string nameOfTable, List<string> nameOfColumns,
    List<string> values, string id, string Username)
        {
            string strCommand = BuildFirstPartUpdateQuery(nameOfTable, nameOfColumns, values);

            strCommand += " Where IdCalendar='" + id + "' AND Username='" + Username + "';";

            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            db.ExecuteNonQuery(strCommand, null);
        }


        public static void DeleteRowToTableCalendar(IDatabase db, string nameOfTable, string id, string Username)
        {
            string strCommand = "Delete From " + nameOfTable;

            strCommand += " Where IdCalendar='" + id + "' AND Username='" + Username + "';";

            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            db.ExecuteNonQuery(strCommand, null);
        }

        public static bool checkAdminExists(SqlConnection conn, string nameOfTable)
        {

            string strCommand = "SELECT * FROM " + nameOfTable + " WHERE Authority = '1'";
            SqlCommand comm = new SqlCommand(strCommand, conn);
            SqlDataReader reader = comm.ExecuteReader();
            reader.Read();
           
            try
            {
                return reader.HasRows;
            }
            finally
            {
                reader.Close();

            }
            
            
        }

        public static List<string> GetAllRowsOfSpecialColumn(string table , string nameOfColumn)
        {
            List<string> result = new List<string>();
            string strCommand = "SELECT "+nameOfColumn+" FROM "+table;
            IDatabase database = DatabaseFactory.Instance;
            DbDataReader reader = database.ExecuteReader(strCommand, null) as DbDataReader;
            while (reader.Read())
            {
                string name = reader.GetString(0).Trim();
                result.Add(name);
            }
            reader.Close();
            return result;
        }

        public static List<ADate> GetAllDateOfUser(string Username, IDatabase db)
        {
            List<ADate> ListDate = new List<ADate>();
            string strCommand = "Select * from calendar where Username = " + Helper.ConvertToSqlString(Username);
            DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader;
            while (reader.Read())
            {
                ListDate.Add(BoxingDate(reader));
            }
            reader.Close();
            return ListDate;
        }

        private static ADate BoxingDate(DbDataReader reader)
        {
            ADate date = new ADate();
            date.Text = reader["Text"].ToString();
            date.color = (int)reader["Color"];
            date.StartTime = (DateTime)reader["StartTime"];
            date.EndTime = (DateTime)reader["EndTime"];
            date.Id = (int)reader["IdCalendar"];
            return date;
        }

        public static bool checkUserExists(string user, string pass,bool setAuthority)
        {
            string strCommand = "Select Authority From ClinicUser Where Username = " + Helper.ConvertToSqlString(user) + " And Password1 = " + Helper.ConvertToSqlString(Helper.Encrypt(pass));

            IDatabase database = DatabaseFactory.Instance;

            IDataReader reader = database.ExecuteReader(strCommand, null);
            reader.Read();
            if (((DbDataReader)reader).HasRows)
            {
                if (setAuthority) LoginForm.Authority = int.Parse(reader["Authority"].ToString());
                
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
           
        }

        public static bool checkAdminExists( string nameOfTable)
        {

            string strCommand = "SELECT * FROM " + nameOfTable + " WHERE Authority = 1";
           // MySqlCommand comm = new MySqlCommand(strCommand, conn);
            //MySqlDataReader reader = comm.ExecuteReader();
            IDatabase db = DatabaseFactory.Instance;
            bool hasrow =false;
            DbDataReader reader = (DbDataReader)db.ExecuteReader(strCommand, null);
            
            try
            {
                reader.Read();
                return reader.HasRows;
            }
            finally
            {
                reader.Close();
                db.CloseCurrentConnection();
            }


        }

        public static string hasOtherNameForThisId(IDatabase db, string Id, string name)
        {

            string strCommand = "SELECT name FROM Patient WHERE Id = " + ConvertToSqlString(Id);
            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            DbDataReader reader = db.ExecuteReader(strCommand,null) as DbDataReader;
            reader.Read();

            try
            {
                if (reader.HasRows)
                {
                    if (reader.GetValue(0) as string != name)
                    {
                        return reader.GetValue(0) as string;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                reader.Close();

            }


        }

        public static bool checkPatientExists(IDatabase db, string Id)
        {

            string strCommand = "SELECT Id FROM Patient WHERE Id = " + ConvertToSqlString(Id);
            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            DbDataReader reader = db.ExecuteReader(strCommand,null) as DbDataReader;
            reader.Read();

            try
            {
                return reader.HasRows;
            }
            finally
            {
                reader.Close();

            }


        }

        public static bool checkVisitExists(IDatabase db, string Id, string visitDate)
        {

            string strCommand = "SELECT Id FROM history WHERE Id = " + ConvertToSqlString(Id) + " AND Day=" + ConvertToSqlString(visitDate) + ";";
            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            DbDataReader reader = db.ExecuteReader(strCommand,null) as DbDataReader;
            reader.Read();
            try
            {
                return reader.HasRows;
            }
            finally
            {
                reader.Close();

            }
        }

        public static bool DoesUserHavePermission()
        {
            try
            {
                SqlClientPermission clientPermission = new SqlClientPermission(PermissionState.Unrestricted);
                clientPermission.Demand();
                return true;
            }
            catch
            {
                return false;
            }
        }


        //internal static int SearchMaxValueOfTable(SqlConnection sqlConnection, string p, string p_2 ,string order)
        //{
        //    string strCommand =" SELECT TOP 1 "+p_2+" FROM "+p+" ORDER BY "+p_2+" "+order;
        //    SqlCommand comm = new SqlCommand(strCommand, Program.conn);
        //    using (SqlDataReader reader = comm.ExecuteReader())
        //    {

        //        reader.Read();
        //        int intTemp;
        //        if (reader.HasRows)
        //        {
        //            string temp = reader.GetValue(0).ToString();
        //            intTemp = int.Parse(temp);
        //        }
        //        else
        //        {
        //            intTemp = 0;
        //        }
        //        int newId = intTemp + 1;
        //        return newId;
        //    }
        //}
        internal static int SearchMaxValueOfTable( string table, string nameOfColumn, string order)
        {
            string strCommand = " SELECT  " + nameOfColumn + " FROM " + table + " ORDER BY " + nameOfColumn + " " + order + " LIMIT 1";
            //MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
            IDatabase db = DatabaseFactory.Instance;
            using (DbDataReader reader = db.ExecuteReader(strCommand,null) as DbDataReader)
            {

                reader.Read();
                int intTemp = 0;
                if (reader.HasRows)
                {
                    string temp = reader.GetValue(0).ToString();
                    try
                    {
                        intTemp = int.Parse(temp);
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
                else
                {
                    intTemp = 0;
                }
                int newId = intTemp + 1;
                return newId;
            }
        }


       // public Patient AddNewPatient(SqlConnection conn, string id, bool Old)
        //{
            //Patient patient = new Patient();
            //patient.Name = txtBoxWaitRoomName.Text.Trim();

            //patient.Birthday = dateTimePicker2.Value;
            //patient.Old = DateTime.Now.Year - patient.Birthday.Year;
            //patient.Address = txtBoxWaitRoomAddress.Text;
            //patient.Symptom = txtBoxWaitingRoomSymptom.Text;
            //patient.Id = id;
            //try
            //{
            //    patient.Weight = int.Parse(txtBoxWaitingRoomWeight.Text);
            //}
            //catch (Exception ex)
            //{
            //    patient.Weight = 0;
            //}
            //try
            //{
            //    patient.Height = int.Parse(txtBoxWaitRoomHeight.Text);
            //}
            //catch (Exception ex)
            //{
            //    patient.Height = 0;
            //}

            //if (Old)
            //{
            //    return patient;
            //}

            //List<string> columns = new List<string>() { "Name", "Old", "Address", "Height", "Weight", "Birthday", "Id" };
            //List<string> values = new List<string>() { patient.Name, patient.Old.ToString(), patient.Address, patient.Height.ToString(), patient.Weight.ToString(), patient.Birthday.ToString("yyyy-MM-dd"), patient.Id };

            //Helper.InsertRowToTable(conn, "Patient", columns, values);
            //MessageBox.Show("Thêm mới bệnh nhân thành công");

            //return patient;

       // }



        internal static string ConvertToDatetimeSql(DateTime dateTime)
        {
            return dateTime.Year+"-"+dateTime.Month+"-"+dateTime.Day + " " + dateTime.Hour + ":" + dateTime.Minute + ":" + dateTime.Second;
        }

        internal static System.Drawing.Color ConvertCodeToColor(int p)
        {
            switch (p)
            {
                case 1:
                    return Color.Red;
                case 2:
                    return Color.Yellow;
                case 3:
                    return Color.Green;
                case 4:
                    return Color.Blue;
                default:
                    return Color.White;
            }
        }
    }
}
