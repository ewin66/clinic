using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using Clinic.Helpers;
using Clinic;
using System.Xml;
using MySql.Data.MySqlClient;
using System.IO;
using Clinic.Database;
using SoftwareLocker;

namespace PhongKham
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 


        public static string stringConnection;//= "Server =.\\SQLEXPRESS ; Database=Clinic;Integrated Security = true";
        //public static SqlConnection conn;//= new SqlConnection(stringConnection);
        public static MySqlConnection conn;

        [STAThread]
        static void Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            TrialMaker t = new TrialMaker("Clinic", Application.StartupPath + "\\RegFile.reg",
    Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\TMSetp.dbf",
    "Phone: +98 21 88281536\nMobile: +98 912 2881860",
    5, 10, "745");

            byte[] MyOwnKey = { 97, 250, 1, 5, 84, 21, 7, 63,
            4, 54, 87, 56, 123, 10, 3, 62,
            7, 9, 20, 36, 37, 21, 101, 57};
            t.TripleDESKey = MyOwnKey;

            TrialMaker.RunTypes RT = t.ShowDialog();
            bool is_trial;
            if (RT != TrialMaker.RunTypes.Expired)
            {
                if (RT == TrialMaker.RunTypes.Full)
                    is_trial = false;
                else
                    is_trial = true;

                //Application.Run(new Form1(is_trial));
            }     


            if (!File.Exists("WriteLines.txt"))
            {
                PassSQL SqlForm = new PassSQL();
                SqlForm.ShowDialog();
                if (SqlForm.DialogResult == DialogResult.Cancel)
                {
                    return;
                }

            }
            try
            {
                Logger.Log("CreateNewDatabase", "begin");
                string[] lines = System.IO.File.ReadAllLines("WriteLines.txt");
                // GetConnectionString(lines[0], lines[1]);
                DatabaseFactory.CreateNewDatabase("", GetConnectionString(lines[0], lines[1]));

            }
            catch (Exception e)
            {

                Logger.Log("CreateNewDatabase", "fail");

                File.Delete("WriteLines.txt");
                MessageBox.Show("Lỗi database! Xin chạy lại chương trình!");
            }
            try
            {

                if (!Helper.checkAdminExists("clinicuser"))
                {
                    Logger.Log("checkAdminExists", "true");
                    CreateUserForm createUserForm = new CreateUserForm();
                    if (createUserForm.ShowDialog() == DialogResult.OK)
                    {

                        LoginForm login = new LoginForm();

                        if (login.ShowDialog() == DialogResult.OK)
                        {

                            Application.Run(new Form1(LoginForm.Authority, LoginForm.Name1));
                        }
                    }
                }
                else
                {
                    Logger.Log("checkAdminExists", "false");
                    LoginForm login = new LoginForm();

                    if (login.ShowDialog() == DialogResult.OK)
                    {
                        Application.Run(new Form1(LoginForm.Authority, LoginForm.Name1));
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.Log("TryOpenLoginForm", "false");
            }
        }

        //public static void InitSqlConnection(string passSql,string IPAddress)
        //{
        //    MySqlConnectionStringBuilder strBuilder = new MySqlConnectionStringBuilder();
        //    strBuilder.Server = IPAddress=="   .   .   ."?"localhost":IPAddress;
        //    strBuilder.UserID="root";
        //    strBuilder.Password = passSql;
        //    strBuilder.Database="clinic";

        //    conn = new MySqlConnection(strBuilder.ConnectionString);
        //}

        private static DbConStringBuilder GetConnectionString(string passSql, string IPAddress)
        {
            DbConStringBuilder strBuilder = new DbConStringBuilder();
            strBuilder.Server = IPAddress == "..." ? "127.0.0.1" : IPAddress;
            strBuilder.UserID = "root";
            strBuilder.Password = passSql;
            strBuilder.Database = "clinic";
            return strBuilder;
        }
    }
}
