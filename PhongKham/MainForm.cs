using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Clinic;
using Clinic.Helpers;
using Clinic.Models;
using MySql.Data.MySqlClient;
using Clinic.Database;
using System.Data.Common;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Drawing;
using PdfSharp.Drawing.Layout;

using MigraDoc.DocumentObjectModel.Shapes;
using System.ComponentModel;
using System.Windows.Forms.Calendar;
using System.IO;
using System.Xml.Serialization;
using System.Threading;
using Clinic;



namespace PhongKham
{
    public partial class Form1 : DevComponents.DotNetBar.Office2007Form
    {
        private static int maxIdOfCalendarItem;
        private  InfoClinic infoClinic;
        private static string UserName;
        private IDatabase db = DatabaseFactory.Instance;
        List<CalendarItem> _items = new List<CalendarItem>();
        List<string> currentMedicines = new List<string>();
        List<string> currentServices = new List<string>();
        private int Authority;

        System.Threading.Timer TimerItem;


        public Form1(int Authority,string name)
        {

            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Text ="Phòng Khám -"+"User: " +name;
            UserName = name;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Authority = Authority;
            this.WindowState = Clinic.Properties.Settings.Default.State;
            if (this.WindowState == FormWindowState.Normal) this.Size = Clinic.Properties.Settings.Default.Size;
            this.Resize += new System.EventHandler(this.Form1_Resize);

            try
            {

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(InfoClinic));
                StreamReader sr = new StreamReader("Information.xml");
                infoClinic = xmlSerializer.Deserialize(sr) as InfoClinic;
            }
            catch(Exception e)
            {}

            Thread thread = new Thread(new ThreadStart(WorkThreadFunction));
            thread.Start();

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Clinic.Properties.Settings.Default.State = this.WindowState;
            if (this.WindowState == FormWindowState.Normal) Clinic.Properties.Settings.Default.Size = this.Size;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           Clinic.Properties.Settings.Default.Save();
        }


        #region Init


        public void WorkThreadFunction()
        {
            try
            {
                // do any background work

                InitInputMedicineMySql();
                InitUser(Authority);
                InitComboboxMedicinesMySql();
                InitClinicRoom();
                InitTableServices();
                dataGridView4.Visible = false;
                checkBox1.Checked = true;
                checkBox2.Checked = true;

                maxIdOfCalendarItem = Helper.SearchMaxValueOfTable("calendar", "IdCalendar", "DESC");
                //
                //Load calendar
                //
                List<ADate> listDate = Helper.GetAllDateOfUser(UserName, db);
                foreach (ADate item in listDate)
                {
                    CalendarItem cal = new CalendarItem(calendar1, item.StartTime, item.EndTime, item.Text);
                    cal.Tag = item.Id;
                    if (item.color != 0)
                    {
                        cal.ApplyColor(Helper.ConvertCodeToColor(item.color));
                    }
                    //if (!(item.R == 0 && item.G == 0 && item.B == 0))
                    //{
                    //    cal.ApplyColor(Color.FromArgb(item.A, item.R, item.G, item.B));
                    //}

                    _items.Add(cal);
                }

                PlaceItems();
            }
            catch (Exception ex)
            {
                // log errors
            }
        }

        private void InitClinicRoom()
        {
            //init id
            int intId = Helper.SearchMaxValueOfTable( "Patient", "Id", "DESC");
            string ID = String.Format("{0:000000}", intId);
            lblClinicRoomId.Text = ID;

            //init comboBoxName

            comboBoxClinicRoomName.Items.Clear();
            Helper.GetAllRowsOfSpecialColumn("Patient","Name");

        }

        private void InitComboboxMedicinesMySql()
        {
            this.Column18.Items.Clear();

            currentMedicines = Helper.GetAllRowsOfSpecialColumn("Medicine", "Name");
            currentServices = Helper.FilterServicesFromAllMedicines(currentMedicines);

            this.Column18.Items.AddRange(currentMedicines.ToArray());
        }

