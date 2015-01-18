using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinic.Helpers;
using Clinic.Database;

namespace Clinic.Extensions.LoaiKham
{
    public partial class themLoaiForm : Form
    {
        public themLoaiForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DatabaseFactory.Instance != null)
            {
                DatabaseFactory.Instance.InsertRowToTable(ClinicConstant.LoaiKhamTable, new List<string>() { ClinicConstant.LoaiKhamTable_Nameloaikham }, new List<string>() {textBox1.Text });
            }
        }
    }
}
