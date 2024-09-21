namespace PharmaUI
{
    partial class frmItemDiscount
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtSpecialDiscount = new System.Windows.Forms.TextBox();
            this.txtVolumeDiscount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Discount (%)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Special Discount (%)";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(99, 57);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(100, 20);
            this.txtDiscount.TabIndex = 2;
            // 
            // txtSpecialDiscount
            // 
            this.txtSpecialDiscount.Location = new System.Drawing.Point(380, 57);
            this.txtSpecialDiscount.Name = "txtSpecialDiscount";
            this.txtSpecialDiscount.Size = new System.Drawing.Size(100, 20);
            this.txtSpecialDiscount.TabIndex = 3;
            // 
            // txtVolumeDiscount
            // 
            this.txtVolumeDiscount.Location = new System.Drawing.Point(640, 57);
            this.txtVolumeDiscount.Name = "txtVolumeDiscount";
            this.txtVolumeDiscount.Size = new System.Drawing.Size(100, 20);
            this.txtVolumeDiscount.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(510, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Volume Discount (%)";
            // 
            // frmItemDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 96);
            this.Controls.Add(this.txtVolumeDiscount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSpecialDiscount);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmItemDiscount";
            this.Text = "frmItemDiscount";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmItemDiscount_FormClosing);
            this.Load += new System.EventHandler(this.frmItemDiscount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtSpecialDiscount;
        private System.Windows.Forms.TextBox txtVolumeDiscount;
        private System.Windows.Forms.Label label3;
    }
}