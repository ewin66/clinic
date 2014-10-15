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
    public partial class Services : Form
    {
        public Services()
        {
            InitializeComponent();
        }

        private void Services_Load(object sender, EventArgs e)
        {
            List<Service> listMedicines = Helper.GetAllServicesFromDB();
            for (int i = 0; i < listMedicines.Count; i++)
            {
                int index = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[index];
                row.Cells["ColumnId"].Value = listMedicines[i].Id;
                row.Cells["ColumnName"].Value = listMedicines[i].Name;
                row.Cells["ColumnCostOut"].Value = listMedicines[i].CostOut.ToString("C0");
            }
        }
    }
}
