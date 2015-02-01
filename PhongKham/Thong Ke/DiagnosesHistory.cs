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

namespace Clinic.Thong_Ke
{
    public partial class DiagnosesHistory : Form
    {
        private List<string> listDiagnosesFromHistory;
        public DiagnosesHistory(List<string> listDiagnosesFromHistory)
        {
            InitializeComponent();
            this.listDiagnosesFromHistory = listDiagnosesFromHistory;
            this.listDiagnosesFromHistory.Sort();
        }

        private void DiagnosesHistory_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < listDiagnosesFromHistory.Count; i++)
            {
                int index = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[index];
                row.Cells[this.ColumnName.Name].Value = listDiagnosesFromHistory[i];
                row.Cells[this.ColumnUpdate.Name].Value = "Cập nhật";

            }
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells.  
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == dataGridView1.Columns[ColumnUpdate.Name].Index)
            {
                string strCommand = "Update "+ClinicConstant.HistoryTable+ " Set "+
                ClinicConstant.HistoryTable_Diagnose + " = " + Helper.ConvertToSqlString(dataGridView1.Rows[e.RowIndex].Cells[this.ColumnName.Name].Value.ToString()) + " Where " + ClinicConstant.HistoryTable_Diagnose + " = " + Helper.ConvertToSqlString(listDiagnosesFromHistory[e.RowIndex]);
                DatabaseFactory.Instance.ExecuteNonQuery(strCommand, null);
                MessageBox.Show("Cập nhật dịch vụ thành công");
                listDiagnosesFromHistory = Helpers.Helper.GetAllDiagnosesFromHistory(DatabaseFactory.Instance);
                DiagnosesHistory_Load(sender, e);
            }
        }



    }
}
