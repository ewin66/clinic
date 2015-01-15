using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinic.Database;
using Clinic.Helpers;
using Clinic.Models;

namespace Clinic
{



    public partial class DoanhThuForm : Form
    {
        public static IDatabase db;
        private List<ItemDoanhThu> listItem;
        private string tongDoanhThu="0";
        private int tongLuotKham=0;

        public DoanhThuForm()
        {
            InitializeComponent();

            //refresh Doanhthu
           // Helper.RefreshDoanhThu();

        }

        public void FillToGrid(List<ItemDoanhThu> listItem)
        {
            List<DoanhThuBacSi> listBacSi = new List<DoanhThuBacSi>();

            List<string> listID = new List<string>();

            for (int i = 0; i < listItem.Count; i++)
            {

                int index = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[index];
                row.Cells["STT"].Value = i + 1;
                row.Cells[1].Value = listItem[i].Date;


                   
                row.Cells[3].Value = listItem[i].Money;
                row.Cells["ColumnIdPatient"].Value = listItem[i].IdPatient;
                if (!listID.Contains(listItem[i].IdPatient))
                {
                    listID.Add(listItem[i].IdPatient);

                }

                row.Cells["ColumnNamePatient"].Value = listItem[i].NamePatient;

                                 string nameDoctor= listItem[i].NameOfDoctor;
                 row.Cells[2].Value = nameDoctor;
                DoanhThuBacSi bsTemp = listBacSi.Where(x => x.NameBacSi == nameDoctor).FirstOrDefault();
                if (bsTemp == null)
                {
                    bsTemp = new DoanhThuBacSi();
                    bsTemp.NameBacSi = nameDoctor;
                    bsTemp.SoLuotKham = 1;
                    bsTemp.SoTien = listItem[i].Money;
                    listBacSi.Add(bsTemp);
                }
                else
                {
                    bsTemp.SoLuotKham++;
                    bsTemp.SoTien += listItem[i].Money;
                }     

            }


            dataGridView2.Rows.Clear();

                  //each doctor
            for (int i = 0; i < listBacSi.Count; i++)
            {
                int index = dataGridView2.Rows.Add();
                DataGridViewRow row = dataGridView2.Rows[index];
                row.Cells["G2NameDoctor"].Value = listBacSi[i].NameBacSi;
                row.Cells["G2SoLuotKham"].Value = listBacSi[i].SoLuotKham.ToString();
                row.Cells["G2TongCong"].Value = listBacSi[i].SoTien.ToString("C0");
            }


            this.PatientNumber.Text = listID.Count.ToString();

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
            this.tongDoanhThu = labelTotal.Text;
            this.tongLuotKham = int.Parse(this.PatientNumber.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string namePDF = "DoanhThu";
            Helper.CreateAPdfThongKeDoanhThu(this.dataGridView1, namePDF,tongLuotKham,tongDoanhThu);
            this.PDFShowDoanhThu.LoadFile("DoanhThu.pdf");
        }
    }
}
