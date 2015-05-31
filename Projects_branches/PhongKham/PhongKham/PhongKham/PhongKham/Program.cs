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
