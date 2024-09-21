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
    public partial class frmReceiptFromCustomer : Form
    {
        IApplicationFacade applicationFacade;
        public bool IsInEditMode = false;

        public frmReceiptFromCustomer()
        {
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
        }

        private void frmReceiptFromCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, "Receipt From Customer");
                GotFocusEventRaised(this);
                EnterKeyDownForTabEvents(this);

                LoadReceiptFromCustomer();

                ///Grid events
                ///
                dgvReceiptFromCustomer.KeyDown += DgvReceiptFromCustomer_KeyDown;
                dgvReceiptFromCustomer.CellEndEdit += DgvReceiptFromCustomer_CellEndEdit;
                // dgvReceiptFromCustomer.EditingControlShowing += DgvReceiptFromCustomer_EditingControlShowing;
                dgvReceiptFromCustomer.SelectionChanged += DgvReceiptFromCustomer_SelectionChanged;

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
                    errorProviderReceipt.SetError(dtReceiptPayment, Constants.Messages.InValidDate);
                    dtReceiptPayment.Focus();
                }
                else
                {
                    errorProviderReceipt.SetError(dtReceiptPayment, String.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvReceiptFromCustomer_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvReceiptFromCustomer.CurrentRow;
                if (row != null && row.Cells["ReceiptPaymentID"].Value != null)
                {
                    TransactionEntity transactionEntity = new TransactionEntity()
                    {
                        ReceiptPaymentID = (long)row.Cells["ReceiptPaymentID"].Value,
                        EntityType = Constants.LedgerType.CustomerLedger,
                        EntityCode = Convert.ToString(row.Cells["LedgerTypeCode"].Value),
                    };

                    LoadGridBillOutstanding(transactionEntity);
                    LoadGridBillAdjusted(transactionEntity);
                }
                else
                {
                    dgvCustomerBillOS.DataSource = null;
                    dgvCustomerBillAdjusted.DataSource = null;
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
        private void LoadReceiptFromCustomer()
        {
            ///Add All the columns as its not a Data Bound data source
            ///
            dgvReceiptFromCustomer.Columns.Add("ReceiptPaymentID", "ReceiptPaymentID");
            dgvReceiptFromCustomer.Columns.Add("VoucherNumber", "VoucherNumber");
            dgvReceiptFromCustomer.Columns.Add("VoucherTypeCode", "VoucherTypeCode");
            dgvReceiptFromCustomer.Columns.Add("VoucherDate", "VoucherDate");
            dgvReceiptFromCustomer.Columns.Add("LedgerType", "LedgerType");
            dgvReceiptFromCustomer.Columns.Add("LedgerTypeCode", "LedgerTypeCode");
            dgvReceiptFromCustomer.Columns.Add("LedgerTypeName", "LedgerTypeName");
            dgvReceiptFromCustomer.Columns.Add("PaymentMode", "PaymentMode");
            dgvReceiptFromCustomer.Columns.Add("Amount", "Amount");
            dgvReceiptFromCustomer.Columns.Add("ChequeNumber", "ChequeNumber");
            dgvReceiptFromCustomer.Columns.Add("BankAccountLedgerTypeCode", "BankAccountLedgerTypeCode");
            dgvReceiptFromCustomer.Columns.Add("BankAccountLedgerTypeName", "BankAccountLedgerTypeName");
            dgvReceiptFromCustomer.Columns.Add("ChequeDate", "ChequeDate");
            dgvReceiptFromCustomer.Columns.Add("ChequeClearDate", "ChequeClearDate");
            dgvReceiptFromCustomer.Columns.Add("IsChequeCleared", "IsChequeCleared");
            dgvReceiptFromCustomer.Columns.Add("POST", "POST");
            dgvReceiptFromCustomer.Columns.Add("PISNumber", "PISNumber");
            dgvReceiptFromCustomer.Columns.Add("UnadjustedAmount", "UnadjustedAmount");
            dgvReceiptFromCustomer.Columns.Add("ConsumedAmount", "ConsumedAmount");
            dgvReceiptFromCustomer.Columns.Add("OldReceiptPaymentID", "OldReceiptPaymentID");

            DisplayDataGrid();

        }

        private void DisplayDataGrid()
        {
            dgvReceiptFromCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReceiptFromCustomer.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvReceiptFromCustomer.AllowUserToAddRows = false;

            for (int i = 0; i < dgvReceiptFromCustomer.Columns.Count; i++)
            {
                dgvReceiptFromCustomer.Columns[i].Visible = false;
            }

            dgvReceiptFromCustomer.Columns["LedgerTypeCode"].Visible = true;
            dgvReceiptFromCustomer.Columns["LedgerTypeCode"].HeaderText = "Party Code";
            dgvReceiptFromCustomer.Columns["LedgerTypeCode"].DisplayIndex = 0;
            dgvReceiptFromCustomer.Columns["LedgerTypeCode"].ReadOnly = true;

            dgvReceiptFromCustomer.Columns["LedgerTypeName"].Visible = true;
            dgvReceiptFromCustomer.Columns["LedgerTypeName"].HeaderText = "Party Name";
            dgvReceiptFromCustomer.Columns["LedgerTypeName"].DisplayIndex = 1;
            dgvReceiptFromCustomer.Columns["LedgerTypeName"].ReadOnly = true;

            dgvReceiptFromCustomer.Columns["ChequeNumber"].Visible = true;
            dgvReceiptFromCustomer.Columns["ChequeNumber"].HeaderText = "Cheque Number";
            dgvReceiptFromCustomer.Columns["ChequeNumber"].DisplayIndex = 2;

            dgvReceiptFromCustomer.Columns["ChequeDate"].Visible = true;
            dgvReceiptFromCustomer.Columns["ChequeDate"].HeaderText = "Cheque Date";
            dgvReceiptFromCustomer.Columns["ChequeDate"].DisplayIndex = 3;

            dgvReceiptFromCustomer.Columns["Amount"].Visible = true;
            dgvReceiptFromCustomer.Columns["Amount"].HeaderText = "Amount";
            dgvReceiptFromCustomer.Columns["Amount"].DisplayIndex = 4;

            dgvReceiptFromCustomer.Columns["UnadjustedAmount"].Visible = true;
            dgvReceiptFromCustomer.Columns["UnadjustedAmount"].HeaderText = "Unadjusted Amount";
            dgvReceiptFromCustomer.Columns["UnadjustedAmount"].DisplayIndex = 5;
            dgvReceiptFromCustomer.Columns["UnadjustedAmount"].ReadOnly = true;
        }

        private void LoadGridBillOutstanding(TransactionEntity transactionEntity)
        {
            List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding> allOutstandings = applicationFacade.GetAllBillOutstandingForLedger(transactionEntity);
            dgvCustomerBillOS.DataSource = allOutstandings;
            ExtensionMethods.SetGridDefaultProperty(dgvCustomerBillOS);

            dgvCustomerBillOS.Columns["InvoiceNumber"].Visible = true;
            dgvCustomerBillOS.Columns["InvoiceNumber"].HeaderText = "Bill Number";
            dgvCustomerBillOS.Columns["InvoiceNumber"].DisplayIndex = 0;

            dgvCustomerBillOS.Columns["InvoiceDate"].Visible = true;
            dgvCustomerBillOS.Columns["InvoiceDate"].HeaderText = "Bill Date";
            dgvCustomerBillOS.Columns["InvoiceDate"].DisplayIndex = 1;
            dgvCustomerBillOS.Columns["InvoiceDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvCustomerBillOS.Columns["BillAmount"].Visible = true;
            dgvCustomerBillOS.Columns["BillAmount"].HeaderText = "Bill Amount";
            dgvCustomerBillOS.Columns["BillAmount"].DisplayIndex = 2;

            dgvCustomerBillOS.Columns["OSAmount"].Visible = true;
            dgvCustomerBillOS.Columns["OSAmount"].HeaderText = "Outstanding Amount";
            dgvCustomerBillOS.Columns["OSAmount"].DisplayIndex = 3;

            //Display totall of outstanding amount
            decimal totallOutstanding = 0;
            allOutstandings.ForEach(x => totallOutstanding += x.OSAmount);
            lblAmtOSVal.Text = Convert.ToString(totallOutstanding);


        }

        private void LoadGridBillAdjusted(TransactionEntity currentTransactionEntity)
        {
            List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillAdjusted> allAdjustment = applicationFacade.GetAllTempBillAdjustmentForLedger(currentTransactionEntity);
            dgvCustomerBillAdjusted.DataSource = allAdjustment;
            ExtensionMethods.SetGridDefaultProperty(dgvCustomerBillAdjusted);

            dgvCustomerBillAdjusted.Columns["InvoiceNumber"].Visible = true;
            dgvCustomerBillAdjusted.Columns["InvoiceNumber"].HeaderText = "Bill Number";
            dgvCustomerBillAdjusted.Columns["InvoiceNumber"].DisplayIndex = 0;

            dgvCustomerBillAdjusted.Columns["InvoiceDate"].Visible = true;
            dgvCustomerBillAdjusted.Columns["InvoiceDate"].HeaderText = "Bill Date";
            dgvCustomerBillAdjusted.Columns["InvoiceDate"].DisplayIndex = 1;
            dgvCustomerBillAdjusted.Columns["InvoiceDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvCustomerBillAdjusted.Columns["Amount"].Visible = true;
            dgvCustomerBillAdjusted.Columns["Amount"].HeaderText = "Adjusted Amount";
            dgvCustomerBillAdjusted.Columns["Amount"].DisplayIndex = 2;

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
                        dgvReceiptFromCustomer.Focus();
                    }

                    if (dgvReceiptFromCustomer.Rows.Count == 0)
                    {
                        AddNewRowToGrid();
                    }

                    dgvReceiptFromCustomer.CurrentCell = dgvReceiptFromCustomer.Rows[0].Cells["LedgerTypeCode"];
                    dgvReceiptFromCustomer.BeginEdit(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormCustomerLedgerMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
                CustomerLedgerMaster selectedCustomer = (sender as frmCustomerLedgerMaster).LastSelectedCustomerLedger;
                if (selectedCustomer != null)
                {
                    ReceiptPaymentItem receiptPaymentForSelectedCust = new ReceiptPaymentItem()
                    {
                        VoucherTypeCode = Constants.VoucherTypeCode.RECEIPTFROMCUSTOMER,
                        VoucherDate = ExtensionMethods.ConvertToSystemDateFormat(dtReceiptPayment.Text),
                        LedgerType = Constants.LedgerType.CustomerLedger,
                        LedgerTypeCode = selectedCustomer.CustomerLedgerCode,
                        LedgerTypeName = selectedCustomer.CustomerLedgerName,
                        PaymentMode = Constants.PaymentMode.CASH,
                        BankAccountLedgerTypeCode = Convert.ToString(txtTransactAccount.Tag),
                        BankAccountLedgerTypeName = Convert.ToString(txtTransactAccount.Text),
                        ChequeDate = DateTime.Now
                    };

                    TransactionEntity transactionEntity = new TransactionEntity()
                    {
                        EntityType = Constants.LedgerType.CustomerLedger,
                        EntityCode = selectedCustomer.CustomerLedgerCode
                    };

                    UpdateReceiptPaymentRow(receiptPaymentForSelectedCust);
                    LoadGridBillOutstanding(transactionEntity);

                    dgvReceiptFromCustomer.Focus();
                    dgvReceiptFromCustomer.CurrentCell = dgvReceiptFromCustomer.Rows[dgvReceiptFromCustomer.SelectedCells[0].RowIndex].Cells["ChequeNumber"];
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

               // dgvReceiptFromCustomer.CurrentCell = dgvReceiptFromCustomer.Rows[rowIndex].Cells["UnadjustedAmount"];

                if ((sender as frmReceiptPaymentAdjustment).ReceiptPaymentState == ReceiptPaymentState.Save)
                {
                    dgvReceiptFromCustomer.Rows[rowIndex].Cells["UnadjustedAmount"].Value = currentTransactionEntity.EntityBalAmount;
                    dgvReceiptFromCustomer.Rows[rowIndex].Cells["ConsumedAmount"].Value = currentTransactionEntity.EntityTotalAmount - currentTransactionEntity.EntityBalAmount;
                }
                else
                {
                    double enteredAmount = ExtensionMethods.SafeConversionDouble(Convert.ToString(dgvReceiptFromCustomer.Rows[rowIndex].Cells["Amount"].Value)) ?? default(double);
                    double consumedAmount = ExtensionMethods.SafeConversionDouble(Convert.ToString(dgvReceiptFromCustomer.Rows[rowIndex].Cells["ConsumedAmount"].Value)) ?? default(double);
                    dgvReceiptFromCustomer.Rows[rowIndex].Cells["UnadjustedAmount"].Value = enteredAmount;
                    dgvReceiptFromCustomer.Rows[rowIndex].Cells["ConsumedAmount"].Value = default(double);
                }

                applicationFacade.InsertUpdateTempReceiptPayment(FillDataboundToCurrentRow());
                LoadGridBillAdjusted(currentTransactionEntity);
                LoadGridBillOutstanding(currentTransactionEntity);

                AddNewRowToGrid();
                if (!IsInEditMode)
                {
                    dgvCustomerBillOS.DataSource = null;
                    dgvCustomerBillAdjusted.DataSource = null;
                    lblAmtOSVal.Text = String.Empty;
                    lblAmtAdjVal.Text = String.Empty;
                    dgvReceiptFromCustomer.CurrentCell = dgvReceiptFromCustomer.Rows[rowIndex + 1].Cells["LedgerTypeCode"];
                    // dgvReceiptFromCustomer.BeginEdit(true);
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
                dgvReceiptFromCustomer.SelectionChanged -= DgvReceiptFromCustomer_SelectionChanged;

                ReceiptPaymentItem transaction = (sender as frmTransactions).SelectedTransaction;
                if (transaction != null && transaction.ReceiptPaymentID > 0)
                {
                    AddNewRowToGrid();

                    
                    ReceiptPaymentItem transactionDetail = applicationFacade.GetTransactionByTransactionID(transaction.ReceiptPaymentID);
                    UpdateReceiptPaymentRow(transactionDetail);
                    DisplayDataGrid();

                    TransactionEntity transactionEntity = new TransactionEntity();

                    txtTransactAccount.Tag = Convert.ToString(dgvReceiptFromCustomer.Rows[0].Cells["BankAccountLedgerTypeCode"].Value);
                    txtTransactAccount.Text = Convert.ToString(dgvReceiptFromCustomer.Rows[0].Cells["BankAccountLedgerTypeName"].Value);

                    transactionEntity.ReceiptPaymentID = (long)dgvReceiptFromCustomer.Rows[0].Cells["OldReceiptPaymentID"].Value;
                    transactionEntity.EntityType = Constants.LedgerType.CustomerLedger;
                    transactionEntity.EntityCode = Convert.ToString(dgvReceiptFromCustomer.Rows[0].Cells["LedgerTypeCode"].Value);

                    LoadGridBillOutstanding(transactionEntity);

                    transactionEntity.ReceiptPaymentID = (long)dgvReceiptFromCustomer.Rows[0].Cells["ReceiptPaymentID"].Value;
                    LoadGridBillAdjusted(transactionEntity);

                    dgvReceiptFromCustomer.SelectionChanged += DgvReceiptFromCustomer_SelectionChanged;

                    dgvReceiptFromCustomer.CurrentCell = dgvReceiptFromCustomer.Rows[0].Cells["LedgerTypeCode"];
                    dgvReceiptFromCustomer.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        ///Data Grid Events
        ///

        private void DgvReceiptFromCustomer_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvReceiptFromCustomer.Rows.Count > 0)
                {
                    string columnName = dgvReceiptFromCustomer.Columns[dgvReceiptFromCustomer.SelectedCells[0].ColumnIndex].Name;
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

        private void DgvReceiptFromCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyData == Keys.Enter || e.KeyData == Keys.Right) && dgvReceiptFromCustomer.Rows.Count > 0)
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

        private void DgvReceiptFromCustomer_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                string columnName = dgvReceiptFromCustomer.Columns[dgvReceiptFromCustomer.CurrentCell.ColumnIndex].Name;
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

            foreach (DataGridViewRow receiptPaymentRow in dgvReceiptFromCustomer.Rows.Cast<DataGridViewRow>())
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
            int rowIndex = dgvReceiptFromCustomer.CurrentRow.Index;
            string columnName = dgvReceiptFromCustomer.Columns[dgvReceiptFromCustomer.SelectedCells[0].ColumnIndex].Name;
            if (columnName == "LedgerTypeCode")
            {
                if (string.IsNullOrEmpty(Convert.ToString(dgvReceiptFromCustomer.CurrentCell.Value)))
                {
                    frmCustomerLedgerMaster formCustomerLedgerMaster = new frmCustomerLedgerMaster();
                    formCustomerLedgerMaster.IsInChildMode = true;
                    //Set Child UI
                    ExtensionMethods.AddChildFormToPanel(this, formCustomerLedgerMaster, ExtensionMethods.MainPanel);
                    formCustomerLedgerMaster.WindowState = FormWindowState.Maximized;

                    formCustomerLedgerMaster.FormClosed += FormCustomerLedgerMaster_FormClosed;
                    formCustomerLedgerMaster.Show();
                }
                else
                {
                    dgvReceiptFromCustomer.CurrentCell = dgvReceiptFromCustomer.Rows[rowIndex].Cells["ChequeNumber"];
                }
            }
            else if (columnName == "LedgerTypeName")
            {
                dgvReceiptFromCustomer.CurrentCell = dgvReceiptFromCustomer.Rows[rowIndex].Cells["ChequeNumber"];
            }
            else if (columnName == "ChequeNumber")
            {
                if (String.IsNullOrWhiteSpace(Convert.ToString(dgvReceiptFromCustomer.CurrentCell.Value)))
                {
                    dgvReceiptFromCustomer.CurrentCell.Value = Constants.PaymentMode.CASHTEXT;
                    dgvReceiptFromCustomer.Rows[rowIndex].Cells["PaymentMode"].Value = Constants.PaymentMode.CASH;
                    dgvReceiptFromCustomer.CurrentCell = dgvReceiptFromCustomer.Rows[rowIndex].Cells["Amount"];
                }
                else
                {
                    if (Convert.ToString(dgvReceiptFromCustomer.CurrentCell.Value).Length > 10)
                    {
                        dgvReceiptFromCustomer.CurrentCell.ErrorText = Constants.Messages.InValidCheque;
                    }
                    else
                    {
                        dgvReceiptFromCustomer.CurrentCell.ErrorText = string.Empty;
                        dgvReceiptFromCustomer.Rows[rowIndex].Cells["PaymentMode"].Value = Constants.PaymentMode.CHEQUE;
                        dgvReceiptFromCustomer.CurrentCell = dgvReceiptFromCustomer.Rows[rowIndex].Cells["ChequeDate"];
                    }
                }
            }
            else if (columnName == "ChequeDate")
            {
                string chequeDate = Convert.ToString(dgvReceiptFromCustomer.Rows[rowIndex].Cells["ChequeDate"].Value);
                if (ExtensionMethods.IsValidDate(chequeDate))
                {
                    dgvReceiptFromCustomer.CurrentCell = dgvReceiptFromCustomer.Rows[rowIndex].Cells["Amount"];
                    dgvReceiptFromCustomer.CurrentRow.Cells["ChequeDate"].ErrorText = String.Empty;
                }
                else
                {
                    dgvReceiptFromCustomer.CurrentCell = dgvReceiptFromCustomer.Rows[rowIndex].Cells["ChequeDate"];
                    dgvReceiptFromCustomer.CurrentRow.Cells["ChequeDate"].ErrorText = Constants.Messages.InValidDate;

                }
            }
            else if (columnName == "Amount")
            {
                RaisePaymentModeCalculations();

                decimal enteredAmount = ExtensionMethods.SafeConversionDecimal(Convert.ToString(dgvReceiptFromCustomer.Rows[rowIndex].Cells["Amount"].Value)) ?? default(decimal);
                decimal unadjustedAmount = ExtensionMethods.SafeConversionDecimal(Convert.ToString(dgvReceiptFromCustomer.Rows[rowIndex].Cells["UnadjustedAmount"].Value)) ?? default(decimal);
                decimal consumedAmount = ExtensionMethods.SafeConversionDecimal(Convert.ToString(dgvReceiptFromCustomer.Rows[rowIndex].Cells["ConsumedAmount"].Value)) ?? default(decimal);


                if (enteredAmount != 0)
                {
                    frmReceiptPaymentAdjustment formReceiptPaymentAdjustment = new frmReceiptPaymentAdjustment(rowIndex);
                    TransactionEntity transactionEntity = new TransactionEntity()
                    {
                        ReceiptPaymentID = (long)dgvReceiptFromCustomer.Rows[rowIndex].Cells["ReceiptPaymentID"].Value,
                        EntityType = Constants.LedgerType.CustomerLedger,
                        EntityCode = Convert.ToString(dgvReceiptFromCustomer.Rows[rowIndex].Cells["LedgerTypeCode"].Value),
                        EntityName = Convert.ToString(dgvReceiptFromCustomer.Rows[rowIndex].Cells["LedgerTypeName"].Value),
                        EntityTotalAmount = enteredAmount,
                        EntityBalAmount = enteredAmount - consumedAmount
                    };

                    formReceiptPaymentAdjustment.ConfigureReceiptPaymentAdjustment(transactionEntity);
                    formReceiptPaymentAdjustment.FormClosed += FormReceiptPaymentAdjustment_FormClosed;
                    formReceiptPaymentAdjustment.Show();
                }

                dgvReceiptFromCustomer.CurrentCell = dgvReceiptFromCustomer.Rows[rowIndex].Cells["Amount"];
            }
            //else if (columnName == "UnadjustedAmount")
            //{
            //    AddNewRowToGrid();
            //    if (!IsInEditMode)
            //    {
            //        dgvCustomerBillOS.DataSource = null;
            //        dgvCustomerBillAdjusted.DataSource = null;
            //        lblAmtOSVal.Text = String.Empty;
            //        lblAmtAdjVal.Text = String.Empty;
            //        dgvReceiptFromCustomer.CurrentCell = dgvReceiptFromCustomer.Rows[rowIndex + 1].Cells["LedgerTypeCode"];
            //        // dgvReceiptFromCustomer.BeginEdit(true);
            //    }
            //}
        }

        private ReceiptPaymentItem FillDataboundToCurrentRow()
        {
            ReceiptPaymentItem receiptPaymentItem = new ReceiptPaymentItem();
            if (dgvReceiptFromCustomer.SelectedCells.Count > 0)
            {
                int rowIndex = dgvReceiptFromCustomer.SelectedCells[0].RowIndex;
                receiptPaymentItem.ReceiptPaymentID = (long)dgvReceiptFromCustomer.Rows[rowIndex].Cells["ReceiptPaymentID"].Value;
                receiptPaymentItem.VoucherNumber = Convert.ToString(dgvReceiptFromCustomer.Rows[rowIndex].Cells["VoucherNumber"].Value);
                receiptPaymentItem.VoucherTypeCode = Convert.ToString(dgvReceiptFromCustomer.Rows[rowIndex].Cells["VoucherTypeCode"].Value);
                receiptPaymentItem.VoucherDate = Convert.ToDateTime(dgvReceiptFromCustomer.Rows[rowIndex].Cells["VoucherDate"].Value);
                receiptPaymentItem.LedgerType = Convert.ToString(dgvReceiptFromCustomer.Rows[rowIndex].Cells["LedgerType"].Value);
                receiptPaymentItem.LedgerTypeCode = Convert.ToString(dgvReceiptFromCustomer.Rows[rowIndex].Cells["LedgerTypeCode"].Value);
                receiptPaymentItem.PaymentMode = Convert.ToString(dgvReceiptFromCustomer.Rows[rowIndex].Cells["PaymentMode"].Value);
                receiptPaymentItem.Amount = ExtensionMethods.SafeConversionDecimal(Convert.ToString(dgvReceiptFromCustomer.Rows[rowIndex].Cells["Amount"].Value));
                receiptPaymentItem.ChequeNumber = Convert.ToString(dgvReceiptFromCustomer.Rows[rowIndex].Cells["ChequeNumber"].Value);
                receiptPaymentItem.BankAccountLedgerTypeCode = Convert.ToString(txtTransactAccount.Tag);
                receiptPaymentItem.BankAccountLedgerTypeName = Convert.ToString(txtTransactAccount.Text);
                receiptPaymentItem.ChequeDate = ExtensionMethods.ConvertToSystemDateFormat(dtReceiptPayment.Text);
                receiptPaymentItem.UnadjustedAmount = ExtensionMethods.SafeConversionDecimal(Convert.ToString(dgvReceiptFromCustomer.Rows[rowIndex].Cells["UnadjustedAmount"].Value));
            }
            return receiptPaymentItem;
        }

        private void UpdateReceiptPaymentRow(ReceiptPaymentItem receiptPayment)
        {
            int rowIndex = -1;
            int colIndex = -1;

            if (dgvReceiptFromCustomer.SelectedCells.Count > 0)
            {
                rowIndex = dgvReceiptFromCustomer.SelectedCells[0].RowIndex;
                colIndex = dgvReceiptFromCustomer.SelectedCells[0].ColumnIndex;
                receiptPayment.ReceiptPaymentID = applicationFacade.InsertUpdateTempReceiptPayment(receiptPayment);

                dgvReceiptFromCustomer.Rows[rowIndex].Cells["ReceiptPaymentID"].Value = receiptPayment.ReceiptPaymentID;
                dgvReceiptFromCustomer.Rows[rowIndex].Cells["LedgerTypeCode"].Value = receiptPayment.LedgerTypeCode;
                dgvReceiptFromCustomer.Rows[rowIndex].Cells["LedgerTypeName"].Value = receiptPayment.LedgerTypeName;
                dgvReceiptFromCustomer.Rows[rowIndex].Cells["PaymentMode"].Value = receiptPayment.PaymentMode;
                dgvReceiptFromCustomer.Rows[rowIndex].Cells["ChequeNumber"].Value = receiptPayment.ChequeNumber;
                dgvReceiptFromCustomer.Rows[rowIndex].Cells["BankAccountLedgerTypeName"].Value = receiptPayment.BankAccountLedgerTypeName;
                dgvReceiptFromCustomer.Rows[rowIndex].Cells["BankAccountLedgerTypeCode"].Value = receiptPayment.BankAccountLedgerTypeCode;
                dgvReceiptFromCustomer.Rows[rowIndex].Cells["ChequeDate"].Value = receiptPayment.ChequeDate == null ? String.Empty : ExtensionMethods.ConvertToAppDateFormat((DateTime)receiptPayment.ChequeDate);
                dgvReceiptFromCustomer.Rows[rowIndex].Cells["Amount"].Value = receiptPayment.Amount;
                dgvReceiptFromCustomer.Rows[rowIndex].Cells["ConsumedAmount"].Value = receiptPayment.Amount - receiptPayment.UnadjustedAmount;
                dgvReceiptFromCustomer.Rows[rowIndex].Cells["UnadjustedAmount"].Value = receiptPayment.UnadjustedAmount;
                dgvReceiptFromCustomer.Rows[rowIndex].Cells["OldReceiptPaymentID"].Value = receiptPayment.OldReceiptPaymentID;
            }
        }

        ///Grid UI Events 
        ///
        public void GotFocusEventRaised(Control control)
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

        private void C_GotFocus(object sender, EventArgs e)
        {
            ExtensionMethods.DisableAllTextBoxAndComboBox(this, (Control)sender);
            return;
        }

        private void EnterKeyDownForTabEvents(Control control)
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
                        frmTransactions frmTrans = new frmTransactions(ExtensionMethods.ConvertToSystemDateFormat(dtReceiptPayment.Text), Constants.LedgerType.CustomerLedger);
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
                if (dgvReceiptFromCustomer.SelectedCells.Count > 0)
                {
                    if (DialogResult.Yes == MessageBox.Show(Constants.Messages.SaveDataPrompt, Constants.Messages.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        List<long> listTempReceiptPaymentList = new List<long>();
                        foreach (DataGridViewRow receiptPaymentRow in dgvReceiptFromCustomer.Rows.Cast<DataGridViewRow>())
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
                if (dgvReceiptFromCustomer.SelectedCells.Count > 0)
                {
                    int rowIndex = dgvReceiptFromCustomer.SelectedCells[0].RowIndex;
                    if (DialogResult.Yes == MessageBox.Show(Constants.Messages.DeletePrompt, Constants.Messages.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        if (dgvReceiptFromCustomer.Rows[rowIndex].Cells["ReceiptPaymentID"].Value != null)
                        {
                            TransactionEntity tranEntity = new TransactionEntity();
                            tranEntity.ReceiptPaymentID = (long)dgvReceiptFromCustomer.Rows[rowIndex].Cells["ReceiptPaymentID"].Value;
                            tranEntity.EntityCode = Convert.ToString(dgvReceiptFromCustomer.Rows[rowIndex].Cells["LedgerTypeCode"].Value);

                            applicationFacade.ClearTempTransaction(tranEntity);
                            dgvReceiptFromCustomer.Rows.RemoveAt(rowIndex);
                            dgvReceiptFromCustomer.Refresh();
                            if (dgvReceiptFromCustomer.Rows.Count == 0)
                            {
                                AddNewRowToGrid();
                                dgvReceiptFromCustomer.CurrentCell = dgvReceiptFromCustomer.Rows[0].Cells["LedgerTypeCode"];
                                dgvReceiptFromCustomer.BeginEdit(true);
                            }

                            RaisePaymentModeCalculations();
                            dgvCustomerBillOS.DataSource = null;
                            dgvCustomerBillAdjusted.DataSource = null;
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

            dgvReceiptFromCustomer.DataSource = null;
            dgvCustomerBillOS.DataSource = null;
            dgvCustomerBillAdjusted.DataSource = null;

            lblTotalCQ.Text = "Total Cheque";
            lblCQVal.Text = String.Empty;
            lblTotalCash.Text = "Total Cash";
            lblCashVal.Text = String.Empty;

            lblAmtOS.Text = "Amount Outstanding";
            lblAmtOSVal.Text = String.Empty;
            lblAmtAdj.Text = "Amount Adjusted";
            lblAmtAdjVal.Text = String.Empty;
        }

        private void frmReceiptFromCustomer_FormClosing(object sender, FormClosingEventArgs e)
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
            if (!IsInEditMode || (IsInEditMode && dgvReceiptFromCustomer.Rows.Count == 0))
            {
                int rowIndex = dgvReceiptFromCustomer.Rows.Add();               
            }
        }

        private List<int> GetUnsavedReceiptPayment()
        {
            List<int> unsavedReceivedPayment = new List<int>();
            unsavedReceivedPayment=dgvReceiptFromCustomer.Rows.Cast<DataGridViewRow>().Where(r =>!String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["ReceiptPaymentID"].Value)))
                                                               .Select(x => Convert.ToInt32(x.Cells["ReceiptPaymentID"].Value)).ToList();
            return unsavedReceivedPayment;
        }
    }
}
