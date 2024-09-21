namespace PharmaUI
{
    partial class frmAccountLedgerMasterAddUpdate
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
            this.cbAccountLedgerType = new System.Windows.Forms.ComboBox();
            this.lblAccNo = new System.Windows.Forms.Label();
            this.txtAccountLedgerCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAccountName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbOpeningBalance = new System.Windows.Forms.TextBox();
            this.cbDebitCredit = new System.Windows.Forms.ComboBox();
            this.cbAccountType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDebitControlCode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbCreditControlCode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbBalanceSheet = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSalePurchaseValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gbBalanceSheet.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ledger Type";
            // 
            // cbAccountLedgerType
            // 
            this.cbAccountLedgerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccountLedgerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAccountLedgerType.FormattingEnabled = true;
            this.cbAccountLedgerType.Location = new System.Drawing.Point(167, 65);
            this.cbAccountLedgerType.Name = "cbAccountLedgerType";
            this.cbAccountLedgerType.Size = new System.Drawing.Size(301, 24);
            this.cbAccountLedgerType.TabIndex = 1;
            // 
            // lblAccNo
            // 
            this.lblAccNo.AutoSize = true;
            this.lblAccNo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccNo.Location = new System.Drawing.Point(33, 104);
            this.lblAccNo.Name = "lblAccNo";
            this.lblAccNo.Size = new System.Drawing.Size(87, 19);
            this.lblAccNo.TabIndex = 2;
            this.lblAccNo.Text = "Ledger Code";
            // 
            // txtAccountLedgerCode
            // 
            this.txtAccountLedgerCode.Enabled = false;
            this.txtAccountLedgerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountLedgerCode.Location = new System.Drawing.Point(167, 102);
            this.txtAccountLedgerCode.Name = "txtAccountLedgerCode";
            this.txtAccountLedgerCode.ReadOnly = true;
            this.txtAccountLedgerCode.Size = new System.Drawing.Size(301, 23);
            this.txtAccountLedgerCode.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ledger Name";
            // 
            // tbAccountName
            // 
            this.tbAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbAccountName.Location = new System.Drawing.Point(167, 173);
            this.tbAccountName.Name = "tbAccountName";
            this.tbAccountName.Size = new System.Drawing.Size(301, 23);
            this.tbAccountName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Opening Balance";
            // 
            // tbOpeningBalance
            // 
            this.tbOpeningBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbOpeningBalance.Location = new System.Drawing.Point(167, 272);
            this.tbOpeningBalance.Name = "tbOpeningBalance";
            this.tbOpeningBalance.Size = new System.Drawing.Size(243, 23);
            this.tbOpeningBalance.TabIndex = 7;
            this.tbOpeningBalance.Text = "0.00";
            this.tbOpeningBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbOpeningBalance_KeyPress);
            // 
            // cbDebitCredit
            // 
            this.cbDebitCredit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDebitCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDebitCredit.FormattingEnabled = true;
            this.cbDebitCredit.Items.AddRange(new object[] {
            "C",
            "D"});
            this.cbDebitCredit.Location = new System.Drawing.Point(416, 271);
            this.cbDebitCredit.Name = "cbDebitCredit";
            this.cbDebitCredit.Size = new System.Drawing.Size(52, 24);
            this.cbDebitCredit.TabIndex = 8;
            // 
            // cbAccountType
            // 
            this.cbAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccountType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAccountType.FormattingEnabled = true;
            this.cbAccountType.Location = new System.Drawing.Point(167, 134);
            this.cbAccountType.Name = "cbAccountType";
            this.cbAccountType.Size = new System.Drawing.Size(301, 24);
            this.cbAccountType.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ledger Type";
            // 
            // cbDebitControlCode
            // 
            this.cbDebitControlCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDebitControlCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDebitControlCode.FormattingEnabled = true;
            this.cbDebitControlCode.Location = new System.Drawing.Point(130, 29);
            this.cbDebitControlCode.Name = "cbDebitControlCode";
            this.cbDebitControlCode.Size = new System.Drawing.Size(302, 24);
            this.cbDebitControlCode.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Debit";
            // 
            // cbCreditControlCode
            // 
            this.cbCreditControlCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCreditControlCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCreditControlCode.FormattingEnabled = true;
            this.cbCreditControlCode.Location = new System.Drawing.Point(130, 68);
            this.cbCreditControlCode.Name = "cbCreditControlCode";
            this.cbCreditControlCode.Size = new System.Drawing.Size(302, 24);
            this.cbCreditControlCode.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 19);
            this.label7.TabIndex = 13;
            this.label7.Text = "Credit";
            // 
            // gbBalanceSheet
            // 
            this.gbBalanceSheet.Controls.Add(this.cbDebitControlCode);
            this.gbBalanceSheet.Controls.Add(this.cbCreditControlCode);
            this.gbBalanceSheet.Controls.Add(this.label6);
            this.gbBalanceSheet.Controls.Add(this.label7);
            this.gbBalanceSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBalanceSheet.Location = new System.Drawing.Point(26, 301);
            this.gbBalanceSheet.Name = "gbBalanceSheet";
            this.gbBalanceSheet.Size = new System.Drawing.Size(442, 116);
            this.gbBalanceSheet.TabIndex = 15;
            this.gbBalanceSheet.TabStop = false;
            this.gbBalanceSheet.Text = "Balance Sheet Codes";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(172, 440);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 48);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(280, 440);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 48);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbxStatus
            // 
            this.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Location = new System.Drawing.Point(167, 239);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(301, 21);
            this.cbxStatus.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 26;
            this.label2.Text = "Status";
            // 
            // txtSalePurchaseValue
            // 
            this.txtSalePurchaseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSalePurchaseValue.Location = new System.Drawing.Point(167, 205);
            this.txtSalePurchaseValue.Name = "txtSalePurchaseValue";
            this.txtSalePurchaseValue.Size = new System.Drawing.Size(301, 23);
            this.txtSalePurchaseValue.TabIndex = 5;
            this.txtSalePurchaseValue.Text = "0.00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(33, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 19);
            this.label8.TabIndex = 28;
            this.label8.Text = "Sale/Purchase Value";
            // 
            // frmAccountLedgerMasterAddUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 515);
            this.ControlBox = false;
            this.Controls.Add(this.txtSalePurchaseValue);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbxStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbBalanceSheet);
            this.Controls.Add(this.cbAccountType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbDebitCredit);
            this.Controls.Add(this.tbOpeningBalance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbAccountName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAccountLedgerCode);
            this.Controls.Add(this.lblAccNo);
            this.Controls.Add(this.cbAccountLedgerType);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAccountLedgerMasterAddUpdate";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAccountLedgerMasterAddUpdate_Load);
            this.gbBalanceSheet.ResumeLayout(false);
            this.gbBalanceSheet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAccountLedgerType;
        private System.Windows.Forms.Label lblAccNo;
        private System.Windows.Forms.TextBox txtAccountLedgerCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAccountName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbOpeningBalance;
        private System.Windows.Forms.ComboBox cbDebitCredit;
        private System.Windows.Forms.ComboBox cbAccountType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDebitControlCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbCreditControlCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbBalanceSheet;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSalePurchaseValue;
        private System.Windows.Forms.Label label8;
    }
}