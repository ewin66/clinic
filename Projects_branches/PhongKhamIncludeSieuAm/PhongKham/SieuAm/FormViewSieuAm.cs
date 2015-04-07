using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinic.SieuAm
{
    public partial class FormViewSieuAm : Form
    {
        public FormViewSieuAm()
        {
            InitializeComponent();
        }

        private void FormViewSieuAm_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
