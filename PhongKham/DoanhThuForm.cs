using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinic.Database;

namespace Clinic
{



    public partial class DoanhThuForm : Form
    {
        public static IDatabase db;
        private List<ItemDoanhThu> listItem;

        public DoanhThuForm()
        {
            InitializeComponent();
        }

        public void FillToGrid(List<ItemDoanhThu> listItem)
        {
            for (int i = 0; i < listItem.Count; i++)
            {
                int index = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[index];
                row.Cells[1].Value = listItem[i].Date;
                row.Cells[2].Value = listItem[i].NameOfDoctor;
                row.Cells[3].Value = listItem[i].Money;
                row.Cells["ColumnIdPatient"].Value = listItem[i].IdPatient;
                row.Cells["ColumnNamePatient"].Value = listItem[i].NamePatient;
                //listItem[i].
            }
        }

        private void button1_Click(object sender, EventArgs e) // ngay
        {
            dataGridView1.Rows.Clear();
             listItem  = Helpers.Helper.DoanhThuTheoNgay(db,dateTimePicker1.Value);
             FillToGrid(listItem);
             CalcuTotal();
        }

        private void button2_Click(object sender, EventArgs e) // thang
        {
            dataGridView1.Rows.Clear();
            listItem = Helpers.Helper.DoanhThuTheoThang(db, dateTimePicker1.Value);
            FillToGrid(listItem);
            CalcuTotal();
        }


        private void CalcuTotal()
        {
            int total =0;
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                total += int.Parse(row.Cells[3].Value.ToString());
            }
            labelTotal.Text = total.ToString("C0");
        }
    }
}
