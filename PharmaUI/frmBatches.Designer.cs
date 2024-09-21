namespace PharmaUI
{
    partial class frmBatches
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
            this.dgvbatchList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbatchList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvbatchList
            // 
            this.dgvbatchList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvbatchList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbatchList.Location = new System.Drawing.Point(12, 64);
            this.dgvbatchList.MultiSelect = false;
            this.dgvbatchList.Name = "dgvbatchList";
            this.dgvbatchList.ReadOnly = true;
            this.dgvbatchList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvbatchList.Size = new System.Drawing.Size(982, 384);
            this.dgvbatchList.TabIndex = 207;
            // 
            // frmBatches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 460);
            this.Controls.Add(this.dgvbatchList);
            this.Name = "frmBatches";
            this.Text = "frmBatches";
            this.Load += new System.EventHandler(this.frmBatches_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbatchList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvbatchList;
    }
}