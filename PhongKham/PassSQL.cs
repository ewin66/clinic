using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PhongKham;
using Clinic.Helpers;
using MySql.Data.MySqlClient;
using Clinic.Database;

namespace Clinic
{
    public partial class PassSQL : Form
    {
        public PassSQL()
        {
            InitializeComponent();
            label3.Visible = false;
            maskedTextBox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string[] lines = {textBox1.Text,maskedTextBox1.Text};
            // WriteAllLines creates a file, writes a collection of strings to the file, 
            // and then closes the file.
            System.IO.File.WriteAllLines("WriteLines.txt", lines);
            File.SetAttributes(
               "WriteLines.txt",
               FileAttributes.Archive |
               FileAttributes.Hidden 
             
               );
            
            //test connection ;
            try
            {
 
                if (checkBox1.Checked == false)
                {
                    ///Old structure
                    //MySqlConnectionStringBuilder strBuilder = new MySqlConnectionStringBuilder();
                    //strBuilder.Server = "localhost";
                    //strBuilder.UserID = "root";
                    //strBuilder.Password = textBox1.Text;
                    //Program.conn = new MySqlConnection(strBuilder.ConnectionString);
                    //Program.conn.Open();
                    //InitDatabase(Program.conn, textBox1.Text);
                    
                    ///New Structure
                    ///
                    
                }
                else
                {
                    Program.InitSqlConnection(textBox1.Text, maskedTextBox1.Text);
                    Program.conn.Open();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối SQl server thất bại , vui lòng thử lại !");
                File.Delete("WriteLines.txt");
                return;
            }

            this.DialogResult = DialogResult.OK;

        }

        private void InitDatabase(MySqlConnection conn , string pass)
        {
            string strCommand = "grant all privileges on *.* to 'root'@'%' identified by " + Helper.ConvertToSqlString(textBox1.Text);
            MySql.Data.MySqlClient.MySqlCommand comm = new MySql.Data.MySqlClient.MySqlCommand(strCommand, Program.conn);
            comm.ExecuteNonQuery();

            MySqlCommand command = new MySqlCommand("CREATE DATABASE IF NOT EXISTS clinic;", conn);

            command.ExecuteNonQuery();



            //create table
            MySqlConnectionStringBuilder strBuilder = new MySqlConnectionStringBuilder();
            strBuilder.Server = "localhost";
            strBuilder.UserID = "root";
            strBuilder.Password = pass;
            strBuilder.Database = "clinic";

            conn = new MySqlConnection(strBuilder.ConnectionString);
            conn.Open();
            command = new MySqlCommand("CREATE Table IF NOT EXISTS clinicuser(Username varchar(50),Password1  varchar(50),Authority  smallint(6), Password2  varchar(50));", conn);
            //command = new MySqlCommand("DROP Table IF EXISTS clinicuser", conn);
            command.ExecuteNonQuery();
            command = new MySqlCommand("CREATE Table IF NOT EXISTS history(Id varchar(10),Symptom Longtext,Diagnose Longtext,Medicines Longtext,Day Datetime);", conn);
            command.ExecuteNonQuery();
            command = new MySqlCommand("CREATE Table IF NOT EXISTS medicine(Name varchar(50),Count int,CostIn int,CostOut int,InputDay Datetime,Id varchar(10));", conn);
            command.ExecuteNonQuery();
            command = new MySqlCommand("CREATE Table IF NOT EXISTS patient(Name varchar(50),Address Varchar(400),birthday datetime,height int(11),weight int(11),Id varchar(10));", conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                label3.Visible = false;
                maskedTextBox1.Visible = false;
            }
            if (checkBox1.Checked == true)
            {
                label3.Visible = true;
                maskedTextBox1.Visible = true;
            }
        }
    }
}
