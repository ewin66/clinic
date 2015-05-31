using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic.Database
{
    public class DatabaseContants
    {
        public static int IdColumnInDataGridViewMedicines = 4;
        public static int NameColumnInDataGridViewMedicines = 0;
        public static int HDSDColumnInDataGridViewMedicines = 5;
        public static int CountColumnInDataGridViewMedicines = 1;
        public static int CostColumnInDataGridViewMedicines = 2;
        public static int MoneyColumnInDataGridViewMedicines = 3;

        public static   List<string> columnsCalendar = new List<string>() { "IdCalendar", "Username", "StartTime", "EndTime", "Text", "Color" };

        public struct clinicuser
        {
          public static string  Username = "Username";
          public static string  Password1 = "Password1";
          public static string  Authority = "Authority";
           public static string Password2 = "Password2";
        }
        public struct history
        {
          public static string  Id = "Id";
          public static string  Symptom = "Symptom";
          public static string temperature = "temperature";
          public static string huyetap = "huyetap";
          public static string  Diagnose = "Diagnose";
          public static string  Medicines = "Medicines";
          public static string  Day = "Day";

        }

        public struct medicine
        {
           public static string Name = "Name";
           public static string Count = "Count";
           public static string CostIn = "CostIn";
           public static string CostOut = "CostOut";
           public static string InputDay = "InputDay";
           public static string Id = "Id";
           public static string Hdsd = "Hdsd";
        }
        public struct patient
        {
           public static string Name = "Name";
           public static string Address = "Address";
           public static string birthday = "birthday";
           public static string height = "height";
           public static string weight = "weight";
           public static string Id = "Id";
        }

        public struct tables
        {
            public static string clinicuser = "clinicuser";
            public static string history = "history";
            public static string medicine = "medicine";
            public static string patient = "patient";
            public static string calendar = "calendar";

        }


               //  ExecuteNonQuery("CREATE Table IF NOT EXISTS medicine(Name varchar(50),Count int,CostIn int,CostOut int,InputDay Datetime,Id varchar(10));", null);

           // ExecuteNonQuery("CREATE Table IF NOT EXISTS patient(Name varchar(50),Address Varchar(400),birthday datetime,height int(11),weight int(11),Id varchar(10));", null);
    }
}
