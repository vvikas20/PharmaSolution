using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Transaction.ReceiptPayment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PharmaUI.ReceiptPayment
{
    public partial class frmTransactions : Form
    {
        public DateTime TransactionDate { get; set; }
        public string TransactionEntityType { get; set; }
        public ReceiptPaymentItem SelectedTransaction { get; set; }
        IApplicationFacade applicationFacade;

        public frmTransactions(DateTime TransactionDate, string TransactionEntityType)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);

            this.TransactionDate = TransactionDate;
            this.TransactionEntityType = TransactionEntityType;
        }

        private void frmTransactions_Load(object sender, EventArgs e)
        {
            if(TransactionEntityType== Constants.LedgerType.CustomerLedger)
            {
                ExtensionMethods.FormLoad(this, "Transactions for Customer");
            }
            else
            {
                ExtensionMethods.FormLoad(this, "Transactions for Supplier");
            }

            GotFocusEventRaised(this);
            ExtensionMethods.EnterKeyDownForTabEvents(this);

            ///Load Grid
            ///
            dgvTransactions.DataSource = applicationFacade.GetAllTransactionForParticularDate(TransactionDate,TransactionEntityType);

            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.AllowUserToAddRows = false;

            for (int i = 0; i < dgvTransactions.Columns.Count; i++)
            {
                dgvTransactions.Columns[i].Visible = false;
            }

            dgvTransactions.Columns["VoucherDate"].Visible = true;
            dgvTransactions.Columns["VoucherDate"].HeaderText = "Bill Date";
            dgvTransactions.Columns["VoucherDate"].ReadOnly = true;
            dgvTransactions.Columns["VoucherDate"].DisplayIndex = 0;
            dgvTransactions.Columns["VoucherDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvTransactions.Columns["VoucherNumber"].Visible = true;
            dgvTransactions.Columns["VoucherNumber"].HeaderText = "Voucher Number";
            dgvTransactions.Columns["VoucherNumber"].DisplayIndex = 1;

            dgvTransactions.Columns["LedgerTypeCode"].Visible = true;
            dgvTransactions.Columns["LedgerTypeCode"].HeaderText = "Ledger Code";
            dgvTransactions.Columns["LedgerTypeCode"].ReadOnly = true;
            dgvTransactions.Columns["LedgerTypeCode"].DisplayIndex = 2;

            dgvTransactions.Columns["LedgerTypeName"].Visible = true;
            dgvTransactions.Columns["LedgerTypeName"].HeaderText = "Ledger Name";
            dgvTransactions.Columns["LedgerTypeName"].ReadOnly = true;
            dgvTransactions.Columns["LedgerTypeName"].DisplayIndex = 3;

            dgvTransactions.Columns["Amount"].Visible = true;
            dgvTransactions.Columns["Amount"].HeaderText = "Amount";
            dgvTransactions.Columns["Amount"].ReadOnly = true;
            dgvTransactions.Columns["Amount"].DisplayIndex = 4;


            ///Events 
            ///
            dgvTransactions.KeyDown += DgvTransactions_KeyDown;
        }

        private void DgvTransactions_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter && dgvTransactions.Rows.Count > 0 && dgvTransactions.SelectedRows.Count>0)
                {
                    SelectedTransaction = dgvTransactions.SelectedRows[0].DataBoundItem as ReceiptPaymentItem;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Add
            if (keyData == Keys.Escape)
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

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
                }
            }
        }

        private void C_GotFocus(object sender, EventArgs e)
        {
            ExtensionMethods.DisableAllTextBoxAndComboBox(this, (Control)sender);
            return;
        }
    }
}
