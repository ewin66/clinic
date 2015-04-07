using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinic.SieuAm
{
    public class TemplateCategory
    {
        public string NameCategory { get; set; }
        public List<ControlSieuAm> ListControl { get; set; }
        public TemplateCategory()
        { }
    }
}