        public void Init()
        {


            if (!Helper.checkAdminExists("ClinicUser"))
            {
                CreateUserForm createUserForm = new CreateUserForm();
                createUserForm.ShowDialog();
            }

            LoginForm login = new LoginForm();
            if (login.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void InitUser(int authority)
        {
            if (authority == 1) //admin
                return;

            if (authority < 100) // khong co quyen tao user moi
            {
                MainTab.TabPages.Remove(tabPage4);
            }
            else
            {
                authority -= 100;
            }

            if (authority < 10) //khong co quyen ke thuoc
            {
                this.dataGridViewMedicine.Visible = false;
                this.label9.Visible = false;
                this.label30.Visible = false;
            }
            else
            {
                authority -= 10;
            }

            switch (authority)
            {
                case 1:
                    //all control
                    break;
                case 2:
                    break;
                case 3:
                    MainTab.TabPages.Remove(tabPage1);
                    break;
                case 4:
                    MainTab.TabPages.Remove(tabPage3);
                    break;
            }
        }
   
        private void InitInputMedicineMySql()
        {

            RefreshIdOfNewMedicine();
            comboBoxInputMedicineName.Items.Clear();
            comboBoxInputMedicineName.Items.AddRange(currentMedicines.ToArray());
        }

        private void InitTableServices()
        {
            RefreshIdOfNewMedicine();
            textBoxServices.Text = "@";
            textBoxServicesCost.Text = "0";
            textBoxServices.AutoCompleteCustomSource.Clear();
            textBoxServices.AutoCompleteCustomSource.AddRange(currentServices.ToArray());
        }

        private void InitWaitRoomMySql()
        {

            string strCommand = " SELECT TOP 1 Id FROM Patient ORDER BY ID DESC";
            //MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
            //MySqlDataReader reader = comm.ExecuteReader();

            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {
                reader.Read();
                int intTemp = 0;
                if (reader.HasRows)
                {
                    string temp = reader.GetString(0);
                    try
                    {
                        intTemp = int.Parse(temp);

                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    intTemp = 0;
                }
                int newId = intTemp + 1;
                string strNewID = String.Format("{0:000000}", newId);

                comboBoxWaitRoomId.Text = strNewID;
            }

            comboBoxWaitRoomId.Items.Add(comboBoxWaitRoomId.Text);

        }
        #endregion

        #region EventCheck
        private void txtBoxInputMedicineNewCount_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
        private void txtBoxInputMedicineNewCostIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtBoxInputMedicineNewCostOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtBoxInputMedicineAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtBoxClinicRoomHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtBoxClinicRoomWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        #endregion

        #region ClearForm
        private void ClearInputNewMedicine()
        {
            txtBoxInputMedicineNewName.Clear();
            txtBoxInputMedicineNewCount.Clear();
            txtBoxInputMedicineNewCostOut.Clear();
            txtBoxInputMedicineNewCostIn.Clear();
        }
        private void ClearInputMedicine()
        {
            //comboBoxInputMedicineId.Text = "";
            label34.Text = "";
            comboBoxInputMedicineName.Text = "";
            lblInputMedicineCount.Text = "0";
            txtBoxInputMedicineAdd.Text = "0";
        }
        private void ClearClinicRoomForm()
        {
            txtBoxClinicRoomAddress.Clear();
            comboBoxClinicRoomName.Text = "";
            txtBoxClinicRoomDiagnose.Clear();
            txtBoxClinicRoomHeight.Text = "0";
            dateTimePickerBirthDay.ResetText();
            txtBoxClinicRoomSymptom.Clear();
            txtBoxClinicRoomWeight.Text = "0";
            lblClinicRoomId.Text = "";
            // comboBoxClinicRoomMedicines.Text = "";
            dataGridViewMedicine.Rows.Clear();
            label30.Text = "0";

        }
        #endregion

        #region Helper
        private void FillDataToInputMedicineForm(DbDataReader reader)
        {
            this.lblInputMedicineCount.Text = reader["Count"].ToString();
            this.label34.Text = reader["Id"].ToString();
            this.textBox3.Text = reader["CostOut"].ToString();
        }
        private void RefreshIdOfNewMedicine()
        {


            string strCommand = " SELECT ID FROM Medicine ORDER BY ID DESC LIMIT 1";
            DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader;
            reader.Read();
            int intTemp = 0;
            if (reader.HasRows)
            {
                string temp = reader.GetString(0);

                try
                {
                    intTemp = int.Parse(temp);

                }
                catch (Exception)
                {
                }
            }
            else
            {
                intTemp = 0;
            }
            int newId = intTemp + 1;
            string strNewID = String.Format("{0:000000}", newId);

            lblInputMedicineNewId.Text = strNewID;
            labelServicesID.Text = strNewID; // Services
            reader.Close();


        }
        private void FillInfoToClinicForm(DbDataReader reader)
        {
            lblClinicRoomId.Text = reader["Id"].ToString();
            txtBoxClinicRoomAddress.Text = reader["Address"].ToString();
            txtBoxClinicRoomWeight.Text = reader["Weight"].ToString();
            txtBoxClinicRoomHeight.Text = reader["Height"].ToString();
            dateTimePickerBirthDay.Text = reader["Birthday"].ToString();
           // dateTimePickerNgayKham.Text = reader["Day"].ToString(); //we update new Date 
            txtBoxClinicRoomSymptom.Text = reader["Symptom"].ToString();
            txtBoxClinicRoomDiagnose.Text = reader["Diagnose"].ToString();
        }
        private void AddVisitData()
        {
            //Save to history
            List<string> columnsHistory = new List<string>() { "Id", "Symptom", "Diagnose", "Day", "Medicines" };
            string medicines = "";
            for (int i = 0; i < dataGridViewMedicine.Rows.Count - 1; i++)
            {
                if (i == dataGridViewMedicine.Rows.Count - 2)
                {
                    medicines += dataGridViewMedicine[0, i].Value + "," + dataGridViewMedicine[1, i].Value;
                }
                else
                {
                    medicines += dataGridViewMedicine[0, i].Value + "," + dataGridViewMedicine[1, i].Value + ",";
                }
            }

            List<string> valuesHistory = new List<string>() { lblClinicRoomId.Text, txtBoxClinicRoomSymptom.Text, txtBoxClinicRoomDiagnose.Text, DateTime.Now.ToString("yyyy-MM-dd"), medicines };
            db.InsertRowToTable("history", columnsHistory, valuesHistory);
        }
        private void ChangeVisitData()
        {
            List<string> columns = new List<string>() { "Name", "Address", "Birthday", "Height", "Weight", "Id" };
            List<string> values = new List<string>() { comboBoxClinicRoomName.Text, txtBoxClinicRoomAddress.Text, dateTimePickerBirthDay.Value.ToString("yyyy-MM-dd"), txtBoxClinicRoomHeight.Text, txtBoxClinicRoomWeight.Text, lblClinicRoomId.Text };
            Helper.UpdateRowToTable(db, "patient", columns, values, lblClinicRoomId.Text);

            //Save to history
            List<string> columnsHistory = new List<string>() { "Id", "Symptom", "Diagnose", "Day", "Medicines" };
            string medicines = "";
            for (int i = 0; i < dataGridViewMedicine.Rows.Count - 1; i++)
            {
                if (i == dataGridViewMedicine.Rows.Count - 2)
                {
                    medicines += dataGridViewMedicine[0, i].Value + "," + dataGridViewMedicine[1, i].Value;
                }
                else
                {
                    medicines += dataGridViewMedicine[0, i].Value + "," + dataGridViewMedicine[1, i].Value + ",";
                }
            }

            List<string> valuesHistory = new List<string>() { lblClinicRoomId.Text, txtBoxClinicRoomSymptom.Text, txtBoxClinicRoomDiagnose.Text, dateTimePickerNgayKham.Value.ToString("yyyy-MM-dd"), medicines };
            Helper.UpdateRowToTable(db, "history", columnsHistory, valuesHistory, lblClinicRoomId.Text, dateTimePickerNgayKham.Value.ToString("yyyy-MM-dd"));
        }
        private void RefreshMedicineLess100()
        {
            dataGridView4.Rows.Clear();
            string strCommand = "Select * From Medicine Where Count < 100";
            // MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);


            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {
                while (reader.Read())
                {
                    int index = dataGridView4.Rows.Add();
                    DataGridViewRow row = dataGridView4.Rows[index];
                    row.Cells[0].Value = reader.GetString(5);
                    row.Cells[1].Value = reader.GetString(0);
                    row.Cells[2].Value = reader.GetValue(2).ToString(); // gia in
                    row.Cells[3].Value = reader.GetValue(3).ToString(); // gia out
                    row.Cells[4].Value = reader.GetValue(1).ToString(); // So luong

                }
            }
        }
        #endregion

        #region Event Main Medicine 
        private void btnInputMedicineNewOk_ClickMySql(object sender, EventArgs e)
        {

            string strCommand = "Select Name From medicine  Where Name = " + Helper.ConvertToSqlString(this.txtBoxInputMedicineNewName.Text);
            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {
                reader.Read();
                if (reader.HasRows == true) //level 2
                {
                    MessageBox.Show("Ten Thuoc Bi Trung, Xin Nhap Lai Ten Khac");
                    return;
                }
            }

            Medicine medicine = new Medicine();
            medicine.Name = txtBoxInputMedicineNewName.Text.Trim();
            medicine.InputDay = dateTimePicker3.Value;
            try
            {
                medicine.CostOut = int.Parse(txtBoxInputMedicineNewCostOut.Text);
                medicine.CostIn = int.Parse(txtBoxInputMedicineNewCostIn.Text);
                medicine.Count = int.Parse(txtBoxInputMedicineNewCount.Text);
                medicine.Id = lblInputMedicineNewId.Text;
                medicine.HDSD = textBoxMedicineHdsd.Text;
            }
            catch (Exception)
            {
            }


            if (medicine.CostOut < medicine.CostIn)
            {
                MessageBox.Show("Giá Out không thể nhỏ hơn giá In!", "Lỗi");
                return;
            }

            List<string> columns = new List<string>() { "Name", "Count", "CostIn", "CostOut", "InputDay", "ID" ,"Hdsd"};
            List<string> values = new List<string>() { medicine.Name, medicine.Count.ToString(), medicine.CostIn.ToString(), medicine.CostOut.ToString(), medicine.InputDay.ToString("yyyy-MM-dd"), medicine.Id, medicine.HDSD };
            db.InsertRowToTable("Medicine", columns, values);
            MessageBox.Show("Thêm mới thuốc thành công");
            InitInputMedicineMySql();
            InitComboboxMedicinesMySql();
            RefreshIdOfNewMedicine();
            ClearInputNewMedicine();

        }
        private void btnInputMedicineOk_ClickMySql(object sender, EventArgs e)
        {
            int count = 0;
            try
            {
                count = int.Parse(lblInputMedicineCount.Text) + int.Parse(txtBoxInputMedicineAdd.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Số lượng thêm vào phải là một số!");
                return;
            }

            string Id = label34.Text;

            int newOutPreise = 0;

            try
            {
                newOutPreise = int.Parse(textBox3.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giá mới phải là một số!");
                return;
            }

            string strCommand = "Update Medicine Set Count =" + count.ToString() + ", CostOut =" + newOutPreise.ToString() + " Where Id =" + Id;
            db.ExecuteNonQuery(strCommand, null);

            MessageBox.Show("Thêm thuốc thành công : " + txtBoxInputMedicineAdd.Text + " " + comboBoxInputMedicineName.Text);
            ClearInputMedicine();


        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainTab.SelectedIndex == 1)
            {
                RefreshMedicineLess100();
            }
        }
        private void comboBoxInputMedicineName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxInputMedicineName.Text.Length > 0)
            {

                string Name = comboBoxInputMedicineName.Text;
                string strCommand = "Select * From Medicine Where Name =" + Helper.ConvertToSqlString(Name);
                // MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
                DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader;
                if (reader.HasRows)
                {
                    reader.Read();
                    FillDataToInputMedicineForm(reader);
                }
                else
                {
                    ClearInputMedicine();
                }
                reader.Close();
            }
        }
        
        #endregion

        #region Event Main Clinic

        private void dataGridViewMedicine_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1) // change name of medicine
            {
                if (dataGridViewMedicine[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    string nameOfMedicine = dataGridViewMedicine[e.ColumnIndex, e.RowIndex].Value.ToString();
                    string strCommand = "Select * From Medicine Where Name =" + Helper.ConvertToSqlString(nameOfMedicine);
                    //MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
                    using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
                    {
                        reader.Read();
                        string temp = reader[DatabaseContants.medicine.CostOut].ToString();
                        string HDSD = reader[DatabaseContants.medicine.Hdsd].ToString();
                        string id = reader["Id"].ToString();
                        reader.Close();
                        dataGridViewMedicine[2, e.RowIndex].Value = temp;
                        dataGridViewMedicine[DatabaseContants.HDSDColumnInDataGridViewMedicines, e.RowIndex].Value = HDSD;
                        dataGridViewMedicine[DatabaseContants.IdColumnInDataGridViewMedicines, e.RowIndex].Value = id;
                    }
                    if (nameOfMedicine[0] == '@')
                    {
                        dataGridViewMedicine[DatabaseContants.CountColumnInDataGridViewMedicines, e.RowIndex].Value = "1";
                    }
                }
            }
            if (e.ColumnIndex == 1 && e.RowIndex > -1) // change count of medicine
            {
                if (dataGridViewMedicine[e.ColumnIndex, e.RowIndex].Value != null && dataGridViewMedicine[2, e.RowIndex].Value != null)
                {
                    try
                    {
                        int count = int.Parse(dataGridViewMedicine[e.ColumnIndex, e.RowIndex].Value.ToString());
                        int cost = int.Parse(dataGridViewMedicine[2, e.RowIndex].Value.ToString()) * count;
                        dataGridViewMedicine[3, e.RowIndex].Value = cost.ToString();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Format sai!");
                    }


                }
            }
            if (e.ColumnIndex == 3 && e.RowIndex > -1) // change cost
            {
                label30.Text = "0";
                int total = 0;
                if (dataGridViewMedicine[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    for (int i = 0; i < dataGridViewMedicine.Rows.Count - 1; i++)
                    {
                        try
                        {
                            total += int.Parse(dataGridViewMedicine[3, i].Value.ToString());
                        }
                        catch (Exception)
                        {
                        }
                    }


                }
                label30.Text = total.ToString();
            }
        }
        private void dataGridViewSearchValue_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string Id = dataGridViewSearchValue[0, e.RowIndex].Value.ToString();
                string strCommand = "SELECT * FROM patient p RIGHT JOIN history h ON p.Id = h.Id WHERE h.Id = "
                    + Id + " AND h.Day = " + Helper.ConvertToSqlString(Helper.ChangePositionOfDayAndYear(this.dataGridViewSearchValue.Rows[e.RowIndex].Cells[3].Value.ToString()));

                // MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);

                using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
                {
                    reader.Read();
                    if (!reader.HasRows) return;

                    string medicines = reader["Medicines"].ToString();
                    string name = reader["Name"].ToString();
                    FillInfoToClinicForm(reader);
                    reader.Close();

                    string[] medicineAndCount = new string[] { };
                    if (!string.IsNullOrEmpty(medicines))
                    {
                        medicineAndCount = medicines.Split(',');
                    }

                    this.dataGridViewMedicine.Rows.Clear();

                    for (int i = 0; i < medicineAndCount.Length; i = i + 2)
                    {
                        if (this.dataGridViewMedicine.RowCount <= i / 2 + 1)
                        {
                            this.dataGridViewMedicine.Rows.Add();
                        }
                        this.dataGridViewMedicine.Rows[i / 2].Cells[0].Value = medicineAndCount[i];
                        this.dataGridViewMedicine.Rows[i / 2].Cells[1].Value = medicineAndCount[i + 1];
                    }

                }
            }
        }
        private void comboBoxClinicRoomName_SelectedValueChanged(object sender, EventArgs e)
        {
            //string strCommand = "Select * From Patient Where Name = " + Helper.ConvertToSqlString(comboBoxClinicRoomName.Text);
            string strCommand = "Select * From patient p RIGHT JOIN history h ON p.Id = h.Id Where p.Name =" + Helper.ConvertToSqlString(comboBoxClinicRoomName.Text);
            //MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);

            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {
                reader.Read();
                FillInfoToClinicForm(reader);
                reader.Close();

            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dataGridViewSearchValue.Rows.Clear();
            dataGridViewMedicine.Rows.Clear();

   

            string findingName = comboBoxClinicRoomName.Text;
            string Id = lblClinicRoomId.Text;
            string strCommandMain = "";
            //
            // Check find level2 if (both Name and ID match)
            string strCommand = "Select Name , Id From patient  Where Name = " + Helper.ConvertToSqlString(findingName) + " and Id =" + Helper.ConvertToSqlString(Id);
            // MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {
                reader.Read();
                if (reader.HasRows == true && !string.IsNullOrEmpty(findingName)) //level 2
                {
                    strCommandMain = "SELECT * FROM patient p RIGHT JOIN history h ON p.Id = h.Id WHERE h.Id = " + Id;
                }
                else // level 1 
                {
                    if (dateTimePickerNgayKham.Value.Date <= DateTime.Now.Date)
                    {
                        if (string.IsNullOrEmpty(findingName)) //name = null --> find due to date
                        {
                            strCommandMain =
                                "SELECT * FROM patient p RIGHT JOIN history h ON p.Id = h.Id WHERE h.Day = " +
                                Helper.ConvertToSqlString(dateTimePickerNgayKham.Value.ToString("yyyy-MM-dd"));
                        }
                        else
                        {
                            strCommandMain =
                                "SELECT * FROM patient p RIGHT JOIN history h ON p.Id = h.Id WHERE p.Name LIKE '%" +
                                findingName + "%'";
                        }
                    }
                    else // ngay kham o tuong lai
                    {
                        return;
                        //strCommandMain = "SELECT * FROM patient p RIGHT JOIN history h ON p.Id = h.Id WHERE p.Name LIKE '%" + findingName + "%' ";
                    }
                }
            }



            //string strCommand = "Select ";
            var style = new DataGridViewCellStyle();
            style.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F,
                                                 System.Drawing.FontStyle.Regular,
                                                 System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewSearchValue.DefaultCellStyle = style;


            string medicines = "";
            // MySqlCommand comm2 = new MySqlCommand(strCommandMain, Program.conn);
            using (DbDataReader reader2 = db.ExecuteReader(strCommandMain, null) as DbDataReader)
            {
                while (reader2.Read())
                {
                    int index = dataGridViewSearchValue.Rows.Add();
                    DataGridViewRow row = dataGridViewSearchValue.Rows[index];
                    row.Cells[0].Value = reader2.GetString(5); // id
                    row.Cells[1].Value = reader2[DatabaseContants.patient.Name].ToString();
                    row.Cells[2].Value = reader2.GetDateTime(2).ToString("dd-MM-yyyy");//birthday
                    row.Cells[3].Value = reader2.GetDateTime(10).ToString("dd-MM-yyyy"); // ngay kham
                    row.Cells[4].Value = reader2.GetString(1);//address
                    row.Cells[5].Value = reader2.GetString(7);//symptom
                    row.Cells[6].Value = reader2.GetString(8);
                    row.Cells[7].Value = reader2.GetString(9) != null ? reader2.GetString(9) : ""; // Total
                    medicines = reader2[DatabaseContants.history.Medicines].ToString();
                    row.Cells[8].Value = Helper.ChangeListMedicines(medicines);
                }
            }

            string askCostOut;
            //MySqlCommand newCommand = null;
            //MySqlDataReader newReader = null;
            int daySum = 0;
            foreach (DataGridViewRow row in this.dataGridViewSearchValue.Rows)
            {
                int total = 0;

                string[] medicineAndCount = row.Cells[7].Value.ToString().Split(',');

                for (int i = 0; i < medicineAndCount.Length; i = i + 2)
                {
                    askCostOut = "Select CostOut From Medicine Where Name =" + Helper.ConvertToSqlString(medicineAndCount[i]);
                    //newCommand = new MySqlCommand(askCostOut, Program.conn);
                    DbDataReader newReader = db.ExecuteReader(askCostOut, null) as DbDataReader;
                    newReader.Read();
                    try
                    {
                        total += int.Parse(medicineAndCount[i + 1]) * (int)newReader.GetValue(0);
                    }
                    catch (Exception)
                    {
                        newReader.Close();
                    }
                    newReader.Close();
                }

                row.Cells[7].Value = total.ToString();
                daySum += total;
            }

            //label33.Text = daySum.ToString();
            //newReader = null;
            //newCommand = null;
        }
        private void comboBoxClinicRoomName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonSearch_Click(sender, e);
            }
        }
        private void buttonPutIn_Click(object sender, EventArgs e)
        {

            Patient patient = new Patient(this.lblClinicRoomId.Text,comboBoxClinicRoomName.Text,int.Parse(txtBoxClinicRoomWeight.Text),int.Parse(txtBoxClinicRoomHeight.Text),txtBoxClinicRoomAddress.Text,dateTimePickerBirthDay.Value);


            if (this.comboBoxClinicRoomName.Text == null || this.comboBoxClinicRoomName.Text == string.Empty)
            {
                MessageBox.Show("Ten Benh Nhan");
                return;
            }

            string originalName = Helper.hasOtherNameForThisId(db, this.lblClinicRoomId.Text,
                this.comboBoxClinicRoomName.Text);
            if (originalName != null)
            {
                MessageBox.Show("Bạn không thể sửa tên bệnh nhân đã nhập!");
                this.comboBoxClinicRoomName.Text = originalName;
                return;
            }

            bool isPatientExist = Helper.checkPatientExists(db, this.lblClinicRoomId.Text);

            if (!isPatientExist)
            {
                List<string> columns = new List<string>() { "Name", "Address", "Birthday", "Height", "Weight", "Id" };
                List<string> values = new List<string>()
                {
                    comboBoxClinicRoomName.Text,
                    txtBoxClinicRoomAddress.Text,
                    dateTimePickerBirthDay.Value.ToString("yyyy-MM-dd"),
                    txtBoxClinicRoomHeight.Text,
                    txtBoxClinicRoomWeight.Text,
                    lblClinicRoomId.Text
                };
                db.InsertRowToTable("patient", columns, values);
            }


            List<Medicine> listMedicines = new List<Medicine>();
            if (this.dataGridViewMedicine.Rows.Count>1)
            {

            listMedicines = Helper.GetAllMedicinesFromDataGrid(db,this.dataGridViewMedicine);
            }

            if (!Helper.checkVisitExists(db, this.lblClinicRoomId.Text, this.dateTimePickerNgayKham.Value.ToString("yyyy-MM-dd")))
            {
                AddVisitData();
            }
            else
            {
                ChangeVisitData();
            }


            ClearClinicRoomForm();
            InitClinicRoom();


            //Thread thread = new Thread(()=>
            //    {
                    ///
                    //
                    //
                    //Create a PDF file
                    Helper.CreateAPdf(infoClinic, lblClinicRoomId.Text, patient, listMedicines);

                    //
                    //Load Pdf and put in form
                    axAcroPDF1.LoadFile("firstpage.pdf");
            //    }
            //    );

            //thread.Start();
            
         
        }

        

        #endregion

        #region Event Main Tool 

        private void button3_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            int Authority = 0;
            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                Authority = 2;
            }
            if (checkBox1.Checked == true && checkBox2.Checked == false)
            {
                Authority = 3;
            }
            if (checkBox1.Checked == false && checkBox2.Checked == true)
            {
                Authority = 4;
            }
            if (checkBox1.Checked == false && checkBox2.Checked == false)
            {
                MessageBox.Show("Không thêm vào nhân viên này được!");
                return;
            }

            if (checkBox3.Checked)
            {
                Authority += 10;
            }

            if (checkBox4.Checked)
            {
                Authority += 100;
            }

            List<string> columns = new List<string>() { "Username", "Password1", "Authority" };
            List<string> values = new List<string>() { username, Helper.Encrypt(password), Authority.ToString() };

            db.InsertRowToTable("ClinicUser", columns, values);
            MessageBox.Show("Thêm mới nhân viên thành công");
        }

        #endregion

           CalendarItem contextItem = null;
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            contextItem = calendar1.ItemAt(contextMenuStrip1.Bounds.Location);
        }

        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            calendar1.ActivateEditMode();
        }

        private void calendar1_ItemDeleted(object sender, CalendarItemEventArgs e)
        {
            _items.Remove(e.Item);
            Helper.DeleteRowToTableCalendar(db, "calendar", e.Item.Tag.ToString(), Form1.UserName);

        }

        private void calendar1_ItemTextEdited(object sender, CalendarItemCancelEventArgs e)
        {

              // e.Item.Tag = // set id
                Helper.UpdateRowToTableCalendar(db, "calendar", new List<string> { "Text" }, new List<string> { e.Item.Text  }, e.Item.Tag.ToString(), UserName);
            
        }

        private void calendar1_ItemDatesChanged(object sender, CalendarItemEventArgs e)
        {

            // e.Item.Tag = // set id
            try
            {
                Helper.UpdateRowToTableCalendar(db, "calendar", new List<string> { "StartTime", "EndTime" }, new List<string> { Helper.ConvertToDatetimeSql(e.Item.StartDate), Helper.ConvertToDatetimeSql(e.Item.EndDate) }, e.Item.Tag.ToString(), UserName);
            }
            catch(Exception ex)
            {}

        }

        private void calendar1_DayHeaderClick(object sender, CalendarDayEventArgs e)
        {
            calendar1.SetViewRange(e.CalendarDay.Date, e.CalendarDay.Date);
        }
        private void calendar1_ItemCreated(object sender, CalendarItemCancelEventArgs e)
        {
            _items.Add(e.Item);
            //if (e.Item.Text.Length > 0)
            //{
                e.Item.Tag = maxIdOfCalendarItem;
                List<string> values = new List<string> { maxIdOfCalendarItem.ToString(), UserName, Helper.ConvertToDatetimeSql(e.Item.StartDate), Helper.ConvertToDatetimeSql(e.Item.EndDate), e.Item.Text, "0" };
              db.InsertRowToTable("calendar", DatabaseContants.columnsCalendar, values);
                //MessageBox.Show("s");
            //}
              maxIdOfCalendarItem = Helper.SearchMaxValueOfTable("calendar", "IdCalendar", "DESC");
        }

        public FileInfo ItemsFile
        {
            get
            {
                return new FileInfo(Path.Combine(Application.StartupPath, "items.xml"));
            }
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    //if (ItemsFile.Exists)
        //    //{
        //    //    List<ADate> lst = new List<ADate>();

        //    //    XmlSerializer xml = new XmlSerializer(lst.GetType());

        //    //    using (Stream s = ItemsFile.OpenRead())
        //    //    {
        //    //        lst = xml.Deserialize(s) as List<ADate>;
        //    //    }

        //    //    foreach (ADate item in lst)
        //    //    {
        //    //        CalendarItem cal = new CalendarItem(calendar1, item.StartTime, item.EndTime, item.Text);

        //    //        //if (!(item.R == 0 && item.G == 0 && item.B == 0))
        //    //        //{
        //    //        //    cal.ApplyColor(System.Drawing.Color.FromArgb(item.A, item.R, item.G, item.B));
        //    //        //}

        //    //        _items.Add(cal);
        //    //    }

        //    //    PlaceItems();
        //    //}
        //}
        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            calendar1.SetViewRange(monthView1.SelectionStart, monthView1.SelectionEnd);
        }
        private void PlaceItems()
        {
            foreach (CalendarItem item in _items)
            {
                if (calendar1.ViewIntersects(item))
                {
                    calendar1.Items.Add(item);
                }
            }
        }

        private void calendar1_ItemClick(object sender, CalendarItemEventArgs e)
        {
            //MessageBox.Show(e.Item.Text);
        }
        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            PlaceItems();
        }
        private void calendar1_ItemMouseHover(object sender, CalendarItemEventArgs e)
        {
            Text = e.Item.Text;
        }
        private void otherColorTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    foreach (CalendarItem item in calendar1.GetSelectedItems())
                    {
                        item.ApplyColor(dlg.Color);
                        calendar1.Invalidate(item);
                    }
                }
            }
        }
        private void redTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ApplyColor(Color.Red);
                calendar1.Invalidate(item);
                Helper.UpdateRowToTableCalendar(db, "calendar", new List<string> { "Color" }, new List<string> { "1" }, item.Tag.ToString(), UserName);


            }
        }

        private void yellowTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ApplyColor(Color.Gold);
                calendar1.Invalidate(item);
                Helper.UpdateRowToTableCalendar(db, "calendar", new List<string> { "Color" }, new List<string> { "2" }, item.Tag.ToString(), UserName);
            }
        }

        private void greenTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ApplyColor(Color.Green);
                calendar1.Invalidate(item);
                Helper.UpdateRowToTableCalendar(db, "calendar", new List<string> { "Color" }, new List<string> { "3" }, item.Tag.ToString(), UserName);
            }
        }

        private void blueTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ApplyColor(Color.DarkBlue);
                calendar1.Invalidate(item);
                Helper.UpdateRowToTableCalendar(db, "calendar", new List<string> { "Color" }, new List<string> { "4" }, item.Tag.ToString(), UserName);
            }
        }
        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calendar1.ActivateEditMode();
        }

        private void label30_Click(object sender, EventArgs e)
        {

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            axAcroPDF1.printWithDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InfoClinic infoClinic = new InfoClinic();
            infoClinic.Name = textBoxNameClinic.Text;
            infoClinic.Address = textBoxAddressClinic.Text;
            infoClinic.Advice = textBoxAdviceClinic.Text;
            XmlSerializer serializer = new XmlSerializer(infoClinic.GetType());
            StreamWriter sw = new StreamWriter("Information.xml");
            serializer.Serialize(sw, infoClinic);
            sw.Close();
        }

        private void checkBoxAutoCopy_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutoCopy.Checked == true)
            {
                System.Threading.TimerCallback TimerDelegate =
        new System.Threading.TimerCallback(TimerTask);

                // Create a timer that calls a procedure every int.Parse(textBoxBackupTimeAuto.Text) seconds. 
                // Note: There is no Start method; the timer starts running as soon as  
                // the instance is created.
                int minute = int.Parse(textBoxBackupTimeAuto.Text) *1000*60;
                TimerItem =
                    new System.Threading.Timer(TimerDelegate, null, minute,minute);

            }

            else
            {
                TimerItem.Dispose();
            }

        }

        private void TimerTask(object StateObj)
        {
            Helper.CopyFilesRecursively(new DirectoryInfo(textBoxBackupSource.Text),new DirectoryInfo(textBoxBackupTarget.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
               textBoxBackupSource.Text= folderBrowserDialog.SelectedPath;

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxBackupTarget.Text = folderBrowserDialog.SelectedPath;

            }
        }

        private void buttonServicesOK_Click(object sender, EventArgs e)
        {
            int giaOut;
            if (textBoxServices.Text[0] != '@' || textBoxServices.Text=="")
            {
                MessageBox.Show("Tên dịch vụ phải bắt đầu với ký tự '@'", "Chú ý"); // phân biệt với thuốc
                return;
            }
            try
            {
                giaOut = int.Parse(textBoxServicesCost.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Xin nhập lại giá. Giá không phù hợp!", "Chú ý");
                return;
            }
            string Id= labelServicesID.Text;
            if (!Helper.CheckMedicineExists(db, Id))
            {
                List<string> columns = new List<string>() { "Name", "CostOut", "ID" };
                List<string> values = new List<string>() { textBoxServices.Text.Trim(), giaOut.ToString(), Id };

                db.InsertRowToTable("Medicine", columns, values);
                MessageBox.Show("Thêm mới dịch vụ thành công");
            }
            else
            {

                string strCommand = "Update Medicine Set CostOut =" + giaOut.ToString() + " Where Id =" + Id;
                db.ExecuteNonQuery(strCommand, null);
                MessageBox.Show("Sửa giá tiền dịch vụ thành công");
            }



            InitTableServices();
        }

        private void dataGridViewMedicine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxServices_TextChanged(object sender, EventArgs e)
        {
            string nameOfService = textBoxServices.Text;
            string strCommand = "Select * From Medicine Where Name =" + Helper.ConvertToSqlString(nameOfService);
            //MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {
                if (reader.Read())
                {
                    string temp = reader[DatabaseContants.medicine.CostOut].ToString();
                    string HDSD = reader[DatabaseContants.medicine.Hdsd].ToString();
                    string id = reader["Id"].ToString();
                    reader.Close();
                    textBoxServicesCost.Text = temp;
                    labelServicesID.Text = id;
                    return;
                }
            }
            RefreshIdOfNewMedicine();
            textBoxServicesCost.Text = "0";
        }
    }
}
