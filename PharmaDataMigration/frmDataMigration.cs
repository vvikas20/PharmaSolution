using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PharmaDataMigration.Master;
using System.Data.Entity.Validation;
using PharmaDataMigration.DBFWriter;
using PharmaBusinessObjects.Common;
using PharmaDataMigration.Transaction;

namespace PharmaDataMigration
{
    public partial class frmDataMigration : Form
    {
        public frmDataMigration()
        {
            InitializeComponent();
            Common.LoggedInUser = new PharmaBusinessObjects.Master.UserMaster() { Username = "admin" };
            Common.companyCodeMap = new List<CompanyCodeMap>();
            Common.itemCodeMap = new List<ItemCodeMap>();
            Common.asmCodeMap = new List<ASMCodeMap>();
            Common.rsmCodeMap = new List<RSMCodeMap>();
            Common.zsmCodeMap = new List<ZSMCodeMap>();
            Common.salesmanCodeMap = new List<SalesManCodeMap>();
            Common.routeCodeMap = new List<RouteCodeMap>();
            Common.areaCodeMap = new List<AreaCodeMap>();
            Common.personalLedgerCodeMap = new List<PersonalLedgerCodeMap>();
            Common.controlCodeMap = new List<ControlCodeMap>();
            Common.accountLedgerCodeMap = new List<AccountLedgerCodeMap>();
            Common.supplierLedgerCodeMap = new List<SupplierLedgerCodeMap>();
            Common.customerLedgerCodeMap = new List<CustomerLedgerCodeMap>();
            Common.voucherTypeMap = new List<VoucherTypeMap>();
            Common.ledgerTypeMap = new List<LedgerTypeMap>();
            Common.voucherNumberMap = new List<VoucherNumberMap>();
            Common.receiptPaymentVoucherNumberMap = new List<ReceiptPaymentVoucherMap>();
            

            FillVoucherType();
            FillLedgerType();
        }

        private void FillLedgerType()
        {
            Common.ledgerTypeMap.Add(new LedgerTypeMap() { OriginaLedgerType = "CL", MappedLedgerType = Constants.LedgerType.CustomerLedger });
            Common.ledgerTypeMap.Add(new LedgerTypeMap() { OriginaLedgerType = "SL", MappedLedgerType = Constants.LedgerType.SupplierLedger });
        }

