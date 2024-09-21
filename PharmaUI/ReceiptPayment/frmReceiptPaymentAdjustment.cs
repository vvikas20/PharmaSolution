using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Transaction;
using PharmaBusinessObjects.Transaction.ReceiptPayment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PharmaBusinessObjects.Common.Enums;

namespace PharmaUI.ReceiptPayment
{
    public partial class frmReceiptPaymentAdjustment : Form
    {
        IApplicationFacade applicationFacade;
        public TransactionEntity CurrentTransactionEntity;
        public ReceiptPaymentState ReceiptPaymentState;
        public int RowIndex;


        public frmReceiptPaymentAdjustment(int _rowIndex)
        {          
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new PharmaBusiness.ApplicationFacade(ExtensionMethods.LoggedInUser);
            this.RowIndex = _rowIndex;
        }

        private void frmReceiptPaymentAdjustment_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, "Receipt Payment Adjustment");
                LoadGridBillAdjustment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvReceiptPaymentAdjustment_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dgvReceiptPaymentAdjustment.Columns[e.ColumnIndex].Name != "Amount")
                {

                    this.BeginInvoke(new MethodInvoker(() =>
                    {
                        SetAmountColumn(e.RowIndex);
                    }));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetAmountColumn(int rowIndex)
        {
            dgvReceiptPaymentAdjustment.CurrentCell = dgvReceiptPaymentAdjustment.Rows[rowIndex].Cells["Amount"];
        }

        private void DgvReceiptPaymentAdjustment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvReceiptPaymentAdjustment.Rows.Count > 0)
                {
                    string columnName = dgvReceiptPaymentAdjustment.Columns[dgvReceiptPaymentAdjustment.SelectedCells[0].ColumnIndex].Name;

                    if (columnName == "Amount")
                    {
                        AdjustBillOS();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdjustBillOS()
        {
            decimal enteredAmount = ExtensionMethods.SafeConversionDecimal(Convert.ToString(dgvReceiptPaymentAdjustment.CurrentRow.Cells["Amount"].Value)) ?? default(decimal);
            decimal correspondingOSAmount = ExtensionMethods.SafeConversionDecimal(Convert.ToString(dgvReceiptPaymentAdjustment.CurrentRow.Cells["OSAmount"].Value)) ?? default(decimal);

            decimal utilizedAmount = GetTotallUtilizedAmount();

            if(enteredAmount == 0)
            {
                if(utilizedAmount > CurrentTransactionEntity.EntityTotalAmount)
                {
                    foreach (DataGridViewRow row in dgvReceiptPaymentAdjustment.Rows)
                    {
                        row.Cells["Amount"].Value = default(decimal);
                    }

                    utilizedAmount = default(decimal);
                }
            }

            decimal tempBalance = CurrentTransactionEntity.EntityTotalAmount - utilizedAmount;

            if (enteredAmount > tempBalance)
            {
                MessageBox.Show("Balance amount is less !");
                dgvReceiptPaymentAdjustment.CurrentRow.Cells["Amount"].Value = default(decimal);

            }
            //else if (enteredAmount > correspondingOSAmount)
            //{
            //    MessageBox.Show("Entered amount is greater than OS amount !");
            //    dgvReceiptPaymentAdjustment.CurrentRow.Cells["Amount"].Value = default(decimal);
            //}
            //else if (enteredAmount != 0)
            {
                CurrentTransactionEntity.EntityBalAmount = CurrentTransactionEntity.EntityTotalAmount - utilizedAmount - enteredAmount;
                lblBalAmountVal.Text = this.CurrentTransactionEntity.EntityBalAmount.ToString();
            }
        }

        private decimal GetTotallUtilizedAmount()
        {
            decimal utilizedAmount = 0;
            for (int i = 0; i < dgvReceiptPaymentAdjustment.Rows.Count; ++i)
            {
                if (i == dgvReceiptPaymentAdjustment.CurrentRow.Index)
                    continue;

                utilizedAmount += Convert.ToDecimal(dgvReceiptPaymentAdjustment.Rows[i].Cells["Amount"].Value);
            }
            return utilizedAmount;
        }

        private void LoadGridBillAdjustment()
        {
            dgvReceiptPaymentAdjustment.CellEndEdit -= DgvReceiptPaymentAdjustment_CellEndEdit;
            dgvReceiptPaymentAdjustment.CellEnter -= DgvReceiptPaymentAdjustment_CellEnter;            

            dgvReceiptPaymentAdjustment.DataSource = applicationFacade.GetAllInitialBillAdjustmentForLedger(CurrentTransactionEntity);

            dgvReceiptPaymentAdjustment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReceiptPaymentAdjustment.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvReceiptPaymentAdjustment.AllowUserToAddRows = false;

            for (int i = 0; i < dgvReceiptPaymentAdjustment.Columns.Count; i++)
            {
                dgvReceiptPaymentAdjustment.Columns[i].Visible = false;
            }

            dgvReceiptPaymentAdjustment.Columns["InvoiceNumber"].Visible = true;
            dgvReceiptPaymentAdjustment.Columns["InvoiceNumber"].HeaderText = "Bill Number";
            dgvReceiptPaymentAdjustment.Columns["InvoiceNumber"].ReadOnly = true;
            dgvReceiptPaymentAdjustment.Columns["InvoiceNumber"].DisplayIndex = 0;

            dgvReceiptPaymentAdjustment.Columns["InvoiceDate"].Visible = true;
            dgvReceiptPaymentAdjustment.Columns["InvoiceDate"].HeaderText = "Bill Date";
            dgvReceiptPaymentAdjustment.Columns["InvoiceDate"].ReadOnly = true;
            dgvReceiptPaymentAdjustment.Columns["InvoiceDate"].DisplayIndex = 1;
            dgvReceiptPaymentAdjustment.Columns["InvoiceDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvReceiptPaymentAdjustment.Columns["OSAmount"].Visible = true;
            dgvReceiptPaymentAdjustment.Columns["OSAmount"].HeaderText = "Outstanding Amount";
            dgvReceiptPaymentAdjustment.Columns["OSAmount"].ReadOnly = true;
            dgvReceiptPaymentAdjustment.Columns["OSAmount"].DisplayIndex = 2;

            dgvReceiptPaymentAdjustment.Columns["Amount"].Visible = true;
            dgvReceiptPaymentAdjustment.Columns["Amount"].HeaderText = "Amount";
            dgvReceiptPaymentAdjustment.Columns["Amount"].DisplayIndex = 3;

            dgvReceiptPaymentAdjustment.CellEndEdit += DgvReceiptPaymentAdjustment_CellEndEdit;
            dgvReceiptPaymentAdjustment.CellEnter += DgvReceiptPaymentAdjustment_CellEnter;
            dgvReceiptPaymentAdjustment.KeyDown += DgvReceiptPaymentAdjustment_KeyDown;
        }

        private void DgvReceiptPaymentAdjustment_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter && dgvReceiptPaymentAdjustment.Rows.Count > 0)
                {
                    if (dgvReceiptPaymentAdjustment.CurrentCell.Value != null
                       && (decimal)dgvReceiptPaymentAdjustment.CurrentCell.Value == default(decimal))
                    {
                        decimal correspondingOSAmount = ExtensionMethods.SafeConversionDecimal(Convert.ToString(dgvReceiptPaymentAdjustment.CurrentRow.Cells["OSAmount"].Value)) ?? default(decimal);
                        dgvReceiptPaymentAdjustment.CurrentCell.Value = CurrentTransactionEntity.EntityBalAmount > correspondingOSAmount ? correspondingOSAmount
                                                                                                                                         : CurrentTransactionEntity.EntityBalAmount;
                        AdjustBillOS();
                    }
                }          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ConfigureReceiptPaymentAdjustment(TransactionEntity transactionEntity)
        {
            this.CurrentTransactionEntity = transactionEntity;

            this.lblPartyCodeVal.Text = transactionEntity.EntityCode;
            this.lblPartyNameVal.Text = transactionEntity.EntityName;
            this.lblTotalAmountVal.Text = Convert.ToString(transactionEntity.EntityTotalAmount);
            this.lblBalAmountVal.Text = Convert.ToString(transactionEntity.EntityBalAmount);          
        }
    
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if(keyData == Keys.End)
            {
                if (dgvReceiptPaymentAdjustment.Rows.Count > 0)
                {
                    List<BillAdjusted> listBillAdjustment = dgvReceiptPaymentAdjustment.Rows
                                                                             .Cast<DataGridViewRow>()
                                                                             .Where(r => !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["Amount"].Value)) && Convert.ToDecimal(r.Cells["Amount"].Value) != 0)
                                                                             .Select(x => new BillAdjusted()
                                                                             {
                                                                                 ReceiptPaymentID = CurrentTransactionEntity.ReceiptPaymentID,
                                                                                 PurchaseSaleBookHeaderID = (x.DataBoundItem as BillAdjusted).PurchaseSaleBookHeaderID,
                                                                                 BillOutStandingsID = (x.DataBoundItem as BillAdjusted).BillOutStandingsID,
                                                                                 AdjustmentVoucherNumber = (x.DataBoundItem as BillAdjusted).VoucherNumber,
                                                                                 AdjustmentVoucherTypeCode = (x.DataBoundItem as BillAdjusted).VoucherTypeCode,
                                                                                 AdjustmentVoucherDate = (x.DataBoundItem as BillAdjusted).VoucherDate,
                                                                                 LedgerType = (x.DataBoundItem as BillAdjusted).LedgerType,
                                                                                 LedgerTypeCode = (x.DataBoundItem as BillAdjusted).LedgerTypeCode,
                                                                                 Amount = (x.DataBoundItem as BillAdjusted).Amount,

                                                                             }).ToList();

                    applicationFacade.InsertTempBillAdjustment(listBillAdjustment);

                    ReceiptPaymentState = ReceiptPaymentState.Save;
                    this.Close();
                }            
            }
            else if (keyData == Keys.Escape)
            {
                if (dgvReceiptPaymentAdjustment.Rows.Count > 0)
                {
                    if (DialogResult.Yes == MessageBox.Show(Constants.Messages.UnsavedDataWarning, Constants.Messages.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        ReceiptPaymentState = ReceiptPaymentState.Cancel;
                        applicationFacade.ClearTempBillAdjustment(CurrentTransactionEntity);
                        this.Close();
                    }
                }
                else
                {
                    ReceiptPaymentState = ReceiptPaymentState.Cancel;
                    this.Close();
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
