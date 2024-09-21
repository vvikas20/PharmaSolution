using PharmaBusiness;
using PharmaBusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PharmaUI.Sale_Entry
{
    public partial class frmAllBillForCustomer : Form
    {
        IApplicationFacade applicationFacade;
        public string CustomerCode { get; set; }
        public int RowIndex { get; set; }

        List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding> list;

        public long PurchaseSaleBookHeaderID { get; set; }
        public string InvoiceNumber { get; private set; }

        public frmAllBillForCustomer(List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding> listinvoice)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
            list = listinvoice;
        }

        private void frmAllBillForCustomer_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "LIST OF SALE INVOICES");

            if (list == null)
            {
                list = new List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding>();
            }

            dgvSaleBill.DataSource = list.OrderByDescending(p => p.VoucherDate).ToList();

            ExtensionMethods.SetGridDefaultProperty(dgvSaleBill);


            dgvSaleBill.Columns["PurchaseSaleBookHeaderID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSaleBill.Columns["PurchaseSaleBookHeaderID"].Visible = true;
            dgvSaleBill.Columns["PurchaseSaleBookHeaderID"].HeaderText = "PurchaseSaleBookHeaderID";

            dgvSaleBill.Columns["InvoiceNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSaleBill.Columns["InvoiceNumber"].Visible = true;
            dgvSaleBill.Columns["InvoiceNumber"].HeaderText = "Sale Invoice No.";


            dgvSaleBill.Columns["VoucherDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSaleBill.Columns["VoucherDate"].Visible = true;
            dgvSaleBill.Columns["VoucherDate"].HeaderText = "Bill Date";

            dgvSaleBill.Columns["BillAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSaleBill.Columns["BillAmount"].Visible = true;
            dgvSaleBill.Columns["BillAmount"].HeaderText = "Bill Amount";

            if (dgvSaleBill.Rows.Count > 0)
            {
                dgvSaleBill.Rows[0].Selected = true;
            }

            dgvSaleBill.KeyDown += DgvSaleBill_KeyDown;

            this.FormClosing += FrmAllBillForCustomer_FormClosing;
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape || keyData == Keys.End)
            {
                this.Close();

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void FrmAllBillForCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.PurchaseSaleBookHeaderID = Convert.ToInt64(dgvSaleBill.SelectedRows[0].Cells["PurchaseSaleBookHeaderID"].Value);
            this.InvoiceNumber = Convert.ToString(dgvSaleBill.SelectedRows[0].Cells["InvoiceNumber"].Value);
        }

        private void DgvSaleBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Close();
            }
        }
    }
}
