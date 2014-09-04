using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic.Models
{
    public class InfoClinic
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string advice;

        public string Advice
        {
            get { return advice; }
            set { advice = value; }
        }
    }
}
