﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PhongKham;
using Clinic.Helpers;


namespace Clinic
{
    public partial class CreateUserForm : Form
    {


        public CreateUserForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {

            if (!checkConfirmTwoPass())
            {
                MessageBox.Show("Mật khẩu xác nhận không đúng");
                return;
            }
            List<string> columns = new List<string>() {"Username","Password1","Authority","Password2"};
            List<string> values = new List<string>() { textBox1.Text, Helper.Encrypt(textBox2.Text), "1", Helper.Encrypt(textBox4.Text) };
            
            Helpers.Helper.InsertRowToTable(Program.conn, "ClinicUser", columns, values);
            this.DialogResult = DialogResult.OK;

            this.Close();


        }
        private bool checkConfirmTwoPass()
        {
            return (textBox2.Text == textBox3.Text && textBox4.Text == textBox5.Text);
        }
    }
}
