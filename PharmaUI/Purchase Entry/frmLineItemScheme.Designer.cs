namespace PharmaUI.Purchase_Entry
{
    partial class frmLineItemScheme
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
            this.txtScheme2 = new System.Windows.Forms.TextBox();
            this.lblScheme = new System.Windows.Forms.Label();
            this.lblSchemeSign = new System.Windows.Forms.Label();
            this.lblHalfScheme = new System.Windows.Forms.Label();
            this.txtScheme1 = new System.Windows.Forms.TextBox();
            this.cbxHalfScheme = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtScheme2
            // 
            this.txtScheme2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScheme2.Location = new System.Drawing.Point(197, 65);
            this.txtScheme2.Name = "txtScheme2";
            this.txtScheme2.Size = new System.Drawing.Size(84, 20);
            this.txtScheme2.TabIndex = 2;
            // 
            // lblScheme
            // 
            this.lblScheme.AutoSize = true;
            this.lblScheme.Location = new System.Drawing.Point(25, 67);
            this.lblScheme.Name = "lblScheme";
            this.lblScheme.Size = new System.Drawing.Size(46, 13);
            this.lblScheme.TabIndex = 0;
            this.lblScheme.Text = "Scheme";
            // 
            // lblSchemeSign
            // 
            this.lblSchemeSign.AutoSize = true;
            this.lblSchemeSign.Location = new System.Drawing.Point(181, 67);
            this.lblSchemeSign.Name = "lblSchemeSign";
            this.lblSchemeSign.Size = new System.Drawing.Size(13, 13);
            this.lblSchemeSign.TabIndex = 1;
            this.lblSchemeSign.Text = "+";
            // 
            // lblHalfScheme
            // 
            this.lblHalfScheme.AutoSize = true;
            this.lblHalfScheme.Location = new System.Drawing.Point(287, 67);
            this.lblHalfScheme.Name = "lblHalfScheme";
            this.lblHalfScheme.Size = new System.Drawing.Size(68, 13);
            this.lblHalfScheme.TabIndex = 2;
            this.lblHalfScheme.Text = "Half Scheme";
            // 
            // txtScheme1
            // 
            this.txtScheme1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScheme1.Location = new System.Drawing.Point(84, 64);
            this.txtScheme1.Name = "txtScheme1";
            this.txtScheme1.Size = new System.Drawing.Size(93, 20);
            this.txtScheme1.TabIndex = 1;
            // 
            // cbxHalfScheme
            // 
            this.cbxHalfScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHalfScheme.FormattingEnabled = true;
            this.cbxHalfScheme.Location = new System.Drawing.Point(370, 63);
            this.cbxHalfScheme.Name = "cbxHalfScheme";
            this.cbxHalfScheme.Size = new System.Drawing.Size(78, 21);
            this.cbxHalfScheme.TabIndex = 3;
            // 
            // frmLineItemScheme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 110);
            this.Controls.Add(this.cbxHalfScheme);
            this.Controls.Add(this.lblHalfScheme);
            this.Controls.Add(this.txtScheme2);
            this.Controls.Add(this.lblSchemeSign);
            this.Controls.Add(this.lblScheme);
            this.Controls.Add(this.txtScheme1);
            this.Name = "frmLineItemScheme";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLineItemScheme_FormClosing);
            this.Load += new System.EventHandler(this.frmLineItemScheme_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtScheme2;
        private System.Windows.Forms.Label lblScheme;
        private System.Windows.Forms.Label lblSchemeSign;
        private System.Windows.Forms.Label lblHalfScheme;
        private System.Windows.Forms.TextBox txtScheme1;
        private System.Windows.Forms.ComboBox cbxHalfScheme;
    }
}