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
    public partial class Services : Form
    {
        public Services()
        {
            InitializeComponent();
        }

        private void Services_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<IMedicine> listServices = Helper.GetAllServiceFromDb();
            for (int i = 0; i < listServices.Count; i++)
            {
                int index = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[index];
                row.Cells["ColumnId"].Value = listServices[i].Id;
                row.Cells["ColumnName"].Value = listServices[i].Name;
                row.Cells["ColumnCostOut"].Value = listServices[i].CostOut.ToString();
                row.Cells[this.ColumnAdmin.Name].Value = listServices[i].Admin;
                row.Cells[this.ColumnUpdate.Name].Value ="Cập Nhật";
                row.Cells[this.ColumnDelete.Name].Value = "Xóa";
            }
        }


        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells.  
            if (e.RowIndex < 0)  return;
            if (e.ColumnIndex == dataGridView1.Columns[ColumnUpdate.Name].Index)
            {

                string giaOut = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnCostOut.Name].Value.ToString();
                string adminOfService = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnAdmin.Name].Value.ToString();
                string Id = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnId.Name].Value.ToString();
                string name = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnName.Name].Value.ToString();
                string strCommand = "Update Medicine Set CostOut =" + giaOut.ToString() + "," + ClinicConstant.MedicineTable_Name + " = " + Helper.ConvertToSqlString(name) + "," + ClinicConstant.MedicineTable_Admin + " = " + Helper.ConvertToSqlString(adminOfService) + " Where Id =" + Id;
                DatabaseFactory.Instance.ExecuteNonQuery(strCommand, null);
                MessageBox.Show("Cập nhật dịch vụ thành công");
                Services_Load(sender, e);
            }
            else if (e.ColumnIndex == dataGridView1.Columns[this.ColumnDelete.Name].Index)
            {
                string Id = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnId.Name].Value.ToString();
                DialogResult dlgResult = MessageBox.Show("Có thật sự muốn xóa dịch vụ này?", "Chú ý", MessageBoxButtons.YesNo);
                if (dlgResult == System.Windows.Forms.DialogResult.Yes)
                {
                    string strCommand = "Delete From medicine Where Id =" + Id;
                    DatabaseFactory.Instance.ExecuteNonQuery(strCommand, null);
                    MessageBox.Show("Xóa dịch vụ thành công");
                    Services_Load(sender, e);
                }
            }
            
        }

    }
}
