using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic.Settings
{
    [Serializable]
    public class MainFormSettings
    {
        private bool showBigForm;

        public bool ShowBigForm
        {
            get { return showBigForm; }
            set { showBigForm = value; }
        }
        private bool showOneRecord;

        public bool ShowOneRecord
        {
            get { return showOneRecord; }
            set { showOneRecord = value; }
        }
        private bool showMedicines;

        public bool ShowMedicines
        {
            get { return showMedicines; }
            set { showMedicines = value; }
        }
    }
}
