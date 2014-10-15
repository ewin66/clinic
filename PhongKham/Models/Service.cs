using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic.Models
{
    public class Service
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int costOut;

        public int CostOut
        {
            get { return costOut; }
            set { costOut = value; }
        }

    }
}