        private void FillVoucherType()
        {
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "CN", MappedVoucherType = Constants.VoucherTypeCode.CREDITNOTE });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "DN", MappedVoucherType = Constants.VoucherTypeCode.DEBITNOTE });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "PB", MappedVoucherType = Constants.VoucherTypeCode.PURCHASEENTRY });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "PR", MappedVoucherType = Constants.VoucherTypeCode.PURCHASERETURN });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "SB", MappedVoucherType = Constants.VoucherTypeCode.SALEENTRY });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "S1", MappedVoucherType = Constants.VoucherTypeCode.SALEENTRY });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "SR", MappedVoucherType = Constants.VoucherTypeCode.SALERETURN });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "R1", MappedVoucherType = Constants.VoucherTypeCode.SALERETURN });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "ST", MappedVoucherType = Constants.VoucherTypeCode.STOCKADUSTMENT });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "S8", MappedVoucherType = Constants.VoucherTypeCode.SALEONCHALLAN });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "RV", MappedVoucherType = Constants.VoucherTypeCode.VOUCHERENTRY });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "PV", MappedVoucherType = Constants.VoucherTypeCode.VOUCHERENTRY });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "JV", MappedVoucherType = Constants.VoucherTypeCode.VOUCHERENTRY });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "R9", MappedVoucherType = Constants.VoucherTypeCode.SALERETURNBREAKAGEEXPIRY });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "S9", MappedVoucherType = Constants.VoucherTypeCode.BREAKAGEEXPIRY });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "RT", MappedVoucherType = Constants.VoucherTypeCode.RECEIPTFROMCUSTOMER });
            Common.voucherTypeMap.Add(new VoucherTypeMap() { OriginalVoucherType = "PT", MappedVoucherType = Constants.VoucherTypeCode.PAYMENTTOSUPPLIER });
        }

        private void frmDataMigration_Load(object sender, EventArgs e)
        {
            //Common.DataDirectory = @"D:\PharmaProject\TestDBF";
            //DBFFileWriter writer = new DBFFileWriter();
            //writer.WriteFile();



        }

        private void btnDataDirectory_Click(object sender, EventArgs e)
        {
            DialogResult result = fbdDataDirectory.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtDataDirectory.Text = fbdDataDirectory.SelectedPath;
                //Common.DataDirectory = txtDataDirectory.Text;
            }
        }

        private void btnStartMigration_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDataDirectory.Text))
            {
                return;
            }
            else
            {
                Common.DataDirectory = txtDataDirectory.Text;
            }

            try
            {
                StartMigration();
            }
            catch (DbEntityValidationException ex)
            {

                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void StartMigration()
        {

            CompanyMaster companyMaster = new CompanyMaster();
            ItemMaster itemMaster = new ItemMaster();
            PersonRouteMaster personRouteMaster = new PersonRouteMaster();
            PersonalLedgerMaster personalLedgerMaster = new PersonalLedgerMaster();
            AccountLedgerMaster accountLedgerMaster = new AccountLedgerMaster();
            SupplierLedgerMaster supplierLedgerMaster = new SupplierLedgerMaster();
            CustomerLedgerMaster customerLedgerMaster = new CustomerLedgerMaster();
            BillOutstanding billOutstanding = new BillOutstanding();
            FIFO fifo = new FIFO();
            PurchaseSaleBookHeaderMigration purchaseSaleBookHeaderMigration = new PurchaseSaleBookHeaderMigration();
            PurchaseSaleBookLineItemMigration purchaseSaleBookLineItemMigration = new PurchaseSaleBookLineItemMigration();
            TRN trn = new TRN();
            ReceiptPaymentMigration receiptPayment = new ReceiptPaymentMigration();
            BillOutStandingsAudjustmentMigration billOsAdjustment = new BillOutStandingsAudjustmentMigration();


            int result = 0;
            int rowIndex = 0;
            SetProcessingText(grdDataMigration, "Company Master", rowIndex, "Processing", result, true);
            result = companyMaster.InsertCompanyMasterData();
            SetProcessingText(grdDataMigration, "Company Master", rowIndex, "Completed", result, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "ASM", rowIndex, "Processing", result, true);
            result = personRouteMaster.InsertASMData();
            SetProcessingText(grdDataMigration, "ASM", rowIndex, "Completed", result, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "RSM", rowIndex, "Processing", result, true);
            result = personRouteMaster.InsertRSMData();
            SetProcessingText(grdDataMigration, "RSM", rowIndex, "Completed", result, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "ZSM", rowIndex, "Processing", result, true);
            result = personRouteMaster.InsertZSMData();
            SetProcessingText(grdDataMigration, "ZSM", rowIndex, "Completed", result, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "Sales Man", rowIndex, "Processing", result, true);
            result = personRouteMaster.InsertSalesManData();
            SetProcessingText(grdDataMigration, "Sales Man", rowIndex, "Completed", result, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "Area", rowIndex, "Processing", result, true);
            result = personRouteMaster.InsertAreaData();
            SetProcessingText(grdDataMigration, "Area", rowIndex, "Completed", result, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "Route", rowIndex, "Processing", result, true);
            result = personRouteMaster.InsertRouteData();
            SetProcessingText(grdDataMigration, "Route", rowIndex, "Completed", result, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "Personal Ledger", rowIndex, "Processing", result, true);
            result = personalLedgerMaster.InsertPersonalLedgerMasterData();
            SetProcessingText(grdDataMigration, "Personal Ledger", rowIndex, "Completed", result, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "Control Codes", rowIndex, "Processing", result, true);
            result = accountLedgerMaster.InsertControlCodesData();
            SetProcessingText(grdDataMigration, "Control Codes", rowIndex, "Completed", result, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "Income Ledger", rowIndex, "Processing", result, true);
            result = accountLedgerMaster.InsertIncomeLedgerData();
            SetProcessingText(grdDataMigration, "Income Ledger", rowIndex, "Completed", result, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "Expenditure Ledger", rowIndex, "Processing", result, true);
            result = accountLedgerMaster.InsertExpenditureLedgerData();
            SetProcessingText(grdDataMigration, "Expenditure Ledger", rowIndex, "Completed", result, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "Transaction Ledger", rowIndex, "Processing", result, true);
            result = accountLedgerMaster.InsertTransactionLedgerData();
            SetProcessingText(grdDataMigration, "Transaction Ledger", rowIndex, "Completed", result, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "General Ledger", rowIndex, "Processing", result, true);
            result = accountLedgerMaster.InsertGeneralLedgerData();
            SetProcessingText(grdDataMigration, "General Ledger", rowIndex, "Completed", result, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "Purchase Ledger", rowIndex, "Processing", result, true);
            result = accountLedgerMaster.InsertPurchaseLedgerData();
            SetProcessingText(grdDataMigration, "Purchase Ledger", rowIndex, "Completed", result, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "Sale Ledger", rowIndex, "Processing", result, true);
            result = accountLedgerMaster.InsertSaleLedgerData();
            SetProcessingText(grdDataMigration, "Sale Ledger", rowIndex, "Completed", result, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "Item Master", rowIndex, "Processing", result, true);
            result = itemMaster.InsertItemMasterData();
            SetProcessingText(grdDataMigration, "Item Master", rowIndex, "Completed", result, false);
                        
            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "Supplier Ledger", rowIndex, "Processing", result, true);
            result = supplierLedgerMaster.InsertSupplierLedgerMasterData();
            SetProcessingText(grdDataMigration, "Supplier Ledger", rowIndex, "Completed", result, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "Customer Ledger", rowIndex, "Processing", result, true);
            result = customerLedgerMaster.InsertCustomerLedgerMasterData(); //confirm mapping columns for columns having comments in CustomerLedgerMaster
            SetProcessingText(grdDataMigration, "Customer Ledger", rowIndex, "Completed", result, false);

            //result = 0;
            //rowIndex += 1;
            //SetProcessingText(grdDataMigration, "Customer Compnay Discount Ref", rowIndex, "Processing", result, true);
            //result = customerLedgerMaster.InsertCustomerCompanyReferenceData();
            //SetProcessingText(grdDataMigration, "Customer Compnay Discount Ref", rowIndex, "Completed", result, false);

            //result = 0;
            //rowIndex += 1;
            //SetProcessingText(grdDataMigration, "Suppiier Compnay Discount Ref", rowIndex, "Processing", result, true);
            //result = supplierLedgerMaster.InsertSupplierCompanyReferenceData();
            //SetProcessingText(grdDataMigration, "Suppiier Compnay Discount Ref", rowIndex, "Completed", result, false);

            /*------------------------------------------------------------*/

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "PurchaseSaleBookHeaderData", rowIndex, "Processing", result, true);
            result = purchaseSaleBookHeaderMigration.InsertPurchaseSaleBookHeaderData();
            SetProcessingText(grdDataMigration, "PurchaseSaleBookHeaderData", rowIndex, "Completed", result, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "PurchaseSaleBookLineItemData", rowIndex, "Processing", result, true);
            result = purchaseSaleBookLineItemMigration.InsertPurchaseSaleBookLineItemData();
            SetProcessingText(grdDataMigration, "PurchaseSaleBookLineItemData", rowIndex, "Completed", result, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "Fifo", rowIndex, "Processing", result, true);
            result = fifo.InsertFIFOData();
            SetProcessingText(grdDataMigration, "Fifo", rowIndex, "Completed", result, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "Bill Outstanding", rowIndex, "Processing", result, true);
            result = billOutstanding.InsertBillOutstandingData();
            SetProcessingText(grdDataMigration, "Bill Outstanding", rowIndex, "Completed", result, false);


            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "TRN", rowIndex, "Processing", result, true);
            trn.InsertTRNData();
            SetProcessingText(grdDataMigration, "TRN", rowIndex, "Completed", 0, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "ReceiptPayment", rowIndex, "Processing", result, true);
            result  = receiptPayment.InsertReceiptPaymentData();
            SetProcessingText(grdDataMigration, "ReceiptPayment", rowIndex, "Completed", 0, false);

            result = 0;
            rowIndex += 1;
            SetProcessingText(grdDataMigration, "BillOutStandingsAudjustment", rowIndex, "Processing", result, true);
            result = billOsAdjustment.InsertBillOutStandingsAudjustmentData();
            SetProcessingText(grdDataMigration, "BillOutStandingsAudjustment", rowIndex, "Completed", 0, false);

            /* ---------------------------------------  ---------------------------------------*/

            MessageBox.Show("Process Completed");
        }

        public delegate void ControlStringConsumer(Control control, string tablname, int rowIndex, string message, int result, bool addRow);  // defines a delegate type

        public void SetProcessingText(Control control, string tablname, int rowIndex, string message, int result, bool addRow)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new ControlStringConsumer(SetProcessingText), new object[] { control, tablname, rowIndex, message, result, addRow });  // invoking itself
            }
            else
            {
                if (addRow)
                {
                    grdDataMigration.Rows.Add(tablname, message, result);
                }
                else
                {
                    grdDataMigration.Rows[rowIndex].Cells[1].Value = message;
                    grdDataMigration.Rows[rowIndex].Cells[2].Value = result;
                }
            }
        }       

    }
}
