namespace Clinic
{
    partial class DoanhThuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoanhThuForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIdPatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNamePatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServices = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.G2NameDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G2SoLuotKham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G2TongCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.PatientNumber = new System.Windows.Forms.Label();
            this.PatientCountLabel = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PDFShowDoanhThu = new AxAcroPDFLib.AxAcroPDF();
            this.ColumnServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServiceAdmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServiceCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServiceTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLoaiKham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.ColumnLkName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLkCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PDFShowDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.date,
            this.NameDoctor,
            this.Money,
            this.ColumnIdPatient,
            this.ColumnNamePatient,
            this.ColumnServices,
            this.ColumnLoaiKham});
            this.dataGridView1.Location = new System.Drawing.Point(3, 340);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1323, 505);
            this.dataGridView1.TabIndex = 0;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // date
            // 
            this.date.HeaderText = "Ngày tháng";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // NameDoctor
            // 
            this.NameDoctor.HeaderText = "Tên bác sĩ";
            this.NameDoctor.Name = "NameDoctor";
            this.NameDoctor.ReadOnly = true;
            this.NameDoctor.Width = 200;
            // 
            // Money
            // 
            this.Money.HeaderText = "Số tiền";
            this.Money.Name = "Money";
            this.Money.ReadOnly = true;
            this.Money.Width = 150;
            // 
            // ColumnIdPatient
            // 
            this.ColumnIdPatient.HeaderText = "Id bệnh nhân";
            this.ColumnIdPatient.Name = "ColumnIdPatient";
            // 
            // ColumnNamePatient
            // 
            this.ColumnNamePatient.HeaderText = "Tên bệnh nhân";
            this.ColumnNamePatient.Name = "ColumnNamePatient";
            this.ColumnNamePatient.Width = 200;
            // 
            // ColumnServices
            // 
            this.ColumnServices.HeaderText = "Các dịch vụ";
            this.ColumnServices.Name = "ColumnServices";
            this.ColumnServices.Width = 350;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.G2NameDoctor,
            this.G2SoLuotKham,
            this.G2TongCong});
            this.dataGridView2.Location = new System.Drawing.Point(777, 6);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(475, 108);
            this.dataGridView2.TabIndex = 2;
            // 
            // G2NameDoctor
            // 
            this.G2NameDoctor.HeaderText = "Tên bác sĩ";
            this.G2NameDoctor.Name = "G2NameDoctor";
            this.G2NameDoctor.ReadOnly = true;
            this.G2NameDoctor.Width = 185;
            // 
            // G2SoLuotKham
            // 
            this.G2SoLuotKham.HeaderText = "Lượt Khám";
            this.G2SoLuotKham.Name = "G2SoLuotKham";
            // 
            // G2TongCong
            // 
            this.G2TongCong.HeaderText = "Tổng Cộng";
            this.G2TongCong.Name = "G2TongCong";
            this.G2TongCong.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tổng cộng:";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(115, 148);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(29, 31);
            this.labelTotal.TabIndex = 4;
            this.labelTotal.Text = "0";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(314, 103);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(648, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ngày";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(648, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Tháng";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1337, 874);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView4);
            this.tabPage1.Controls.Add(this.dataGridView3);
            this.tabPage1.Controls.Add(this.PatientNumber);
            this.tabPage1.Controls.Add(this.PatientCountLabel);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.labelTotal);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1329, 848);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Doanh Thu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnServiceName,
            this.ColumnServiceAdmin,
            this.ColumnServiceCount,
            this.ColumnServiceTotal});
            this.dataGridView3.Location = new System.Drawing.Point(777, 119);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(475, 90);
            this.dataGridView3.TabIndex = 12;
            // 
            // PatientNumber
            // 
            this.PatientNumber.AutoSize = true;
            this.PatientNumber.Location = new System.Drawing.Point(108, 85);
            this.PatientNumber.Name = "PatientNumber";
            this.PatientNumber.Size = new System.Drawing.Size(13, 13);
            this.PatientNumber.TabIndex = 11;
            this.PatientNumber.Text = "0";
            // 
            // PatientCountLabel
            // 
            this.PatientCountLabel.AutoSize = true;
            this.PatientCountLabel.Location = new System.Drawing.Point(26, 85);
            this.PatientCountLabel.Name = "PatientCountLabel";
            this.PatientCountLabel.Size = new System.Drawing.Size(62, 13);
            this.PatientCountLabel.TabIndex = 10;
            this.PatientCountLabel.Text = "Bệnh nhân:";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(564, 24);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 56);
            this.button4.TabIndex = 9;
            this.button4.Text = "Close";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button3.Location = new System.Drawing.Point(392, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 55);
            this.button3.TabIndex = 8;
            this.button3.Text = "Print";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PDFShowDoanhThu);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1329, 848);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Print";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // PDFShowDoanhThu
            // 
            this.PDFShowDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PDFShowDoanhThu.Enabled = true;
            this.PDFShowDoanhThu.Location = new System.Drawing.Point(3, 3);
            this.PDFShowDoanhThu.Name = "PDFShowDoanhThu";
            this.PDFShowDoanhThu.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("PDFShowDoanhThu.OcxState")));
            this.PDFShowDoanhThu.Size = new System.Drawing.Size(1323, 842);
            this.PDFShowDoanhThu.TabIndex = 0;
            // 
            // ColumnServiceName
            // 
            this.ColumnServiceName.HeaderText = "Tên Dịch Vụ";
            this.ColumnServiceName.Name = "ColumnServiceName";
            // 
            // ColumnServiceAdmin
            // 
            this.ColumnServiceAdmin.HeaderText = "Người phụ trách";
            this.ColumnServiceAdmin.Name = "ColumnServiceAdmin";
            // 
            // ColumnServiceCount
            // 
            this.ColumnServiceCount.HeaderText = "Số ca";
            this.ColumnServiceCount.Name = "ColumnServiceCount";
            // 
            // ColumnServiceTotal
            // 
            this.ColumnServiceTotal.HeaderText = "Tổng tiền";
            this.ColumnServiceTotal.Name = "ColumnServiceTotal";
            // 
            // ColumnLoaiKham
            // 
            this.ColumnLoaiKham.HeaderText = "Loại Khám";
            this.ColumnLoaiKham.Name = "ColumnLoaiKham";
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnLkName,
            this.ColumnLkCount});
            this.dataGridView4.Location = new System.Drawing.Point(777, 215);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(475, 102);
            this.dataGridView4.TabIndex = 13;
            // 
            // ColumnLkName
            // 
            this.ColumnLkName.HeaderText = "Tên Loại Khám";
            this.ColumnLkName.Name = "ColumnLkName";
            // 
            // ColumnLkCount
            // 
            this.ColumnLkCount.HeaderText = "Số Ca";
            this.ColumnLkCount.Name = "ColumnLkCount";
            // 
            // DoanhThuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 874);
            this.Controls.Add(this.tabControl1);
            this.Name = "DoanhThuForm";
            this.Text = "DoanhThuForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PDFShowDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private AxAcroPDFLib.AxAcroPDF PDFShowDoanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn G2NameDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn G2SoLuotKham;
        private System.Windows.Forms.DataGridViewTextBoxColumn G2TongCong;
        private System.Windows.Forms.Label PatientNumber;
        private System.Windows.Forms.Label PatientCountLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Money;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIdPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNamePatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServices;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceAdmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLoaiKham;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLkName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLkCount;
    }
}