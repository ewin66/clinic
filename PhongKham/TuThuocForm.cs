using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinic.Models;
using Clinic.Helpers;

namespace Clinic
{
    public partial class TuThuocForm : Form
    {
        public TuThuocForm()
        {
            InitializeComponent();
        }

        private void TuThuocForm_Load(object sender, EventArgs e)
        {
            List<Medicine> listMedicines = Helper.GetAllMedicinesFromDB();
            for (int i = 0; i < listMedicines.Count; i++)
            {
                int index = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[index];
                row.Cells["ColumnId"].Value = listMedicines[i].Id;
                row.Cells["ColumnName"].Value = listMedicines[i].Name;
                row.Cells["ColumnCount"].Value = listMedicines[i].Count.ToString();
                row.Cells["ColumnCostIn"].Value = listMedicines[i].CostIn.ToString("C0");
                row.Cells["ColumnCostOut"].Value = listMedicines[i].CostOut.ToString("C0");
                row.Cells["ColumnInputDay"].Value = listMedicines[i].InputDay.ToString("dd-MM-yyyy");
            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            string namePDF = "";
            Helper.CreateAPdfThongKe(this.dataGridView1, namePDF);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
