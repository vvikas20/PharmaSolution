using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Master;
using PharmaBusinessObjects.Transaction;
using PharmaBusinessObjects.Transaction.ReceiptPayment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PharmaBusinessObjects.Common.Constants;
using static PharmaBusinessObjects.Common.Enums;

namespace PharmaUI.ReceiptPayment
{
    public partial class frmPaymentToSupplier : Form
    {

        IApplicationFacade applicationFacade;
        public bool IsInEditMode = false;

        public frmPaymentToSupplier()
        {
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
        }

        private void frmPaymentToSupplier_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, "Payment To Supplier");
                GotFocusEventRaised(this);
                EnterKeyDownForTabEvents(this);

                ///Load all the grid 
                ///
                LoadGridPaymentToSupplier();

                ///Grid events
                ///
                dgvPaymentToSupplier.KeyDown += DgvPaymentToSupplier_KeyDown;
                dgvPaymentToSupplier.CellEndEdit += DgvPaymentToSupplier_CellEndEdit;
                // dgvPaymentToSupplier.EditingControlShowing += dgvCustomerItemDiscount_EditingControlShowing;
                dgvPaymentToSupplier.SelectionChanged += DgvPaymentToSupplier_SelectionChanged;

                dtReceiptPayment.Text = ExtensionMethods.ConvertToAppDateFormat(DateTime.Now);
                dtReceiptPayment.Focus();
                dtReceiptPayment.Select(0, 0);

