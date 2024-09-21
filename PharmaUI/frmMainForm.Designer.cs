namespace PharmaUI
{
    partial class frmMainForm
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.masterMaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.accoutMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.accountLedgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.personalDiaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.customerLedgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.supplierLedgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.companyMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.itemMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.personRouteMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.userMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.inventoryMaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.purchaseBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.transactionCtrlPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.modificationPurchaseEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saleEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.transactionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.modificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.chaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.challanModificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.receiptPaymentBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.receiptFromCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.receiptFromCustTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.paymentToCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.transactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.modifyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saleReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gSTInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.masterMaintenanceToolStripMenuItem,
            this.inventoryMaintenanceToolStripMenuItem,
            this.receiptPaymentBooksToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(756, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// homeToolStripMenuItem
			// 
			this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
			this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.homeToolStripMenuItem.Text = "Home";
			this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
			// 
			// masterMaintenanceToolStripMenuItem
			// 
			this.masterMaintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accoutMasterToolStripMenuItem,
            this.companyMasterToolStripMenuItem,
            this.itemMasterToolStripMenuItem,
            this.personRouteMasterToolStripMenuItem,
            this.userMasterToolStripMenuItem});
			this.masterMaintenanceToolStripMenuItem.Name = "masterMaintenanceToolStripMenuItem";
			this.masterMaintenanceToolStripMenuItem.Size = new System.Drawing.Size(127, 20);
			this.masterMaintenanceToolStripMenuItem.Text = "Master Maintenance";
			// 
			// accoutMasterToolStripMenuItem
			// 
			this.accoutMasterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountLedgerToolStripMenuItem,
            this.personalDiaryToolStripMenuItem,
            this.customerLedgerToolStripMenuItem,
            this.supplierLedgerToolStripMenuItem});
			this.accoutMasterToolStripMenuItem.Name = "accoutMasterToolStripMenuItem";
			this.accoutMasterToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
			this.accoutMasterToolStripMenuItem.Text = "Accout Master";
			// 
			// accountLedgerToolStripMenuItem
			// 
			this.accountLedgerToolStripMenuItem.Name = "accountLedgerToolStripMenuItem";
			this.accountLedgerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.accountLedgerToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.accountLedgerToolStripMenuItem.Text = "Account Ledger";
			this.accountLedgerToolStripMenuItem.Click += new System.EventHandler(this.accountLedgerToolStripMenuItem_Click);
			// 
			// personalDiaryToolStripMenuItem
			// 
			this.personalDiaryToolStripMenuItem.Name = "personalDiaryToolStripMenuItem";
			this.personalDiaryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.personalDiaryToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.personalDiaryToolStripMenuItem.Text = "Personal Diary";
			this.personalDiaryToolStripMenuItem.Click += new System.EventHandler(this.personalDiaryToolStripMenuItem_Click);
			// 
			// customerLedgerToolStripMenuItem
			// 
			this.customerLedgerToolStripMenuItem.Name = "customerLedgerToolStripMenuItem";
			this.customerLedgerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
			this.customerLedgerToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.customerLedgerToolStripMenuItem.Text = "Customer Ledger";
			this.customerLedgerToolStripMenuItem.Click += new System.EventHandler(this.customerLedgerToolStripMenuItem_Click);
			// 
			// supplierLedgerToolStripMenuItem
			// 
			this.supplierLedgerToolStripMenuItem.Name = "supplierLedgerToolStripMenuItem";
			this.supplierLedgerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.supplierLedgerToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.supplierLedgerToolStripMenuItem.Text = "Supplier Ledger";
			this.supplierLedgerToolStripMenuItem.Click += new System.EventHandler(this.supplierLedgerToolStripMenuItem_Click);
			// 
			// companyMasterToolStripMenuItem
			// 
			this.companyMasterToolStripMenuItem.Name = "companyMasterToolStripMenuItem";
			this.companyMasterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.companyMasterToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
			this.companyMasterToolStripMenuItem.Text = "Company Master";
			this.companyMasterToolStripMenuItem.Click += new System.EventHandler(this.companyMasterToolStripMenuItem_Click);
			// 
			// itemMasterToolStripMenuItem
			// 
			this.itemMasterToolStripMenuItem.Name = "itemMasterToolStripMenuItem";
			this.itemMasterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
			this.itemMasterToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
			this.itemMasterToolStripMenuItem.Text = "Item Master";
			this.itemMasterToolStripMenuItem.Click += new System.EventHandler(this.itemMasterToolStripMenuItem_Click);
			// 
			// personRouteMasterToolStripMenuItem
			// 
			this.personRouteMasterToolStripMenuItem.Name = "personRouteMasterToolStripMenuItem";
			this.personRouteMasterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
			this.personRouteMasterToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
			this.personRouteMasterToolStripMenuItem.Text = "Person Route Master";
			this.personRouteMasterToolStripMenuItem.Click += new System.EventHandler(this.personRouteMasterToolStripMenuItem_Click);
			// 
			// userMasterToolStripMenuItem
			// 
			this.userMasterToolStripMenuItem.Name = "userMasterToolStripMenuItem";
			this.userMasterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
			this.userMasterToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
			this.userMasterToolStripMenuItem.Text = "User Master";
			this.userMasterToolStripMenuItem.Click += new System.EventHandler(this.userMasterToolStripMenuItem_Click);
			// 
			// inventoryMaintenanceToolStripMenuItem
			// 
			this.inventoryMaintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseBookToolStripMenuItem,
            this.saleEntryToolStripMenuItem});
			this.inventoryMaintenanceToolStripMenuItem.Name = "inventoryMaintenanceToolStripMenuItem";
			this.inventoryMaintenanceToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
			this.inventoryMaintenanceToolStripMenuItem.Text = "Inventory Maintenance";
			// 
			// purchaseBookToolStripMenuItem
			// 
			this.purchaseBookToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transactionCtrlPToolStripMenuItem,
            this.modificationPurchaseEntryToolStripMenuItem});
			this.purchaseBookToolStripMenuItem.Name = "purchaseBookToolStripMenuItem";
			this.purchaseBookToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.purchaseBookToolStripMenuItem.Text = "Purchase Book";
			// 
			// transactionCtrlPToolStripMenuItem
			// 
			this.transactionCtrlPToolStripMenuItem.Name = "transactionCtrlPToolStripMenuItem";
			this.transactionCtrlPToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
			this.transactionCtrlPToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.transactionCtrlPToolStripMenuItem.Text = "Transaction";
			this.transactionCtrlPToolStripMenuItem.Click += new System.EventHandler(this.purchaseTransactionToolStripMenuItem_Click);
			// 
			// modificationPurchaseEntryToolStripMenuItem
			// 
			this.modificationPurchaseEntryToolStripMenuItem.Name = "modificationPurchaseEntryToolStripMenuItem";
			this.modificationPurchaseEntryToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.modificationPurchaseEntryToolStripMenuItem.Text = "Modification";
			this.modificationPurchaseEntryToolStripMenuItem.Click += new System.EventHandler(this.modificationPurchaseEntryToolStripMenuItem_Click);
			// 
			// saleEntryToolStripMenuItem
			// 
			this.saleEntryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transactionToolStripMenuItem1,
            this.modificationToolStripMenuItem,
            this.chaToolStripMenuItem,
            this.challanModificationToolStripMenuItem});
			this.saleEntryToolStripMenuItem.Name = "saleEntryToolStripMenuItem";
			this.saleEntryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saleEntryToolStripMenuItem.Text = "Sale Entry";
			// 
			// transactionToolStripMenuItem1
			// 
			this.transactionToolStripMenuItem1.Name = "transactionToolStripMenuItem1";
			this.transactionToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.transactionToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
			this.transactionToolStripMenuItem1.Text = "Transaction";
			this.transactionToolStripMenuItem1.Click += new System.EventHandler(this.saleEntryToolStripMenuItem_Click);
			// 
			// modificationToolStripMenuItem
			// 
			this.modificationToolStripMenuItem.Name = "modificationToolStripMenuItem";
			this.modificationToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.modificationToolStripMenuItem.Text = "Modification";
			this.modificationToolStripMenuItem.Click += new System.EventHandler(this.modificationToolStripMenuItem_Click);
			// 
			// chaToolStripMenuItem
			// 
			this.chaToolStripMenuItem.Name = "chaToolStripMenuItem";
			this.chaToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.chaToolStripMenuItem.Text = "Challan";
			this.chaToolStripMenuItem.Click += new System.EventHandler(this.saleEntryChallanToolStripMenuItem_Click);
			// 
			// challanModificationToolStripMenuItem
			// 
			this.challanModificationToolStripMenuItem.Name = "challanModificationToolStripMenuItem";
			this.challanModificationToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.challanModificationToolStripMenuItem.Text = "Challan Modification";
			this.challanModificationToolStripMenuItem.Click += new System.EventHandler(this.modificationSaleChallanToolStripMenuItem_Click);
			// 
			// receiptPaymentBooksToolStripMenuItem
			// 
			this.receiptPaymentBooksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.receiptFromCustomerToolStripMenuItem,
            this.paymentToCustomerToolStripMenuItem});
			this.receiptPaymentBooksToolStripMenuItem.Name = "receiptPaymentBooksToolStripMenuItem";
			this.receiptPaymentBooksToolStripMenuItem.Size = new System.Drawing.Size(145, 20);
			this.receiptPaymentBooksToolStripMenuItem.Text = "Receipt/Payment Books";
			// 
			// receiptFromCustomerToolStripMenuItem
			// 
			this.receiptFromCustomerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.receiptFromCustTransactionToolStripMenuItem,
            this.modifyToolStripMenuItem});
			this.receiptFromCustomerToolStripMenuItem.Name = "receiptFromCustomerToolStripMenuItem";
			this.receiptFromCustomerToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.receiptFromCustomerToolStripMenuItem.Text = "Receipt From Customer";
			this.receiptFromCustomerToolStripMenuItem.Click += new System.EventHandler(this.receiptFromCustomerToolStripMenuItem_Click);
			// 
			// receiptFromCustTransactionToolStripMenuItem
			// 
			this.receiptFromCustTransactionToolStripMenuItem.Name = "receiptFromCustTransactionToolStripMenuItem";
			this.receiptFromCustTransactionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
			this.receiptFromCustTransactionToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
			this.receiptFromCustTransactionToolStripMenuItem.Text = "Transaction";
			this.receiptFromCustTransactionToolStripMenuItem.Click += new System.EventHandler(this.receiptFromCustTransactionToolStripMenuItem_Click);
			// 
			// modifyToolStripMenuItem
			// 
			this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
			this.modifyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
			this.modifyToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
			this.modifyToolStripMenuItem.Text = "Modify";
			this.modifyToolStripMenuItem.Click += new System.EventHandler(this.modifyToolStripMenuItem_Click);
			// 
			// paymentToCustomerToolStripMenuItem
			// 
			this.paymentToCustomerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transactionToolStripMenuItem,
            this.modifyToolStripMenuItem1});
			this.paymentToCustomerToolStripMenuItem.Name = "paymentToCustomerToolStripMenuItem";
			this.paymentToCustomerToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.paymentToCustomerToolStripMenuItem.Text = "Payment To Supplier";
			// 
			// transactionToolStripMenuItem
			// 
			this.transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
			this.transactionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
			this.transactionToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
			this.transactionToolStripMenuItem.Text = "Transaction";
			this.transactionToolStripMenuItem.Click += new System.EventHandler(this.transactionToolStripMenuItem_Click);
			// 
			// modifyToolStripMenuItem1
			// 
			this.modifyToolStripMenuItem1.Name = "modifyToolStripMenuItem1";
			this.modifyToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.M)));
			this.modifyToolStripMenuItem1.Size = new System.Drawing.Size(207, 22);
			this.modifyToolStripMenuItem1.Text = "Modify";
			this.modifyToolStripMenuItem1.Click += new System.EventHandler(this.modifyToolStripMenuItem1_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// reportToolStripMenuItem
			// 
			this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saleReportToolStripMenuItem,
            this.gSTInvoiceToolStripMenuItem});
			this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
			this.reportToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
			this.reportToolStripMenuItem.Text = "Report";
			// 
			// saleReportToolStripMenuItem
			// 
			this.saleReportToolStripMenuItem.Name = "saleReportToolStripMenuItem";
			this.saleReportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.saleReportToolStripMenuItem.Text = "Sale Invoice";
			this.saleReportToolStripMenuItem.Click += new System.EventHandler(this.saleReportToolStripMenuItem_Click);
			// 
			// gSTInvoiceToolStripMenuItem
			// 
			this.gSTInvoiceToolStripMenuItem.Name = "gSTInvoiceToolStripMenuItem";
			this.gSTInvoiceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.gSTInvoiceToolStripMenuItem.Text = "GST Invoice";
			this.gSTInvoiceToolStripMenuItem.Click += new System.EventHandler(this.gSTInvoiceToolStripMenuItem_Click);
			// 
			// pnlMain
			// 
			this.pnlMain.Location = new System.Drawing.Point(0, 27);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(756, 31);
			this.pnlMain.TabIndex = 1;
			// 
			// frmMainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(756, 477);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmMainForm";
			this.Text = "Pharma Application";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmMainForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem masterMaintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accoutMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountLedgerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personalDiaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerLedgerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierLedgerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companyMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personRouteMasterToolStripMenuItem;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem userMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryMaintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionCtrlPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiptPaymentBooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiptFromCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiptFromCustTransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentToCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificationPurchaseEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saleEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem chaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem challanModificationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saleReportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gSTInvoiceToolStripMenuItem;
	}
}