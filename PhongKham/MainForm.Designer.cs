using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using Clinic;
namespace PhongKham
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange1 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange2 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange3 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange4 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange5 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.Label label26;
            this.circularProgress1 = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.MainTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Show1Record = new System.Windows.Forms.CheckBox();
            this.ShowMedicines = new System.Windows.Forms.CheckBox();
            this.ShowBigForm = new System.Windows.Forms.CheckBox();
            this.checkBoxHen = new System.Windows.Forms.CheckBox();
            this.buttonList = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dateTimePickerHen = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonPutIn = new System.Windows.Forms.Button();
            this.dataGridViewMedicine = new System.Windows.Forms.DataGridView();
            this.Column18 = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.Column19 = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.Column20 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column21 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewMedicinesId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMedicinesHDSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGridViewSearchValue = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNamePatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNgayKham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSymtom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNhietDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHuyetAp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiagno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchValueMedicines = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTongTien = new System.Windows.Forms.Label();
            this.txtBoxClinicRoomSymptom = new System.Windows.Forms.TextBox();
            this.textBoxClinicPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBoxClinicRoomDiagnose = new System.Windows.Forms.TextBox();
            this.Calendar = new System.Windows.Forms.TabPage();
            this.panelCalendarDate = new System.Windows.Forms.Panel();
            this.dataGridViewCalendar = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKhamVaXoa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panelCalendar = new System.Windows.Forms.Panel();
            this.tabPageLich = new System.Windows.Forms.Calendar.MonthView();
            this.calendar1 = new System.Windows.Forms.Calendar.Calendar();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.redTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yellowTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherColorTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPagenhapthuoc = new System.Windows.Forms.TabPage();
            this.buttonServicesCancel = new System.Windows.Forms.Button();
            this.buttonServicesOK = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.btnInputMedicineNewOk = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btnInputMedicineOk = new System.Windows.Forms.Button();
            this.tabPageTools = new System.Windows.Forms.TabPage();
            this.textBoxNameDoctor = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxKethuoc = new System.Windows.Forms.CheckBox();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.Column22 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column23 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column24 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column25 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column26 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.buttonCreateUser = new System.Windows.Forms.Button();
            this.checkBoxNhapThuoc = new System.Windows.Forms.CheckBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPagePrint = new System.Windows.Forms.TabPage();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.patternToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagonalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timescaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.minutesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.minutesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.minutesToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageAlignmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.Column7 = new System.Windows.Forms.DataGridViewColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnWaitRoomContinue = new System.Windows.Forms.Button();
            this.btnWaitRoomCancel = new System.Windows.Forms.Button();
            this.btnWaitRoomOK = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doanhThuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tủThuốcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cácDịchVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mởRộngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loaiKhamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmLoạiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxLoaiKham = new System.Windows.Forms.ComboBox();
            this.CoTableLayoutPanel1 = new Clinic.CoTableLayoutPanel();
            this.label28 = new System.Windows.Forms.Label();
            this.lblClinicRoomId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxClinicNhietDo = new System.Windows.Forms.TextBox();
            this.dateTimePickerBirthDay = new System.Windows.Forms.DateTimePicker();
            this.txtBoxClinicRoomAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.comboBoxClinicRoomName = new System.Windows.Forms.TextBox();
            this.buttonClinicCreateNew = new System.Windows.Forms.Button();
            this.buttonClinicClear = new System.Windows.Forms.Button();
            this.txtBoxClinicRoomWeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxClinicRoomHeight = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.dateTimePickerNgayKham = new System.Windows.Forms.DateTimePicker();
            this.label30 = new System.Windows.Forms.Label();
            this.textBoxHuyetAp = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.labelTuoi = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.CoTableLayoutPanel7 = new Clinic.CoTableLayoutPanel();
            this.labelServicesID = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.textBoxServices = new System.Windows.Forms.TextBox();
            this.textBoxServicesCost = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.textBoxAdminOfService = new System.Windows.Forms.TextBox();
            this.CoTableLayoutPanel4 = new Clinic.CoTableLayoutPanel();
            this.label23 = new System.Windows.Forms.Label();
            this.txtBoxInputMedicineAdd = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblInputMedicineCount = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.dateTimePicker6 = new System.Windows.Forms.DateTimePicker();
            this.label34 = new System.Windows.Forms.Label();
            this.comboBoxInputMedicineName = new System.Windows.Forms.ComboBox();
            this.CoTableLayoutPanel3 = new Clinic.CoTableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.lblInputMedicineNewId = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtBoxInputMedicineNewName = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtBoxInputMedicineNewCount = new System.Windows.Forms.TextBox();
            this.txtBoxInputMedicineNewCostOut = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBoxInputMedicineNewCostIn = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.textBoxMedicineHdsd = new System.Windows.Forms.TextBox();
            this.CoTableLayoutPanel6 = new Clinic.CoTableLayoutPanel();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.textBoxBackupSource = new System.Windows.Forms.TextBox();
            this.textBoxBackupTarget = new System.Windows.Forms.TextBox();
            this.textBoxBackupTimeAuto = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBoxAutoCopy = new System.Windows.Forms.CheckBox();
            this.label38 = new System.Windows.Forms.Label();
            this.CoTableLayoutPanel5 = new Clinic.CoTableLayoutPanel();
            this.textBoxNameClinic = new System.Windows.Forms.TextBox();
            this.textBoxAddressClinic = new System.Windows.Forms.TextBox();
            this.textBoxAdviceClinic = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.labelSdt = new System.Windows.Forms.Label();
            this.textBoxSDT = new System.Windows.Forms.TextBox();
            this.CoTableLayoutPanel2 = new Clinic.CoTableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxWaitRoomId = new System.Windows.Forms.ComboBox();
            this.txtBoxWaitRoomHeight = new System.Windows.Forms.TextBox();
            this.txtBoxWaitRoomDiagnose = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lblWaitRoomName = new System.Windows.Forms.Label();
            this.txtBoxWaitRoomName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBoxWaitingRoomSymptom = new System.Windows.Forms.TextBox();
            this.lblWaitRoomBirthday = new System.Windows.Forms.Label();
            this.txtBoxWaitingRoomWeight = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.lblWaitRoomAddress = new System.Windows.Forms.Label();
            this.txtBoxWaitRoomAddress = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            this.MainTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMedicine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchValue)).BeginInit();
            this.Calendar.SuspendLayout();
            this.panelCalendarDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCalendar)).BeginInit();
            this.panelCalendar.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPagenhapthuoc.SuspendLayout();
            this.tabPageTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.tabPagePrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.CoTableLayoutPanel1.SuspendLayout();
            this.CoTableLayoutPanel7.SuspendLayout();
            this.CoTableLayoutPanel4.SuspendLayout();
            this.CoTableLayoutPanel3.SuspendLayout();
            this.CoTableLayoutPanel6.SuspendLayout();
            this.CoTableLayoutPanel5.SuspendLayout();
            this.CoTableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // circularProgress1
            // 
            this.circularProgress1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.circularProgress1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.circularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress1.FocusCuesEnabled = false;
            this.circularProgress1.Location = new System.Drawing.Point(454, 219);
            this.circularProgress1.Name = "circularProgress1";
            this.circularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut;
            this.circularProgress1.ProgressColor = System.Drawing.SystemColors.ControlDarkDark;
            this.circularProgress1.ProgressTextVisible = true;
            this.circularProgress1.Size = new System.Drawing.Size(301, 70);
            this.circularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress1.TabIndex = 0;
            // 
            // MainTab
            // 
            this.MainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTab.Controls.Add(this.tabPage1);
            this.MainTab.Controls.Add(this.Calendar);
            this.MainTab.Controls.Add(this.tabPagenhapthuoc);
            this.MainTab.Controls.Add(this.tabPageTools);
            this.MainTab.Controls.Add(this.tabPagePrint);
            this.MainTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTab.Location = new System.Drawing.Point(0, 27);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(1375, 680);
            this.MainTab.TabIndex = 0;
            this.MainTab.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Show1Record);
            this.tabPage1.Controls.Add(this.circularProgress1);
            this.tabPage1.Controls.Add(this.ShowMedicines);
            this.tabPage1.Controls.Add(this.ShowBigForm);
            this.tabPage1.Controls.Add(this.checkBoxHen);
            this.tabPage1.Controls.Add(this.buttonList);
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.dateTimePickerHen);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.buttonPutIn);
            this.tabPage1.Controls.Add(this.dataGridViewMedicine);
            this.tabPage1.Controls.Add(this.buttonSearch);
            this.tabPage1.Controls.Add(this.dataGridViewSearchValue);
            this.tabPage1.Controls.Add(this.labelTongTien);
            this.tabPage1.Controls.Add(this.CoTableLayoutPanel1);
            this.tabPage1.Controls.Add(this.txtBoxClinicRoomSymptom);
            this.tabPage1.Controls.Add(this.textBoxClinicPhone);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label44);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtBoxClinicRoomDiagnose);
            this.tabPage1.Controls.Add(this.comboBoxLoaiKham);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1367, 649);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "";
            this.tabPage1.Text = "Phòng Khám";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Show1Record
            // 
            this.Show1Record.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Show1Record.AutoSize = true;
            this.Show1Record.Checked = true;
            this.Show1Record.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Show1Record.Location = new System.Drawing.Point(1211, 67);
            this.Show1Record.Name = "Show1Record";
            this.Show1Record.Size = new System.Drawing.Size(138, 22);
            this.Show1Record.TabIndex = 49;
            this.Show1Record.Text = "Chỉ 1 Record /bn";
            this.Show1Record.UseVisualStyleBackColor = true;
            // 
            // ShowMedicines
            // 
            this.ShowMedicines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowMedicines.AutoSize = true;
            this.ShowMedicines.Checked = true;
            this.ShowMedicines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowMedicines.Location = new System.Drawing.Point(1211, 39);
            this.ShowMedicines.Name = "ShowMedicines";
            this.ShowMedicines.Size = new System.Drawing.Size(103, 22);
            this.ShowMedicines.TabIndex = 48;
            this.ShowMedicines.Text = "Hiện Thuốc";
            this.ShowMedicines.UseVisualStyleBackColor = true;
            // 
            // ShowBigForm
            // 
            this.ShowBigForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowBigForm.AutoSize = true;
            this.ShowBigForm.Checked = true;
            this.ShowBigForm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowBigForm.Location = new System.Drawing.Point(1211, 11);
            this.ShowBigForm.Name = "ShowBigForm";
            this.ShowBigForm.Size = new System.Drawing.Size(126, 22);
            this.ShowBigForm.TabIndex = 47;
            this.ShowBigForm.Text = "Hiện Form Lớn";
            this.ShowBigForm.UseVisualStyleBackColor = true;
            // 
            // checkBoxHen
            // 
            this.checkBoxHen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHen.AutoSize = true;
            this.checkBoxHen.Location = new System.Drawing.Point(1228, 463);
            this.checkBoxHen.Name = "checkBoxHen";
            this.checkBoxHen.Size = new System.Drawing.Size(121, 22);
            this.checkBoxHen.TabIndex = 46;
            this.checkBoxHen.Text = "Hẹn Tái Khám";
            this.checkBoxHen.UseVisualStyleBackColor = true;
            this.checkBoxHen.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // buttonList
            // 
            this.buttonList.Location = new System.Drawing.Point(9, 205);
            this.buttonList.Name = "buttonList";
            this.buttonList.Size = new System.Drawing.Size(29, 234);
            this.buttonList.TabIndex = 45;
            this.buttonList.Text = "Danh   Sách ";
            this.buttonList.UseVisualStyleBackColor = true;
            this.buttonList.MouseHover += new System.EventHandler(this.buttonList_MouseHover);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Lime;
            this.pictureBox2.Location = new System.Drawing.Point(9, 445);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1340, 10);
            this.pictureBox2.TabIndex = 44;
            this.pictureBox2.TabStop = false;
            // 
            // dateTimePickerHen
            // 
            this.dateTimePickerHen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerHen.Location = new System.Drawing.Point(1004, 461);
            this.dateTimePickerHen.Name = "dateTimePickerHen";
            this.dateTimePickerHen.Size = new System.Drawing.Size(200, 24);
            this.dateTimePickerHen.TabIndex = 42;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.Image = global::Clinic.Properties.Resources.print_printer;
            this.pictureBox1.Location = new System.Drawing.Point(1222, 621);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1104, 488);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 24);
            this.label9.TabIndex = 37;
            this.label9.Text = "Total:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonPutIn
            // 
            this.buttonPutIn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonPutIn.AutoSize = true;
            this.buttonPutIn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonPutIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPutIn.Location = new System.Drawing.Point(1222, 557);
            this.buttonPutIn.Name = "buttonPutIn";
            this.buttonPutIn.Size = new System.Drawing.Size(127, 62);
            this.buttonPutIn.TabIndex = 36;
            this.buttonPutIn.Text = " Nhập";
            this.buttonPutIn.UseVisualStyleBackColor = false;
            this.buttonPutIn.Click += new System.EventHandler(this.buttonPutIn_Click);
            // 
            // dataGridViewMedicine
            // 
            this.dataGridViewMedicine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMedicine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMedicine.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewMedicine.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridViewMedicine.ColumnHeadersHeight = 40;
            this.dataGridViewMedicine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column21,
            this.dataGridViewMedicinesId,
            this.ColumnMedicinesHDSD});
            this.dataGridViewMedicine.GridColor = System.Drawing.SystemColors.MenuHighlight;
            this.dataGridViewMedicine.Location = new System.Drawing.Point(8, 535);
            this.dataGridViewMedicine.Name = "dataGridViewMedicine";
            this.dataGridViewMedicine.Size = new System.Drawing.Size(1090, 114);
            this.dataGridViewMedicine.TabIndex = 35;
            this.dataGridViewMedicine.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMedicine_CellContentClick);
            this.dataGridViewMedicine.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMedicine_CellValueChanged_1);
            this.dataGridViewMedicine.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridViewMedicine_RowsRemoved);
            this.dataGridViewMedicine.Leave += new System.EventHandler(this.dataGridViewMedicine_Leave);
            this.dataGridViewMedicine.MouseLeave += new System.EventHandler(this.dataGridViewMedicine_MouseLeave);
            // 
            // Column18
            // 
            this.Column18.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Column18.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Column18.DisplayMember = "Text";
            this.Column18.DropDownHeight = 106;
            this.Column18.DropDownWidth = 121;
            this.Column18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column18.HeaderText = "Tên Thuốc";
            this.Column18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Column18.IntegralHeight = false;
            this.Column18.ItemHeight = 15;
            this.Column18.Name = "Column18";
            this.Column18.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column18.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // Column19
            // 
            this.Column19.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.Column19.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.Column19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column19.FillWeight = 75F;
            this.Column19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Column19.HeaderText = "Số lượng";
            this.Column19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Column19.Name = "Column19";
            this.Column19.PasswordChar = '\0';
            this.Column19.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Column19.Text = "";
            // 
            // Column20
            // 
            this.Column20.FillWeight = 75F;
            this.Column20.HeaderText = "Giá";
            this.Column20.Name = "Column20";
            this.Column20.ReadOnly = true;
            this.Column20.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // Column21
            // 
            this.Column21.HeaderText = "Tiền";
            this.Column21.Name = "Column21";
            this.Column21.ReadOnly = true;
            this.Column21.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // dataGridViewMedicinesId
            // 
            this.dataGridViewMedicinesId.HeaderText = "Id";
            this.dataGridViewMedicinesId.Name = "dataGridViewMedicinesId";
            this.dataGridViewMedicinesId.Visible = false;
            // 
            // ColumnMedicinesHDSD
            // 
            this.ColumnMedicinesHDSD.HeaderText = "Cách dùng";
            this.ColumnMedicinesHDSD.Name = "ColumnMedicinesHDSD";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.Location = new System.Drawing.Point(1222, 108);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(127, 93);
            this.buttonSearch.TabIndex = 34;
            this.buttonSearch.Text = "Tìm";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // dataGridViewSearchValue
            // 
            this.dataGridViewSearchValue.AllowUserToAddRows = false;
            this.dataGridViewSearchValue.AllowUserToDeleteRows = false;
            this.dataGridViewSearchValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSearchValue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSearchValue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewSearchValue.ColumnHeadersHeight = 40;
            this.dataGridViewSearchValue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnNamePatient,
            this.ColumnNgaySinh,
            this.ColumnNgayKham,
            this.ColumnAddress,
            this.ColumnSymtom,
            this.ColumnNhietDo,
            this.ColumnHuyetAp,
            this.ColumnDiagno,
            this.ColumnSearchValueMedicines});
            this.dataGridViewSearchValue.Location = new System.Drawing.Point(57, 205);
            this.dataGridViewSearchValue.Name = "dataGridViewSearchValue";
            this.dataGridViewSearchValue.ReadOnly = true;
            this.dataGridViewSearchValue.Size = new System.Drawing.Size(1292, 234);
            this.dataGridViewSearchValue.TabIndex = 33;
            this.dataGridViewSearchValue.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSearchValue_CellDoubleClick);
            // 
            // ColumnID
            // 
            this.ColumnID.FillWeight = 5.581299F;
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            // 
            // ColumnNamePatient
            // 
            this.ColumnNamePatient.FillWeight = 12.63171F;
            this.ColumnNamePatient.HeaderText = "Tên";
            this.ColumnNamePatient.Name = "ColumnNamePatient";
            this.ColumnNamePatient.ReadOnly = true;
            // 
            // ColumnNgaySinh
            // 
            this.ColumnNgaySinh.FillWeight = 8.930079F;
            this.ColumnNgaySinh.HeaderText = "Ngày Sinh";
            this.ColumnNgaySinh.Name = "ColumnNgaySinh";
            this.ColumnNgaySinh.ReadOnly = true;
            // 
            // ColumnNgayKham
            // 
            this.ColumnNgayKham.FillWeight = 8.930079F;
            this.ColumnNgayKham.HeaderText = "Ngày Khám";
            this.ColumnNgayKham.Name = "ColumnNgayKham";
            this.ColumnNgayKham.ReadOnly = true;
            // 
            // ColumnAddress
            // 
            this.ColumnAddress.FillWeight = 15.62764F;
            this.ColumnAddress.HeaderText = "Địa chỉ";
            this.ColumnAddress.Name = "ColumnAddress";
            this.ColumnAddress.ReadOnly = true;
            // 
            // ColumnSymtom
            // 
            this.ColumnSymtom.FillWeight = 12.63171F;
            this.ColumnSymtom.HeaderText = "Triệu chứng";
            this.ColumnSymtom.Name = "ColumnSymtom";
            this.ColumnSymtom.ReadOnly = true;
            // 
            // ColumnNhietDo
            // 
            this.ColumnNhietDo.FillWeight = 12.63171F;
            this.ColumnNhietDo.HeaderText = "Nhiệt độ";
            this.ColumnNhietDo.Name = "ColumnNhietDo";
            this.ColumnNhietDo.ReadOnly = true;
            // 
            // ColumnHuyetAp
            // 
            this.ColumnHuyetAp.FillWeight = 38.06841F;
            this.ColumnHuyetAp.HeaderText = "Huyết Áp";
            this.ColumnHuyetAp.Name = "ColumnHuyetAp";
            this.ColumnHuyetAp.ReadOnly = true;
            // 
            // ColumnDiagno
            // 
            this.ColumnDiagno.FillWeight = 463.9643F;
            this.ColumnDiagno.HeaderText = "Chẩn đoán";
            this.ColumnDiagno.Name = "ColumnDiagno";
            this.ColumnDiagno.ReadOnly = true;
            // 
            // ColumnSearchValueMedicines
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSearchValueMedicines.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnSearchValueMedicines.FillWeight = 22.3252F;
            this.ColumnSearchValueMedicines.HeaderText = "Thuốc đã dùng";
            this.ColumnSearchValueMedicines.Name = "ColumnSearchValueMedicines";
            this.ColumnSearchValueMedicines.ReadOnly = true;
            // 
            // labelTongTien
            // 
            this.labelTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTongTien.AutoSize = true;
            this.labelTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTongTien.Location = new System.Drawing.Point(1119, 512);
            this.labelTongTien.Name = "labelTongTien";
            this.labelTongTien.Size = new System.Drawing.Size(20, 24);
            this.labelTongTien.TabIndex = 30;
            this.labelTongTien.Text = "0";
            this.labelTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelTongTien.Click += new System.EventHandler(this.label30_Click);
            // 
            // txtBoxClinicRoomSymptom
            // 
            this.txtBoxClinicRoomSymptom.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtBoxClinicRoomSymptom.Location = new System.Drawing.Point(110, 464);
            this.txtBoxClinicRoomSymptom.Name = "txtBoxClinicRoomSymptom";
            this.txtBoxClinicRoomSymptom.Size = new System.Drawing.Size(491, 24);
            this.txtBoxClinicRoomSymptom.TabIndex = 22;
            // 
            // textBoxClinicPhone
            // 
            this.textBoxClinicPhone.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBoxClinicPhone.Location = new System.Drawing.Point(702, 498);
            this.textBoxClinicPhone.Name = "textBoxClinicPhone";
            this.textBoxClinicPhone.Size = new System.Drawing.Size(173, 24);
            this.textBoxClinicPhone.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 470);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Triệu chứng:";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(637, 496);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(42, 18);
            this.label44.TabIndex = 27;
            this.label44.Text = "SĐT:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 501);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Chẩn đoán:";
            // 
            // txtBoxClinicRoomDiagnose
            // 
            this.txtBoxClinicRoomDiagnose.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBoxClinicRoomDiagnose.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBoxClinicRoomDiagnose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtBoxClinicRoomDiagnose.Location = new System.Drawing.Point(110, 498);
            this.txtBoxClinicRoomDiagnose.Name = "txtBoxClinicRoomDiagnose";
            this.txtBoxClinicRoomDiagnose.Size = new System.Drawing.Size(491, 24);
            this.txtBoxClinicRoomDiagnose.TabIndex = 23;

            // 
            // Calendar
            // 
            this.Calendar.Controls.Add(this.panelCalendarDate);
            this.Calendar.Controls.Add(this.panelCalendar);
            this.Calendar.Location = new System.Drawing.Point(4, 27);
            this.Calendar.Name = "Calendar";
            this.Calendar.Padding = new System.Windows.Forms.Padding(3);
            this.Calendar.Size = new System.Drawing.Size(1367, 649);
            this.Calendar.TabIndex = 5;
            this.Calendar.Text = "Lịch";
            this.Calendar.UseVisualStyleBackColor = true;
            // 
            // panelCalendarDate
            // 
            this.panelCalendarDate.BackColor = System.Drawing.Color.LightBlue;
            this.panelCalendarDate.Controls.Add(this.dataGridViewCalendar);
            this.panelCalendarDate.Controls.Add(this.expandableSplitter1);
            this.panelCalendarDate.Controls.Add(this.calendar1);
            this.panelCalendarDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCalendarDate.Location = new System.Drawing.Point(213, 3);
            this.panelCalendarDate.Name = "panelCalendarDate";
            this.panelCalendarDate.Size = new System.Drawing.Size(1151, 643);
            this.panelCalendarDate.TabIndex = 1;
            // 
            // dataGridViewCalendar
            // 
            this.dataGridViewCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCalendar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Patient,
            this.phone,
            this.sick,
            this.dataGridViewButtonColumn1,
            this.ColumnKhamVaXoa});
            this.dataGridViewCalendar.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridViewCalendar.Location = new System.Drawing.Point(502, 0);
            this.dataGridViewCalendar.Name = "dataGridViewCalendar";
            this.dataGridViewCalendar.Size = new System.Drawing.Size(649, 643);
            this.dataGridViewCalendar.TabIndex = 3;
            this.dataGridViewCalendar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCalendar_CellClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 50;
            // 
            // Patient
            // 
            this.Patient.HeaderText = "Họ và Tên";
            this.Patient.Name = "Patient";
            this.Patient.ReadOnly = true;
            this.Patient.Width = 150;
            // 
            // phone
            // 
            this.phone.HeaderText = "SĐT";
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            this.phone.Width = 80;
            // 
            // sick
            // 
            this.sick.HeaderText = "Bệnh";
            this.sick.Name = "sick";
            this.sick.ReadOnly = true;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "Bác sĩ khám";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewButtonColumn1.Width = 150;
            // 
            // ColumnKhamVaXoa
            // 
            this.ColumnKhamVaXoa.HeaderText = "Khám Và Xóa";
            this.ColumnKhamVaXoa.Name = "ColumnKhamVaXoa";
            this.ColumnKhamVaXoa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnKhamVaXoa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.ExpandableControl = this.panelCalendar;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripDarkColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(236)))), ((int)(((byte)(248)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(140)))), ((int)(((byte)(72)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(136)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(236)))), ((int)(((byte)(248)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(0, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.expandableSplitter1.Size = new System.Drawing.Size(3, 643);
            this.expandableSplitter1.TabIndex = 0;
            this.expandableSplitter1.TabStop = false;
            // 
            // panelCalendar
            // 
            this.panelCalendar.BackColor = System.Drawing.Color.Gainsboro;
            this.panelCalendar.Controls.Add(this.tabPageLich);
            this.panelCalendar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelCalendar.Location = new System.Drawing.Point(3, 3);
            this.panelCalendar.Name = "panelCalendar";
            this.panelCalendar.Size = new System.Drawing.Size(210, 643);
            this.panelCalendar.TabIndex = 0;
            // 
            // tabPageLich
            // 
            this.tabPageLich.ArrowsColor = System.Drawing.SystemColors.Window;
            this.tabPageLich.ArrowsSelectedColor = System.Drawing.Color.Gold;
            this.tabPageLich.DayBackgroundColor = System.Drawing.Color.Empty;
            this.tabPageLich.DayGrayedText = System.Drawing.SystemColors.GrayText;
            this.tabPageLich.DaySelectedBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.tabPageLich.DaySelectedColor = System.Drawing.SystemColors.WindowText;
            this.tabPageLich.DaySelectedTextColor = System.Drawing.SystemColors.HighlightText;
            this.tabPageLich.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabPageLich.ItemPadding = new System.Windows.Forms.Padding(2);
            this.tabPageLich.Location = new System.Drawing.Point(0, 0);
            this.tabPageLich.MaxSelectionCount = 35;
            this.tabPageLich.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPageLich.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.tabPageLich.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPageLich.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.tabPageLich.Name = "tabPageLich";
            this.tabPageLich.Size = new System.Drawing.Size(208, 643);
            this.tabPageLich.TabIndex = 3;
            this.tabPageLich.Text = "monthView1";
            this.tabPageLich.TodayBorderColor = System.Drawing.Color.Maroon;
            this.tabPageLich.SelectionChanged += new System.EventHandler(this.monthView1_SelectionChanged);
            // 
            // calendar1
            // 
            this.calendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calendar1.ContextMenuStrip = this.contextMenuStrip1;
            this.calendar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            calendarHighlightRange1.DayOfWeek = System.DayOfWeek.Monday;
            calendarHighlightRange1.EndTime = System.TimeSpan.Parse("19:00:00");
            calendarHighlightRange1.StartTime = System.TimeSpan.Parse("07:00:00");
            calendarHighlightRange2.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange2.EndTime = System.TimeSpan.Parse("19:00:00");
            calendarHighlightRange2.StartTime = System.TimeSpan.Parse("07:00:00");
            calendarHighlightRange3.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange3.EndTime = System.TimeSpan.Parse("19:00:00");
            calendarHighlightRange3.StartTime = System.TimeSpan.Parse("07:00:00");
            calendarHighlightRange4.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange4.EndTime = System.TimeSpan.Parse("19:00:00");
            calendarHighlightRange4.StartTime = System.TimeSpan.Parse("07:00:00");
            calendarHighlightRange5.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange5.EndTime = System.TimeSpan.Parse("19:00:00");
            calendarHighlightRange5.StartTime = System.TimeSpan.Parse("07:00:00");
            this.calendar1.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange1,
        calendarHighlightRange2,
        calendarHighlightRange3,
        calendarHighlightRange4,
        calendarHighlightRange5};
            this.calendar1.Location = new System.Drawing.Point(0, 0);
            this.calendar1.Name = "calendar1";
            this.calendar1.Size = new System.Drawing.Size(496, 624);
            this.calendar1.TabIndex = 2;
            this.calendar1.Text = "calendar1";
            this.calendar1.LoadItems += new System.Windows.Forms.Calendar.Calendar.CalendarLoadEventHandler(this.calendar1_LoadItems);
            this.calendar1.DayHeaderClick += new System.Windows.Forms.Calendar.Calendar.CalendarDayEventHandler(this.calendar1_DayHeaderClick);
            this.calendar1.ItemCreated += new System.Windows.Forms.Calendar.Calendar.CalendarItemCancelEventHandler(this.calendar1_ItemCreated);
            this.calendar1.ItemDeleted += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemDeleted);
            this.calendar1.ItemTextEdited += new System.Windows.Forms.Calendar.Calendar.CalendarItemCancelEventHandler(this.calendar1_ItemTextEdited);
            this.calendar1.ItemDatesChanged += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemDatesChanged);
            this.calendar1.ItemClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemClick);
            this.calendar1.ItemDoubleClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemDoubleClick);
            this.calendar1.ItemMouseHover += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemMouseHover);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redTagToolStripMenuItem,
            this.yellowTagToolStripMenuItem,
            this.greenTagToolStripMenuItem,
            this.blueTagToolStripMenuItem,
            this.otherColorTagToolStripMenuItem,
            this.editItemToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(164, 136);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // redTagToolStripMenuItem
            // 
            this.redTagToolStripMenuItem.Name = "redTagToolStripMenuItem";
            this.redTagToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.redTagToolStripMenuItem.Text = "Red tag";
            this.redTagToolStripMenuItem.Click += new System.EventHandler(this.redTagToolStripMenuItem_Click);
            // 
            // yellowTagToolStripMenuItem
            // 
            this.yellowTagToolStripMenuItem.Name = "yellowTagToolStripMenuItem";
            this.yellowTagToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.yellowTagToolStripMenuItem.Text = "Yellow tag";
            this.yellowTagToolStripMenuItem.Click += new System.EventHandler(this.yellowTagToolStripMenuItem_Click);
            // 
            // greenTagToolStripMenuItem
            // 
            this.greenTagToolStripMenuItem.Name = "greenTagToolStripMenuItem";
            this.greenTagToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.greenTagToolStripMenuItem.Text = "Green tag";
            this.greenTagToolStripMenuItem.Click += new System.EventHandler(this.greenTagToolStripMenuItem_Click);
            // 
            // blueTagToolStripMenuItem
            // 
            this.blueTagToolStripMenuItem.Name = "blueTagToolStripMenuItem";
            this.blueTagToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.blueTagToolStripMenuItem.Text = "Blue tag";
            this.blueTagToolStripMenuItem.Click += new System.EventHandler(this.blueTagToolStripMenuItem_Click);
            // 
            // otherColorTagToolStripMenuItem
            // 
            this.otherColorTagToolStripMenuItem.Name = "otherColorTagToolStripMenuItem";
            this.otherColorTagToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.otherColorTagToolStripMenuItem.Text = "Other color tag...";
            this.otherColorTagToolStripMenuItem.Click += new System.EventHandler(this.otherColorTagToolStripMenuItem_Click);
            // 
            // editItemToolStripMenuItem
            // 
            this.editItemToolStripMenuItem.Name = "editItemToolStripMenuItem";
            this.editItemToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.editItemToolStripMenuItem.Text = "Edit item\'s text";
            this.editItemToolStripMenuItem.Click += new System.EventHandler(this.editItemToolStripMenuItem_Click);
            // 
            // tabPagenhapthuoc
            // 
            this.tabPagenhapthuoc.Controls.Add(this.buttonServicesCancel);
            this.tabPagenhapthuoc.Controls.Add(this.buttonServicesOK);
            this.tabPagenhapthuoc.Controls.Add(this.button9);
            this.tabPagenhapthuoc.Controls.Add(this.btnInputMedicineNewOk);
            this.tabPagenhapthuoc.Controls.Add(this.button7);
            this.tabPagenhapthuoc.Controls.Add(this.btnInputMedicineOk);
            this.tabPagenhapthuoc.Controls.Add(this.CoTableLayoutPanel7);
            this.tabPagenhapthuoc.Controls.Add(this.CoTableLayoutPanel4);
            this.tabPagenhapthuoc.Controls.Add(this.CoTableLayoutPanel3);
            this.tabPagenhapthuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPagenhapthuoc.Location = new System.Drawing.Point(4, 27);
            this.tabPagenhapthuoc.Name = "tabPagenhapthuoc";
            this.tabPagenhapthuoc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagenhapthuoc.Size = new System.Drawing.Size(1367, 649);
            this.tabPagenhapthuoc.TabIndex = 2;
            this.tabPagenhapthuoc.Text = "Nhập thuốc";
            this.tabPagenhapthuoc.UseVisualStyleBackColor = true;
            // 
            // buttonServicesCancel
            // 
            this.buttonServicesCancel.BackColor = System.Drawing.Color.Salmon;
            this.buttonServicesCancel.Location = new System.Drawing.Point(822, 592);
            this.buttonServicesCancel.Name = "buttonServicesCancel";
            this.buttonServicesCancel.Size = new System.Drawing.Size(170, 48);
            this.buttonServicesCancel.TabIndex = 28;
            this.buttonServicesCancel.Text = "Cancel";
            this.buttonServicesCancel.UseVisualStyleBackColor = false;
            // 
            // buttonServicesOK
            // 
            this.buttonServicesOK.BackColor = System.Drawing.Color.YellowGreen;
            this.buttonServicesOK.Location = new System.Drawing.Point(822, 526);
            this.buttonServicesOK.Name = "buttonServicesOK";
            this.buttonServicesOK.Size = new System.Drawing.Size(170, 50);
            this.buttonServicesOK.TabIndex = 27;
            this.buttonServicesOK.Text = "OK/ Cập Nhật";
            this.buttonServicesOK.UseVisualStyleBackColor = false;
            this.buttonServicesOK.Click += new System.EventHandler(this.buttonServicesOK_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Salmon;
            this.button9.Location = new System.Drawing.Point(839, 376);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(153, 84);
            this.button9.TabIndex = 11;
            this.button9.Text = "Cancel";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // btnInputMedicineNewOk
            // 
            this.btnInputMedicineNewOk.BackColor = System.Drawing.Color.YellowGreen;
            this.btnInputMedicineNewOk.Location = new System.Drawing.Point(839, 268);
            this.btnInputMedicineNewOk.Name = "btnInputMedicineNewOk";
            this.btnInputMedicineNewOk.Size = new System.Drawing.Size(153, 84);
            this.btnInputMedicineNewOk.TabIndex = 10;
            this.btnInputMedicineNewOk.Text = "OK";
            this.btnInputMedicineNewOk.UseVisualStyleBackColor = false;
            this.btnInputMedicineNewOk.Click += new System.EventHandler(this.btnInputMedicineNewOk_ClickMySql);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Salmon;
            this.button7.Location = new System.Drawing.Point(839, 128);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(153, 83);
            this.button7.TabIndex = 5;
            this.button7.Text = "Cancel";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // btnInputMedicineOk
            // 
            this.btnInputMedicineOk.BackColor = System.Drawing.Color.YellowGreen;
            this.btnInputMedicineOk.Location = new System.Drawing.Point(839, 27);
            this.btnInputMedicineOk.Name = "btnInputMedicineOk";
            this.btnInputMedicineOk.Size = new System.Drawing.Size(153, 81);
            this.btnInputMedicineOk.TabIndex = 4;
            this.btnInputMedicineOk.Text = "OK";
            this.btnInputMedicineOk.UseVisualStyleBackColor = false;
            this.btnInputMedicineOk.Click += new System.EventHandler(this.btnInputMedicineOk_ClickMySql);
            // 
            // tabPageTools
            // 
            this.tabPageTools.Controls.Add(this.textBoxNameDoctor);
            this.tabPageTools.Controls.Add(this.label46);
            this.tabPageTools.Controls.Add(this.button1);
            this.tabPageTools.Controls.Add(this.checkBoxKethuoc);
            this.tabPageTools.Controls.Add(this.dataGridView4);
            this.tabPageTools.Controls.Add(this.buttonCreateUser);
            this.tabPageTools.Controls.Add(this.checkBoxNhapThuoc);
            this.tabPageTools.Controls.Add(this.label29);
            this.tabPageTools.Controls.Add(this.label10);
            this.tabPageTools.Controls.Add(this.textBox2);
            this.tabPageTools.Controls.Add(this.textBox1);
            this.tabPageTools.Controls.Add(this.CoTableLayoutPanel6);
            this.tabPageTools.Controls.Add(this.CoTableLayoutPanel5);
            this.tabPageTools.Location = new System.Drawing.Point(4, 27);
            this.tabPageTools.Name = "tabPageTools";
            this.tabPageTools.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTools.Size = new System.Drawing.Size(1367, 649);
            this.tabPageTools.TabIndex = 3;
            this.tabPageTools.Text = "Tools";
            this.tabPageTools.UseVisualStyleBackColor = true;
            // 
            // textBoxNameDoctor
            // 
            this.textBoxNameDoctor.Location = new System.Drawing.Point(115, 117);
            this.textBoxNameDoctor.Name = "textBoxNameDoctor";
            this.textBoxNameDoctor.Size = new System.Drawing.Size(158, 24);
            this.textBoxNameDoctor.TabIndex = 34;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(24, 117);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(75, 18);
            this.label46.TabIndex = 33;
            this.label46.Text = "Họ và tên:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(789, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 31;
            this.button1.Text = "Thay đổi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxKethuoc
            // 
            this.checkBoxKethuoc.AutoSize = true;
            this.checkBoxKethuoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.checkBoxKethuoc.Location = new System.Drawing.Point(292, 58);
            this.checkBoxKethuoc.Name = "checkBoxKethuoc";
            this.checkBoxKethuoc.Size = new System.Drawing.Size(138, 22);
            this.checkBoxKethuoc.TabIndex = 28;
            this.checkBoxKethuoc.Text = "Quyền Kê Thuốc";
            this.checkBoxKethuoc.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column22,
            this.Column23,
            this.Column24,
            this.Column25,
            this.Column26});
            this.dataGridView4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView4.Location = new System.Drawing.Point(3, 481);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(1361, 165);
            this.dataGridView4.TabIndex = 27;
            // 
            // Column22
            // 
            this.Column22.HeaderText = "ID";
            this.Column22.Name = "Column22";
            // 
            // Column23
            // 
            this.Column23.HeaderText = "Tên Thuốc";
            this.Column23.Name = "Column23";
            // 
            // Column24
            // 
            this.Column24.HeaderText = "Giá In";
            this.Column24.Name = "Column24";
            // 
            // Column25
            // 
            this.Column25.HeaderText = "Giá Out";
            this.Column25.Name = "Column25";
            // 
            // Column26
            // 
            this.Column26.HeaderText = "Số Lượng";
            this.Column26.Name = "Column26";
            this.Column26.SingleLineColor = System.Drawing.Color.Red;
            // 
            // buttonCreateUser
            // 
            this.buttonCreateUser.Location = new System.Drawing.Point(24, 147);
            this.buttonCreateUser.Name = "buttonCreateUser";
            this.buttonCreateUser.Size = new System.Drawing.Size(75, 27);
            this.buttonCreateUser.TabIndex = 6;
            this.buttonCreateUser.Text = "OK";
            this.buttonCreateUser.UseVisualStyleBackColor = true;
            this.buttonCreateUser.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBoxNhapThuoc
            // 
            this.checkBoxNhapThuoc.AutoSize = true;
            this.checkBoxNhapThuoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.checkBoxNhapThuoc.Location = new System.Drawing.Point(292, 89);
            this.checkBoxNhapThuoc.Name = "checkBoxNhapThuoc";
            this.checkBoxNhapThuoc.Size = new System.Drawing.Size(155, 22);
            this.checkBoxNhapThuoc.TabIndex = 4;
            this.checkBoxNhapThuoc.Text = "Quyền Nhập Thuốc";
            this.checkBoxNhapThuoc.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(21, 78);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(83, 18);
            this.label29.TabIndex = 3;
            this.label29.Text = "Password :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 18);
            this.label10.TabIndex = 2;
            this.label10.Text = "UserName :";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(115, 76);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 24);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(115, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 24);
            this.textBox1.TabIndex = 0;
            // 
            // tabPagePrint
            // 
            this.tabPagePrint.Controls.Add(this.axAcroPDF1);
            this.tabPagePrint.Location = new System.Drawing.Point(4, 27);
            this.tabPagePrint.Name = "tabPagePrint";
            this.tabPagePrint.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePrint.Size = new System.Drawing.Size(1367, 649);
            this.tabPagePrint.TabIndex = 4;
            this.tabPagePrint.Text = "Print";
            this.tabPagePrint.UseVisualStyleBackColor = true;
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(3, 3);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(1361, 643);
            this.axAcroPDF1.TabIndex = 0;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(64, 6);
            // 
            // patternToolStripMenuItem
            // 
            this.patternToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diagonalToolStripMenuItem,
            this.verticalToolStripMenuItem,
            this.horizontalToolStripMenuItem,
            this.hatchToolStripMenuItem,
            this.toolStripMenuItem3,
            this.noneToolStripMenuItem});
            this.patternToolStripMenuItem.Name = "patternToolStripMenuItem";
            this.patternToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.patternToolStripMenuItem.Text = "Pattern";
            // 
            // diagonalToolStripMenuItem
            // 
            this.diagonalToolStripMenuItem.Name = "diagonalToolStripMenuItem";
            this.diagonalToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // hatchToolStripMenuItem
            // 
            this.hatchToolStripMenuItem.Name = "hatchToolStripMenuItem";
            this.hatchToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(64, 6);
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // timescaleToolStripMenuItem
            // 
            this.timescaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hourToolStripMenuItem,
            this.minutesToolStripMenuItem,
            this.toolStripMenuItem4,
            this.minutesToolStripMenuItem1,
            this.minutesToolStripMenuItem2,
            this.minutesToolStripMenuItem3});
            this.timescaleToolStripMenuItem.Name = "timescaleToolStripMenuItem";
            this.timescaleToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.timescaleToolStripMenuItem.Text = "Timescale";
            // 
            // hourToolStripMenuItem
            // 
            this.hourToolStripMenuItem.Name = "hourToolStripMenuItem";
            this.hourToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // minutesToolStripMenuItem
            // 
            this.minutesToolStripMenuItem.Name = "minutesToolStripMenuItem";
            this.minutesToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(67, 22);
            // 
            // minutesToolStripMenuItem1
            // 
            this.minutesToolStripMenuItem1.Name = "minutesToolStripMenuItem1";
            this.minutesToolStripMenuItem1.Size = new System.Drawing.Size(67, 22);
            // 
            // minutesToolStripMenuItem2
            // 
            this.minutesToolStripMenuItem2.Name = "minutesToolStripMenuItem2";
            this.minutesToolStripMenuItem2.Size = new System.Drawing.Size(67, 22);
            // 
            // minutesToolStripMenuItem3
            // 
            this.minutesToolStripMenuItem3.Name = "minutesToolStripMenuItem3";
            this.minutesToolStripMenuItem3.Size = new System.Drawing.Size(67, 22);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(64, 6);
            // 
            // selectImageToolStripMenuItem
            // 
            this.selectImageToolStripMenuItem.Name = "selectImageToolStripMenuItem";
            this.selectImageToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // imageAlignmentToolStripMenuItem
            // 
            this.imageAlignmentToolStripMenuItem.Name = "imageAlignmentToolStripMenuItem";
            this.imageAlignmentToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(64, 6);
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Tên Thuốc";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Số lượng";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Giá";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Tiền";
            this.Column10.Name = "Column10";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.CoTableLayoutPanel2);
            this.tabPage2.Controls.Add(this.btnWaitRoomContinue);
            this.tabPage2.Controls.Add(this.btnWaitRoomCancel);
            this.tabPage2.Controls.Add(this.btnWaitRoomOK);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(833, 484);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Phòng đợi";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView1.Location = new System.Drawing.Point(3, 250);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(778, 164);
            this.dataGridView1.TabIndex = 21;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Tên";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Ngày Sinh";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Địa chỉ";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Triệu chứng";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Chẩn đoán";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Số thứ tự";
            this.Column6.Name = "Column6";
            // 
            // btnWaitRoomContinue
            // 
            this.btnWaitRoomContinue.Location = new System.Drawing.Point(578, 201);
            this.btnWaitRoomContinue.Name = "btnWaitRoomContinue";
            this.btnWaitRoomContinue.Size = new System.Drawing.Size(75, 23);
            this.btnWaitRoomContinue.TabIndex = 9;
            this.btnWaitRoomContinue.Text = "Tiếp tục";
            this.btnWaitRoomContinue.UseVisualStyleBackColor = true;
            this.btnWaitRoomContinue.Visible = false;
            // 
            // btnWaitRoomCancel
            // 
            this.btnWaitRoomCancel.Location = new System.Drawing.Point(670, 162);
            this.btnWaitRoomCancel.Name = "btnWaitRoomCancel";
            this.btnWaitRoomCancel.Size = new System.Drawing.Size(75, 23);
            this.btnWaitRoomCancel.TabIndex = 10;
            this.btnWaitRoomCancel.Text = "Cancel";
            this.btnWaitRoomCancel.UseVisualStyleBackColor = true;
            // 
            // btnWaitRoomOK
            // 
            this.btnWaitRoomOK.Location = new System.Drawing.Point(508, 162);
            this.btnWaitRoomOK.Name = "btnWaitRoomOK";
            this.btnWaitRoomOK.Size = new System.Drawing.Size(75, 23);
            this.btnWaitRoomOK.TabIndex = 8;
            this.btnWaitRoomOK.Text = "OK";
            this.btnWaitRoomOK.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.doanhThuToolStripMenuItem,
            this.mởRộngToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1375, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.logOutToolStripMenuItem.Text = "Log out";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // doanhThuToolStripMenuItem
            // 
            this.doanhThuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doanhThuToolStripMenuItem1,
            this.tủThuốcToolStripMenuItem,
            this.cácDịchVụToolStripMenuItem});
            this.doanhThuToolStripMenuItem.Name = "doanhThuToolStripMenuItem";
            this.doanhThuToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.doanhThuToolStripMenuItem.Text = "Thống Kê";
            // 
            // doanhThuToolStripMenuItem1
            // 
            this.doanhThuToolStripMenuItem1.Name = "doanhThuToolStripMenuItem1";
            this.doanhThuToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.doanhThuToolStripMenuItem1.Text = "Doanh Thu";
            this.doanhThuToolStripMenuItem1.Click += new System.EventHandler(this.doanhThuToolStripMenuItem1_Click);
            // 
            // tủThuốcToolStripMenuItem
            // 
            this.tủThuốcToolStripMenuItem.Name = "tủThuốcToolStripMenuItem";
            this.tủThuốcToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.tủThuốcToolStripMenuItem.Text = "Tủ Thuốc";
            this.tủThuốcToolStripMenuItem.Click += new System.EventHandler(this.tủThuốcToolStripMenuItem_Click);
            // 
            // cácDịchVụToolStripMenuItem
            // 
            this.cácDịchVụToolStripMenuItem.Name = "cácDịchVụToolStripMenuItem";
            this.cácDịchVụToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.cácDịchVụToolStripMenuItem.Text = "Các dịch vụ";
            this.cácDịchVụToolStripMenuItem.Click += new System.EventHandler(this.cácDịchVụToolStripMenuItem_Click);
            // 
            // mởRộngToolStripMenuItem
            // 
            this.mởRộngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loaiKhamToolStripMenuItem});
            this.mởRộngToolStripMenuItem.Name = "mởRộngToolStripMenuItem";
            this.mởRộngToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.mởRộngToolStripMenuItem.Text = "Mở rộng";
            // 
            // loaiKhamToolStripMenuItem
            // 
            this.loaiKhamToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmLoạiToolStripMenuItem});
            this.loaiKhamToolStripMenuItem.Name = "loaiKhamToolStripMenuItem";
            this.loaiKhamToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.loaiKhamToolStripMenuItem.Text = "Loại Khám";
            this.loaiKhamToolStripMenuItem.Click += new System.EventHandler(this.loaiKhamToolStripMenuItem_Click);
            // 
            // thêmLoạiToolStripMenuItem
            // 
            this.thêmLoạiToolStripMenuItem.Name = "thêmLoạiToolStripMenuItem";
            this.thêmLoạiToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.thêmLoạiToolStripMenuItem.Text = "Thêm Loại";
            this.thêmLoạiToolStripMenuItem.Click += new System.EventHandler(this.themLoaiToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.aboutToolStripMenuItem.Text = "Supports";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // comboBoxLoaiKham
            // 
            this.comboBoxLoaiKham.FormattingEnabled = true;
            this.comboBoxLoaiKham.Location = new System.Drawing.Point(702, 464);
            this.comboBoxLoaiKham.Name = "comboBoxLoaiKham";
            this.comboBoxLoaiKham.Size = new System.Drawing.Size(142, 26);
            this.comboBoxLoaiKham.TabIndex = 46;
            // 
            // CoTableLayoutPanel1
            // 
            this.CoTableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CoTableLayoutPanel1.AutoSize = true;
            this.CoTableLayoutPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.CoTableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.CoTableLayoutPanel1.ColumnCount = 6;
            this.CoTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.CoTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.30303F));
            this.CoTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.06061F));
            this.CoTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.CoTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 201F));
            this.CoTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 443F));
            this.CoTableLayoutPanel1.Controls.Add(this.label28, 0, 0);
            this.CoTableLayoutPanel1.Controls.Add(this.lblClinicRoomId, 1, 0);
            this.CoTableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.CoTableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.CoTableLayoutPanel1.Controls.Add(this.textBoxClinicNhietDo, 3, 3);
            this.CoTableLayoutPanel1.Controls.Add(this.dateTimePickerBirthDay, 1, 2);
            this.CoTableLayoutPanel1.Controls.Add(this.txtBoxClinicRoomAddress, 1, 3);
            this.CoTableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.CoTableLayoutPanel1.Controls.Add(this.label45, 2, 3);
            this.CoTableLayoutPanel1.Controls.Add(this.comboBoxClinicRoomName, 1, 1);
            this.CoTableLayoutPanel1.Controls.Add(this.buttonClinicCreateNew, 4, 0);
            this.CoTableLayoutPanel1.Controls.Add(this.buttonClinicClear, 4, 1);
            this.CoTableLayoutPanel1.Controls.Add(this.txtBoxClinicRoomWeight, 3, 2);
            this.CoTableLayoutPanel1.Controls.Add(this.label5, 2, 2);
            this.CoTableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.CoTableLayoutPanel1.Controls.Add(this.txtBoxClinicRoomHeight, 3, 1);
            this.CoTableLayoutPanel1.Controls.Add(this.label31, 2, 0);
            this.CoTableLayoutPanel1.Controls.Add(this.dateTimePickerNgayKham, 3, 0);
            this.CoTableLayoutPanel1.Controls.Add(this.label30, 2, 4);
            this.CoTableLayoutPanel1.Controls.Add(this.textBoxHuyetAp, 3, 4);
            this.CoTableLayoutPanel1.Controls.Add(this.label47, 0, 4);
            this.CoTableLayoutPanel1.Controls.Add(this.labelTuoi, 1, 4);
            this.CoTableLayoutPanel1.Controls.Add(this.button3, 4, 4);
            this.CoTableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoTableLayoutPanel1.Location = new System.Drawing.Point(9, 6);
            this.CoTableLayoutPanel1.Name = "CoTableLayoutPanel1";
            this.CoTableLayoutPanel1.RowCount = 5;
            this.CoTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.CoTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.CoTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.CoTableLayoutPanel1.Size = new System.Drawing.Size(1189, 193);
            this.CoTableLayoutPanel1.TabIndex = 27;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 3);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(22, 18);
            this.label28.TabIndex = 0;
            this.label28.Text = "ID";
            // 
            // lblClinicRoomId
            // 
            this.lblClinicRoomId.AutoSize = true;
            this.lblClinicRoomId.Location = new System.Drawing.Point(83, 3);
            this.lblClinicRoomId.Name = "lblClinicRoomId";
            this.lblClinicRoomId.Size = new System.Drawing.Size(19, 18);
            this.lblClinicRoomId.TabIndex = 1;
            this.lblClinicRoomId.Text = "Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày Sinh";
            // 
            // textBoxClinicNhietDo
            // 
            this.textBoxClinicNhietDo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxClinicNhietDo.Location = new System.Drawing.Point(362, 119);
            this.textBoxClinicNhietDo.Name = "textBoxClinicNhietDo";
            this.textBoxClinicNhietDo.Size = new System.Drawing.Size(147, 24);
            this.textBoxClinicNhietDo.TabIndex = 22;
            // 
            // dateTimePickerBirthDay
            // 
            this.dateTimePickerBirthDay.CustomFormat = "dd-MM-yyyy";
            this.dateTimePickerBirthDay.Location = new System.Drawing.Point(83, 85);
            this.dateTimePickerBirthDay.Name = "dateTimePickerBirthDay";
            this.dateTimePickerBirthDay.Size = new System.Drawing.Size(173, 24);
            this.dateTimePickerBirthDay.TabIndex = 18;
            this.dateTimePickerBirthDay.ValueChanged += new System.EventHandler(this.dateTimePickerBirthDay_ValueChanged);
            // 
            // txtBoxClinicRoomAddress
            // 
            this.txtBoxClinicRoomAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBoxClinicRoomAddress.Location = new System.Drawing.Point(83, 119);
            this.txtBoxClinicRoomAddress.Name = "txtBoxClinicRoomAddress";
            this.txtBoxClinicRoomAddress.Size = new System.Drawing.Size(173, 24);
            this.txtBoxClinicRoomAddress.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Địa chỉ";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(265, 116);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(67, 18);
            this.label45.TabIndex = 40;
            this.label45.Text = "Nhiệt độ:";
            // 
            // comboBoxClinicRoomName
            // 
            this.comboBoxClinicRoomName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.comboBoxClinicRoomName.Location = new System.Drawing.Point(83, 49);
            this.comboBoxClinicRoomName.Name = "comboBoxClinicRoomName";
            this.comboBoxClinicRoomName.Size = new System.Drawing.Size(173, 24);
            this.comboBoxClinicRoomName.TabIndex = 17;
            this.comboBoxClinicRoomName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxClinicRoomName_KeyPress);
            // 
            // buttonClinicCreateNew
            // 
            this.buttonClinicCreateNew.Location = new System.Drawing.Point(539, 6);
            this.buttonClinicCreateNew.Name = "buttonClinicCreateNew";
            this.buttonClinicCreateNew.Size = new System.Drawing.Size(187, 26);
            this.buttonClinicCreateNew.TabIndex = 24;
            this.buttonClinicCreateNew.Text = "Thêm mới/Cập nhật";
            this.buttonClinicCreateNew.UseVisualStyleBackColor = true;
            this.buttonClinicCreateNew.Click += new System.EventHandler(this.buttonClinicCreateNew_Click);
            // 
            // buttonClinicClear
            // 
            this.buttonClinicClear.Location = new System.Drawing.Point(539, 49);
            this.buttonClinicClear.Name = "buttonClinicClear";
            this.buttonClinicClear.Size = new System.Drawing.Size(75, 26);
            this.buttonClinicClear.TabIndex = 30;
            this.buttonClinicClear.Text = "Clear";
            this.buttonClinicClear.UseVisualStyleBackColor = true;
            this.buttonClinicClear.Click += new System.EventHandler(this.buttonClinicClear_Click);
            // 
            // txtBoxClinicRoomWeight
            // 
            this.txtBoxClinicRoomWeight.Location = new System.Drawing.Point(362, 85);
            this.txtBoxClinicRoomWeight.Name = "txtBoxClinicRoomWeight";
            this.txtBoxClinicRoomWeight.Size = new System.Drawing.Size(147, 24);
            this.txtBoxClinicRoomWeight.TabIndex = 21;
            this.txtBoxClinicRoomWeight.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nặng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Chiều Cao";
            // 
            // txtBoxClinicRoomHeight
            // 
            this.txtBoxClinicRoomHeight.Location = new System.Drawing.Point(362, 49);
            this.txtBoxClinicRoomHeight.Name = "txtBoxClinicRoomHeight";
            this.txtBoxClinicRoomHeight.Size = new System.Drawing.Size(147, 24);
            this.txtBoxClinicRoomHeight.TabIndex = 20;
            this.txtBoxClinicRoomHeight.Text = "0";
            // 
            // label31
            // 
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(265, 3);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(88, 40);
            this.label31.TabIndex = 25;
            this.label31.Text = "Ngày Khám";
            // 
            // dateTimePickerNgayKham
            // 
            this.dateTimePickerNgayKham.CustomFormat = "dd-MM-yyyy";
            this.dateTimePickerNgayKham.Location = new System.Drawing.Point(362, 6);
            this.dateTimePickerNgayKham.Name = "dateTimePickerNgayKham";
            this.dateTimePickerNgayKham.Size = new System.Drawing.Size(168, 24);
            this.dateTimePickerNgayKham.TabIndex = 26;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(265, 152);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(71, 18);
            this.label30.TabIndex = 41;
            this.label30.Text = "Huyết Áp:";
            // 
            // textBoxHuyetAp
            // 
            this.textBoxHuyetAp.Location = new System.Drawing.Point(362, 155);
            this.textBoxHuyetAp.Name = "textBoxHuyetAp";
            this.textBoxHuyetAp.Size = new System.Drawing.Size(147, 24);
            this.textBoxHuyetAp.TabIndex = 23;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(6, 152);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(41, 18);
            this.label47.TabIndex = 43;
            this.label47.Text = "Tuổi:";
            // 
            // labelTuoi
            // 
            this.labelTuoi.AutoSize = true;
            this.labelTuoi.Location = new System.Drawing.Point(83, 152);
            this.labelTuoi.Name = "labelTuoi";
            this.labelTuoi.Size = new System.Drawing.Size(16, 18);
            this.labelTuoi.TabIndex = 44;
            this.labelTuoi.Text = "0";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(539, 155);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 32);
            this.button3.TabIndex = 45;
            this.button3.Text = "Chỉ Làm mới ID";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // CoTableLayoutPanel7
            // 
            this.CoTableLayoutPanel7.BackColor = System.Drawing.Color.LightGray;
            this.CoTableLayoutPanel7.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.CoTableLayoutPanel7.ColumnCount = 2;
            this.CoTableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.59006F));
            this.CoTableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.40993F));
            this.CoTableLayoutPanel7.Controls.Add(this.labelServicesID, 1, 0);
            this.CoTableLayoutPanel7.Controls.Add(this.label41, 0, 1);
            this.CoTableLayoutPanel7.Controls.Add(this.label42, 0, 2);
            this.CoTableLayoutPanel7.Controls.Add(this.textBoxServices, 1, 1);
            this.CoTableLayoutPanel7.Controls.Add(this.textBoxServicesCost, 1, 2);
            this.CoTableLayoutPanel7.Controls.Add(this.label43, 0, 0);
            this.CoTableLayoutPanel7.Controls.Add(this.label48, 0, 3);
            this.CoTableLayoutPanel7.Controls.Add(this.textBoxAdminOfService, 1, 3);
            this.CoTableLayoutPanel7.Location = new System.Drawing.Point(8, 523);
            this.CoTableLayoutPanel7.Name = "CoTableLayoutPanel7";
            this.CoTableLayoutPanel7.RowCount = 4;
            this.CoTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CoTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.CoTableLayoutPanel7.Size = new System.Drawing.Size(808, 117);
            this.CoTableLayoutPanel7.TabIndex = 26;
            // 
            // labelServicesID
            // 
            this.labelServicesID.AutoSize = true;
            this.labelServicesID.Location = new System.Drawing.Point(213, 3);
            this.labelServicesID.Name = "labelServicesID";
            this.labelServicesID.Size = new System.Drawing.Size(54, 18);
            this.labelServicesID.TabIndex = 18;
            this.labelServicesID.Text = "label44";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(6, 26);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(92, 18);
            this.label41.TabIndex = 0;
            this.label41.Text = "Tên Dịch Vụ:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(6, 56);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(35, 18);
            this.label42.TabIndex = 1;
            this.label42.Text = "Giá:";
            // 
            // textBoxServices
            // 
            this.textBoxServices.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxServices.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxServices.Location = new System.Drawing.Point(213, 29);
            this.textBoxServices.Name = "textBoxServices";
            this.textBoxServices.Size = new System.Drawing.Size(589, 24);
            this.textBoxServices.TabIndex = 2;
            this.textBoxServices.Text = "@";
            this.textBoxServices.TextChanged += new System.EventHandler(this.textBoxServices_TextChanged);
            // 
            // textBoxServicesCost
            // 
            this.textBoxServicesCost.Location = new System.Drawing.Point(213, 59);
            this.textBoxServicesCost.Name = "textBoxServicesCost";
            this.textBoxServicesCost.Size = new System.Drawing.Size(589, 24);
            this.textBoxServicesCost.TabIndex = 3;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(6, 3);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(26, 18);
            this.label43.TabIndex = 4;
            this.label43.Text = "ID:";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(6, 86);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(171, 18);
            this.label48.TabIndex = 19;
            this.label48.Text = "Người phụ trách(nếu có):";
            // 
            // textBoxAdminOfService
            // 
            this.textBoxAdminOfService.Location = new System.Drawing.Point(213, 89);
            this.textBoxAdminOfService.Name = "textBoxAdminOfService";
            this.textBoxAdminOfService.Size = new System.Drawing.Size(589, 24);
            this.textBoxAdminOfService.TabIndex = 20;
            // 
            // CoTableLayoutPanel4
            // 
            this.CoTableLayoutPanel4.BackColor = System.Drawing.Color.Gainsboro;
            this.CoTableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.CoTableLayoutPanel4.ColumnCount = 2;
            this.CoTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoTableLayoutPanel4.Controls.Add(this.label23, 0, 0);
            this.CoTableLayoutPanel4.Controls.Add(this.txtBoxInputMedicineAdd, 1, 3);
            this.CoTableLayoutPanel4.Controls.Add(this.label24, 0, 3);
            this.CoTableLayoutPanel4.Controls.Add(this.label18, 0, 1);
            this.CoTableLayoutPanel4.Controls.Add(this.label19, 0, 2);
            this.CoTableLayoutPanel4.Controls.Add(this.lblInputMedicineCount, 1, 2);
            this.CoTableLayoutPanel4.Controls.Add(this.label27, 0, 5);
            this.CoTableLayoutPanel4.Controls.Add(this.label32, 0, 4);
            this.CoTableLayoutPanel4.Controls.Add(this.textBox3, 1, 4);
            this.CoTableLayoutPanel4.Controls.Add(this.dateTimePicker6, 1, 5);
            this.CoTableLayoutPanel4.Controls.Add(this.label34, 1, 0);
            this.CoTableLayoutPanel4.Controls.Add(this.comboBoxInputMedicineName, 1, 1);
            this.CoTableLayoutPanel4.Location = new System.Drawing.Point(8, 25);
            this.CoTableLayoutPanel4.Name = "CoTableLayoutPanel4";
            this.CoTableLayoutPanel4.RowCount = 6;
            this.CoTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.05195F));
            this.CoTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.94805F));
            this.CoTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.CoTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.CoTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.CoTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.CoTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CoTableLayoutPanel4.Size = new System.Drawing.Size(808, 195);
            this.CoTableLayoutPanel4.TabIndex = 25;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(22, 18);
            this.label23.TabIndex = 18;
            this.label23.Text = "ID";
            // 
            // txtBoxInputMedicineAdd
            // 
            this.txtBoxInputMedicineAdd.Location = new System.Drawing.Point(408, 90);
            this.txtBoxInputMedicineAdd.Name = "txtBoxInputMedicineAdd";
            this.txtBoxInputMedicineAdd.Size = new System.Drawing.Size(383, 24);
            this.txtBoxInputMedicineAdd.TabIndex = 2;
            this.txtBoxInputMedicineAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInputMedicineAdd_KeyPress);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 87);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(132, 18);
            this.label24.TabIndex = 21;
            this.label24.Text = "Số lượng thêm vào";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 30);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 18);
            this.label18.TabIndex = 0;
            this.label18.Text = "Tên Thuốc";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 60);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(124, 18);
            this.label19.TabIndex = 1;
            this.label19.Text = "Số lượng đang có";
            // 
            // lblInputMedicineCount
            // 
            this.lblInputMedicineCount.AutoSize = true;
            this.lblInputMedicineCount.Location = new System.Drawing.Point(408, 60);
            this.lblInputMedicineCount.Name = "lblInputMedicineCount";
            this.lblInputMedicineCount.Size = new System.Drawing.Size(16, 18);
            this.lblInputMedicineCount.TabIndex = 23;
            this.lblInputMedicineCount.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 157);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(78, 18);
            this.label27.TabIndex = 24;
            this.label27.Text = "Ngày nhập";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 122);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(88, 18);
            this.label32.TabIndex = 25;
            this.label32.Text = "Giá Out Mới";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(408, 125);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(383, 24);
            this.textBox3.TabIndex = 26;
            // 
            // dateTimePicker6
            // 
            this.dateTimePicker6.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker6.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker6.Location = new System.Drawing.Point(408, 160);
            this.dateTimePicker6.Name = "dateTimePicker6";
            this.dateTimePicker6.Size = new System.Drawing.Size(383, 24);
            this.dateTimePicker6.TabIndex = 30;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(408, 3);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(0, 18);
            this.label34.TabIndex = 32;
            // 
            // comboBoxInputMedicineName
            // 
            this.comboBoxInputMedicineName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxInputMedicineName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxInputMedicineName.FormattingEnabled = true;
            this.comboBoxInputMedicineName.Location = new System.Drawing.Point(408, 33);
            this.comboBoxInputMedicineName.Name = "comboBoxInputMedicineName";
            this.comboBoxInputMedicineName.Size = new System.Drawing.Size(383, 26);
            this.comboBoxInputMedicineName.Sorted = true;
            this.comboBoxInputMedicineName.TabIndex = 1;
            this.comboBoxInputMedicineName.SelectedValueChanged += new System.EventHandler(this.comboBoxInputMedicineName_SelectedValueChanged);
            // 
            // CoTableLayoutPanel3
            // 
            this.CoTableLayoutPanel3.BackColor = System.Drawing.Color.Gainsboro;
            this.CoTableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.CoTableLayoutPanel3.ColumnCount = 2;
            this.CoTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoTableLayoutPanel3.Controls.Add(this.label13, 0, 1);
            this.CoTableLayoutPanel3.Controls.Add(this.lblInputMedicineNewId, 1, 1);
            this.CoTableLayoutPanel3.Controls.Add(this.label20, 0, 2);
            this.CoTableLayoutPanel3.Controls.Add(this.txtBoxInputMedicineNewName, 1, 2);
            this.CoTableLayoutPanel3.Controls.Add(this.label21, 0, 3);
            this.CoTableLayoutPanel3.Controls.Add(this.txtBoxInputMedicineNewCount, 1, 3);
            this.CoTableLayoutPanel3.Controls.Add(this.txtBoxInputMedicineNewCostOut, 1, 5);
            this.CoTableLayoutPanel3.Controls.Add(this.label22, 0, 0);
            this.CoTableLayoutPanel3.Controls.Add(label26, 1, 0);
            this.CoTableLayoutPanel3.Controls.Add(this.label25, 0, 6);
            this.CoTableLayoutPanel3.Controls.Add(this.dateTimePicker3, 1, 6);
            this.CoTableLayoutPanel3.Controls.Add(this.label12, 0, 5);
            this.CoTableLayoutPanel3.Controls.Add(this.label8, 0, 4);
            this.CoTableLayoutPanel3.Controls.Add(this.txtBoxInputMedicineNewCostIn, 1, 4);
            this.CoTableLayoutPanel3.Controls.Add(this.label33, 0, 7);
            this.CoTableLayoutPanel3.Controls.Add(this.textBoxMedicineHdsd, 1, 7);
            this.CoTableLayoutPanel3.Location = new System.Drawing.Point(8, 226);
            this.CoTableLayoutPanel3.Name = "CoTableLayoutPanel3";
            this.CoTableLayoutPanel3.RowCount = 8;
            this.CoTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.CoTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.CoTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.CoTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.CoTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.CoTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.CoTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CoTableLayoutPanel3.Size = new System.Drawing.Size(808, 291);
            this.CoTableLayoutPanel3.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 18);
            this.label13.TabIndex = 16;
            this.label13.Text = "ID:";
            // 
            // lblInputMedicineNewId
            // 
            this.lblInputMedicineNewId.AutoSize = true;
            this.lblInputMedicineNewId.Location = new System.Drawing.Point(408, 43);
            this.lblInputMedicineNewId.Name = "lblInputMedicineNewId";
            this.lblInputMedicineNewId.Size = new System.Drawing.Size(153, 18);
            this.lblInputMedicineNewId.TabIndex = 17;
            this.lblInputMedicineNewId.Text = "lblInputMedicineNewId";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 84);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 18);
            this.label20.TabIndex = 6;
            this.label20.Text = "Tên Thuốc";
            // 
            // txtBoxInputMedicineNewName
            // 
            this.txtBoxInputMedicineNewName.Location = new System.Drawing.Point(408, 87);
            this.txtBoxInputMedicineNewName.Name = "txtBoxInputMedicineNewName";
            this.txtBoxInputMedicineNewName.Size = new System.Drawing.Size(383, 24);
            this.txtBoxInputMedicineNewName.TabIndex = 6;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 119);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 18);
            this.label21.TabIndex = 8;
            this.label21.Text = "Số lượng";
            // 
            // txtBoxInputMedicineNewCount
            // 
            this.txtBoxInputMedicineNewCount.Location = new System.Drawing.Point(408, 122);
            this.txtBoxInputMedicineNewCount.Name = "txtBoxInputMedicineNewCount";
            this.txtBoxInputMedicineNewCount.Size = new System.Drawing.Size(383, 24);
            this.txtBoxInputMedicineNewCount.TabIndex = 7;
            this.txtBoxInputMedicineNewCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInputMedicineNewCount_KeyPress);
            // 
            // txtBoxInputMedicineNewCostOut
            // 
            this.txtBoxInputMedicineNewCostOut.Location = new System.Drawing.Point(408, 196);
            this.txtBoxInputMedicineNewCostOut.Name = "txtBoxInputMedicineNewCostOut";
            this.txtBoxInputMedicineNewCostOut.Size = new System.Drawing.Size(383, 24);
            this.txtBoxInputMedicineNewCostOut.TabIndex = 9;
            this.txtBoxInputMedicineNewCostOut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInputMedicineNewCostOut_KeyPress);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(6, 3);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(162, 26);
            this.label22.TabIndex = 10;
            this.label22.Text = "Form Nhập Mới";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label26.Location = new System.Drawing.Point(408, 3);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(388, 37);
            label26.TabIndex = 26;
            label26.Text = "Đây là khung nhập mới thuốc , số Id là mặc định";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 229);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(81, 18);
            this.label25.TabIndex = 25;
            this.label25.Text = "Ngày Nhập";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(408, 232);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(383, 24);
            this.dateTimePicker3.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 193);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 18);
            this.label12.TabIndex = 13;
            this.label12.Text = "Giá Out";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 18);
            this.label8.TabIndex = 27;
            this.label8.Text = "Giá In";
            // 
            // txtBoxInputMedicineNewCostIn
            // 
            this.txtBoxInputMedicineNewCostIn.Location = new System.Drawing.Point(408, 163);
            this.txtBoxInputMedicineNewCostIn.Name = "txtBoxInputMedicineNewCostIn";
            this.txtBoxInputMedicineNewCostIn.Size = new System.Drawing.Size(383, 24);
            this.txtBoxInputMedicineNewCostIn.TabIndex = 8;
            this.txtBoxInputMedicineNewCostIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInputMedicineNewCostIn_KeyPress);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 262);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(79, 18);
            this.label33.TabIndex = 28;
            this.label33.Text = "Cách dùng";
            // 
            // textBoxMedicineHdsd
            // 
            this.textBoxMedicineHdsd.Location = new System.Drawing.Point(408, 265);
            this.textBoxMedicineHdsd.Name = "textBoxMedicineHdsd";
            this.textBoxMedicineHdsd.Size = new System.Drawing.Size(383, 24);
            this.textBoxMedicineHdsd.TabIndex = 29;
            // 
            // CoTableLayoutPanel6
            // 
            this.CoTableLayoutPanel6.BackColor = System.Drawing.Color.DarkGray;
            this.CoTableLayoutPanel6.ColumnCount = 3;
            this.CoTableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.20567F));
            this.CoTableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.79433F));
            this.CoTableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.CoTableLayoutPanel6.Controls.Add(this.label39, 0, 1);
            this.CoTableLayoutPanel6.Controls.Add(this.label40, 0, 2);
            this.CoTableLayoutPanel6.Controls.Add(this.textBoxBackupSource, 1, 0);
            this.CoTableLayoutPanel6.Controls.Add(this.textBoxBackupTarget, 1, 1);
            this.CoTableLayoutPanel6.Controls.Add(this.textBoxBackupTimeAuto, 1, 2);
            this.CoTableLayoutPanel6.Controls.Add(this.button2, 2, 0);
            this.CoTableLayoutPanel6.Controls.Add(this.button4, 2, 1);
            this.CoTableLayoutPanel6.Controls.Add(this.checkBoxAutoCopy, 2, 2);
            this.CoTableLayoutPanel6.Controls.Add(this.label38, 0, 0);
            this.CoTableLayoutPanel6.Location = new System.Drawing.Point(24, 351);
            this.CoTableLayoutPanel6.Name = "CoTableLayoutPanel6";
            this.CoTableLayoutPanel6.RowCount = 3;
            this.CoTableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoTableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoTableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.CoTableLayoutPanel6.Size = new System.Drawing.Size(552, 124);
            this.CoTableLayoutPanel6.TabIndex = 32;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(3, 44);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(70, 36);
            this.label39.TabIndex = 1;
            this.label39.Text = "Thư mục backup:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(3, 88);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(77, 36);
            this.label40.TabIndex = 2;
            this.label40.Text = "Thời gian(phút):";
            // 
            // textBoxBackupSource
            // 
            this.textBoxBackupSource.Location = new System.Drawing.Point(87, 3);
            this.textBoxBackupSource.Name = "textBoxBackupSource";
            this.textBoxBackupSource.Size = new System.Drawing.Size(181, 24);
            this.textBoxBackupSource.TabIndex = 3;
            // 
            // textBoxBackupTarget
            // 
            this.textBoxBackupTarget.Location = new System.Drawing.Point(87, 47);
            this.textBoxBackupTarget.Name = "textBoxBackupTarget";
            this.textBoxBackupTarget.Size = new System.Drawing.Size(181, 24);
            this.textBoxBackupTarget.TabIndex = 4;
            // 
            // textBoxBackupTimeAuto
            // 
            this.textBoxBackupTimeAuto.Location = new System.Drawing.Point(87, 91);
            this.textBoxBackupTimeAuto.Name = "textBoxBackupTimeAuto";
            this.textBoxBackupTimeAuto.Size = new System.Drawing.Size(100, 24);
            this.textBoxBackupTimeAuto.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(274, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 38);
            this.button2.TabIndex = 6;
            this.button2.Text = "Duyệt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(274, 47);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 38);
            this.button4.TabIndex = 7;
            this.button4.Text = "Duyệt";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBoxAutoCopy
            // 
            this.checkBoxAutoCopy.AutoSize = true;
            this.checkBoxAutoCopy.Location = new System.Drawing.Point(274, 91);
            this.checkBoxAutoCopy.Name = "checkBoxAutoCopy";
            this.checkBoxAutoCopy.Size = new System.Drawing.Size(93, 22);
            this.checkBoxAutoCopy.TabIndex = 8;
            this.checkBoxAutoCopy.Text = "Auto copy";
            this.checkBoxAutoCopy.UseVisualStyleBackColor = true;
            this.checkBoxAutoCopy.CheckedChanged += new System.EventHandler(this.checkBoxAutoCopy_CheckedChanged);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(3, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(70, 36);
            this.label38.TabIndex = 0;
            this.label38.Text = "Thư mục data:";
            // 
            // CoTableLayoutPanel5
            // 
            this.CoTableLayoutPanel5.BackColor = System.Drawing.Color.DarkGray;
            this.CoTableLayoutPanel5.ColumnCount = 2;
            this.CoTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.95951F));
            this.CoTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.04049F));
            this.CoTableLayoutPanel5.Controls.Add(this.textBoxNameClinic, 1, 0);
            this.CoTableLayoutPanel5.Controls.Add(this.textBoxAddressClinic, 1, 1);
            this.CoTableLayoutPanel5.Controls.Add(this.textBoxAdviceClinic, 1, 2);
            this.CoTableLayoutPanel5.Controls.Add(this.label37, 0, 2);
            this.CoTableLayoutPanel5.Controls.Add(this.label36, 0, 1);
            this.CoTableLayoutPanel5.Controls.Add(this.label35, 0, 0);
            this.CoTableLayoutPanel5.Controls.Add(this.labelSdt, 0, 3);
            this.CoTableLayoutPanel5.Controls.Add(this.textBoxSDT, 1, 3);
            this.CoTableLayoutPanel5.Location = new System.Drawing.Point(783, 13);
            this.CoTableLayoutPanel5.Name = "CoTableLayoutPanel5";
            this.CoTableLayoutPanel5.RowCount = 4;
            this.CoTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.CoTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.CoTableLayoutPanel5.Size = new System.Drawing.Size(494, 144);
            this.CoTableLayoutPanel5.TabIndex = 30;
            // 
            // textBoxNameClinic
            // 
            this.textBoxNameClinic.Location = new System.Drawing.Point(150, 3);
            this.textBoxNameClinic.Name = "textBoxNameClinic";
            this.textBoxNameClinic.Size = new System.Drawing.Size(287, 24);
            this.textBoxNameClinic.TabIndex = 2;
            // 
            // textBoxAddressClinic
            // 
            this.textBoxAddressClinic.Location = new System.Drawing.Point(150, 46);
            this.textBoxAddressClinic.Name = "textBoxAddressClinic";
            this.textBoxAddressClinic.Size = new System.Drawing.Size(290, 24);
            this.textBoxAddressClinic.TabIndex = 3;
            // 
            // textBoxAdviceClinic
            // 
            this.textBoxAdviceClinic.Location = new System.Drawing.Point(150, 89);
            this.textBoxAdviceClinic.Name = "textBoxAdviceClinic";
            this.textBoxAdviceClinic.Size = new System.Drawing.Size(290, 24);
            this.textBoxAdviceClinic.TabIndex = 5;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(3, 86);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(56, 18);
            this.label37.TabIndex = 4;
            this.label37.Text = "Lời dặn";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(3, 43);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(53, 18);
            this.label36.TabIndex = 1;
            this.label36.Text = "Địa chỉ";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(3, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(119, 18);
            this.label35.TabIndex = 0;
            this.label35.Text = "Tên phòng khám";
            // 
            // labelSdt
            // 
            this.labelSdt.AutoSize = true;
            this.labelSdt.Location = new System.Drawing.Point(3, 117);
            this.labelSdt.Name = "labelSdt";
            this.labelSdt.Size = new System.Drawing.Size(42, 18);
            this.labelSdt.TabIndex = 6;
            this.labelSdt.Text = "SĐT:";
            // 
            // textBoxSDT
            // 
            this.textBoxSDT.Location = new System.Drawing.Point(150, 120);
            this.textBoxSDT.Name = "textBoxSDT";
            this.textBoxSDT.Size = new System.Drawing.Size(287, 24);
            this.textBoxSDT.TabIndex = 7;
            // 
            // CoTableLayoutPanel2
            // 
            this.CoTableLayoutPanel2.BackColor = System.Drawing.Color.Gainsboro;
            this.CoTableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.CoTableLayoutPanel2.ColumnCount = 4;
            this.CoTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.01303F));
            this.CoTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.98697F));
            this.CoTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.CoTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 378F));
            this.CoTableLayoutPanel2.Controls.Add(this.label11, 0, 0);
            this.CoTableLayoutPanel2.Controls.Add(this.comboBoxWaitRoomId, 1, 0);
            this.CoTableLayoutPanel2.Controls.Add(this.txtBoxWaitRoomHeight, 3, 0);
            this.CoTableLayoutPanel2.Controls.Add(this.txtBoxWaitRoomDiagnose, 3, 3);
            this.CoTableLayoutPanel2.Controls.Add(this.label17, 2, 3);
            this.CoTableLayoutPanel2.Controls.Add(this.lblWaitRoomName, 0, 1);
            this.CoTableLayoutPanel2.Controls.Add(this.txtBoxWaitRoomName, 1, 1);
            this.CoTableLayoutPanel2.Controls.Add(this.label16, 2, 2);
            this.CoTableLayoutPanel2.Controls.Add(this.txtBoxWaitingRoomSymptom, 3, 2);
            this.CoTableLayoutPanel2.Controls.Add(this.lblWaitRoomBirthday, 0, 2);
            this.CoTableLayoutPanel2.Controls.Add(this.txtBoxWaitingRoomWeight, 3, 1);
            this.CoTableLayoutPanel2.Controls.Add(this.dateTimePicker2, 1, 2);
            this.CoTableLayoutPanel2.Controls.Add(this.label15, 2, 1);
            this.CoTableLayoutPanel2.Controls.Add(this.lblWaitRoomAddress, 0, 3);
            this.CoTableLayoutPanel2.Controls.Add(this.txtBoxWaitRoomAddress, 1, 3);
            this.CoTableLayoutPanel2.Controls.Add(this.label14, 2, 0);
            this.CoTableLayoutPanel2.Location = new System.Drawing.Point(9, 12);
            this.CoTableLayoutPanel2.Name = "CoTableLayoutPanel2";
            this.CoTableLayoutPanel2.RowCount = 4;
            this.CoTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.CoTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.CoTableLayoutPanel2.Size = new System.Drawing.Size(778, 144);
            this.CoTableLayoutPanel2.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Id";
            // 
            // comboBoxWaitRoomId
            // 
            this.comboBoxWaitRoomId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxWaitRoomId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxWaitRoomId.FormattingEnabled = true;
            this.comboBoxWaitRoomId.Location = new System.Drawing.Point(87, 6);
            this.comboBoxWaitRoomId.Name = "comboBoxWaitRoomId";
            this.comboBoxWaitRoomId.Size = new System.Drawing.Size(98, 21);
            this.comboBoxWaitRoomId.TabIndex = 0;
            // 
            // txtBoxWaitRoomHeight
            // 
            this.txtBoxWaitRoomHeight.Location = new System.Drawing.Point(399, 6);
            this.txtBoxWaitRoomHeight.Name = "txtBoxWaitRoomHeight";
            this.txtBoxWaitRoomHeight.Size = new System.Drawing.Size(100, 20);
            this.txtBoxWaitRoomHeight.TabIndex = 4;
            // 
            // txtBoxWaitRoomDiagnose
            // 
            this.txtBoxWaitRoomDiagnose.Location = new System.Drawing.Point(399, 110);
            this.txtBoxWaitRoomDiagnose.Name = "txtBoxWaitRoomDiagnose";
            this.txtBoxWaitRoomDiagnose.Size = new System.Drawing.Size(297, 20);
            this.txtBoxWaitRoomDiagnose.TabIndex = 7;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(291, 107);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 13);
            this.label17.TabIndex = 14;
            this.label17.Text = "Chẩn đoán";
            // 
            // lblWaitRoomName
            // 
            this.lblWaitRoomName.AutoSize = true;
            this.lblWaitRoomName.Location = new System.Drawing.Point(6, 36);
            this.lblWaitRoomName.Name = "lblWaitRoomName";
            this.lblWaitRoomName.Size = new System.Drawing.Size(26, 13);
            this.lblWaitRoomName.TabIndex = 0;
            this.lblWaitRoomName.Text = "Tên";
            // 
            // txtBoxWaitRoomName
            // 
            this.txtBoxWaitRoomName.Location = new System.Drawing.Point(87, 39);
            this.txtBoxWaitRoomName.Name = "txtBoxWaitRoomName";
            this.txtBoxWaitRoomName.Size = new System.Drawing.Size(174, 20);
            this.txtBoxWaitRoomName.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(291, 69);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Triệu chứng";
            // 
            // txtBoxWaitingRoomSymptom
            // 
            this.txtBoxWaitingRoomSymptom.Location = new System.Drawing.Point(399, 72);
            this.txtBoxWaitingRoomSymptom.Name = "txtBoxWaitingRoomSymptom";
            this.txtBoxWaitingRoomSymptom.Size = new System.Drawing.Size(297, 20);
            this.txtBoxWaitingRoomSymptom.TabIndex = 6;
            // 
            // lblWaitRoomBirthday
            // 
            this.lblWaitRoomBirthday.AutoSize = true;
            this.lblWaitRoomBirthday.Location = new System.Drawing.Point(6, 69);
            this.lblWaitRoomBirthday.Name = "lblWaitRoomBirthday";
            this.lblWaitRoomBirthday.Size = new System.Drawing.Size(54, 13);
            this.lblWaitRoomBirthday.TabIndex = 16;
            this.lblWaitRoomBirthday.Text = "Ngày sinh";
            // 
            // txtBoxWaitingRoomWeight
            // 
            this.txtBoxWaitingRoomWeight.Location = new System.Drawing.Point(399, 39);
            this.txtBoxWaitingRoomWeight.Name = "txtBoxWaitingRoomWeight";
            this.txtBoxWaitingRoomWeight.Size = new System.Drawing.Size(100, 20);
            this.txtBoxWaitingRoomWeight.TabIndex = 5;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(87, 72);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(125, 20);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(291, 36);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Nặng";
            // 
            // lblWaitRoomAddress
            // 
            this.lblWaitRoomAddress.AutoSize = true;
            this.lblWaitRoomAddress.Location = new System.Drawing.Point(6, 107);
            this.lblWaitRoomAddress.Name = "lblWaitRoomAddress";
            this.lblWaitRoomAddress.Size = new System.Drawing.Size(40, 13);
            this.lblWaitRoomAddress.TabIndex = 7;
            this.lblWaitRoomAddress.Text = "Địa chỉ";
            // 
            // txtBoxWaitRoomAddress
            // 
            this.txtBoxWaitRoomAddress.Location = new System.Drawing.Point(87, 110);
            this.txtBoxWaitRoomAddress.Name = "txtBoxWaitRoomAddress";
            this.txtBoxWaitRoomAddress.Size = new System.Drawing.Size(166, 20);
            this.txtBoxWaitRoomAddress.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(291, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Chiều Cao";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 707);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.MainTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Phòng Khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMedicine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchValue)).EndInit();
            this.Calendar.ResumeLayout(false);
            this.panelCalendarDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCalendar)).EndInit();
            this.panelCalendar.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPagenhapthuoc.ResumeLayout(false);
            this.tabPageTools.ResumeLayout(false);
            this.tabPageTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.tabPagePrint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.CoTableLayoutPanel1.ResumeLayout(false);
            this.CoTableLayoutPanel1.PerformLayout();
            this.CoTableLayoutPanel7.ResumeLayout(false);
            this.CoTableLayoutPanel7.PerformLayout();
            this.CoTableLayoutPanel4.ResumeLayout(false);
            this.CoTableLayoutPanel4.PerformLayout();
            this.CoTableLayoutPanel3.ResumeLayout(false);
            this.CoTableLayoutPanel3.PerformLayout();
            this.CoTableLayoutPanel6.ResumeLayout(false);
            this.CoTableLayoutPanel6.PerformLayout();
            this.CoTableLayoutPanel5.ResumeLayout(false);
            this.CoTableLayoutPanel5.PerformLayout();
            this.CoTableLayoutPanel2.ResumeLayout(false);
            this.CoTableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtBoxClinicRoomDiagnose;
        private System.Windows.Forms.TextBox txtBoxClinicRoomSymptom;
        private System.Windows.Forms.TextBox txtBoxClinicRoomWeight;
        private System.Windows.Forms.TextBox txtBoxClinicRoomAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnWaitRoomCancel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtBoxWaitRoomDiagnose;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtBoxWaitingRoomWeight;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBoxWaitRoomAddress;
        private System.Windows.Forms.Label lblWaitRoomAddress;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button btnWaitRoomOK;
        private System.Windows.Forms.TextBox txtBoxWaitingRoomSymptom;
        private System.Windows.Forms.Label lblWaitRoomBirthday;
        private System.Windows.Forms.TextBox txtBoxWaitRoomName;
        private System.Windows.Forms.Label lblWaitRoomName; //NT Tên
        private System.Windows.Forms.TabPage tabPagenhapthuoc;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnInputMedicineNewOk;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtBoxInputMedicineNewCount;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtBoxInputMedicineNewName;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnInputMedicineOk;
        private System.Windows.Forms.ComboBox comboBoxInputMedicineName;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox comboBoxWaitRoomId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBoxWaitRoomHeight;
        private System.Windows.Forms.Button btnWaitRoomContinue;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.TextBox txtBoxInputMedicineNewCostOut;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblInputMedicineNewId;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtBoxInputMedicineAdd;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblInputMedicineCount;
        private CoTableLayoutPanel CoTableLayoutPanel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private CoTableLayoutPanel CoTableLayoutPanel3;
        private System.Windows.Forms.Label label25;
        private CoTableLayoutPanel CoTableLayoutPanel4;
        private System.Windows.Forms.Label label27;
        private CoTableLayoutPanel CoTableLayoutPanel1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lblClinicRoomId;
        private System.Windows.Forms.TextBox txtBoxClinicRoomHeight;
        private System.Windows.Forms.Label labelTongTien;
        private System.Windows.Forms.DataGridViewColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dataGridViewSearchValue;
        private System.Windows.Forms.TextBox comboBoxClinicRoomName;
        private DataGridView dataGridViewMedicine;
        private Button buttonPutIn;
        private Label label8;
        private TextBox txtBoxInputMedicineNewCostIn;
        private Label label9;
        private TabPage tabPageTools;
        private Button buttonCreateUser;
        private CheckBox checkBoxNhapThuoc;
        private Label label29;
        private Label label10;
        private TextBox textBox2;
        private TextBox textBox1;
        private DataGridView dataGridView4;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column22;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column23;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column24;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column25;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column26;
        private DateTimePicker dateTimePickerBirthDay;
        private DateTimePicker dateTimePickerNgayKham;
        private Label label31;
        private Label label32;
        private TextBox textBox3;
        private DateTimePicker dateTimePicker6;
        private Label label34;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn Column18;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn Column19;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column20;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column21;
        private CheckBox checkBoxKethuoc;
        private TabPage tabPagePrint;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
       
        private TabPage Calendar;
        private Panel panelCalendar;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private Panel panelCalendarDate;

        private MonthView tabPageLich;
        private System.Windows.Forms.Calendar.Calendar calendar1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem redTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yellowTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem timescaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem editItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minutesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem minutesToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem minutesToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem otherColorTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patternToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagonalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem selectImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageAlignmentToolStripMenuItem;
        private PictureBox pictureBox1;
        private Label label33;
        private TextBox textBoxMedicineHdsd;
        private DataGridViewTextBoxColumn dataGridViewMedicinesId;
        private Button button1;
        private CoTableLayoutPanel CoTableLayoutPanel5;
        private Label label35;
        private TextBox textBoxNameClinic;
        private TextBox textBoxAddressClinic;
        private TextBox textBoxAdviceClinic;
        private Label label37;
        private Label label36;
        private CoTableLayoutPanel CoTableLayoutPanel6;
        private Label label38;
        private Label label39;
        private Label label40;
        private TextBox textBoxBackupSource;
        private TextBox textBoxBackupTarget;
        private TextBox textBoxBackupTimeAuto;
        private Button button2;
        private Button button4;
        private CheckBox checkBoxAutoCopy;
        private Button buttonServicesCancel;
        private Button buttonServicesOK;
        private CoTableLayoutPanel CoTableLayoutPanel7;
        private Label label41;
        private Label label42;
        private TextBox textBoxServicesCost;
        private Label label43;
        private TextBox textBoxServices;
        private Label labelServicesID;
        private DataGridViewTextBoxColumn ColumnMedicinesHDSD;
        private Label label44;
        private TextBox textBoxClinicPhone;
        private Button buttonClinicCreateNew;
        private Button buttonClinicClear;
        private TextBox textBoxClinicNhietDo;
        private Label label45;
        private TextBox textBoxNameDoctor;
        private Label label46;
        private DateTimePicker dateTimePickerHen;
        private DataGridView dataGridViewCalendar;
        private PictureBox pictureBox2;
        private Button buttonList;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem programToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem doanhThuToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private CheckBox checkBoxHen;
        private Label labelSdt;
        private TextBox textBoxSDT;
        private DataGridViewTextBoxColumn ColumnID;
        private DataGridViewTextBoxColumn ColumnNamePatient;
        private DataGridViewTextBoxColumn ColumnNgaySinh;
        private DataGridViewTextBoxColumn ColumnNgayKham;
        private DataGridViewTextBoxColumn ColumnAddress;
        private DataGridViewTextBoxColumn ColumnSymtom;
        private DataGridViewTextBoxColumn ColumnNhietDo;
        private DataGridViewTextBoxColumn ColumnHuyetAp;
        private DataGridViewTextBoxColumn ColumnDiagno;
        private DataGridViewTextBoxColumn ColumnSearchValueMedicines;
        private Label label30;
        private TextBox textBoxHuyetAp;
        private Label label47;
        private Label labelTuoi;
        private ToolStripMenuItem doanhThuToolStripMenuItem1;
        private ToolStripMenuItem tủThuốcToolStripMenuItem;
        private ToolStripMenuItem cácDịchVụToolStripMenuItem;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Patient;
        private DataGridViewTextBoxColumn phone;
        private DataGridViewTextBoxColumn sick;
        private DataGridViewTextBoxColumn dataGridViewButtonColumn1;
        private DataGridViewButtonColumn ColumnKhamVaXoa;
        private Button button3;
        private CheckBox ShowMedicines;
        private CheckBox ShowBigForm;
        private CheckBox Show1Record;

        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress1;
        private ToolStripMenuItem mởRộngToolStripMenuItem;
        private ToolStripMenuItem loaiKhamToolStripMenuItem;
        private ToolStripMenuItem thêmLoạiToolStripMenuItem;
        private ComboBox comboBoxLoaiKham;
        private Label label48;
        private TextBox textBoxAdminOfService;
    }
}

