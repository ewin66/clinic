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
using System.Globalization;
using System.Runtime.InteropServices;



namespace PhongKham
{
    public partial class Form1 : DevComponents.DotNetBar.Office2007Form
    {

        [DllImport("user32")]
        public static extern int SetParent(int hWndChild, int hWndNewParent);


        public static Dictionary<string, string> listPatientToday = new Dictionary<string, string>();
        private static int maxIdOfCalendarItem;
        private int TongTien;
        private InfoClinic infoClinic;
        private static string UserName;
        public static string nameOfDoctor;
        private IDatabase db = DatabaseFactory.Instance;
        List<CalendarItem> _items = new List<CalendarItem>();
        List<string> currentMedicines = new List<string>();
        List<string> currentServices = new List<string>();
        public static int Authority;

        System.Threading.Timer TimerItem;
        private ListPatientsTodayForm listPatientForm;

        public Form1(int Authority, string name)
        {

            InitializeComponent();
            //this.ResizeBegin += (s, e) => { this.SuspendLayout(); };
            //this.ResizeEnd += (s, e) => { this.ResumeLayout(true); };
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Text = "Phòng Khám -" + "User: " + name;
            UserName = name;
            nameOfDoctor = Helper.GetNameOfDoctor(db, name);
            this.StartPosition = FormStartPosition.CenterScreen;
            Form1.Authority = Authority;
            this.WindowState = Clinic.Properties.Settings.Default.State;
            if (this.WindowState == FormWindowState.Normal) this.Size = Clinic.Properties.Settings.Default.Size;
            this.Resize += new System.EventHandler(this.Form1_Resize);
            InitUser(Authority);
            try
            {

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(InfoClinic));
                StreamReader sr = new StreamReader("Information.xml");
                infoClinic = xmlSerializer.Deserialize(sr) as InfoClinic;
            }
            catch (Exception e)
            { }

            Thread thread = new Thread(new ThreadStart(WorkThreadFunction));
            thread.Start();
            listPatientForm = new Clinic.ListPatientsTodayForm();
            listPatientForm.sendCommandKham = new Clinic.ListPatientsTodayForm.SendCommandKham(KhamVaXoa);
            ///favouriteForm.sendCommand = new Form2.SendCommand(PlayFromFavouriteForm);
            ///

            this.ColumnID.Width = 50;
            this.ColumnNamePatient.Width = 150;
            this.ColumnNgaySinh.Width = 100;
            this.ColumnNgayKham.Width = 100;
            this.ColumnAddress.Width = 100;
            this.ColumnSymtom.Width = 100;
            this.ColumnNhietDo.Width = 50;
            this.ColumnHuyetAp.Width = 50;
            this.ColumnDiagno.Width = 150;
            this.ColumnSearchValueMedicines.Width = 250;

        }

