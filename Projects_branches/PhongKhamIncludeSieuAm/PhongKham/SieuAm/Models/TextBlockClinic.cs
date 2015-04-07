using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinic.SieuAm.Models
{
    public partial class TextBlockClinic : TextBox , IUserControl
    {
        public TextBlockClinic()
        {
            InitializeComponent();
        }


        public string Value
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