                dtReceiptPayment.LostFocus += DtReceiptPayment_LostFocus;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DtReceiptPayment_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (!ExtensionMethods.IsValidDate(dtReceiptPayment.Text))
                {
                    errorProviderPaymentToSupplier.SetError(dtReceiptPayment, Constants.Messages.InValidDate);
                    dtReceiptPayment.Focus();
                }
                else
                {
                    errorProviderPaymentToSupplier.SetError(dtReceiptPayment, String.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvPaymentToSupplier_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvPaymentToSupplier.CurrentRow;
                if (row != null && row.Cells["ReceiptPaymentID"].Value != null)
                {
                    TransactionEntity transactionEntity = new TransactionEntity()
                    {
                        ReceiptPaymentID = (long)row.Cells["ReceiptPaymentID"].Value,
                        EntityType = Constants.LedgerType.SupplierLedger,
                        EntityCode = Convert.ToString(row.Cells["LedgerTypeCode"].Value),
                    };

                    LoadGridBillOutstanding(transactionEntity);
                    LoadGridBillAdjusted(transactionEntity);
                }
                else
                {
                    dgvSupplierBillOS.DataSource = null;
                    dgvSupplierBillAdjusted.DataSource = null;
                    lblAmtOSVal.Text = String.Empty;
                    lblAmtAdjVal.Text = String.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///All Grid
        ///
        private void LoadGridPaymentToSupplier()
        {
            ///Add All the columns as its not a Data Bound data source
            ///
            dgvPaymentToSupplier.Columns.Add("ReceiptPaymentID", "ReceiptPaymentID");
            dgvPaymentToSupplier.Columns.Add("VoucherNumber", "VoucherNumber");
            dgvPaymentToSupplier.Columns.Add("VoucherTypeCode", "VoucherTypeCode");
            dgvPaymentToSupplier.Columns.Add("VoucherDate", "VoucherDate");
            dgvPaymentToSupplier.Columns.Add("LedgerType", "LedgerType");
            dgvPaymentToSupplier.Columns.Add("LedgerTypeCode", "LedgerTypeCode");
            dgvPaymentToSupplier.Columns.Add("LedgerTypeName", "LedgerTypeName");
            dgvPaymentToSupplier.Columns.Add("PaymentMode", "PaymentMode");
            dgvPaymentToSupplier.Columns.Add("Amount", "Amount");
            dgvPaymentToSupplier.Columns.Add("ChequeNumber", "ChequeNumber");
            dgvPaymentToSupplier.Columns.Add("BankAccountLedgerTypeCode", "BankAccountLedgerTypeCode");
            dgvPaymentToSupplier.Columns.Add("BankAccountLedgerTypeName", "BankAccountLedgerTypeName");
            dgvPaymentToSupplier.Columns.Add("ChequeDate", "ChequeDate");
            dgvPaymentToSupplier.Columns.Add("ChequeClearDate", "ChequeClearDate");
            dgvPaymentToSupplier.Columns.Add("IsChequeCleared", "IsChequeCleared");
            dgvPaymentToSupplier.Columns.Add("POST", "POST");
            dgvPaymentToSupplier.Columns.Add("PISNumber", "PISNumber");
            dgvPaymentToSupplier.Columns.Add("UnadjustedAmount", "UnadjustedAmount");
            dgvPaymentToSupplier.Columns.Add("ConsumedAmount", "ConsumedAmount");
            dgvPaymentToSupplier.Columns.Add("OldReceiptPaymentID", "OldReceiptPaymentID");

            DisplayDataGrid();
        }

        private void DisplayDataGrid()
        {
            dgvPaymentToSupplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPaymentToSupplier.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvPaymentToSupplier.AllowUserToAddRows = false;

            for (int i = 0; i < dgvPaymentToSupplier.Columns.Count; i++)
            {
                dgvPaymentToSupplier.Columns[i].Visible = false;
            }

            dgvPaymentToSupplier.Columns["LedgerTypeCode"].Visible = true;
            dgvPaymentToSupplier.Columns["LedgerTypeCode"].HeaderText = "Party Code";
            dgvPaymentToSupplier.Columns["LedgerTypeCode"].DisplayIndex = 0;
            dgvPaymentToSupplier.Columns["LedgerTypeCode"].ReadOnly = true;

            dgvPaymentToSupplier.Columns["LedgerTypeName"].Visible = true;
            dgvPaymentToSupplier.Columns["LedgerTypeName"].HeaderText = "Party Name";
            dgvPaymentToSupplier.Columns["LedgerTypeName"].DisplayIndex = 1;
            dgvPaymentToSupplier.Columns["LedgerTypeName"].ReadOnly = true;

            dgvPaymentToSupplier.Columns["ChequeNumber"].Visible = true;
            dgvPaymentToSupplier.Columns["ChequeNumber"].HeaderText = "Cheque Number";
            dgvPaymentToSupplier.Columns["ChequeNumber"].DisplayIndex = 2;

            dgvPaymentToSupplier.Columns["ChequeDate"].Visible = true;
            dgvPaymentToSupplier.Columns["ChequeDate"].HeaderText = "Cheque Date";
            dgvPaymentToSupplier.Columns["ChequeDate"].DisplayIndex = 3;

            dgvPaymentToSupplier.Columns["Amount"].Visible = true;
            dgvPaymentToSupplier.Columns["Amount"].HeaderText = "Amount";
            dgvPaymentToSupplier.Columns["Amount"].DisplayIndex = 4;

            dgvPaymentToSupplier.Columns["UnadjustedAmount"].Visible = true;
            dgvPaymentToSupplier.Columns["UnadjustedAmount"].HeaderText = "Unadjusted Amount";
            dgvPaymentToSupplier.Columns["UnadjustedAmount"].DisplayIndex = 5;
            dgvPaymentToSupplier.Columns["UnadjustedAmount"].ReadOnly = true;
        }


        private void LoadGridBillOutstanding(TransactionEntity transactionEntity)
        {
            List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding> allOutstandings = applicationFacade.GetAllBillOutstandingForLedger(transactionEntity);
            dgvSupplierBillOS.DataSource = allOutstandings;
            ExtensionMethods.SetGridDefaultProperty(dgvSupplierBillOS);

            dgvSupplierBillOS.Columns["InvoiceNumber"].Visible = true;
            dgvSupplierBillOS.Columns["InvoiceNumber"].HeaderText = "Bill Number";
            dgvSupplierBillOS.Columns["InvoiceNumber"].DisplayIndex = 0;

            dgvSupplierBillOS.Columns["InvoiceDate"].Visible = true;
            dgvSupplierBillOS.Columns["InvoiceDate"].HeaderText = "Bill Date";
            dgvSupplierBillOS.Columns["InvoiceDate"].DisplayIndex = 1;
            dgvSupplierBillOS.Columns["InvoiceDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvSupplierBillOS.Columns["BillAmount"].Visible = true;
            dgvSupplierBillOS.Columns["BillAmount"].HeaderText = "Bill Amount";
            dgvSupplierBillOS.Columns["BillAmount"].DisplayIndex = 2;

            dgvSupplierBillOS.Columns["OSAmount"].Visible = true;
            dgvSupplierBillOS.Columns["OSAmount"].HeaderText = "Outstanding Amount";
            dgvSupplierBillOS.Columns["OSAmount"].DisplayIndex = 3;

            //Display totall of outstanding amount
            decimal totallOutstanding = 0;
            allOutstandings.ForEach(x => totallOutstanding += x.OSAmount);
            lblAmtOSVal.Text = Convert.ToString(totallOutstanding);


        }

        private void LoadGridBillAdjusted(TransactionEntity currentTransactionEntity)
        {
            List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillAdjusted> allAdjustment = applicationFacade.GetAllTempBillAdjustmentForLedger(currentTransactionEntity);
            dgvSupplierBillAdjusted.DataSource = allAdjustment;
            ExtensionMethods.SetGridDefaultProperty(dgvSupplierBillAdjusted);

            dgvSupplierBillAdjusted.Columns["InvoiceNumber"].Visible = true;
            dgvSupplierBillAdjusted.Columns["InvoiceNumber"].HeaderText = "Bill Number";
            dgvSupplierBillAdjusted.Columns["InvoiceNumber"].DisplayIndex = 0;

            dgvSupplierBillAdjusted.Columns["InvoiceDate"].Visible = true;
            dgvSupplierBillAdjusted.Columns["InvoiceDate"].HeaderText = "Bill Date";
            dgvSupplierBillAdjusted.Columns["InvoiceDate"].DisplayIndex = 1;
            dgvSupplierBillAdjusted.Columns["InvoiceDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvSupplierBillAdjusted.Columns["Amount"].Visible = true;
            dgvSupplierBillAdjusted.Columns["Amount"].HeaderText = "Adjusted Amount";
            dgvSupplierBillAdjusted.Columns["Amount"].DisplayIndex = 2;

            //Display totall of adjusted amount
            decimal totallAdjusted = 0;
            allAdjustment.ForEach(x => totallAdjusted += (decimal)x.Amount);
            lblAmtAdjVal.Text = Convert.ToString(totallAdjusted);
        }

        ///Child Form Close Events
        ///
        private void FormTransactionBook_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
                AccountLedgerMaster lastSelectedTransactionBook = (sender as frmAccountLedgerMaster).LastSelectedAccountLedger;

                if (lastSelectedTransactionBook != null)
                {
                    if (lastSelectedTransactionBook.AccountLedgerID > 0)
                    {
                        txtTransactAccount.Text = lastSelectedTransactionBook.AccountLedgerName;
                        txtTransactAccount.Tag = lastSelectedTransactionBook.AccountLedgerCode;
                        dgvPaymentToSupplier.Focus();
                    }

                    if (dgvPaymentToSupplier.Rows.Count == 0)
                    {
                        AddNewRowToGrid();
                    }

                    dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[0].Cells["LedgerTypeCode"];
                    dgvPaymentToSupplier.BeginEdit(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormSupplierLedgerMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
                SupplierLedgerMaster selectedSupplier = (sender as frmSupplierLedger).LastSelectedSupplier;
                if (selectedSupplier != null)
                {
                    ReceiptPaymentItem receiptPaymentForSelectedCust = new ReceiptPaymentItem()
                    {
                        VoucherTypeCode = Constants.VoucherTypeCode.PAYMENTTOSUPPLIER,
                        VoucherDate = ExtensionMethods.ConvertToSystemDateFormat(dtReceiptPayment.Text),
                        LedgerType = Constants.LedgerType.SupplierLedger,
                        LedgerTypeCode = selectedSupplier.SupplierLedgerCode,
                        LedgerTypeName = selectedSupplier.SupplierLedgerName,
                        PaymentMode = Constants.PaymentMode.CASH,
                        BankAccountLedgerTypeCode = Convert.ToString(txtTransactAccount.Tag),
                        BankAccountLedgerTypeName = Convert.ToString(txtTransactAccount.Text),
                        ChequeDate = DateTime.Now
                    };

                    TransactionEntity transactionEntity = new TransactionEntity()
                    {
                        EntityType = Constants.LedgerType.SupplierLedger,
                        EntityCode = selectedSupplier.SupplierLedgerCode
                    };

                    UpdateReceiptPaymentRow(receiptPaymentForSelectedCust);
                    LoadGridBillOutstanding(transactionEntity);

                    dgvPaymentToSupplier.Focus();
                    dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[dgvPaymentToSupplier.SelectedCells[0].RowIndex].Cells["ChequeNumber"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormReceiptPaymentAdjustment_FormClosed(object sender, FormClosedEventArgs e)
        {

            try
            {
                TransactionEntity currentTransactionEntity = (sender as frmReceiptPaymentAdjustment).CurrentTransactionEntity;

                int rowIndex = (sender as frmReceiptPaymentAdjustment).RowIndex;

               // dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[rowIndex].Cells["UnadjustedAmount"];

                if ((sender as frmReceiptPaymentAdjustment).ReceiptPaymentState == ReceiptPaymentState.Save)
                {
                    dgvPaymentToSupplier.Rows[rowIndex].Cells["UnadjustedAmount"].Value = currentTransactionEntity.EntityBalAmount;
                    dgvPaymentToSupplier.Rows[rowIndex].Cells["ConsumedAmount"].Value = currentTransactionEntity.EntityTotalAmount - currentTransactionEntity.EntityBalAmount;
                }
                else
                {
                    double enteredAmount = ExtensionMethods.SafeConversionDouble(Convert.ToString(dgvPaymentToSupplier.Rows[rowIndex].Cells["Amount"].Value)) ?? default(double);
                    double consumedAmount = ExtensionMethods.SafeConversionDouble(Convert.ToString(dgvPaymentToSupplier.Rows[rowIndex].Cells["ConsumedAmount"].Value)) ?? default(double);
                    dgvPaymentToSupplier.Rows[rowIndex].Cells["UnadjustedAmount"].Value = enteredAmount;
                    dgvPaymentToSupplier.Rows[rowIndex].Cells["ConsumedAmount"].Value = default(double);
                }

                applicationFacade.InsertUpdateTempReceiptPayment(FillDataboundToCurrentRow());
                LoadGridBillAdjusted(currentTransactionEntity);
                LoadGridBillOutstanding(currentTransactionEntity);

                AddNewRowToGrid();

                if (!IsInEditMode)
                {
                    dgvSupplierBillOS.DataSource = null;
                    dgvSupplierBillAdjusted.DataSource = null;
                    lblAmtOSVal.Text = String.Empty;
                    lblAmtAdjVal.Text = String.Empty;

                    dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[rowIndex + 1].Cells["LedgerTypeCode"];
                    // dgvPaymentToSupplier.BeginEdit(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FrmTrans_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                dgvPaymentToSupplier.SelectionChanged -= DgvPaymentToSupplier_SelectionChanged;

                ReceiptPaymentItem transaction = (sender as frmTransactions).SelectedTransaction;
                if (transaction != null && transaction.ReceiptPaymentID > 0)
                {
                    AddNewRowToGrid();

                    
                    ReceiptPaymentItem transactionDetail = applicationFacade.GetTransactionByTransactionID(transaction.ReceiptPaymentID);
                    UpdateReceiptPaymentRow(transactionDetail);
                    DisplayDataGrid();

                    TransactionEntity transactionEntity = new TransactionEntity();

                    txtTransactAccount.Tag = Convert.ToString(dgvPaymentToSupplier.Rows[0].Cells["BankAccountLedgerTypeCode"].Value);
                    txtTransactAccount.Text = Convert.ToString(dgvPaymentToSupplier.Rows[0].Cells["BankAccountLedgerTypeName"].Value);

                    transactionEntity.ReceiptPaymentID = (long)dgvPaymentToSupplier.Rows[0].Cells["OldReceiptPaymentID"].Value;
                    transactionEntity.EntityType = Constants.LedgerType.SupplierLedger;
                    transactionEntity.EntityCode = Convert.ToString(dgvPaymentToSupplier.Rows[0].Cells["LedgerTypeCode"].Value);

                    LoadGridBillOutstanding(transactionEntity);

                    transactionEntity.ReceiptPaymentID = (long)dgvPaymentToSupplier.Rows[0].Cells["ReceiptPaymentID"].Value;
                    LoadGridBillAdjusted(transactionEntity);

                    dgvPaymentToSupplier.SelectionChanged += DgvPaymentToSupplier_SelectionChanged;

                    dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[0].Cells["LedgerTypeCode"];
                    dgvPaymentToSupplier.Focus();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///Data Grid Events
        ///

        private void DgvPaymentToSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyData == Keys.Enter || e.KeyData == Keys.Right) && dgvPaymentToSupplier.Rows.Count > 0)
                {
                    e.Handled = true;
                    Grid_CellNextlAction();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvPaymentToSupplier_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dgvPaymentToSupplier.Rows.Count > 0)
                {
                    string columnName = dgvPaymentToSupplier.Columns[dgvPaymentToSupplier.SelectedCells[0].ColumnIndex].Name;
                    if (columnName == "Amount")
                    {
                        RaisePaymentModeCalculations();
                    }

                    Grid_CellNextlAction();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvPaymentToSupplier_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                string columnName = dgvPaymentToSupplier.Columns[dgvPaymentToSupplier.CurrentCell.ColumnIndex].Name;
                if (columnName.Equals("Amount"))
                {
                    e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///
        private void RaisePaymentModeCalculations()
        {
            int cashCount = 0;
            int chequeCount = 0;
            StringBuilder cashSequence = new StringBuilder(string.Empty);
            StringBuilder checkSequence = new StringBuilder(string.Empty);

            foreach (DataGridViewRow receiptPaymentRow in dgvPaymentToSupplier.Rows.Cast<DataGridViewRow>())
            {
                if (Convert.ToString(receiptPaymentRow.Cells["ChequeNumber"].Value) == PaymentMode.CASHTEXT)
                {
                    cashCount++;

                    if (cashCount == 1)
                        cashSequence.Append(String.Format("{0}", Convert.ToString(receiptPaymentRow.Cells["Amount"].Value)));
                    else
                        cashSequence.Append(String.Format("+ {0}", Convert.ToString(receiptPaymentRow.Cells["Amount"].Value)));
                }
                else
                {
                    chequeCount++;

                    if (chequeCount == 1)
                        checkSequence.Append(String.Format("{0}", Convert.ToString(receiptPaymentRow.Cells["Amount"].Value)));
                    else
                        checkSequence.Append(String.Format("+ {0}", Convert.ToString(receiptPaymentRow.Cells["Amount"].Value)));
                }
            }

            lblTotalCash.Text = "Total Cash (" + cashCount.ToString() + ")";
            lblCashVal.Text = Convert.ToString(cashSequence);

            lblTotalCQ.Text = "Total Cheque (" + chequeCount.ToString() + ")";
            lblCQVal.Text = Convert.ToString(checkSequence);

        }

        private void Grid_CellNextlAction()
        {
            int rowIndex = dgvPaymentToSupplier.CurrentRow.Index;
            string columnName = dgvPaymentToSupplier.Columns[dgvPaymentToSupplier.SelectedCells[0].ColumnIndex].Name;
            if (columnName == "LedgerTypeCode")
            {
                if (string.IsNullOrEmpty(Convert.ToString(dgvPaymentToSupplier.CurrentCell.Value)))
                {
                    frmSupplierLedger formSupplierLedgerMaster = new frmSupplierLedger();
                    formSupplierLedgerMaster.IsInChildMode = true;
                    //Set Child UI
                    ExtensionMethods.AddChildFormToPanel(this, formSupplierLedgerMaster, ExtensionMethods.MainPanel);
                    formSupplierLedgerMaster.WindowState = FormWindowState.Maximized;

                    formSupplierLedgerMaster.FormClosed += FormSupplierLedgerMaster_FormClosed;
                    formSupplierLedgerMaster.Show();
                }
                else
                {
                    dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[rowIndex].Cells["ChequeNumber"];
                }
            }
            else if (columnName == "LedgerTypeName")
            {
                dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[rowIndex].Cells["ChequeNumber"];
            }
            else if (columnName == "ChequeNumber")
            {
                if (String.IsNullOrWhiteSpace(Convert.ToString(dgvPaymentToSupplier.CurrentCell.Value)))
                {
                    dgvPaymentToSupplier.CurrentCell.Value = Constants.PaymentMode.CASHTEXT;
                    dgvPaymentToSupplier.Rows[rowIndex].Cells["PaymentMode"].Value = Constants.PaymentMode.CASH;
                    dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[rowIndex].Cells["Amount"];
                }
                else
                {
                    if (Convert.ToString(dgvPaymentToSupplier.CurrentCell.Value).Length > 10)
                    {
                        dgvPaymentToSupplier.CurrentCell.ErrorText = Constants.Messages.InValidCheque;
                    }
                    else
                    {
                        dgvPaymentToSupplier.CurrentCell.ErrorText = string.Empty;
                        dgvPaymentToSupplier.Rows[rowIndex].Cells["PaymentMode"].Value = Constants.PaymentMode.CHEQUE;
                        dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[rowIndex].Cells["ChequeDate"];
                    }
                }
            }
            else if (columnName == "ChequeDate")
            {
                string chequeDate = Convert.ToString(dgvPaymentToSupplier.Rows[rowIndex].Cells["ChequeDate"].Value);
                if (ExtensionMethods.IsValidDate(chequeDate))
                {
                    dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[rowIndex].Cells["Amount"];
                    dgvPaymentToSupplier.CurrentRow.Cells["ChequeDate"].ErrorText = String.Empty;
                }
                else
                {
                    dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[rowIndex].Cells["ChequeDate"];
                    dgvPaymentToSupplier.CurrentRow.Cells["ChequeDate"].ErrorText = Constants.Messages.InValidDate;

                }
            }
            else if (columnName == "Amount")
            {
                RaisePaymentModeCalculations();

                decimal enteredAmount = ExtensionMethods.SafeConversionDecimal(Convert.ToString(dgvPaymentToSupplier.CurrentRow.Cells["Amount"].Value)) ?? default(decimal);
                decimal unadjustedAmount = ExtensionMethods.SafeConversionDecimal(Convert.ToString(dgvPaymentToSupplier.CurrentRow.Cells["UnadjustedAmount"].Value)) ?? default(decimal);
                decimal consumedAmount = ExtensionMethods.SafeConversionDecimal(Convert.ToString(dgvPaymentToSupplier.CurrentRow.Cells["ConsumedAmount"].Value)) ?? default(decimal);

                if (enteredAmount != 0)
                {
                    frmReceiptPaymentAdjustment formReceiptPaymentAdjustment = new frmReceiptPaymentAdjustment(rowIndex);
                    TransactionEntity transactionEntity = new TransactionEntity()
                    {
                        ReceiptPaymentID = (long)dgvPaymentToSupplier.CurrentRow.Cells["ReceiptPaymentID"].Value,
                        EntityType = Constants.LedgerType.SupplierLedger,
                        EntityCode = Convert.ToString(dgvPaymentToSupplier.CurrentRow.Cells["LedgerTypeCode"].Value),
                        EntityName = Convert.ToString(dgvPaymentToSupplier.CurrentRow.Cells["LedgerTypeName"].Value),
                        EntityTotalAmount = enteredAmount,
                        EntityBalAmount = enteredAmount - consumedAmount
                    };

                    formReceiptPaymentAdjustment.ConfigureReceiptPaymentAdjustment(transactionEntity);
                    formReceiptPaymentAdjustment.FormClosed += FormReceiptPaymentAdjustment_FormClosed;
                    formReceiptPaymentAdjustment.Show();
                }

                dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[rowIndex].Cells["Amount"];
            }
            //else if (columnName == "UnadjustedAmount")
            //{
            //    AddNewRowToGrid();

            //    if (!IsInEditMode)
            //    {
            //        dgvSupplierBillOS.DataSource = null;
            //        dgvSupplierBillAdjusted.DataSource = null;
            //        lblAmtOSVal.Text = String.Empty;
            //        lblAmtAdjVal.Text = String.Empty;

            //        dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[rowIndex + 1].Cells["LedgerTypeCode"];
            //        // dgvPaymentToSupplier.BeginEdit(true);
            //    }
            //}
        }

        private ReceiptPaymentItem FillDataboundToCurrentRow()
        {
            ReceiptPaymentItem receiptPaymentItem = new ReceiptPaymentItem();

            if (dgvPaymentToSupplier.SelectedCells.Count > 0)
            {
                int rowIndex = dgvPaymentToSupplier.SelectedCells[0].RowIndex;
                receiptPaymentItem.ReceiptPaymentID = (long)dgvPaymentToSupplier.Rows[rowIndex].Cells["ReceiptPaymentID"].Value;
                receiptPaymentItem.VoucherNumber = Convert.ToString(dgvPaymentToSupplier.Rows[rowIndex].Cells["VoucherNumber"].Value);
                receiptPaymentItem.VoucherTypeCode = Convert.ToString(dgvPaymentToSupplier.Rows[rowIndex].Cells["VoucherTypeCode"].Value);
                receiptPaymentItem.VoucherDate = Convert.ToDateTime(dgvPaymentToSupplier.Rows[rowIndex].Cells["VoucherDate"].Value);
                receiptPaymentItem.LedgerType = Convert.ToString(dgvPaymentToSupplier.Rows[rowIndex].Cells["LedgerType"].Value);
                receiptPaymentItem.LedgerTypeCode = Convert.ToString(dgvPaymentToSupplier.Rows[rowIndex].Cells["LedgerTypeCode"].Value);
                receiptPaymentItem.PaymentMode = Convert.ToString(dgvPaymentToSupplier.Rows[rowIndex].Cells["PaymentMode"].Value);
                receiptPaymentItem.Amount = ExtensionMethods.SafeConversionDecimal(Convert.ToString(dgvPaymentToSupplier.Rows[rowIndex].Cells["Amount"].Value));
                receiptPaymentItem.ChequeNumber = Convert.ToString(dgvPaymentToSupplier.Rows[rowIndex].Cells["ChequeNumber"].Value);
                receiptPaymentItem.BankAccountLedgerTypeCode = Convert.ToString(txtTransactAccount.Tag);
                receiptPaymentItem.BankAccountLedgerTypeName = Convert.ToString(txtTransactAccount.Text);
                receiptPaymentItem.ChequeDate = ExtensionMethods.ConvertToSystemDateFormat(dtReceiptPayment.Text);
                receiptPaymentItem.UnadjustedAmount = ExtensionMethods.SafeConversionDecimal(Convert.ToString(dgvPaymentToSupplier.Rows[rowIndex].Cells["UnadjustedAmount"].Value));
            }
            return receiptPaymentItem;
        }

        private void UpdateReceiptPaymentRow(ReceiptPaymentItem receiptPayment)
        {
            int rowIndex = -1;
            int colIndex = -1;

            if (dgvPaymentToSupplier.SelectedCells.Count > 0)
            {
                rowIndex = dgvPaymentToSupplier.SelectedCells[0].RowIndex;
                colIndex = dgvPaymentToSupplier.SelectedCells[0].ColumnIndex;
                receiptPayment.ReceiptPaymentID = applicationFacade.InsertUpdateTempReceiptPayment(receiptPayment);

                dgvPaymentToSupplier.Rows[rowIndex].Cells["ReceiptPaymentID"].Value = receiptPayment.ReceiptPaymentID;
                dgvPaymentToSupplier.Rows[rowIndex].Cells["LedgerTypeCode"].Value = receiptPayment.LedgerTypeCode;
                dgvPaymentToSupplier.Rows[rowIndex].Cells["LedgerTypeName"].Value = receiptPayment.LedgerTypeName;
                dgvPaymentToSupplier.Rows[rowIndex].Cells["PaymentMode"].Value = receiptPayment.PaymentMode;
                dgvPaymentToSupplier.Rows[rowIndex].Cells["ChequeNumber"].Value = receiptPayment.ChequeNumber;
                dgvPaymentToSupplier.Rows[rowIndex].Cells["BankAccountLedgerTypeName"].Value = receiptPayment.BankAccountLedgerTypeName;
                dgvPaymentToSupplier.Rows[rowIndex].Cells["BankAccountLedgerTypeCode"].Value = receiptPayment.BankAccountLedgerTypeCode;
                dgvPaymentToSupplier.Rows[rowIndex].Cells["ChequeDate"].Value = receiptPayment.ChequeDate == null ? String.Empty : ExtensionMethods.ConvertToAppDateFormat((DateTime)receiptPayment.ChequeDate);
                dgvPaymentToSupplier.Rows[rowIndex].Cells["Amount"].Value = receiptPayment.Amount;
                dgvPaymentToSupplier.Rows[rowIndex].Cells["ConsumedAmount"].Value = receiptPayment.Amount - receiptPayment.UnadjustedAmount;
                dgvPaymentToSupplier.Rows[rowIndex].Cells["UnadjustedAmount"].Value = receiptPayment.UnadjustedAmount;
                dgvPaymentToSupplier.Rows[rowIndex].Cells["OldReceiptPaymentID"].Value = receiptPayment.OldReceiptPaymentID;
            }
        }

        ///Grid UI Events 
        ///
        public void GotFocusEventRaised(Control control)
        {
            try
            {
                foreach (Control c in control.Controls)
                {
                    if (c.Controls.Count > 0)
                    {
                        GotFocusEventRaised(c);
                    }
                    else
                    {
                        if (c is TextBox)
                        {
                            TextBox tb1 = (TextBox)c;
                            tb1.GotFocus += C_GotFocus;
                        }

                        else if (c is ComboBox)
                        {
                            ComboBox tb1 = (ComboBox)c;
                            tb1.GotFocus += C_GotFocus;
                        }
                        else if (c is MaskedTextBox)
                        {
                            MaskedTextBox tb1 = (MaskedTextBox)c;
                            tb1.GotFocus += C_GotFocus;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void C_GotFocus(object sender, EventArgs e)
        {
            ExtensionMethods.DisableAllTextBoxAndComboBox(this, (Control)sender);
            return;
        }

        private void EnterKeyDownForTabEvents(Control control)
        {
            try
            {
                foreach (Control c in control.Controls)
                {
                    if (c.Controls.Count > 0)
                    {
                        EnterKeyDownForTabEvents(c);
                    }
                    else
                    {

                        c.KeyDown -= C_KeyDown;
                        c.KeyDown += C_KeyDown;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void C_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sender is TextBox)
                {
                    TextBox activeControl = (sender as TextBox);

                    if (activeControl.Name == "txtTransactAccount" && String.IsNullOrWhiteSpace(activeControl.Text))
                    {
                        PharmaBusinessObjects.Common.AccountLedgerType accountLedgerMaster = new PharmaBusinessObjects.Common.AccountLedgerType()
                        {
                            AccountLedgerTypeName = Constants.AccountLedgerTypeText.TransactionBooks
                        };

                        frmAccountLedgerMaster formTransactionBook = new frmAccountLedgerMaster();
                        //Set Child UI
                        ExtensionMethods.AddChildFormToPanel(this, formTransactionBook, ExtensionMethods.MainPanel);
                        formTransactionBook.WindowState = FormWindowState.Maximized;
                        formTransactionBook.FormClosed += FormTransactionBook_FormClosed;
                        formTransactionBook.Show();
                        formTransactionBook.IsInChildMode = true;
                        formTransactionBook.ConfigureAccountLedger(accountLedgerMaster);
                    }
                    else
                    {
                        SendKeys.Send("{TAB}");
                    }
                }
                else if (sender is MaskedTextBox)
                {
                    if (IsInEditMode)
                    {
                        frmTransactions frmTrans = new frmTransactions(ExtensionMethods.ConvertToSystemDateFormat(dtReceiptPayment.Text), Constants.LedgerType.SupplierLedger);
                        frmTrans.Show();
                        frmTrans.FormClosed += FrmTrans_FormClosed;
                    }
                    else
                    {
                        SendKeys.Send("{TAB}");
                    }
                }
                else
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.End)
            {
                if (dgvPaymentToSupplier.SelectedCells.Count > 0)
                {
                    if (DialogResult.Yes == MessageBox.Show(Constants.Messages.SaveDataPrompt, Constants.Messages.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        List<long> listTempReceiptPaymentList = new List<long>();
                        foreach (DataGridViewRow receiptPaymentRow in dgvPaymentToSupplier.Rows.Cast<DataGridViewRow>())
                        {
                            if (receiptPaymentRow.Cells["ReceiptPaymentID"].Value != null)
                            {
                                listTempReceiptPaymentList.Add((long)receiptPaymentRow.Cells["ReceiptPaymentID"].Value);
                            }
                        }

                        if (listTempReceiptPaymentList.Count > 0)
                        {
                            applicationFacade.SaveAllTempTransaction(listTempReceiptPaymentList);
                            this.Close();
                        }
                    }
                }
            }
            else if (keyData == Keys.Escape || keyData == Keys.Delete)
            {
                if (dgvPaymentToSupplier.SelectedCells.Count > 0)
                {
                    int rowIndex = dgvPaymentToSupplier.SelectedCells[0].RowIndex;
                    if (DialogResult.Yes == MessageBox.Show(Constants.Messages.DeletePrompt, Constants.Messages.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        if (dgvPaymentToSupplier.Rows[rowIndex].Cells["ReceiptPaymentID"].Value != null)
                        {
                            TransactionEntity tranEntity = new TransactionEntity();
                            tranEntity.ReceiptPaymentID = (long)dgvPaymentToSupplier.Rows[rowIndex].Cells["ReceiptPaymentID"].Value;
                            tranEntity.EntityCode = Convert.ToString(dgvPaymentToSupplier.Rows[rowIndex].Cells["LedgerTypeCode"].Value);

                            applicationFacade.ClearTempTransaction(tranEntity);
                            dgvPaymentToSupplier.Rows.RemoveAt(rowIndex);
                            dgvPaymentToSupplier.Refresh();
                            if (dgvPaymentToSupplier.Rows.Count == 0)
                            {
                                AddNewRowToGrid();
                                dgvPaymentToSupplier.CurrentCell = dgvPaymentToSupplier.Rows[0].Cells["LedgerTypeCode"];
                                dgvPaymentToSupplier.BeginEdit(true);
                            }

                            RaisePaymentModeCalculations();
                            dgvSupplierBillOS.DataSource = null;
                            dgvSupplierBillAdjusted.DataSource = null;
                            lblAmtOSVal.Text = String.Empty;
                            lblAmtAdjVal.Text = String.Empty;
                        }
                    }
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ClearScreen()
        {
            dtReceiptPayment.Focus();

            txtTransactAccount.Text = String.Empty;
            txtTransactAccount.Tag = null;

            dgvPaymentToSupplier.DataSource = null;
            dgvPaymentToSupplier.DataSource = null;
            dgvPaymentToSupplier.DataSource = null;

            lblTotalCQ.Text = "Total Cheque";
            lblCQVal.Text = String.Empty;
            lblTotalCash.Text = "Total Cash";
            lblCashVal.Text = String.Empty;

            lblAmtOS.Text = "Amount Outstanding";
            lblAmtOSVal.Text = String.Empty;
            lblAmtAdj.Text = "Amount Adjusted";
            lblAmtAdjVal.Text = String.Empty;
        }

        private void frmPaymentToSupplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExtensionMethods.RemoveTransactionFormToPanel(this, ExtensionMethods.MainPanel);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> unsavedReceiptPayment = GetUnsavedReceiptPayment();
                if (unsavedReceiptPayment.Count > 0)
                {
                    DialogResult isConfirm = MessageBox.Show("There are some unsaved changes. Do you want to close the screen", "Warning", MessageBoxButtons.YesNo);
                    if (isConfirm == DialogResult.Yes)
                    {
                        applicationFacade.ClearUnsavedReceiptPayment(unsavedReceiptPayment);
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///Configure for Edit Mode
        ///
        public void ConfigureUIForModification()
        {
            this.IsInEditMode = true;
        }

        private void AddNewRowToGrid()
        {
            if (!IsInEditMode || (IsInEditMode && dgvPaymentToSupplier.Rows.Count == 0))
            {
                int rowIndex = dgvPaymentToSupplier.Rows.Add();
                DataGridViewRow row = dgvPaymentToSupplier.Rows[rowIndex];
                // row.Cells["ChequeDate"].Value = ExtensionMethods.ConvertToAppDateFormat(DateTime.Now);
            }
        }

        private List<int> GetUnsavedReceiptPayment()
        {
            List<int> unsavedReceivedPayment = new List<int>();
            unsavedReceivedPayment = dgvPaymentToSupplier.Rows.Cast<DataGridViewRow>().Where(r => !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["ReceiptPaymentID"].Value)))
                                                               .Select(x => Convert.ToInt32(x.Cells["ReceiptPaymentID"].Value)).ToList();
            return unsavedReceivedPayment;
        }
    }
}
