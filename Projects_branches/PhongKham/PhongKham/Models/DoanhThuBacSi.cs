using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic.Models
{
    public class DoanhThuBacSi
    {
        private string nameBacSi;

        public string NameBacSi
        {
            get { return nameBacSi; }
            set { nameBacSi = value; }
        }
        private int soLuotKham;

        public int SoLuotKham
        {
            get { return soLuotKham; }
            set { soLuotKham = value; }
        }
        private int  soTien;

        public int SoTien
        {
            get { return soTien; }
            set { soTien = value; }
        }
    }
}
