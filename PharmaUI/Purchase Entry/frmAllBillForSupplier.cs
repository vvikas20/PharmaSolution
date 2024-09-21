using PharmaBusiness;
using PharmaBusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmaUI.Purchase_Entry
{
    public partial class frmAllBillForSupplier : Form
    {
        IApplicationFacade applicationFacade;
        public string SupplierCode { get; set; }
        public int RowIndex { get; set; }
        public string Date { get; set; }

        public long PurchaseSaleBookHeaderID { get; set; }

        public frmAllBillForSupplier(string _supplierCode, string date)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
            SupplierCode = _supplierCode;
            Date = date;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape || keyData == Keys.End)
            {
                this.Close();

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }



        private void frmAllBillForSupplier_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "LIST OF PURCHASE INVOICES");

            List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding> list = applicationFacade.GetAllPurchaseInvoiceForSuppier(SupplierCode,Date);

            if (list == null)
                list = new List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding>();

            dgvPurchaseBill.DataSource = list.OrderByDescending(p => p.VoucherDate).ToList();

            ExtensionMethods.SetGridDefaultProperty(dgvPurchaseBill);


            dgvPurchaseBill.Columns["PurchaseSaleBookHeaderID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPurchaseBill.Columns["PurchaseSaleBookHeaderID"].Visible = true;
            dgvPurchaseBill.Columns["PurchaseSaleBookHeaderID"].HeaderText = "PurchaseSaleBookHeaderID";

            dgvPurchaseBill.Columns["InvoiceNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPurchaseBill.Columns["InvoiceNumber"].Visible = true;
            dgvPurchaseBill.Columns["InvoiceNumber"].HeaderText = "Purchase Bill No.";


            dgvPurchaseBill.Columns["VoucherDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPurchaseBill.Columns["VoucherDate"].Visible = true;
            dgvPurchaseBill.Columns["VoucherDate"].HeaderText = "Bill Date";

            dgvPurchaseBill.Columns["BillAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPurchaseBill.Columns["BillAmount"].Visible = true;
            dgvPurchaseBill.Columns["BillAmount"].HeaderText = "Bill Amount";

            if (dgvPurchaseBill.Rows.Count > 0)
            {
                dgvPurchaseBill.Rows[0].Selected = true;
            }

            dgvPurchaseBill.KeyDown += DgvPurchaseBill_KeyDown;

            this.FormClosing += FrmAllBillForSupplier_FormClosing;

        }

        private void DgvPurchaseBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Close();
            }
        }

        private void FrmAllBillForSupplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dgvPurchaseBill.Rows.Count > 0)
            {
                this.PurchaseSaleBookHeaderID = Convert.ToInt64(dgvPurchaseBill.SelectedRows[0].Cells["PurchaseSaleBookHeaderID"].Value);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
