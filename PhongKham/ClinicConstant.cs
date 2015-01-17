using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic
{
    public class ClinicConstant
    {
        /// <summary>
        /// clinicuser table Username varchar(50),Password1  varchar(50),Authority  smallint(6), Password2  varchar(50))
        /// </summary>
        public const string ClinicUserTable_Username = "Username";
        public const string ClinicUserTable_Password1 = "Password1";
        public const string ClinicUserTable_Authority = "Authority";
        public const string ClinicUserTable_Password2 = "Password2";
        
        /// <summary>
        /// history(Id varchar(10),Symptom Longtext,Diagnose Longtext,Medicines Longtext,Day Datetime)
        /// </summary>
        public const string HistoryTable_Id = "Id";
        public const string HistoryTable_Symptom = "Symptom";
        public const string HistoryTable_Diagnose = "Diagnose";
        public const string HistoryTable_Medicines = "Medicines";
        public const string HistoryTable_Day = "Day";

        /// <summary>
        /// medicine(Name varchar(50),Count int,CostIn int,CostOut int,InputDay Datetime,Id varchar(10))
        /// </summary>
        public const string MedicineTable_Name = "Name";
        public const string MedicineTable_Count = "Count";
        public const string MedicineTable_CostIn = "CostIn";
        public const string MedicineTable_CostOut = "CostOut";
        public const string MedicineTable_InputDay = "InputDay";
        public const string MedicineTable_Id = "Id";

        /// <summary>
        /// patient(Idpatient INT NOT NULL AUTO_INCREMENT,Name varchar(50),Address Varchar(400),birthday datetime,height int(11),weight int(11)
        /// </summary>
        public const string PatientTable_Idpatient = "Idpatient";

    }
}
