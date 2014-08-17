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

namespace PhongKham
{
    public partial class Form1 : DevComponents.DotNetBar.Office2007Form
    {

        private IDatabase db = DatabaseFactory.Instance;

        public Form1(int Authority)
        {

            InitializeComponent();
            InitInputMedicineMySql();
            InitUser(Authority);
            InitComboboxMedicinesMySql();
            InitClinicRoom();
            dataGridView4.Visible = false;
            checkBox1.Checked = true;
            checkBox2.Checked = true;
           
        }

        #region Init

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
            this.Column18.Items.AddRange(Helper.GetAllRowsOfSpecialColumn("Medicine", "Name").ToArray());
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
                tabControl1.TabPages.Remove(tabPage4);
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
                    tabControl1.TabPages.Remove(tabPage1);
                    break;
                case 4:
                    tabControl1.TabPages.Remove(tabPage3);
                    break;
            }
        }
   
        private void InitInputMedicineMySql()
        {

            RefreshIdOfNewMedicine();
            comboBoxInputMedicineName.Items.Clear();

            comboBoxInputMedicineName.Items.AddRange(Helper.GetAllRowsOfSpecialColumn("Medicine", "Name").ToArray());



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
            reader.Close();


        }
        private void FillInfoToClinicForm(DbDataReader reader)
        {
            lblClinicRoomId.Text = reader["Id"].ToString();
            txtBoxClinicRoomAddress.Text = reader["Address"].ToString();
            txtBoxClinicRoomWeight.Text = reader["Weight"].ToString();
            txtBoxClinicRoomHeight.Text = reader["Height"].ToString();
            dateTimePickerBirthDay.Text = reader["Birthday"].ToString();
            dateTimePickerNgayKham.Text = reader["Day"].ToString(); //ngay kham
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
            }
            catch (Exception)
            {
            }


            if (medicine.CostOut < medicine.CostIn)
            {
                MessageBox.Show("Giá Out không thể nhỏ hơn giá In!", "Lỗi");
                return;
            }

            List<string> columns = new List<string>() { "Name", "Count", "CostIn", "CostOut", "InputDay", "ID" };
            List<string> values = new List<string>() { medicine.Name, medicine.Count.ToString(), medicine.CostIn.ToString(), medicine.CostOut.ToString(), medicine.InputDay.ToString("yyyy-MM-dd"), medicine.Id };
            db.InsertRowToTable("Medicine", columns, values);
            MessageBox.Show("Thêm mới thuốc thành công");

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
            //MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
            db.ExecuteNonQuery(strCommand, null);

            MessageBox.Show("Thêm thuốc thành công : " + txtBoxInputMedicineAdd.Text + " " + comboBoxInputMedicineName.Text);
            ClearInputMedicine();


        }
        private void button9_Click(object sender, EventArgs e)
        {
            ClearInputNewMedicine();
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
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
                    string strCommand = "Select CostOut From Medicine Where Name =" + Helper.ConvertToSqlString(nameOfMedicine);
                    //MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
                    using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
                    {
                        reader.Read();
                        string temp = reader.GetValue(0).ToString();
                        reader.Close();
                        dataGridViewMedicine[2, e.RowIndex].Value = temp;
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
                    + Id + " AND h.Day = " + Helper.ConvertToSqlString(this.dataGridViewSearchValue.Rows[e.RowIndex].Cells[3].Value.ToString());

                // MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);

                using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
                {
                    reader.Read();
                    if (!reader.HasRows) return;

                    string medicines = reader["Medicines"].ToString();
                    string name = reader["Name"].ToString();
                    FillInfoToClinicForm(reader);
                    reader.Close();

                    //comboBoxClinicRoomName.Text = name; // this will fill all infos via comboBox name changed event

                    string[] medicineAndCount = new string[] { };
                    if (!string.IsNullOrEmpty(medicines))
                    {
                        medicineAndCount = medicines.Split(',');
                    }

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


            // MySqlCommand comm2 = new MySqlCommand(strCommandMain, Program.conn);
            using (DbDataReader reader2 = db.ExecuteReader(strCommandMain, null) as DbDataReader)
            {
                while (reader2.Read())
                {
                    int index = dataGridViewSearchValue.Rows.Add();
                    DataGridViewRow row = dataGridViewSearchValue.Rows[index];
                    row.Cells[0].Value = reader2.GetString(5); // id
                    row.Cells[1].Value = reader2.GetString(0);
                    row.Cells[2].Value = reader2.GetDateTime(2).ToString("yyyy-MM-dd");//birthday
                    row.Cells[3].Value = reader2.GetDateTime(10).ToString("yyyy-MM-dd"); // ngay kham
                    row.Cells[4].Value = reader2.GetString(1);//address
                    row.Cells[5].Value = reader2.GetString(7);//symptom
                    row.Cells[6].Value = reader2.GetString(8);
                    row.Cells[7].Value = reader2.GetString(9) != null ? reader2.GetString(9) : ""; // Thuoc
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

            label33.Text = daySum.ToString();
            //newReader = null;
            //newCommand = null;
        }
        private void buttonPutIn_Click(object sender, EventArgs e)
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
    }
}
