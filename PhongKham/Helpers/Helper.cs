//-----------------------------------------------------------------------
// <copyright file="Helper.cs" company="emotive GmbH">
//     Copyright (c) emotive GmbH. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

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
        public static void InsertRowToTable(SqlConnection conn, string nameOfTable, List<string>nameOfColumns,List<string> values)
        {

            for (int i = 0; i < values.Count; i++)
            {
                values[i] = ConvertToSqlString(values[i]);
            }

            string columns = "Insert Into " +nameOfTable+" (";
            foreach (string name in nameOfColumns)
            {
                columns += name + ",";
            }
            columns = columns.Remove(columns.Length - 1);
            columns += ")"; 
            string vals = " VALUES (";
            foreach (string value in values)
            {
                vals += value + ",";
            }
            vals= vals.Remove(vals.Length -1 );
            vals += ")";

            string strCommand = columns + vals;

            SqlCommand comm = new SqlCommand(strCommand, conn);
            comm.ExecuteNonQuery();

        }

        public static void InsertRowToTable(MySqlConnection conn, string nameOfTable, List<string> nameOfColumns, List<string> values)
        {

            for (int i = 0; i < values.Count; i++)
            {
                values[i] = ConvertToSqlString(values[i]);
            }

            string columns = "Insert Into " + nameOfTable + " (";
            foreach (string name in nameOfColumns)
            {
                columns += name + ",";
            }
            columns = columns.Remove(columns.Length - 1);
            columns += ")";
            string vals = " VALUES (";
            foreach (string value in values)
            {
                vals += value + ",";
            }
            vals = vals.Remove(vals.Length - 1);
            vals += ")";

            string strCommand = columns + vals;

            MySqlCommand comm = new MySqlCommand(strCommand, conn);
            comm.ExecuteNonQuery();

        }

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

        public static void UpdateRowToTable(MySqlConnection conn, string nameOfTable, List<string> nameOfColumns,
            List<string> values, string id)
        {
            string strCommand = BuildFirstPartUpdateQuery(nameOfTable, nameOfColumns, values);

            strCommand += " Where Id='" + id +"';";

            MySqlCommand comm = new MySqlCommand(strCommand, conn);
            comm.ExecuteNonQuery();            
        }

        public static void UpdateRowToTable(MySqlConnection conn, string nameOfTable, List<string> nameOfColumns,
            List<string> values, string id, string visitDate)
        {
            string strCommand = BuildFirstPartUpdateQuery(nameOfTable, nameOfColumns, values);

            strCommand += " Where Id='" + id + "' AND Day='" + visitDate + "';";

            MySqlCommand comm = new MySqlCommand(strCommand, conn);
            comm.ExecuteNonQuery();
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


        public static bool checkAdminExists( string nameOfTable)
        {

            string strCommand = "SELECT * FROM " + nameOfTable + " WHERE Authority = 1";
           // MySqlCommand comm = new MySqlCommand(strCommand, conn);
            //MySqlDataReader reader = comm.ExecuteReader();
            IDatabase db = DatabaseFactory.Instance;
            bool hasrow =false;
            DbDataReader reader = (DbDataReader)db.ExecuteReader(strCommand, null,ref hasrow);

            try
            {
                return hasrow;
            }
            finally
            {
                reader.Close();

            }


        }

        public static string hasOtherNameForThisId(MySqlConnection conn, string Id, string name)
        {

            string strCommand = "SELECT name FROM Patient WHERE Id = " + ConvertToSqlString(Id);
            MySqlCommand comm = new MySqlCommand(strCommand, conn);
            MySqlDataReader reader = comm.ExecuteReader();
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

        public static bool checkPatientExists(MySqlConnection conn, string Id)
        {

            string strCommand = "SELECT Id FROM Patient WHERE Id = " + ConvertToSqlString(Id);
            MySqlCommand comm = new MySqlCommand(strCommand, conn);
            MySqlDataReader reader = comm.ExecuteReader();
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

        public static bool checkVisitExists(MySqlConnection conn, string Id, string visitDate)
        {

            string strCommand = "SELECT Id FROM history WHERE Id = " + ConvertToSqlString(Id) + " AND Day=" + ConvertToSqlString(visitDate) + ";";
            MySqlCommand comm = new MySqlCommand(strCommand, conn);
            MySqlDataReader reader = comm.ExecuteReader();
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
        internal static int SearchMaxValueOfTable(MySqlConnection sqlConnection, string p, string p_2, string order)
        {
            string strCommand = " SELECT  " + p_2 + " FROM " + p + " ORDER BY " + p_2 + " " + order + " LIMIT 1";
            MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
            using (MySqlDataReader reader = comm.ExecuteReader())
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
                }
                else
                {
                    intTemp = 0;
                }
                int newId = intTemp + 1;
                return newId;
            }
        }


    }
}
