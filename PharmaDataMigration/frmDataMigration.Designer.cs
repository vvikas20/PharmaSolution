namespace PharmaDataMigration
{
    partial class frmDataMigration
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
            this.txtDataDirectory = new System.Windows.Forms.TextBox();
            this.lblDataDirectory = new System.Windows.Forms.Label();
            this.btnDataDirectory = new System.Windows.Forms.Button();
            this.fbdDataDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.btnStartMigration = new System.Windows.Forms.Button();
            this.grdDataMigration = new System.Windows.Forms.DataGridView();
            this.colTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecordCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataMigration)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDataDirectory
            // 
            this.txtDataDirectory.Location = new System.Drawing.Point(142, 35);
            this.txtDataDirectory.Name = "txtDataDirectory";
            this.txtDataDirectory.Size = new System.Drawing.Size(337, 20);
            this.txtDataDirectory.TabIndex = 0;
            // 
            // lblDataDirectory
            // 
            this.lblDataDirectory.AutoSize = true;
            this.lblDataDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataDirectory.Location = new System.Drawing.Point(37, 35);
            this.lblDataDirectory.Name = "lblDataDirectory";
            this.lblDataDirectory.Size = new System.Drawing.Size(99, 17);
            this.lblDataDirectory.TabIndex = 1;
            this.lblDataDirectory.Text = "Data Directory";
            // 
            // btnDataDirectory
            // 
            this.btnDataDirectory.Location = new System.Drawing.Point(485, 33);
            this.btnDataDirectory.Name = "btnDataDirectory";
            this.btnDataDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnDataDirectory.TabIndex = 2;
            this.btnDataDirectory.Text = "Browse";
            this.btnDataDirectory.UseVisualStyleBackColor = true;
            this.btnDataDirectory.Click += new System.EventHandler(this.btnDataDirectory_Click);
            // 
            // btnStartMigration
            // 
            this.btnStartMigration.Location = new System.Drawing.Point(566, 32);
            this.btnStartMigration.Name = "btnStartMigration";
            this.btnStartMigration.Size = new System.Drawing.Size(138, 24);
            this.btnStartMigration.TabIndex = 3;
            this.btnStartMigration.Text = "Start Migration";
            this.btnStartMigration.UseVisualStyleBackColor = true;
            this.btnStartMigration.Click += new System.EventHandler(this.btnStartMigration_Click);
            // 
            // grdDataMigration
            // 
            this.grdDataMigration.AllowUserToDeleteRows = false;
            this.grdDataMigration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDataMigration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDataMigration.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTableName,
            this.colStatus,
            this.colRecordCount});
            this.grdDataMigration.Location = new System.Drawing.Point(40, 63);
            this.grdDataMigration.Name = "grdDataMigration";
            this.grdDataMigration.ReadOnly = true;
            this.grdDataMigration.Size = new System.Drawing.Size(831, 448);
            this.grdDataMigration.TabIndex = 4;
            // 
            // colTableName
            // 
            this.colTableName.HeaderText = "Table Name";
            this.colTableName.MinimumWidth = 10;
            this.colTableName.Name = "colTableName";
            this.colTableName.ReadOnly = true;
            this.colTableName.Width = 250;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 10;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 120;
            // 
            // colRecordCount
            // 
            this.colRecordCount.HeaderText = "# Rows Inserted";
            this.colRecordCount.MinimumWidth = 10;
            this.colRecordCount.Name = "colRecordCount";
            this.colRecordCount.ReadOnly = true;
            // 
            // frmDataMigration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 523);
            this.Controls.Add(this.grdDataMigration);
            this.Controls.Add(this.btnStartMigration);
            this.Controls.Add(this.btnDataDirectory);
            this.Controls.Add(this.lblDataDirectory);
            this.Controls.Add(this.txtDataDirectory);
            this.Name = "frmDataMigration";
            this.Text = "Data Migration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDataMigration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDataMigration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDataDirectory;
        private System.Windows.Forms.Label lblDataDirectory;
        private System.Windows.Forms.Button btnDataDirectory;
        private System.Windows.Forms.FolderBrowserDialog fbdDataDirectory;
        private System.Windows.Forms.Button btnStartMigration;
        private System.Windows.Forms.DataGridView grdDataMigration;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecordCount;
    }
}

