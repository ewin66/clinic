using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Clinic.Database;
using Clinic.Helpers;
using PhongKham;

namespace Clinic.Thong_Ke
{
    public class HelperThongKe
    {
        public static List<ItemDoanhThu> GetDoanhThuFromHistory(DateTime dateTime, DaysFormat daysFormat)
        {
            List<ItemDoanhThu> result = new List<ItemDoanhThu>();
            string strCommand = "";
            if (daysFormat == DaysFormat.Ngay)
            {
                strCommand = " SELECT * FROM " + ClinicConstant.HistoryTable + " WHERE Day = " + Helper.ConvertToSqlString(dateTime.ToString("yyyy-MM-dd"));
            }
            if (daysFormat == DaysFormat.Thang)
            {
                strCommand = " SELECT * FROM " + ClinicConstant.HistoryTable + " WHERE month(Day) = " + dateTime.Month.ToString() + " and year(Day) = " + dateTime.Year.ToString();
            }
            using (DbDataReader reader = DatabaseFactory.Instance.ExecuteReader(strCommand, null) as DbDataReader)
            {
                while (reader.Read())
                {
                    ItemDoanhThu item = new ItemDoanhThu();
                    item.Date = reader.GetDateTime(reader.GetOrdinal(ClinicConstant.HistoryTable_Day)).ToString("dd-MM-yyyy");
                    item.NameOfDoctor = reader[ClinicConstant.HistoryTable_NameDoctor].ToString();



                    item.IdPatient = reader[ClinicConstant.HistoryTable_Id].ToString();

                    item.AllMedicines = reader[ClinicConstant.HistoryTable_Medicines].ToString();

                    string Services = "";
                    item.Money = CalcuMoneyFromAllMedicines(item.AllMedicines, ref Services);
                    item.Services = Services;

                    item.NamePatient = GetNameFromIdPatient(item.IdPatient);

                    item.LoaiKham = reader[ClinicConstant.HistoryTable_NameLoaiKham].ToString();
                    item.Diagnose = reader[ClinicConstant.HistoryTable_Diagnose].ToString();

                    if (result.Where(x => x.IdPatient == item.IdPatient && x.Date == item.Date).FirstOrDefault() == null)
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        private static string GetNameFromIdPatient(string idPatient)
        {
            try
            {
                string strCommand = "SELECT Name FROM patient WHERE Idpatient = " + Helper.ConvertToSqlString(idPatient);
                using (DbDataReader reader = DatabaseFactory.Instance2.ExecuteReader(strCommand, null) as DbDataReader)
                {
                    reader.Read();
                    return reader[ClinicConstant.PatientTable_Name].ToString();
                }
            }
            catch
            {
                return "";
            }
        }

        private static int CalcuMoneyFromAllMedicines(string allMedicines, ref string Services)
        {
            string[] Medicines = allMedicines.Split(',');
            if (Medicines.Count() < 2)
            {
                return 0;
            }
            if (Medicines[1] == "!")
            {
                return 0;
            }
            int result = 0;
            for (int i = 0; i < Medicines.Count(); i += 2)
            {
                if (Medicines[i][0] == '@')
                {
                    Services = Services + Medicines[i] + ClinicConstant.StringBetweenServicesInDoanhThu;
                }
                int money;
                try
                {
                    money = GetMoneyFromNameMedicine(Medicines[i], Medicines[i + 1]);
                }
                catch
                {
                    money = 0;
                }
                result += money;
            }
            return result;
        }

        private static int GetMoneyFromNameMedicine(string nameMedicine, string soLuong)
        {
            if (string.IsNullOrEmpty(soLuong))
            {
                return 0;
            }
            try
            {
                return Form1.currentMedicines.Where(x => x.Name == nameMedicine).FirstOrDefault().CostOut * int.Parse(soLuong);
            }
            catch { return 0; }
        }
    }
}
