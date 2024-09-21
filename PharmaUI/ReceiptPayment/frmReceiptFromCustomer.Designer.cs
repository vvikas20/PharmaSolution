namespace PharmaUI.ReceiptPayment
{
    partial class frmReceiptFromCustomer
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
            this.lblTransAccount = new System.Windows.Forms.Label();
            this.txtTransactAccount = new System.Windows.Forms.TextBox();
            this.dtReceiptPayment = new System.Windows.Forms.MaskedTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCQVal = new System.Windows.Forms.Label();
            this.lblTotalCQ = new System.Windows.Forms.Label();
            this.lblCashVal = new System.Windows.Forms.Label();
            this.lblTotalCash = new System.Windows.Forms.Label();
            this.lblAmtAdjVal = new System.Windows.Forms.Label();
            this.dgvCustomerBillAdjusted = new System.Windows.Forms.DataGridView();
            this.lblAmtAdj = new System.Windows.Forms.Label();
            this.dgvCustomerBillOS = new System.Windows.Forms.DataGridView();
            this.lblAmtOSVal = new System.Windows.Forms.Label();
            this.lblAmtOS = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvReceiptFromCustomer = new System.Windows.Forms.DataGridView();
            this.errorProviderReceipt = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerBillAdjusted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerBillOS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptFromCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderReceipt)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTransAccount
            // 
            this.lblTransAccount.AutoSize = true;
            this.lblTransAccount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransAccount.Location = new System.Drawing.Point(192, 62);
            this.lblTransAccount.Name = "lblTransAccount";
            this.lblTransAccount.Size = new System.Drawing.Size(153, 19);
            this.lblTransAccount.TabIndex = 206;
            this.lblTransAccount.Text = "Transaction Account";
            // 
            // txtTransactAccount
            // 
            this.txtTransactAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransactAccount.Location = new System.Drawing.Point(350, 59);
            this.txtTransactAccount.Name = "txtTransactAccount";
            this.txtTransactAccount.Size = new System.Drawing.Size(294, 26);
            this.txtTransactAccount.TabIndex = 207;
            // 
            // dtReceiptPayment
            // 
            this.dtReceiptPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtReceiptPayment.Location = new System.Drawing.Point(59, 59);
            this.dtReceiptPayment.Mask = "00/00/0000";
            this.dtReceiptPayment.Name = "dtReceiptPayment";
            this.dtReceiptPayment.Size = new System.Drawing.Size(119, 26);
            this.dtReceiptPayment.TabIndex = 205;
            this.dtReceiptPayment.ValidatingType = typeof(System.DateTime);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblCQVal, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalCQ, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCashVal, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalCash, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAmtAdjVal, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvCustomerBillAdjusted, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblAmtAdj, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvCustomerBillOS, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblAmtOSVal, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAmtOS, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 285);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1028, 242);
            this.tableLayoutPanel1.TabIndex = 209;
            // 
            // lblCQVal
            // 
            this.lblCQVal.AutoSize = true;
            this.lblCQVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCQVal.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCQVal.ForeColor = System.Drawing.Color.Blue;
            this.lblCQVal.Location = new System.Drawing.Point(688, 4);
            this.lblCQVal.Margin = new System.Windows.Forms.Padding(3);
            this.lblCQVal.Name = "lblCQVal";
            this.lblCQVal.Padding = new System.Windows.Forms.Padding(1);
            this.lblCQVal.Size = new System.Drawing.Size(336, 17);
            this.lblCQVal.TabIndex = 115;
            this.lblCQVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalCQ
            // 
            this.lblTotalCQ.AutoSize = true;
            this.lblTotalCQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalCQ.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCQ.Location = new System.Drawing.Point(522, 4);
            this.lblTotalCQ.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalCQ.Name = "lblTotalCQ";
            this.lblTotalCQ.Padding = new System.Windows.Forms.Padding(1);
            this.lblTotalCQ.Size = new System.Drawing.Size(159, 17);
            this.lblTotalCQ.TabIndex = 115;
            this.lblTotalCQ.Text = "Total Cheque";
            // 
            // lblCashVal
            // 
            this.lblCashVal.AutoSize = true;
            this.lblCashVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCashVal.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashVal.ForeColor = System.Drawing.Color.Blue;
            this.lblCashVal.Location = new System.Drawing.Point(180, 4);
            this.lblCashVal.Margin = new System.Windows.Forms.Padding(3);
            this.lblCashVal.Name = "lblCashVal";
            this.lblCashVal.Padding = new System.Windows.Forms.Padding(1);
            this.lblCashVal.Size = new System.Drawing.Size(335, 17);
            this.lblCashVal.TabIndex = 113;
            this.lblCashVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalCash
            // 
            this.lblTotalCash.AutoSize = true;
            this.lblTotalCash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalCash.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCash.Location = new System.Drawing.Point(4, 4);
            this.lblTotalCash.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalCash.Name = "lblTotalCash";
            this.lblTotalCash.Padding = new System.Windows.Forms.Padding(1);
            this.lblTotalCash.Size = new System.Drawing.Size(169, 17);
            this.lblTotalCash.TabIndex = 112;
            this.lblTotalCash.Text = "Total Cash";
            // 
            // lblAmtAdjVal
            // 
            this.lblAmtAdjVal.AutoSize = true;
            this.lblAmtAdjVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAmtAdjVal.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmtAdjVal.ForeColor = System.Drawing.Color.Green;
            this.lblAmtAdjVal.Location = new System.Drawing.Point(688, 28);
            this.lblAmtAdjVal.Margin = new System.Windows.Forms.Padding(3);
            this.lblAmtAdjVal.Name = "lblAmtAdjVal";
            this.lblAmtAdjVal.Padding = new System.Windows.Forms.Padding(1);
            this.lblAmtAdjVal.Size = new System.Drawing.Size(336, 17);
            this.lblAmtAdjVal.TabIndex = 114;
            this.lblAmtAdjVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvCustomerBillAdjusted
            // 
            this.dgvCustomerBillAdjusted.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomerBillAdjusted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvCustomerBillAdjusted, 2);
            this.dgvCustomerBillAdjusted.Location = new System.Drawing.Point(522, 52);
            this.dgvCustomerBillAdjusted.MultiSelect = false;
            this.dgvCustomerBillAdjusted.Name = "dgvCustomerBillAdjusted";
            this.dgvCustomerBillAdjusted.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomerBillAdjusted.Size = new System.Drawing.Size(502, 186);
            this.dgvCustomerBillAdjusted.TabIndex = 400;
            // 
            // lblAmtAdj
            // 
            this.lblAmtAdj.AutoSize = true;
            this.lblAmtAdj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAmtAdj.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmtAdj.Location = new System.Drawing.Point(522, 28);
            this.lblAmtAdj.Margin = new System.Windows.Forms.Padding(3);
            this.lblAmtAdj.Name = "lblAmtAdj";
            this.lblAmtAdj.Padding = new System.Windows.Forms.Padding(1);
            this.lblAmtAdj.Size = new System.Drawing.Size(159, 17);
            this.lblAmtAdj.TabIndex = 113;
            this.lblAmtAdj.Text = "Amount Adjusted ";
            this.lblAmtAdj.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dgvCustomerBillOS
            // 
            this.dgvCustomerBillOS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomerBillOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvCustomerBillOS, 2);
            this.dgvCustomerBillOS.Location = new System.Drawing.Point(4, 52);
            this.dgvCustomerBillOS.MultiSelect = false;
            this.dgvCustomerBillOS.Name = "dgvCustomerBillOS";
            this.dgvCustomerBillOS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomerBillOS.Size = new System.Drawing.Size(511, 186);
            this.dgvCustomerBillOS.TabIndex = 300;
            // 
            // lblAmtOSVal
            // 
            this.lblAmtOSVal.AutoSize = true;
            this.lblAmtOSVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAmtOSVal.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmtOSVal.ForeColor = System.Drawing.Color.Red;
            this.lblAmtOSVal.Location = new System.Drawing.Point(180, 28);
            this.lblAmtOSVal.Margin = new System.Windows.Forms.Padding(3);
            this.lblAmtOSVal.Name = "lblAmtOSVal";
            this.lblAmtOSVal.Padding = new System.Windows.Forms.Padding(1);
            this.lblAmtOSVal.Size = new System.Drawing.Size(335, 17);
            this.lblAmtOSVal.TabIndex = 112;
            this.lblAmtOSVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAmtOS
            // 
            this.lblAmtOS.AutoSize = true;
            this.lblAmtOS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAmtOS.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmtOS.Location = new System.Drawing.Point(4, 28);
            this.lblAmtOS.Margin = new System.Windows.Forms.Padding(3);
            this.lblAmtOS.Name = "lblAmtOS";
            this.lblAmtOS.Padding = new System.Windows.Forms.Padding(1);
            this.lblAmtOS.Size = new System.Drawing.Size(169, 17);
            this.lblAmtOS.TabIndex = 111;
            this.lblAmtOS.Text = "Amount Outstanding ";
            this.lblAmtOS.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(12, 62);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(41, 19);
            this.lblSearch.TabIndex = 204;
            this.lblSearch.Text = "Date";
            // 
            // dgvReceiptFromCustomer
            // 
            this.dgvReceiptFromCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReceiptFromCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceiptFromCustomer.Location = new System.Drawing.Point(12, 91);
            this.dgvReceiptFromCustomer.MultiSelect = false;
            this.dgvReceiptFromCustomer.Name = "dgvReceiptFromCustomer";
            this.dgvReceiptFromCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceiptFromCustomer.Size = new System.Drawing.Size(1028, 192);
            this.dgvReceiptFromCustomer.TabIndex = 208;
            // 
            // errorProviderReceipt
            // 
            this.errorProviderReceipt.ContainerControl = this;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(953, 49);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 32);
            this.btnCancel.TabIndex = 210;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmReceiptFromCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 537);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTransAccount);
            this.Controls.Add(this.txtTransactAccount);
            this.Controls.Add(this.dtReceiptPayment);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.dgvReceiptFromCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmReceiptFromCustomer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReceiptFromCustomer_FormClosing);
            this.Load += new System.EventHandler(this.frmReceiptFromCustomer_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerBillAdjusted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerBillOS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptFromCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderReceipt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTransAccount;
        private System.Windows.Forms.TextBox txtTransactAccount;
        private System.Windows.Forms.MaskedTextBox dtReceiptPayment;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblCQVal;
        private System.Windows.Forms.Label lblTotalCQ;
        private System.Windows.Forms.Label lblCashVal;
        private System.Windows.Forms.Label lblTotalCash;
        private System.Windows.Forms.Label lblAmtAdjVal;
        private System.Windows.Forms.DataGridView dgvCustomerBillAdjusted;
        private System.Windows.Forms.Label lblAmtAdj;
        private System.Windows.Forms.DataGridView dgvCustomerBillOS;
        private System.Windows.Forms.Label lblAmtOSVal;
        private System.Windows.Forms.Label lblAmtOS;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridView dgvReceiptFromCustomer;
        private System.Windows.Forms.ErrorProvider errorProviderReceipt;
        private System.Windows.Forms.Button btnCancel;
    }
}