        private void KhamVaXoa(string id, string name,string state)
        {

            string strCommand = "Select * From patient  Where Name = " + Helper.ConvertToSqlString(name) + " and Idpatient =" + Helper.ConvertToSqlString(id);

            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {
                reader.Read();
                FillInfoToClinicForm(reader, true);
            }
            string []stateString = state.Split(';');
            this.textBoxClinicNhietDo.Text = stateString[0];
            this.textBoxHuyetAp.Text = stateString[1];
            buttonSearch.PerformClick();
            Helper.DeleteRowFromTablelistpatienttoday(db, id, name);
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

                //do not change 

                InitComboboxMedicinesMySql();
                InitInputMedicineMySql();
                InitClinicRoom();
                InitTableServices();
                dataGridView4.Visible = false;



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


                //load lichhen
                LoadLichHen(DateTime.Now);

                //xoa listtoday
                XoaListToday();
            }
            catch (Exception ex)
            {
                // log errors
            }
        }

        private void XoaListToday()
        {
            string cmd = "Delete from listpatienttoday Where time != " + Helper.ConvertToSqlString(DateTime.Now.ToString("yyyy-MM-dd") );
            db.ExecuteNonQuery(cmd, null);
        }

        private void LoadLichHen(DateTime time)
        {
            string cmd = "Select * from lichhen Where time = " + Helper.ConvertToSqlString(time.ToString("yyyy-MM-dd"));
            using (DbDataReader reader = db.ExecuteReader(cmd, null) as DbDataReader)
            {

                while (reader.Read())
                {
                    
                    int index = dataGridViewCalendar.Rows.Add();
                    DataGridViewRow row = dataGridViewCalendar.Rows[index];
                    row.Cells[0].Value = reader["Idpatient"].ToString();
                    row.Cells[1].Value = reader["Namepatient"].ToString();
                    row.Cells[2].Value = reader["phone"].ToString();
                    row.Cells[3].Value = reader["benh"].ToString();
                    row.Cells[4].Value = reader["Namedoctor"].ToString();
                }
            }
        }

        private void InitClinicRoom()
        {
            //init id
            int intId = Helper.SearchMaxValueOfTable("Patient", "Idpatient", "DESC");
            string ID = intId.ToString();
            lblClinicRoomId.Text = ID;

            //init comboBoxName

            comboBoxClinicRoomName.Items.Clear();
            // Helper.GetAllRowsOfSpecialColumn("Patient","Name");

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

                //  Authority = 2; // bac si

                //Authority = 3; // nhan vien nhap thuoc

                //Authority = 4; // ca 2

            if (authority == 1)
            { //admin

                return;
            }

            MainTab.TabPages.Remove(tabPageTools);
            MainTab.TabPages.Remove(tabPagePrint);
            MainTab.TabPages.Remove(tabPagenhapthuoc);
            this.pictureBox1.Visible = false;

            switch (authority)
            {
                case 1:
                    //all control
                    break;
                case 2:
                    MainTab.TabPages.Add(tabPagePrint);
                    this.pictureBox1.Visible = true;
                    break;
                case 3://khong co quyen ke thuoc
                    this.dataGridViewMedicine.Visible = false;
                    this.label9.Visible = false;
                    this.labelTongTien.Visible = false;
                    this.label44.Visible = false; // SDT:
                    this.textBoxClinicPhone.Visible = false;
                    this.txtBoxClinicRoomSymptom.Visible = false;
                    this.txtBoxClinicRoomDiagnose.Visible = false;
                    this.buttonPutIn.Visible = false;
                    MainTab.TabPages.Add(tabPagenhapthuoc);             
                    break;
                case 4:
                    this.pictureBox1.Visible = true;
                    MainTab.TabPages.Add(tabPagePrint);
                    MainTab.TabPages.Add(tabPagenhapthuoc);
                    break;
                case 0:
                    this.dataGridViewMedicine.Visible = false;
                    this.label9.Visible = false;
                    this.labelTongTien.Visible = false;
                    this.label44.Visible = false; // SDT:
                    this.textBoxClinicPhone.Visible = false;
                    this.txtBoxClinicRoomSymptom.Visible = false;
                    this.txtBoxClinicRoomDiagnose.Visible = false;
                    this.buttonPutIn.Visible = false;
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
        //private void txtBoxClinicRoomHeight_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        //}
        //private void txtBoxClinicRoomWeight_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        //}
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
            labelTongTien.Text = "0";
            textBoxClinicPhone.Text = "";
            textBoxClinicNhietDo.Text = "";
            textBoxHuyetAp.Text = "";
            labelTuoi.Text = "0";
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
        private void FillInfoToClinicForm(DbDataReader reader, bool onlyInfo)
        {
            lblClinicRoomId.Text = reader["Idpatient"].ToString();
            txtBoxClinicRoomAddress.Text = reader["Address"].ToString();
            txtBoxClinicRoomWeight.Text = reader["Weight"].ToString();
            txtBoxClinicRoomHeight.Text = reader["Height"].ToString();
            dateTimePickerBirthDay.Text = reader["Birthday"].ToString();
            comboBoxClinicRoomName.Text = reader["name"].ToString();
            // dateTimePickerNgayKham.Text = reader["Day"].ToString(); //we update new Date 
            if (!onlyInfo)
            {
                txtBoxClinicRoomSymptom.Text = reader["Symptom"].ToString();
                txtBoxClinicRoomDiagnose.Text = reader["Diagnose"].ToString();
                textBoxClinicNhietDo.Text = reader[DatabaseContants.history.temperature].ToString();
                textBoxHuyetAp.Text = reader[DatabaseContants.history.huyetap].ToString();
            }
            textBoxClinicPhone.Text = reader["phone"].ToString();


        }
        private void AddVisitData()
        {
            //Save to history
            List<string> columnsHistory = new List<string>() { "Id", "Symptom", "Diagnose", "Day", "Medicines", "temperature","huyetap" };
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

            List<string> valuesHistory = new List<string>() { lblClinicRoomId.Text, txtBoxClinicRoomSymptom.Text, txtBoxClinicRoomDiagnose.Text, DateTime.Now.ToString("yyyy-MM-dd"), medicines, textBoxClinicNhietDo.Text ,textBoxHuyetAp.Text};
            db.InsertRowToTable("history", columnsHistory, valuesHistory);

        }
        private void ChangeVisitData()
        {
            List<string> columns = new List<string>() { "Name", "Address", "Birthday", "Height", "Weight"};
            List<string> values = new List<string>() { comboBoxClinicRoomName.Text, txtBoxClinicRoomAddress.Text, dateTimePickerBirthDay.Value.ToString("yyyy-MM-dd"), txtBoxClinicRoomHeight.Text, txtBoxClinicRoomWeight.Text };
            Helper.UpdateRowToTable(db, "patient", columns, values, lblClinicRoomId.Text);



            //Save to history
            List<string> columnsHistory = new List<string>() { "Id", "Symptom", "Diagnose", "Day", "Medicines", "temperature","huyetap" };
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

            List<string> valuesHistory = new List<string>() { lblClinicRoomId.Text, txtBoxClinicRoomSymptom.Text, txtBoxClinicRoomDiagnose.Text, dateTimePickerNgayKham.Value.ToString("yyyy-MM-dd"), medicines, textBoxClinicNhietDo.Text,textBoxHuyetAp.Text };
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
            if (txtBoxInputMedicineNewName.Text.Contains(','))
            {
                MessageBox.Show("Tên thuốc không được chứa dấu phẩy .Gợi ý: dấu chấm ");
                return;
            }
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

            List<string> columns = new List<string>() { "Name", "Count", "CostIn", "CostOut", "InputDay", "ID", "Hdsd" };
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
            if (MainTab.SelectedTab.Name == "tabnhapthuoc")
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
                        if (reader.HasRows)
                        {
                            string temp = reader[DatabaseContants.medicine.CostOut].ToString();
                            string HDSD = reader[DatabaseContants.medicine.Hdsd].ToString();
                            string id = reader["Id"].ToString();

                            dataGridViewMedicine[2, e.RowIndex].Value = temp;
                            dataGridViewMedicine[DatabaseContants.HDSDColumnInDataGridViewMedicines, e.RowIndex].Value = HDSD;
                            dataGridViewMedicine[DatabaseContants.IdColumnInDataGridViewMedicines, e.RowIndex].Value = id;
                        }
                        reader.Close();
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
                        dataGridViewMedicine[e.ColumnIndex, e.RowIndex].Value = "";
                    }


                }
            }
            if (e.ColumnIndex == 3 && e.RowIndex > -1) // change cost
            {
                labelTongTien.Text = "0";
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

                int temp = total;
                TongTien = total;
                labelTongTien.Text = temp.ToString("C0");
            }
        }
        private void dataGridViewSearchValue_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string Id = dataGridViewSearchValue[0, e.RowIndex].Value.ToString();
                string strCommand = "SELECT * FROM patient p RIGHT JOIN history h ON p.Idpatient = h.Id WHERE h.Id = "
                    + Id + " AND h.Day = " + Helper.ConvertToSqlString(Helper.ChangePositionOfDayAndYear(this.dataGridViewSearchValue.Rows[e.RowIndex].Cells[3].Value.ToString()));

                // MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);

                using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
                {
                    reader.Read();
                    if (!reader.HasRows) return;

                    string medicines = reader["Medicines"].ToString();
                    string name = reader["Name"].ToString();
                    comboBoxClinicRoomName.Text = name;
                    FillInfoToClinicForm(reader, false);
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
                        try
                        {
                            this.dataGridViewMedicine.Rows[i / 2].Cells[1].Value = medicineAndCount[i + 1];
                        }
                        catch (Exception ex)
                        { }
                        
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
                FillInfoToClinicForm(reader, false);
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
            string strCommand = "Select Name , Idpatient From patient  Where Name = " + Helper.ConvertToSqlString(findingName) + " and Idpatient =" + Helper.ConvertToSqlString(Id);
            // MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {
                reader.Read();
                if (reader.HasRows == true && !string.IsNullOrEmpty(findingName)) //level 2
                {
                    strCommandMain = "SELECT * FROM patient p RIGHT JOIN history h ON p.Idpatient = h.Id WHERE h.Id = " + Id;
                }
                else // level 1 
                {
                    if (dateTimePickerNgayKham.Value.Date <= DateTime.Now.Date)
                    {
                        if (string.IsNullOrEmpty(findingName)) //name = null --> find due to date
                        {
                            strCommandMain =
                                "SELECT * FROM patient p RIGHT JOIN history h ON p.Idpatient = h.Id WHERE h.Day = " +
                                Helper.ConvertToSqlString(dateTimePickerNgayKham.Value.ToString("yyyy-MM-dd"));
                        }
                        else
                        {
                            strCommandMain =
                                "SELECT * FROM patient p RIGHT JOIN history h ON p.Idpatient = h.Id WHERE p.Name LIKE '%" +
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
                    row.Cells["ColumnID"].Value = reader2[DatabaseContants.patient.Id].ToString(); // id
                    row.Cells["ColumnNamePatient"].Value = reader2[DatabaseContants.patient.Name].ToString();
                    row.Cells["ColumnNgaySinh"].Value = reader2.GetDateTime(reader2.GetOrdinal(DatabaseContants.patient.birthday)).ToString("dd-MM-yyyy");//birthday
                    row.Cells["ColumnNgayKham"].Value = reader2.GetDateTime(reader2.GetOrdinal(DatabaseContants.history.Day)).ToString("dd-MM-yyyy");  // ngay kham
                    row.Cells["ColumnAddress"].Value = reader2[DatabaseContants.patient.Address].ToString();//address
                    row.Cells["ColumnSymtom"].Value = reader2[DatabaseContants.history.Symptom].ToString();//symptom
                    row.Cells["ColumnDiagno"].Value = reader2[DatabaseContants.history.Diagnose].ToString(); // chan doan
                    row.Cells["ColumnNhietDo"].Value = reader2[DatabaseContants.history.temperature].ToString(); 
                    medicines = reader2[DatabaseContants.history.Medicines].ToString();
                    try
                    {
                        row.Cells["ColumnSearchValueMedicines"].Value = Helper.ChangeListMedicines(medicines);
                    }
                    catch(Exception exp)
                    {

                    }
                    row.Cells["ColumnHuyetAp"].Value = reader2[DatabaseContants.history.huyetap].ToString(); 
                }
            }

            string askCostOut;
            //MySqlCommand newCommand = null;
            //MySqlDataReader newReader = null;
            int daySum = 0;
            foreach (DataGridViewRow row in this.dataGridViewSearchValue.Rows)
            {
                //int total = 0;

                //string[] medicineAndCount = row.Cells[7].Value.ToString().Split(',');

                //for (int i = 0; i < medicineAndCount.Length; i = i + 2)
                //{
                //    askCostOut = "Select CostOut From Medicine Where Name =" + Helper.ConvertToSqlString(medicineAndCount[i]);
                //    //newCommand = new MySqlCommand(askCostOut, Program.conn);
                //    DbDataReader newReader = db.ExecuteReader(askCostOut, null) as DbDataReader;
                //    newReader.Read();
                //    try
                //    {
                //        total += int.Parse(medicineAndCount[i + 1]) * (int)newReader.GetValue(0);
                //    }
                //    catch (Exception)
                //    {
                //        newReader.Close();
                //    }
                //    newReader.Close();
                //}

                //row.Cells[7].Value = total.ToString();
                //daySum += total;
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
            if (dateTimePickerNgayKham.Value.ToShortDateString() != DateTime.Now.ToShortDateString())
            {
                MessageBox.Show("Không thể khám ở quá khứ");
                return;
            }

            if (Helper.EmptyNumberCell(this.dataGridViewMedicine))
            {
                MessageBox.Show("Ô số lượng trống!");
                return;
            }
            if (Helper.ExistMoreThanOneRowOfMedicine(this.dataGridViewMedicine))
            {
                MessageBox.Show("Trùng Thuốc!");
                return;
            }

            string thongbao = "Kết thúc phiên khám! và không hẹn";
            if (checkBoxHen.Checked == true)
            {
                thongbao = "Kết thúc phiên khám! và hẹn tái khám vào ngày: " + dateTimePickerHen.Value.ToString("dd-MM-yyyy");
            }

            DialogResult result = MessageBox.Show(thongbao, "Xin xác nhận!", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
           if(result == DialogResult.Cancel)
            { 
                return;
            }
            else if (result == DialogResult.OK)
           {
               string strHenTaiKham = "";
               if (checkBoxHen.Checked == true)
               {
                   List<string> columnslichhen = new List<string>() { "Idpatient", "Namedoctor", "Namepatient", "time", "phone", "benh" };
                   List<string> valueslichhen = new List<string>() { lblClinicRoomId.Text, Form1.nameOfDoctor, comboBoxClinicRoomName.Text, dateTimePickerHen.Value.ToString("yyyy-MM-dd"), textBoxClinicPhone.Text, txtBoxClinicRoomDiagnose.Text };
                   db.InsertRowToTable("lichhen", columnslichhen, valueslichhen);
                   strHenTaiKham = "Mời tái khám vào ngày: " + dateTimePickerHen.Value.ToString("dd-MM-yyyy");
               }

               checkBoxHen.Checked = false;
               
               //MessageBox.Show("Hẹn vào ngày: " + dateTimePickerHen.Value.ToString("dd-MM-yyyy"));

            Patient patient = new Patient(this.lblClinicRoomId.Text,comboBoxClinicRoomName.Text,txtBoxClinicRoomWeight.Text,txtBoxClinicRoomHeight.Text,txtBoxClinicRoomAddress.Text,dateTimePickerBirthDay.Value);


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
                List<string> columns = new List<string>() { "Name", "Address", "Birthday", "Height", "Weight", "Id","phone" };
                List<string> values = new List<string>()
                {
                    comboBoxClinicRoomName.Text,
                    txtBoxClinicRoomAddress.Text,
                    dateTimePickerBirthDay.Value.ToString("yyyy-MM-dd"),
                    txtBoxClinicRoomHeight.Text,
                    txtBoxClinicRoomWeight.Text,
                    lblClinicRoomId.Text,
                    textBoxClinicPhone.Text
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
                //save to doanhthu
                List<string> columnsDoanhThu = new List<string>() { "Namedoctor", "Money", "time", "Idpatient", "Namepatient" };
                List<string> valuesDoanhThu = new List<string>() { Form1.nameOfDoctor, TongTien.ToString(), DateTime.Now.ToString("yyyy-MM-dd"), lblClinicRoomId.Text, comboBoxClinicRoomName.Text };
                db.InsertRowToTable("doanhthu", columnsDoanhThu, valuesDoanhThu);

                //tru tu thuoc
                Helper.TruTuThuoc(db, listMedicines);

                
                
            }
            else
            {
                //sua tu thuoc 
                List<Medicine> listMedicineFromHistory = new List<Medicine>();
                try
                {
                     listMedicineFromHistory = Helper.GetMedicinesFromHistory(db, lblClinicRoomId.Text, DateTime.Now.ToString("yyyy-MM-dd"));
                }
                catch (Exception exss)
                {

                }
                List<Medicine> UpdateMedicines = Helper.CompareTwoListMedicineToUpdate(listMedicineFromHistory, listMedicines);

                Helper.TruTuThuoc(db, UpdateMedicines);

                ChangeVisitData();
                //update to doanhthu
                List<string> columnsDoanhThu = new List<string>() { "Namedoctor", "Money", "time" };
                List<string> valuesDoanhThu = new List<string>() { Form1.nameOfDoctor, TongTien.ToString(), DateTime.Now.ToString("yyyy-MM-dd") };
                Helper.UpdateRowToTableDoanhThu(db, "doanhthu", columnsDoanhThu, valuesDoanhThu, lblClinicRoomId.Text);


            }


            if (!Helper.checkVisitExistsDoanhThu(db, this.lblClinicRoomId.Text, this.dateTimePickerNgayKham.Value.ToString("yyyy-MM-dd")))
            {

                //save to doanhthu
                List<string> columnsDoanhThu = new List<string>() { "Namedoctor", "Money", "time", "Idpatient", "Namepatient" };
                List<string> valuesDoanhThu = new List<string>() { Form1.nameOfDoctor, TongTien.ToString(), DateTime.Now.ToString("yyyy-MM-dd"), lblClinicRoomId.Text, comboBoxClinicRoomName.Text };
                db.InsertRowToTable("doanhthu", columnsDoanhThu, valuesDoanhThu);
            }
            else
            {

                //update to doanhthu
                List<string> columnsDoanhThu = new List<string>() { "Namedoctor", "Money", "time" };
                List<string> valuesDoanhThu = new List<string>() { Form1.nameOfDoctor, TongTien.ToString(), DateTime.Now.ToString("yyyy-MM-dd") };
                Helper.UpdateRowToTableDoanhThu(db, "doanhthu", columnsDoanhThu, valuesDoanhThu, lblClinicRoomId.Text);
            }

            //ClearClinicRoomForm();
            //InitClinicRoom();


            //Thread thread = new Thread(()=>
            //    {
                    ///
                    //
                    //
                    //Create a PDF file
                    Helper.CreateAPdf(infoClinic, lblClinicRoomId.Text, patient, listMedicines,strHenTaiKham , this.txtBoxClinicRoomDiagnose.Text,this.labelTuoi.Text);

                    //
                    //Load Pdf and put in form
                    axAcroPDF1.LoadFile("firstpage.pdf");
            //    }
            //    );

            //thread.Start();
            



             
                // update phone
                Helper.UpdateRowToTable(db, "patient", new List<string>() { "phone" }, new List<string>() { this.textBoxClinicPhone.Text }, this.lblClinicRoomId.Text);


            }

        }



        #endregion

        #region Event Main Tool

        private void button3_Click(object sender, EventArgs e)
        {



            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (Helper.checkUserExistsWithoutPassword(username))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng nhập tên đăng nhập khác!");
                return;
            }

            int Authority = 0;
            if (checkBoxKethuoc.Checked == true)
            {
                Authority = 2; // bac si
            }
            if (checkBoxNhapThuoc.Checked == true )
            {
                Authority = 3; // nhan vien nhap thuoc
            }
            if (checkBoxNhapThuoc.Checked == true && checkBoxKethuoc.Checked == true)
            {
                Authority = 4; // ca 2
            }


            List<string> columns = new List<string>() { "Username", "Password1", "Authority", "namedoctor" };
            List<string> values = new List<string>() { username, Helper.Encrypt(password), Authority.ToString(), textBoxNameDoctor.Text };

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
            Helper.UpdateRowToTableCalendar(db, "calendar", new List<string> { "Text" }, new List<string> { e.Item.Text }, e.Item.Tag.ToString(), UserName);

        }

        private void calendar1_ItemDatesChanged(object sender, CalendarItemEventArgs e)
        {

            // e.Item.Tag = // set id
            try
            {
                Helper.UpdateRowToTableCalendar(db, "calendar", new List<string> { "StartTime", "EndTime" }, new List<string> { Helper.ConvertToDatetimeSql(e.Item.StartDate), Helper.ConvertToDatetimeSql(e.Item.EndDate) }, e.Item.Tag.ToString(), UserName);
            }
            catch (Exception ex)
            { }

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
            calendar1.SetViewRange(tabPageLich.SelectionStart, tabPageLich.SelectionEnd);

            //refresh datagridViewCalendar

            this.dataGridViewCalendar.Rows.Clear();
            LoadLichHen(tabPageLich.SelectionStart);

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
            infoClinic.Sdt = textBoxSDT.Text;
            XmlSerializer serializer = new XmlSerializer(infoClinic.GetType());
            StreamWriter sw = new StreamWriter("Information.xml");
            serializer.Serialize(sw, infoClinic);
            sw.Close();

            MessageBox.Show("Thay đổi thành công, yêu cầu chạy lại chương trình để áp dụng thông tin mới", "Thông báo!");
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
                int minute = int.Parse(textBoxBackupTimeAuto.Text) * 1000 * 60;
                TimerItem =
                    new System.Threading.Timer(TimerDelegate, null, minute, minute);

            }

            else
            {
                TimerItem.Dispose();
            }

        }

        private void TimerTask(object StateObj)
        {
            Helper.CopyFilesRecursively(new DirectoryInfo(textBoxBackupSource.Text), new DirectoryInfo(textBoxBackupTarget.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxBackupSource.Text = folderBrowserDialog.SelectedPath;

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
            if (textBoxServices.Text[0] != '@' || textBoxServices.Text == "")
            {
                MessageBox.Show("Tên dịch vụ phải bắt đầu với ký tự '@'", "Chú ý"); // phân biệt với thuốc
                return;
            }
            try
            {
                giaOut = int.Parse(textBoxServicesCost.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xin nhập lại giá. Giá không phù hợp!", "Chú ý");
                return;
            }
            string Id = labelServicesID.Text;
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

        private void buttonClinicClear_Click(object sender, EventArgs e)
        {
            ClearClinicRoomForm();
            InitClinicRoom();
        }

        private void buttonClinicCreateNew_Click(object sender, EventArgs e)
        {
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
                List<string> columns = new List<string>() { "Name", "Address", "Birthday", "Height", "Weight", "phone" };
                List<string> values = new List<string>()
                {
                    comboBoxClinicRoomName.Text,
                    txtBoxClinicRoomAddress.Text,
                    dateTimePickerBirthDay.Value.ToString("yyyy-MM-dd"),
                    txtBoxClinicRoomHeight.Text,
                    txtBoxClinicRoomWeight.Text,
                    textBoxClinicPhone.Text
                };
                db.InsertRowToTable("patient", columns, values);
                List<string> columnsHistory = new List<string>() { "Id", "Symptom", "Diagnose", "Day", "Medicines" };
                string medicines = "Dd nhập bệnh nhân mới,!";


                List<string> valuesHistory = new List<string>() { lblClinicRoomId.Text, txtBoxClinicRoomSymptom.Text, txtBoxClinicRoomDiagnose.Text, DateTime.Now.ToString("yyyy-MM-dd"), medicines };
                db.InsertRowToTable("history", columnsHistory, valuesHistory);
                MessageBox.Show("Thêm bệnh nhân mới thành công");
            }
            else // cap nhat
            {
                List<string> columns = new List<string>() { "Address", "Birthday", "Height", "Weight", "phone" };
                List<string> values = new List<string>() { txtBoxClinicRoomAddress.Text, dateTimePickerBirthDay.Value.ToString("yyyy-MM-dd"), txtBoxClinicRoomHeight.Text, txtBoxClinicRoomWeight.Text, textBoxClinicPhone.Text };
                Helper.UpdateRowToTable(db, "patient", columns, values, lblClinicRoomId.Text);
                MessageBox.Show("Sửa thông tin thành công");
            }

            //put into listpatientToday
            try
            {
                List<string> columnslistpatientToday = new List<string>() { "Id", "Name", "State", "time" };
                List<string> valueslistpatientToday = new List<string>() { lblClinicRoomId.Text, comboBoxClinicRoomName.Text,textBoxClinicNhietDo.Text+';'+textBoxHuyetAp.Text, DateTime.Now.ToString("yyyy-MM-dd") };
                db.InsertRowToTable("listpatienttoday", columnslistpatientToday, valueslistpatientToday);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bệnh nhân đã có trong danh sách");
            }

        }

        private void buttonList_MouseHover(object sender, EventArgs e)
        {


            listPatientForm.Show();
            SetParent((int)listPatientForm.Handle, (int)this.Handle);
            listPatientForm.Location = new Point(10, 100);

            //update database

            listPatientToday = Helper.GetListPatientToday(db);
            listPatientForm.PutIntoGrid(listPatientToday);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }





        private void buttonHen_Click(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePickerBirthDay_ValueChanged(object sender, EventArgs e)
        {
            //int day = DateTime.Now.Day - dateTimePickerBirthDay.Value.Day;
            Age age = new Age(dateTimePickerBirthDay.Value, DateTime.Now);
            if (age.Years >= 6)
            {
                labelTuoi.Text = age.Years.ToString() + " tuổi ";
            }
            else
            {
                int thang = age.Years * 12 + age.Months +1;
                labelTuoi.Text = thang.ToString() + " tháng";
            }

        }

        private void doanhThuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Authority == 1)
            {
                DoanhThuForm dtForm = new Clinic.DoanhThuForm();
                dtForm.Show();
                DoanhThuForm.db = this.db;
            }
            else
            {
                MessageBox.Show("Chỉ khả dụng cho admin! ");
            }
        }

        private void tủThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Authority == 1)
            {
                TuThuocForm dtForm = new Clinic.TuThuocForm();
                dtForm.Show();
            }
            else
            {
                MessageBox.Show("Chỉ khả dụng cho admin! ");
            }
        }

        private void cácDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Authority == 1)
            {
                Services formservices = new Clinic.Services();
                formservices.Show();
            }
            else
            {
                MessageBox.Show("Chỉ khả dụng cho admin! ");
            }
        }

        private void dataGridViewMedicine_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            labelTongTien.Text = "0";
            int total = 0;

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


            

            int temp = total;
            TongTien = total;
            labelTongTien.Text = temp.ToString("C0");
        }

        private void dataGridViewCalendar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridViewCalendar.Columns["ColumnKhamVaXoa"].Index) return;
            string id = dataGridViewCalendar.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            string name = dataGridViewCalendar.Rows[e.RowIndex].Cells["Patient"].Value.ToString();

            string strCommand = "Select * From patient  Where Name = " + Helper.ConvertToSqlString(name) + " and Idpatient =" + Helper.ConvertToSqlString(id);

            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {
                reader.Read();
                FillInfoToClinicForm(reader, true);
            }
            buttonSearch.PerformClick();
            Helper.DeleteRowFromTableCalendar(db, id, name);
            dataGridViewCalendar.Rows.RemoveAt(e.RowIndex);
        }

        private void dataGridViewMedicine_Leave(object sender, EventArgs e)
        {

        }

        private void dataGridViewMedicine_MouseLeave(object sender, EventArgs e)
        {
            int total = 0;

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




            int temp = total;
            TongTien = total;
            labelTongTien.Text = temp.ToString("C0");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int intId = Helper.SearchMaxValueOfTable("Patient", "Idpatient", "DESC");
            string ID = intId.ToString();
            lblClinicRoomId.Text = ID;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }







    }
}
