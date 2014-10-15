namespace Clinic
{
    partial class TuThuocForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCostIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCostOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInputDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnName,
            this.ColumnCount,
            this.ColumnCostIn,
            this.ColumnCostOut,
            this.ColumnInputDay});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1053, 523);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColumnId
            // 
            this.ColumnId.HeaderText = "ID";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Tên Thuốc";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 200;
            // 
            // ColumnCount
            // 
            this.ColumnCount.HeaderText = "Số Lượng";
            this.ColumnCount.Name = "ColumnCount";
            // 
            // ColumnCostIn
            // 
            this.ColumnCostIn.HeaderText = "Giá vào";
            this.ColumnCostIn.Name = "ColumnCostIn";
            this.ColumnCostIn.ReadOnly = true;
            // 
            // ColumnCostOut
            // 
            this.ColumnCostOut.HeaderText = "Giá ra";
            this.ColumnCostOut.Name = "ColumnCostOut";
            this.ColumnCostOut.ReadOnly = true;
            // 
            // ColumnInputDay
            // 
            this.ColumnInputDay.HeaderText = "Ngày Nhập";
            this.ColumnInputDay.Name = "ColumnInputDay";
            this.ColumnInputDay.ReadOnly = true;
            this.ColumnInputDay.Width = 150;
            // 
            // TuThuocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 606);
            this.Controls.Add(this.dataGridView1);
            this.Name = "TuThuocForm";
            this.Text = "Tủ Thuốc";
            this.Load += new System.EventHandler(this.TuThuocForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCostIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCostOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInputDay;
    }
}