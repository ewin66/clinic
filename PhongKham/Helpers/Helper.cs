

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
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
    using MigraDoc.DocumentObjectModel;
    using MigraDoc.Rendering;
    using MigraDoc.DocumentObjectModel.Tables;

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
        public static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            DirectoryInfo[] directories = source.GetDirectories();
            for (int i = 0; i < directories.Length; i++)
            {
                DirectoryInfo directoryInfo = directories[i];
                CopyFilesRecursively(directoryInfo, target.CreateSubdirectory(directoryInfo.Name));
            }
            FileInfo[] files = source.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo fileInfo = files[i];
                fileInfo.CopyTo(Path.Combine(target.FullName, fileInfo.Name), true);
            }
        }

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

        public static void CreateAPdf(InfoClinic InformationOfClinic , string MaBn,Patient patient ,List<Medicine> Medicines)
        {
           //  PdfDocument pdf = new PdfDocument();
           // PdfPage pdfPage = pdf.AddPage();
           // XGraphics graph = XGraphics.FromPdfPage(pdfPage);
           //// FontFamily theFont = FontFamily.Families.Single<FontFamily>(font => font.Name == "VNI-Times");
           // XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
           // XFont font = new XFont("Times New Roman", 12, XFontStyle.Bold, options);
           // XFont fontNotBold = new XFont("Times New Roman", 12,XFontStyle.Regular, options);
           // XFont fontBoldTitle = new XFont("Times New Roman", 26, XFontStyle.Bold, options);
           // XTextFormatter tf = new XTextFormatter(graph);
           // XRect rectTopLeft = new XRect(0, 0, 150, 120);
           // XRect rectTopRight = new XRect(pdfPage.Width-200, 0, 150, 120);

           // XRect rectPatient = new XRect(20, 120, pdfPage.Width, 100);
           // XRect rectMedicines = new XRect(20, 200, pdfPage.Width, pdfPage.Height);

           // graph.DrawRectangle(XBrushes.White, rectTopLeft);
           // graph.DrawRectangle(XBrushes.White, rectTopRight);
           // graph.DrawRectangle(XBrushes.White, rectPatient);
           // graph.DrawRectangle(XBrushes.White, rectMedicines);
 

           // //
           // // top left
           // tf.DrawString("Bệnh viện xxxxx \n" + " Địa chỉ xxxxx", font, XBrushes.Black, rectTopLeft, XStringFormats.TopLeft);
           // //
           // //top right
           // tf.DrawString("Mã BN: " + MaBn, font, XBrushes.Black, rectTopRight, XStringFormats.TopLeft);



           // //
           // //patient
           // int tuoi = DateTime.Now.Year - patient.Birthday.Year;

           // tf.DrawString("Bệnh nhân:   " + patient.Name + "         - Tuổi: " + tuoi + " \n" + "Địa chỉ:         " + patient.Address, fontNotBold, XBrushes.Black, rectPatient, XStringFormats.TopLeft);



           // //
           // //medicine, notes, sign, 


           // //title
           // tf.Alignment = XParagraphAlignment.Center;
           // tf.DrawString("TOA THUỐC", fontBoldTitle, XBrushes.Black, new XRect(0, 70, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            

           // pdf.Save("firstpage.pdf");

            Document document = new Document();

            
            document.Info.Author = "Luong Y";

            // Get the A4 page size
            Unit width, height;
            PageSetup.GetPageSize(PageFormat.A5, out width, out height);
            Section section = document.AddSection();

            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.Alignment = ParagraphAlignment.Left;

            paragraph.AddText("Bệnh viện: " + InformationOfClinic.Name); //+"Mã BN: " + patient.Id + " \n" +" Địa chỉ xxxxx");
            paragraph.AddText(" \n");
            paragraph.AddText("Địa chỉ: " + InformationOfClinic.Address);
            paragraph.AddText(" \n");
            paragraph.AddText(" \n");



            Paragraph paragraphTitle = section.AddParagraph();
            paragraphTitle.Format.Alignment = ParagraphAlignment.Center;
            paragraphTitle.AddFormattedText("TOA THUỐC \n \n", new MigraDoc.DocumentObjectModel.Font("Times New Roman", 28));






            Table table = new Table();
            table.Borders.Width = 0;
            Column column = table.AddColumn();
            column.Width = 80;
            table.AddColumn(280);
            table.AddColumn();
            Row row = table.AddRow();
            row.Cells[0].AddParagraph("Bệnh nhân: ");
            row.Cells[1].AddParagraph(patient.Name);
            int tuoi = DateTime.Now.Year - patient.Birthday.Year;
            row.Cells[2].AddParagraph("Tuổi:" + tuoi);
            Row row2 = table.AddRow();
            row2.Cells[0].AddParagraph("Địa chỉ: ");
            row2.Cells[1].AddParagraph(patient.Address);
            



            Table tableMedicines = new Table();
            tableMedicines.Borders.Width = 0;
            tableMedicines.BottomPadding = 10;
            Column columnMedicines1 = tableMedicines.AddColumn(30);
            Column columnMedicines2 = tableMedicines.AddColumn(300);
            Column columnMedicines3 = tableMedicines.AddColumn(70);
            Row rowMedicinesHeader = tableMedicines.AddRow();
            rowMedicinesHeader.Cells[0].AddParagraph("STT");
            rowMedicinesHeader.Cells[1].AddParagraph("Tên thuốc/Cách dùng");
            rowMedicinesHeader.Cells[2].AddParagraph("Số lượng");
            for (int i = 0; i < Medicines.Count; i++)
            {
                Row rowDetail = tableMedicines.AddRow();
                rowDetail.Cells[0].AddParagraph((i+1).ToString());
                rowDetail.Cells[1].AddParagraph(Medicines[i].Name +"\n"+ Medicines[i].HDSD);        
                rowDetail.Cells[2].AddParagraph(Medicines[i].Number.ToString());
            }

            //Table loi dan , chu ky
            Table signatureAndMore = new Table();
            signatureAndMore.Borders.Width = 0;
            Column columnsignatureAndMore1 = signatureAndMore.AddColumn(250);
            Column columnsignatureAndMore2 = signatureAndMore.AddColumn(30);
            Column columnsignatureAndMore3 = signatureAndMore.AddColumn(200);
            Row rowsignatureAndMore1 = signatureAndMore.AddRow();
            
            rowsignatureAndMore1.Cells[0].AddParagraph("Lời dặn: "+InformationOfClinic.Advice);
            rowsignatureAndMore1.Cells[2].AddParagraph("Tp. HCM, "+"Ngày "+DateTime.Now.Day+" tháng "+DateTime.Now.Month+" năm "+DateTime.Now.Year);
            Row rowsignatureAndMore2 = signatureAndMore.AddRow();
            rowsignatureAndMore2.VerticalAlignment = VerticalAlignment.Center;
            Paragraph para= rowsignatureAndMore2.Cells[2].AddParagraph("Bác sĩ khám");
            para.Format.Alignment = ParagraphAlignment.Center;

            document.LastSection.Add(table);
            document.LastSection.AddParagraph("\n");
            document.LastSection.Add(tableMedicines);
            document.LastSection.AddParagraph("\n");
            document.LastSection.Add(signatureAndMore);



            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            pdfRenderer.PdfDocument.Save("firstpage.pdf");


        }

        internal static string ConvertToDatetimeSql(DateTime dateTime)
        {
            return dateTime.Year+"-"+dateTime.Month+"-"+dateTime.Day + " " + dateTime.Hour + ":" + dateTime.Minute + ":" + dateTime.Second;
        }

        internal static System.Drawing.Color ConvertCodeToColor(int p)
        {
            switch (p)
            {
                case 1:
                    return System.Drawing.Color.Red;
                case 2:
                    return System.Drawing.Color.Yellow;
                case 3:
                    return System.Drawing.Color.Green;
                case 4:
                    return System.Drawing.Color.Blue;
                default:
                    return System.Drawing.Color.White;
            }
        }



        internal static List<Medicine> GetAllMedicinesFromDataGrid(IDatabase db,System.Windows.Forms.DataGridView dataGridView)
        {
            List<string> listIdMedicines = new List<string>();
            List<int> listCountMedicines = new List<int>();


            for (int i = 0; i < dataGridView.Rows.Count-1; i++)
            {
                listIdMedicines.Add(dataGridView[DatabaseContants.IdColumnInDataGridViewMedicines, i].Value.ToString());
                listCountMedicines.Add(int.Parse(dataGridView[DatabaseContants.CountColumnInDataGridViewMedicines, i].Value.ToString()));
            }

            string listStr = ConvertListToListSQL(listIdMedicines);

            string command = "select * from medicine WHERE Id IN " + listStr;
            DbDataReader reader = db.ExecuteReader(command, null) as DbDataReader;
            
            List<Medicine> result = new List<Medicine>();

            int k = 0;
            while (reader.Read())
            {
                Medicine medic = new Medicine();
                medic.Id =  reader[DatabaseContants.medicine.Id].ToString();
                medic.Number = listCountMedicines[k];
                k++;

                medic.Name = reader[DatabaseContants.medicine.Name].ToString();
                medic.HDSD = reader[DatabaseContants.medicine.Hdsd].ToString();
                result.Add(medic);
            }
            reader.Close();
            return result;

            //for (int i = 0; i < listMedicines.Count; i++)
            //{

            //}
        }

        private static string ConvertListToListSQL( List<string>  listIdMedicines)
        {
            string result = "(";
            for (int i = 0; i < listIdMedicines.Count; i++)
            {
                result += ConvertToSqlString(listIdMedicines[i])+',';

            }
            result= result.Substring(0,result.Length-1);
            result = result += ")";
            return result;
        }

        internal static List<string> FilterServicesFromAllMedicines(List<string> currentMedicines)
        {
            List<string> services = new List<string>();
            foreach (string medi in currentMedicines)
            {
                if (medi[0] == '@')
                {
                    services.Add(medi);
                }
            }
            return services;
        }

        internal static bool CheckMedicineExists(IDatabase db, string Id)
        {
            string strCommand = "SELECT Id FROM medicine WHERE Id = " + ConvertToSqlString(Id);
            DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader;
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
        public static string ChangeListMedicines(string medicines)
        {
            if(!medicines.Contains(','))
            {
                return "";
            }
            string result = "";
            string[] medicinesAndCount = medicines.Split(',');
            for (int i = 0; i < medicinesAndCount.Length; i=i+2)
            {
                string temp = medicinesAndCount[i] +"       " + medicinesAndCount[i + 1];
                result += temp;
                if (i != medicinesAndCount.Length - 2)
                {
                    result += "\n";
                }
            }
            return result;
        }
    }
}
