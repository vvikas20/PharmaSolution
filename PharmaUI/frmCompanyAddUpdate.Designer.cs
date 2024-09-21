namespace PharmaUI
{
    partial class frmCompanyAddUpdate
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
            this.txtCompanyCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOrderPrefRating = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBillingPrefRating = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.cbxDI = new System.Windows.Forms.ComboBox();
            this.cbxSSRequired = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.Enabled = false;
            this.txtCompanyCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCompanyCode.Location = new System.Drawing.Point(218, 78);
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.ReadOnly = true;
            this.txtCompanyCode.Size = new System.Drawing.Size(212, 23);
            this.txtCompanyCode.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 20;
            this.label3.Text = "Company Code";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCompanyName.Location = new System.Drawing.Point(218, 107);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(212, 23);
            this.txtCompanyName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "Company Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 24;
            this.label2.Text = "Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 19);
            this.label4.TabIndex = 26;
            this.label4.Text = "Direct/Indirect";
            // 
            // txtOrderPrefRating
            // 
            this.txtOrderPrefRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtOrderPrefRating.Location = new System.Drawing.Point(218, 196);
            this.txtOrderPrefRating.Name = "txtOrderPrefRating";
            this.txtOrderPrefRating.Size = new System.Drawing.Size(212, 23);
            this.txtOrderPrefRating.TabIndex = 5;
            this.txtOrderPrefRating.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrderPrefRating_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 196);
            this.label5.MaximumSize = new System.Drawing.Size(200, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 19);
            this.label5.TabIndex = 28;
            this.label5.Text = "Order Form Preference Rating";
            // 
            // txtBillingPrefRating
            // 
            this.txtBillingPrefRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtBillingPrefRating.Location = new System.Drawing.Point(218, 225);
            this.txtBillingPrefRating.Name = "txtBillingPrefRating";
            this.txtBillingPrefRating.Size = new System.Drawing.Size(212, 23);
            this.txtBillingPrefRating.TabIndex = 6;
            this.txtBillingPrefRating.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBillingPrefRating_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 227);
            this.label6.MaximumSize = new System.Drawing.Size(200, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 19);
            this.label6.TabIndex = 30;
            this.label6.Text = "Billing Form Preference Rating";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 19);
            this.label7.TabIndex = 32;
            this.label7.Text = "Stock Summary Required";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(211, 300);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 48);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(103, 300);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 48);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbxStatus
            // 
            this.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Location = new System.Drawing.Point(218, 138);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(121, 21);
            this.cbxStatus.TabIndex = 3;
            // 
            // cbxDI
            // 
            this.cbxDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDI.FormattingEnabled = true;
            this.cbxDI.Location = new System.Drawing.Point(218, 169);
            this.cbxDI.Name = "cbxDI";
            this.cbxDI.Size = new System.Drawing.Size(121, 21);
            this.cbxDI.TabIndex = 4;
            // 
            // cbxSSRequired
            // 
            this.cbxSSRequired.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSSRequired.FormattingEnabled = true;
            this.cbxSSRequired.Location = new System.Drawing.Point(218, 254);
            this.cbxSSRequired.Name = "cbxSSRequired";
            this.cbxSSRequired.Size = new System.Drawing.Size(121, 21);
            this.cbxSSRequired.TabIndex = 7;
            // 
            // frmCompanyAddUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(458, 380);
            this.ControlBox = false;
            this.Controls.Add(this.cbxSSRequired);
            this.Controls.Add(this.cbxDI);
            this.Controls.Add(this.cbxStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBillingPrefRating);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOrderPrefRating);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCompanyCode);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCompanyAddUpdate";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmCompanyAddUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCompanyCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOrderPrefRating;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBillingPrefRating;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.ComboBox cbxDI;
        private System.Windows.Forms.ComboBox cbxSSRequired;
    }
}