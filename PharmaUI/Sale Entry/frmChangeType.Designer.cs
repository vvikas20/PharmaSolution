namespace PharmaUI
{
    partial class frmChangeType
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
            this.dgvChangeType = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChangeType)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChangeType
            // 
            this.dgvChangeType.AllowUserToAddRows = false;
            this.dgvChangeType.AllowUserToDeleteRows = false;
            this.dgvChangeType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChangeType.Location = new System.Drawing.Point(13, 60);
            this.dgvChangeType.Name = "dgvChangeType";
            this.dgvChangeType.ReadOnly = true;
            this.dgvChangeType.Size = new System.Drawing.Size(358, 150);
            this.dgvChangeType.TabIndex = 0;
            // 
            // frmChangeType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 259);
            this.Controls.Add(this.dgvChangeType);
            this.Name = "frmChangeType";
            this.Text = "frmChangeType";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChangeType_FormClosing);
            this.Load += new System.EventHandler(this.frmChangeType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChangeType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChangeType;
    }
}