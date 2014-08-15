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

        private void InitClinicRoom()
        {
            //init id
            int intId = Helper.SearchMaxValueOfTable( "Patient", "Id", "DESC");
            string ID = String.Format("{0:000000}", intId);
            lblClinicRoomId.Text = ID;

            //init comboBoxName

            comboBoxClinicRoomName.Items.Clear();
            string strCommand = "Select Name From Patient";
            MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);

            using (MySqlDataReader reader = comm.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxClinicRoomName.Items.Add(reader.GetString(0));
                }
            }

        }

        private void InitComboboxMedicinesMySql()
        {

            //string strCommand = "Select Name From Medicine";
            //MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);

            //using (MySqlDataReader reader = comm.ExecuteReader())
            //{
            //    while (reader.Read())
            //    {
            //         this.Column18.Items.Add(reader.GetString(0));
            //    }
            //}
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
                this.dataGridView2.Visible = false;
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
                    //((Control)tabPage4).Enabled = false;
                    //tabControl1.TabPages.Remove(tabPage4);
                    break;
                case 3:
                    //((Control)tabPage1).Enabled = false;
                    //((Control)tabPage3).Enabled = false;
                    //tabControl1.TabPages.Remove(tabPage4);
                    tabControl1.TabPages.Remove(tabPage1);
                    break;
                case 4:
                    //((Control)tabPage1).Enabled = false;
                    //((Control)tabPage3).Enabled = false;
                    //tabControl1.TabPages.Remove(tabPage4);
                    tabControl1.TabPages.Remove(tabPage3);
                    break;
            }
        }

        

        private void InitTableWaiting()
        {

        }

        //private void InitInputMedicine()
        //{
         
        //    RefreshIdOfNewMedicine();


        //    //FillComboboxID
        //    string strCommand = " SELECT Id FROM Medicine";
        //    SqlCommand comm = new SqlCommand(strCommand, Program.conn);
        //    SqlDataReader reader = comm.ExecuteReader();
        //    comboBoxInputMedicineId.Items.Clear();
        //    while (reader.Read())
        //    {
        //        int intId = int.Parse(reader.GetString(0).Trim());
        //        string ID = String.Format("{0:000000}", intId);
        //        comboBoxInputMedicineId.Items.Add(ID);
        //    }
        //    reader.Close();

        //    //FillComboboxName
        //    strCommand = " SELECT Name FROM Medicine";
        //    comm = new SqlCommand(strCommand, Program.conn);
        //    reader = comm.ExecuteReader();
        //    comboBoxInputMedicineName.Items.Clear();
        //    while (reader.Read())
        //    {
        //        string name =reader.GetString(0).Trim();
        //        comboBoxInputMedicineName.Items.Add(name);
        //    }
        //    reader.Close();

        //}

        private void InitInputMedicineMySql()
        {

            RefreshIdOfNewMedicine();
            comboBoxInputMedicineName.Items.Clear();

            comboBoxInputMedicineName.Items.AddRange(Helper.GetAllRowsOfSpecialColumn("Medicine", "Name").ToArray());



        }

        //private void InitWaitRoom()
        //{

        //    string strCommand = " SELECT TOP 1 Id FROM Patient ORDER BY ID DESC";
        //    SqlCommand comm = new SqlCommand(strCommand, Program.conn);
        //    SqlDataReader reader = comm.ExecuteReader();
        //    reader.Read();
        //    int intTemp;
        //    if (reader.HasRows)
        //    {
        //        string temp = reader.GetString(0);
        //        intTemp = int.Parse(temp);
        //    }
        //    else
        //    {
        //        intTemp = 0;
        //    }
        //    int newId = intTemp + 1;
        //    string strNewID = String.Format("{0:000000}", newId);
        //    reader.Close();
        //    comboBoxWaitRoomId.Text = strNewID;
            

        //    comboBoxWaitRoomId.Items.Add(comboBoxWaitRoomId.Text);

        //}

        private void InitWaitRoomMySql()
        {

            string strCommand = " SELECT TOP 1 Id FROM Patient ORDER BY ID DESC";
            MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
            MySqlDataReader reader = comm.ExecuteReader();
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
            reader.Close();
            comboBoxWaitRoomId.Text = strNewID;


            comboBoxWaitRoomId.Items.Add(comboBoxWaitRoomId.Text);

        }

        private Patient AddNewPatient(SqlConnection conn,string id, bool Old)
        {
            Patient patient = new Patient();
            patient.Name = txtBoxWaitRoomName.Text.Trim();

            patient.Birthday = dateTimePicker2.Value;
            patient.Old = DateTime.Now.Year - patient.Birthday.Year;
            patient.Address = txtBoxWaitRoomAddress.Text;
            patient.Symptom = txtBoxWaitingRoomSymptom.Text;
            patient.Id = id;
            try
            {
                patient.Weight = int.Parse(txtBoxWaitingRoomWeight.Text);
            }
            catch (Exception ex)
            {
                patient.Weight = 0;
            }
            try
            {
                patient.Height = int.Parse(txtBoxWaitRoomHeight.Text);
            }
            catch (Exception ex)
            {
                patient.Height = 0;
            }

            if (Old)
            {
                return patient;
            }

            List<string> columns = new List<string>(){"Name","Old","Address","Height","Weight","Birthday","Id"};
            List<string> values = new List<string>(){patient.Name,patient.Old.ToString(),patient.Address,patient.Height.ToString(),patient.Weight.ToString(),patient.Birthday.ToString("yyyy-MM-dd"),patient.Id};

            Helper.InsertRowToTable(conn, "Patient", columns, values);
            MessageBox.Show("Thêm mới bệnh nhân thành công");

            return patient;

        }


        //private void btnWaitRoomOK_Click(object sender, EventArgs e) // button waitingRoom OK
        //{

        //    Patient patient =null;
        //    string id = comboBoxWaitRoomId.Text.ToString();
        //    string strCommand = "SELECT * FROM Patient WHERE Id ="+id+"";
        //    SqlCommand comm = new SqlCommand(strCommand, Program.conn);
        //    SqlDataReader reader = comm.ExecuteReader();
        //    if (reader.HasRows)
        //    {
        //        reader.Close();
        //        patient = AddNewPatient(Program.conn, id, true);
        //    }
        //    else
        //    {
        //        reader.Close();
        //        patient = AddNewPatient(Program.conn, id, false);
        //    }
     

        //    //Fill to wait table

        //    int index = dataGridView1.Rows.Add();
        //    DataGridViewRow row = dataGridView1.Rows[index];
        //    row.Cells[0].Value = patient.Name;
        //    row.Cells[1].Value = patient.Birthday.ToShortDateString();
        //    row.Cells[2].Value = patient.Address;
        //    row.Cells[3].Value = patient.Symptom;
        //    row.Cells[4].Value = txtBoxWaitRoomDiagnose.Text;
        //    row.Cells[5].Value = (index+1).ToString();

        //    // Save to db PatientToday

        //    List<string> columns = new List<string>() { "Id", "Symptom", "Diagnose", "Medicines","Position" };
        //    int maxPosition = Helper.SearchMaxValueOfTable(Program.conn, "PatientToday", "Id","DESC");
        //    List<string> values = new List<string>() { id, patient.Symptom, txtBoxWaitRoomDiagnose.Text, "",maxPosition.ToString() };
           
        //    Helper.InsertRowToTable(Program.conn, "PatientToday", columns, values);
        //    comboBoxWaitRoomId.Items.Clear();
        //    ClearWaitRoomForm();
        //    InitWaitRoomMySql();


        //}

        //private void comboBoxWaitRoomId_ChangedValue(object sender, EventArgs e)
        //{

        //    string id = comboBoxWaitRoomId.Text.ToString();
        //    if (id.Length == 6)
        //    {

        //        string strCommand = "SELECT * FROM Patient WHERE Id =" + id + "";
        //        SqlCommand comm = new SqlCommand(strCommand, Program.conn);

        //        SqlDataReader reader = comm.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            reader.Read();
        //            FillDataToForm(reader);
        //        }
        //        else // new person
        //        {
        //            ClearWaitRoomForm();
        //        }
        //        reader.Close();
               

        //    }

        //}

        private void FillDataToForm(SqlDataReader reader)
        {
            txtBoxWaitRoomName.Text = reader["Name"].ToString();
            txtBoxWaitRoomAddress.Text = reader["Address"].ToString();
            txtBoxWaitingRoomWeight.Text = reader["Weight"].ToString();
            txtBoxWaitRoomHeight.Text = reader["Height"].ToString();
            dateTimePicker2.Text = reader["Birthday"].ToString();
        }

        private void ClearWaitRoomForm()
        {
            txtBoxWaitingRoomSymptom.Clear();
            txtBoxWaitingRoomWeight.Clear();
            txtBoxWaitRoomAddress.Clear();
            txtBoxWaitRoomName.Clear();
            txtBoxWaitRoomHeight.Text = "";
            dateTimePicker2.ResetText();
            txtBoxWaitRoomDiagnose.Clear();
            
        }

        private void btnWaitRoomCancel_Click(object sender, EventArgs e)
        {
            ClearWaitRoomForm();
        }

        //private void btnWaitRoomContinue_Click(object sender, EventArgs e)
        //{
        //    comboBoxWaitRoomId.Items.Clear();
        //    ClearWaitRoomForm();
        //    InitWaitRoom();
        //}

        private void btnClinicRoomNext_Click(object sender, EventArgs e)
        {
            //get database from waitroom and fill to form
            //FillDataToClinicForm();
        }

        //private void InitWaitingCountForClinicRoom()
        //{

        //    //SqlDependency.Stop(Program.stringConnection);
        //    //SqlDependency.Start(Program.stringConnection);
        //    string strCommand = "SELECT COUNT(Id) FROM PatientToday";
        //    using (SqlCommand comm = Program.conn.CreateCommand())
        //    {
        //        comm.CommandType = CommandType.Text;
        //        comm.CommandText = strCommand;
        //        comm.Notification = null;
        //        //SqlDependency sqlDependency = new SqlDependency(comm);
        //        //sqlDependency.OnChange += new OnChangeEventHandler(sqlDependency_OnChange);
        //        Int32 count = (Int32)comm.ExecuteScalar();

        //    }

        //}

        //private void FillDataToClinicForm()
        //{
        //    int minPosition = Helper.SearchMaxValueOfTable(Program.conn, "PatientToday", "Position", "ASC")-1;
        //    string strCommand = "SELECT * FROM Patient T INNER JOIN PatientToday C ON T.Id = C.Id WHERE C.Position = " + minPosition;

        //    //string strCommand = "Select Id , Symptom, Diagnose Medicines From PatientToday";
        //    using (SqlCommand comm = Program.conn.CreateCommand())
        //    {
        //        comm.CommandType = CommandType.Text;
        //        comm.CommandText = strCommand;
        //        comm.Notification = null;
                
                
        //        using (SqlDataReader reader = comm.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                //txtBoxClinicRoomName.Text = reader.GetString(0);

        //                txtBoxClinicRoomAddress.Text = reader.GetString(2);
        //                txtBoxClinicRoomHeight.Text = reader.GetValue(3).ToString();
        //                txtBoxClinicRoomWeight.Text = reader.GetValue(4).ToString();
        //                dateTimePicker1.Text = reader.GetValue(5).ToString();
        //                lblClinicRoomId.Text = reader.GetString(6);
                        
        //            }
        //        }
        //    }

           

        //}

        //private void sqlDependency_OnChange(object sender ,SqlNotificationEventArgs e)
        //{

        //    if (this.InvokeRequired)
        //    {
        //       // this.label29.Invoke(new MethodInvoker( InitWaitingCountForClinicRoom));
        //    }
        //    else
        //    {
        //        InitWaitingCountForClinicRoom();
        //    }
        //    SqlDependency sqlDependency = sender as SqlDependency;
        //    sqlDependency.OnChange -= new OnChangeEventHandler(sqlDependency_OnChange);

        //}

        //private void btnInputMedicineNewOk_Click(object sender, EventArgs e)
        //{


        //    Medicine medicine = new Medicine();
        //    medicine.Name = txtBoxInputMedicineNewName.Text.Trim();
        //    medicine.InputDay = dateTimePicker3.Value;
        //    medicine.Cost = int.Parse(txtBoxInputMedicineNewCost.Text);
        //    medicine.Count = int.Parse(txtBoxInputMedicineNewCount.Text);
        //    medicine.Id = lblInputMedicineNewId.Text;


        //    List<string> columns = new List<string>() { "Name", "Count", "Cost", "InputDay", "ID"};
        //    List<string> values = new List<string>() { medicine.Name, medicine.Count.ToString(), medicine.Cost.ToString(), medicine.InputDay.ToString("yyyy-MM-dd"), medicine.Id};
        //    Helper.InsertRowToTable(Program.conn, "Medicine", columns, values);
        //    MessageBox.Show("Thêm mới thuốc thành công");

        //    RefreshIdOfNewMedicine();
        //    ClearInputNewMedicine();

        //}

        private void btnInputMedicineNewOk_ClickMySql(object sender, EventArgs e)
        {

            string strCommand = "Select Name From medicine  Where Name = " + Helper.ConvertToSqlString(this.txtBoxInputMedicineNewName.Text);
            MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
            using (MySqlDataReader reader = comm.ExecuteReader())
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

            List<string> columns = new List<string>() { "Name", "Count", "CostIn","CostOut", "InputDay", "ID" };
            List<string> values = new List<string>() { medicine.Name, medicine.Count.ToString(), medicine.CostIn.ToString(),medicine.CostOut.ToString(), medicine.InputDay.ToString("yyyy-MM-dd"), medicine.Id };
            Helper.InsertRowToTable(Program.conn, "Medicine", columns, values);
            MessageBox.Show("Thêm mới thuốc thành công");

            RefreshIdOfNewMedicine();
            ClearInputNewMedicine();

        }

        private void ClearInputNewMedicine()
        {
            txtBoxInputMedicineNewName.Clear();
            txtBoxInputMedicineNewCount.Clear();
            txtBoxInputMedicineNewCostOut.Clear();
            txtBoxInputMedicineNewCostIn.Clear();
        }

        //private void RefreshIdOfNewMedicine()
        //{


        //    string strCommand = " SELECT TOP 1 Id FROM Medicine ORDER BY ID DESC";
        //    SqlCommand comm = new SqlCommand(strCommand, Program.conn);
        //    SqlDataReader reader = comm.ExecuteReader();
        //    reader.Read();
        //    int intTemp;
        //    if (reader.HasRows)
        //    {
        //        string temp = reader.GetString(0);
        //        intTemp = int.Parse(temp);
        //    }
        //    else
        //    {
        //        intTemp = 0;
        //    }
        //    int newId = intTemp + 1;
        //    string strNewID = String.Format("{0:000000}", newId);

        //    lblInputMedicineNewId.Text = strNewID;
        //    reader.Close();


        //}


        private void RefreshIdOfNewMedicine()
        {


            string strCommand = " SELECT ID FROM Medicine ORDER BY ID DESC LIMIT 1";
            //MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
            //MySqlDataReader reader = comm.ExecuteReader();
            IDatabase database = DatabaseFactory.Instance;
            DbDataReader reader = database.ExecuteReader(strCommand, null) as DbDataReader;
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

       

        private void comboBoxInputMedicineName_TextChanged(object sender, EventArgs e)
        {
            //if (comboBoxInputMedicineName.Text.Length > 0)
            //{

            //    string Name = comboBoxInputMedicineName.Text;
            //    string strCommand = "Select * From Medicine Where Name =" + Helper.ConvertToSqlString(Name);
            //    MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
            //    MySqlDataReader reader = comm.ExecuteReader();
            //    if (reader.HasRows)
            //    {
            //        reader.Read();
            //        FillDataToInputMedicineForm(reader);
            //    }
            //    else
            //    {
            //        ClearInputMedicine();
            //    }
            //    reader.Close();
            //}
        }

        //private void comboBoxInputMedicineId_TextChanged(object sender, EventArgs e)
        //{

        //    if(comboBoxInputMedicineId.Text.Length==6)
        //    {

        //        string Id = comboBoxInputMedicineId.Text;
        //        string strCommand = "Select * From Medicine Where Id ="+Id;
        //        SqlCommand comm = new SqlCommand(strCommand, Program.conn);
        //        SqlDataReader reader = comm.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            reader.Read();
        //            FillDataToInputMedicineForm(reader);
        //        }
        //        else
        //        {
        //            ClearInputMedicine();
        //        }
        //        reader.Close();
        //    }

        //}

        //private void comboBoxInputMedicineId_TextChangedMySql(object sender, EventArgs e)
        //{

        //    if (comboBoxInputMedicineId.Text.Length == 6)
        //    {
        //        string Id = comboBoxInputMedicineId.Text;
        //        string strCommand = "Select * From Medicine Where Id =" + Id;
        //        MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
        //        MySqlDataReader reader = comm.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            reader.Read();
        //            FillDataToInputMedicineForm(reader);
        //        }
        //        else
        //        {
        //            ClearInputMedicine();
        //        }
        //        reader.Close();
        //    }

        //}

        private void ClearInputMedicine()
        {
            //comboBoxInputMedicineId.Text = "";
            label34.Text = "";
            comboBoxInputMedicineName.Text = "";
            lblInputMedicineCount.Text = "0";
            txtBoxInputMedicineAdd.Text = "0";
        }

        //private void FillDataToInputMedicineForm(SqlDataReader reader)
        //{
        //    comboBoxInputMedicineName.Text = reader["Name"].ToString();
        //    lblInputMedicineCount.Text = reader["Count"].ToString();

        //}

        private void FillDataToInputMedicineForm(MySqlDataReader reader)
        {
            this.lblInputMedicineCount.Text = reader["Count"].ToString();
            this.label34.Text = reader["Id"].ToString();
            this.textBox3.Text = reader["CostOut"].ToString();
        }

        //private void btnInputMedicineOk_Click(object sender, EventArgs e)
        //{

        //    int count = int.Parse(lblInputMedicineCount.Text) + int.Parse(txtBoxInputMedicineAdd.Text);
        //    string Id = comboBoxInputMedicineId.Text;

        //    string strCommand = "Update Medicine Set Count ="+count.ToString()+" Where Id =" + Id;
        //    SqlCommand comm = new SqlCommand(strCommand, Program.conn);
        //    comm.ExecuteNonQuery();

        //    MessageBox.Show("Thêm thuốc thành công : "+txtBoxInputMedicineAdd.Text+" " + comboBoxInputMedicineName.Text);
        //    ClearInputMedicine();


        //}

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
            MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
            comm.ExecuteNonQuery();

            MessageBox.Show("Thêm thuốc thành công : " + txtBoxInputMedicineAdd.Text + " " + comboBoxInputMedicineName.Text);
            ClearInputMedicine();


        }

        private void btnClinicRoomOKMedicine_Click(object sender, EventArgs e)
        {
            //FillMedicineToTable();
        }

        //private void FillMedicineToTable()
        //{
        //    int index = dataGridView2.Rows.Add();
        //    DataGridViewRow row = dataGridView2.Rows[index];
        //    row.Cells[0].Value = comboBoxClinicRoomMedicines.Text;
        //    row.Cells[1].Value = txtBoxClinicRoomCountMedicine.Text;
        //    row.Cells[2].Value = txtBoxClinicRoomCostMedicine.Text;
        //    int totalOfThisMedicine = int.Parse(txtBoxClinicRoomCountMedicine.Text) * int.Parse(txtBoxClinicRoomCostMedicine.Text);

        //    row.Cells[3].Value = totalOfThisMedicine.ToString();

        //}

        //private void comboBoxClinicRoomMedicines_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string nameOfMedicine = comboBoxClinicRoomMedicines.Text;
        //    string strCommand ="Select Cost From Medicine Where Name ="+Helper.ConvertToSqlString(nameOfMedicine);
        //    SqlCommand comm = new SqlCommand(strCommand,Program.conn);
        //    using (SqlDataReader reader = comm.ExecuteReader())
        //    {
        //        reader.Read();
        //        txtBoxClinicRoomCostMedicine.Text = reader.GetInt32(0).ToString() ;
        //    }

            
        //}

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            if (rowIndex > -1)
            {
                if(dataGridView2[2, rowIndex].Value !=null && dataGridView2[1, rowIndex].Value!=null)
                {
                    try
                    {
                        dataGridView2[3, rowIndex].Value = int.Parse(dataGridView2[2, rowIndex].Value.ToString()) * int.Parse(dataGridView2[1, rowIndex].Value.ToString());
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            int totalMoneyOfPatient = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2[3, i].Value != null)
                {
                    try
                    {
                        totalMoneyOfPatient += int.Parse(dataGridView2[3, i].Value.ToString());

                    }
                    catch (Exception)
                    {
                    }
                }
            }
            label30.Text = totalMoneyOfPatient.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            //RemovePatientFromTablePatientToday();
        }

        //private void RemovePatientFromTablePatientToday()
        //{
        //    string strCommand = "DELETE FROM PatientToday WHERE Id = " +Helper.ConvertToSqlString(lblClinicRoomId.Text);
        //    SqlCommand comm = new SqlCommand(strCommand, Program.conn);
        //    comm.ExecuteNonQuery();
        //    ClearClinicRoomForm();

        //}

        private void ClearClinicRoomForm()
        {
            txtBoxClinicRoomAddress.Clear();
            comboBoxClinicRoomName.Text = "";
            txtBoxClinicRoomDiagnose.Clear();
            txtBoxClinicRoomHeight.Text = "0";
            dateTimePicker1.ResetText();
            txtBoxClinicRoomSymptom.Clear();
            txtBoxClinicRoomWeight.Text = "0";
            lblClinicRoomId.Text = "";
           // comboBoxClinicRoomMedicines.Text = "";
            dataGridView2.Rows.Clear();
            label30.Text = "0";
            
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    comboBoxClinicRoomMedicines.Text = "";
        //    txtBoxClinicRoomCostMedicine.Clear();
        //    txtBoxClinicRoomCountMedicine.Clear();
        //}

        private void button9_Click(object sender, EventArgs e)
        {
            ClearInputNewMedicine();
        }

        private void AddVisitData()
        {
            //Save to history
            List<string> columnsHistory = new List<string>() { "Id", "Symptom", "Diagnose", "Day", "Medicines" };
            string medicines = "";
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                if (i == dataGridView2.Rows.Count - 2)
                {
                    medicines += dataGridView2[0, i].Value + "," + dataGridView2[1, i].Value;
                }
                else
                {
                    medicines += dataGridView2[0, i].Value + "," + dataGridView2[1, i].Value + ",";
                }
            }

            List<string> valuesHistory = new List<string>() { lblClinicRoomId.Text, txtBoxClinicRoomSymptom.Text, txtBoxClinicRoomDiagnose.Text, DateTime.Now.ToString("yyyy-MM-dd"), medicines };
            Helper.InsertRowToTable(Program.conn, "history", columnsHistory, valuesHistory);
        }

        private void ChangeVisitData()
        {
            List<string> columns = new List<string>() { "Name", "Address", "Birthday", "Height", "Weight", "Id" };
            List<string> values = new List<string>() { comboBoxClinicRoomName.Text, txtBoxClinicRoomAddress.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"), txtBoxClinicRoomHeight.Text, txtBoxClinicRoomWeight.Text, lblClinicRoomId.Text };
            Helper.UpdateRowToTable(Program.conn, "patient", columns, values, lblClinicRoomId.Text);

            //Save to history
            List<string> columnsHistory = new List<string>() { "Id", "Symptom", "Diagnose", "Day", "Medicines" };
            string medicines = "";
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                if (i == dataGridView2.Rows.Count - 2)
                {
                    medicines += dataGridView2[0, i].Value + "," + dataGridView2[1, i].Value;
                }
                else
                {
                    medicines += dataGridView2[0, i].Value + "," + dataGridView2[1, i].Value + ",";
                }
            }

            List<string> valuesHistory = new List<string>() { lblClinicRoomId.Text, txtBoxClinicRoomSymptom.Text, txtBoxClinicRoomDiagnose.Text, dateTimePicker5.Value.ToString("yyyy-MM-dd"), medicines };
            Helper.UpdateRowToTable(Program.conn, "history", columnsHistory, valuesHistory, lblClinicRoomId.Text, dateTimePicker5.Value.ToString("yyyy-MM-dd"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.comboBoxClinicRoomName.Text == null || this.comboBoxClinicRoomName.Text == string.Empty)
            {
                MessageBox.Show("Ten Benh Nhan");
                return;
            }

            string originalName = Helper.hasOtherNameForThisId(Program.conn, this.lblClinicRoomId.Text,
                this.comboBoxClinicRoomName.Text);
            if (originalName != null)
            {
                MessageBox.Show("Bạn không thể sửa tên bệnh nhân đã nhập!");
                this.comboBoxClinicRoomName.Text = originalName;
                return;
            }

            bool isPatientExist = Helper.checkPatientExists(Program.conn, this.lblClinicRoomId.Text);

            if (!isPatientExist)
            {
                List<string> columns = new List<string>() {"Name", "Address", "Birthday", "Height", "Weight", "Id"};
                List<string> values = new List<string>()
                {
                    comboBoxClinicRoomName.Text,
                    txtBoxClinicRoomAddress.Text,
                    dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                    txtBoxClinicRoomHeight.Text,
                    txtBoxClinicRoomWeight.Text,
                    lblClinicRoomId.Text
                };
                Helper.InsertRowToTable(Program.conn, "patient", columns, values);
            }

            if (!Helper.checkVisitExists(Program.conn, this.lblClinicRoomId.Text, this.dateTimePicker5.Value.ToString("yyyy-MM-dd")))
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            dataGridView2.Rows.Clear();
            //txtBoxClinicRoomAddress.Text = string.Empty;
            //txtBoxClinicRoomHeight.Text = "0";
            //txtBoxClinicRoomWeight.Text = "0";
            //txtBoxClinicRoomSymptom.Text = string.Empty;
            //txtBoxClinicRoomDiagnose.Text = string.Empty;

            string findingName = comboBoxClinicRoomName.Text;
            string Id = lblClinicRoomId.Text;
            string strCommandMain = "";
            //
            // Check find level2 if (both Name and ID match)
            string strCommand = "Select Name , Id From patient  Where Name = " + Helper.ConvertToSqlString(findingName) + " and Id =" + Helper.ConvertToSqlString(Id);
            MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
            using (MySqlDataReader reader = comm.ExecuteReader())
            {
                reader.Read();
                if (reader.HasRows == true && !string.IsNullOrEmpty(findingName)) //level 2
                {
                    strCommandMain = "SELECT * FROM patient p RIGHT JOIN history h ON p.Id = h.Id WHERE h.Id = " + Id;
                }
                else // level 1 
                {
                    if (dateTimePicker5.Value.Date <= DateTime.Now.Date)
                    {
                        if (string.IsNullOrEmpty(findingName)) //name = null --> find due to date
                        {
                            strCommandMain =
                                "SELECT * FROM patient p RIGHT JOIN history h ON p.Id = h.Id WHERE h.Day = " +
                                Helper.ConvertToSqlString(dateTimePicker5.Value.ToString("yyyy-MM-dd"));
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


            MySqlCommand comm2 = new MySqlCommand(strCommandMain, Program.conn);
            using (MySqlDataReader reader2 = comm2.ExecuteReader())
            {
                while (reader2.Read())
                {
                    int index = dataGridView3.Rows.Add();
                    DataGridViewRow row = dataGridView3.Rows[index];
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
            MySqlCommand newCommand = null;
            MySqlDataReader newReader = null;
            int daySum = 0;
            foreach (DataGridViewRow row in this.dataGridView3.Rows)
            {
                int total = 0;
                string[] medicineAndCount = row.Cells[7].Value.ToString().Split(',');

                for (int i = 0; i < medicineAndCount.Length; i = i + 2)
                {
                    askCostOut = "Select CostOut From Medicine Where Name =" + Helper.ConvertToSqlString(medicineAndCount[i]);
                    newCommand = new MySqlCommand(askCostOut, Program.conn);
                    newReader = newCommand.ExecuteReader();
                    newReader.Read();
                    try
                    {
                        total += int.Parse(medicineAndCount[i + 1])* (int)newReader.GetValue(0);
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
            newReader = null;
            newCommand = null;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                RefreshMedicineLess100();
            }
        }

        private void RefreshMedicineLess100()
        {
            dataGridView4.Rows.Clear();
            string strCommand = "Select * From Medicine Where Count < 100";
            MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
            using (MySqlDataReader reader = comm.ExecuteReader())
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

        private void dataGridView2_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex>-1) // change name of medicine
            {
                if (dataGridView2[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    string nameOfMedicine = dataGridView2[e.ColumnIndex, e.RowIndex].Value.ToString();
                    string strCommand = "Select CostOut From Medicine Where Name =" + Helper.ConvertToSqlString(nameOfMedicine);
                    MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
                    using (MySqlDataReader reader = comm.ExecuteReader())
                    {
                        reader.Read();
                        string temp = reader.GetValue(0).ToString();
                        reader.Close();
                        dataGridView2[2, e.RowIndex].Value = temp;
                    }
                }
            }
            if (e.ColumnIndex == 1 && e.RowIndex > -1) // change count of medicine
            {
                if (dataGridView2[e.ColumnIndex, e.RowIndex].Value != null && dataGridView2[2, e.RowIndex].Value!=null)
                {
                    try
                    {
                        int count = int.Parse(dataGridView2[e.ColumnIndex, e.RowIndex].Value.ToString());
                        int cost = int.Parse(dataGridView2[2, e.RowIndex].Value.ToString()) * count;
                        dataGridView2[3, e.RowIndex].Value = cost.ToString();
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
                if (dataGridView2[e.ColumnIndex, e.RowIndex].Value != null )
                {
                    for (int i = 0; i < dataGridView2.Rows.Count-1; i++)
                    {
                        try
                        {
                            total += int.Parse(dataGridView2[3, i].Value.ToString());
                        }
                        catch (Exception)
                        {
                        }
                    }
                    

                }
                label30.Text = total.ToString();
            }
        }

        private void comboBoxClinicRoomName_SelectedValueChanged(object sender, EventArgs e)
        {
            //string strCommand = "Select * From Patient Where Name = " + Helper.ConvertToSqlString(comboBoxClinicRoomName.Text);
            string strCommand = "Select * From patient p RIGHT JOIN history h ON p.Id = h.Id Where p.Name =" + Helper.ConvertToSqlString(comboBoxClinicRoomName.Text);
            MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
            
            using (MySqlDataReader reader = comm.ExecuteReader())
            {
                reader.Read();
                FillInfoToClinicForm(reader);
                reader.Close();

            }
        }

        private void FillInfoToClinicForm(MySqlDataReader reader)
        {
            lblClinicRoomId.Text = reader["Id"].ToString();
            txtBoxClinicRoomAddress.Text = reader["Address"].ToString();
            txtBoxClinicRoomWeight.Text = reader["Weight"].ToString();
            txtBoxClinicRoomHeight.Text = reader["Height"].ToString();
            dateTimePicker1.Text = reader["Birthday"].ToString();
            dateTimePicker5.Text = reader["Day"].ToString(); //ngay kham
            txtBoxClinicRoomSymptom.Text = reader["Symptom"].ToString();
            txtBoxClinicRoomDiagnose.Text = reader["Diagnose"].ToString();
        }
            


        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string Id = dataGridView3[0, e.RowIndex].Value.ToString();
            string strCommand = "SELECT * FROM patient p RIGHT JOIN history h ON p.Id = h.Id WHERE h.Id = " 
                + Id + " AND h.Day = " + Helper.ConvertToSqlString(this.dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString());

            MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);

            using (MySqlDataReader reader = comm.ExecuteReader())
            {
                reader.Read();
                if (!reader.HasRows) return;

                string medicines = reader.GetString(9);
                string name = reader["Name"].ToString();
                reader.Close();

                comboBoxClinicRoomName.Text = name; // this will fill all infos via comboBox name changed event

                string[] medicineAndCount = new string[] { };
                if (!string.IsNullOrEmpty(medicines))
                {
                    medicineAndCount = medicines.Split(',');
                }

                for (int i = 0; i < medicineAndCount.Length; i = i + 2)
                {
                    if (this.dataGridView2.RowCount <= i/2 + 1)
                    {
                        this.dataGridView2.Rows.Add();
                    }
                    this.dataGridView2.Rows[i/2].Cells[0].Value = medicineAndCount[i];
                    this.dataGridView2.Rows[i/2].Cells[1].Value = medicineAndCount[i + 1];
                }

            }
        }

        private void comboBoxInputMedicineName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxInputMedicineName.Text.Length > 0)
            {

                string Name = comboBoxInputMedicineName.Text;
                string strCommand = "Select * From Medicine Where Name =" + Helper.ConvertToSqlString(Name);
                MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
                MySqlDataReader reader = comm.ExecuteReader();
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

        private void button3_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            int Authority =0;
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

            List<string> columns = new List<string>() { "Username", "Password1", "Authority"};
            List<string> values = new List<string>() { username, Helper.Encrypt(password), Authority.ToString()};

            Clinic.Helpers.Helper.InsertRowToTable(Program.conn, "ClinicUser", columns, values);
            MessageBox.Show("Thêm mới nhân viên thành công");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //init id
            int intId = Helper.SearchMaxValueOfTable( "Patient", "Id", "DESC");
            string ID = String.Format("{0:000000}", intId);
            lblClinicRoomId.Text = ID;
        }














        
    }
}
