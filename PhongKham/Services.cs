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
            List<IMedicine> listServices = Helper.GetAllServiceFromDb();
            for (int i = 0; i < listServices.Count; i++)
            {
                int index = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[index];
                row.Cells["ColumnId"].Value = listServices[i].Id;
                row.Cells["ColumnName"].Value = listServices[i].Name;
                row.Cells["ColumnCostOut"].Value = listServices[i].CostOut.ToString("C0");
            }
        }
    }
}
