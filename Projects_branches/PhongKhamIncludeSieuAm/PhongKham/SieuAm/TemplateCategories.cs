using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic.SieuAm
{
    public class TemplateCategories
    {
        public List<TemplateCategory> ListTemplateCategory;
        public TemplateCategory this[int index]
        {
            get {
                return this.ListTemplateCategory[index];
            }
        }
    }
}
