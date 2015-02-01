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
using PhongKham;
using Clinic.Models.ItemMedicine;
using Clinic.Database;

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
                    
            dataGridView1.Rows.Clear();
            List<IMedicine> listMedicines = Helper.GetAllMedicineFromDb();

            for (int i = 0; i < listMedicines.Count; i++)
            {
                int index = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[index];
                row.Cells["ColumnId"].Value = listMedicines[i].Id;
                row.Cells["ColumnName"].Value = listMedicines[i].Name;
                row.Cells["ColumnCount"].Value = listMedicines[i].Count.ToString();
                row.Cells["ColumnCostIn"].Value = listMedicines[i].CostIn.ToString();
                row.Cells["ColumnCostOut"].Value = listMedicines[i].CostOut.ToString();
                row.Cells["ColumnInputDay"].Value = listMedicines[i].InputDay.ToString("dd-MM-yyyy");
                row.Cells[this.ColumnHDSD.Name].Value = listMedicines[i].HDSD.ToString();
                row.Cells[this.ColumnUpdate.Name].Value = "Cập Nhật";
                row.Cells[this.ColumnDelete.Name].Value = "Xóa";
            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            string namePDF = "TuThuoc";
            Helper.CreateAPdfThongKe(this.dataGridView1, namePDF);
            this.PDFShowMedicines.LoadFile("TuThuoc.pdf");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells.  
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == dataGridView1.Columns[ColumnUpdate.Name].Index)
            {
                string giaIn = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnCostIn.Name].Value.ToString();
                string giaOut = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnCostOut.Name].Value.ToString();
                string count = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnCount.Name].Value.ToString();
                string hdsd = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnHDSD.Name].Value.ToString();
                string Id = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnId.Name].Value.ToString();
                string name = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnName.Name].Value.ToString();
                string strCommand = "Update " + ClinicConstant.MedicineTable + 
                    " Set CostOut =" + giaOut.ToString() 
                    + "," +
                    ClinicConstant.MedicineTable_Name + " = " + Helper.ConvertToSqlString(name) 
                    + "," + 
                    ClinicConstant.MedicineTable_Hdsd + " = " + Helper.ConvertToSqlString(hdsd)
                    + "," +
                    ClinicConstant.MedicineTable_Count + " = " + Helper.ConvertToSqlString(count)
                    + "," +
                    ClinicConstant.MedicineTable_CostIn + " = " + Helper.ConvertToSqlString(giaIn)
                    + " Where Id =" + Id;
                DatabaseFactory.Instance.ExecuteNonQuery(strCommand, null);
                MessageBox.Show("Cập nhật thuốc thành công");
                TuThuocForm_Load(sender, e);
            }
            else if (e.ColumnIndex == dataGridView1.Columns[this.ColumnDelete.Name].Index)
            {
                string Id = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnId.Name].Value.ToString();
                DialogResult dlgResult = MessageBox.Show("Có thật sự muốn xóa dịch vụ này?", "Chú ý", MessageBoxButtons.YesNo);
                if (dlgResult == System.Windows.Forms.DialogResult.Yes)
                {
                    string strCommand = "Delete From medicine Where Id =" + Id;
                    DatabaseFactory.Instance.ExecuteNonQuery(strCommand, null);
                    MessageBox.Show("Xóa thuốc thành công");
                    TuThuocForm_Load(sender, e);
                }
            }

        }

    }
}
