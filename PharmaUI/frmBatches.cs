using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PharmaUI
{
    public partial class frmBatches : Form
    {
       IApplicationFacade applicationFacade;
       private string ItemCode { get; set; }
       private string ItemName { get; set; }

        public frmBatches(string _itemCode,string _itemName)
        {
            InitializeComponent();
            ExtensionMethods.SetFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
            ItemCode = _itemCode;
            ItemName = _itemName;
        }

        private void frmBatches_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, "Batch List - Item Code - " + ItemName) ;
                ExtensionMethods.EnterKeyDownForTabEvents(this);

                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvbatchList_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.F3)
            {
                if (dgvbatchList.CurrentRow != null)
                {
                    FifoBatches fifoBatches = dgvbatchList.CurrentRow.DataBoundItem as FifoBatches;

                    frmBatchesEdit frm = new frmBatchesEdit(fifoBatches);
                    frm.FormClosed += Frm_FormClosed;
                    frm.ShowDialog();
                }
            }
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadDataGrid();
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

        private void LoadDataGrid()
        {
            dgvbatchList.DataSource = applicationFacade.GetFifoBatchesByItemCode(ItemCode);
            ExtensionMethods.SetGridDefaultProperty(dgvbatchList);

            dgvbatchList.Columns["Batch"].Visible = true;
            dgvbatchList.Columns["Batch"].HeaderText = "Batch";

            dgvbatchList.Columns["VoucherDate"].Visible = true;
            dgvbatchList.Columns["VoucherDate"].HeaderText = "Voucher Date";

            dgvbatchList.Columns["PurchaseRate"].Visible = true;
            dgvbatchList.Columns["PurchaseRate"].HeaderText = "Purchase Rate";

            dgvbatchList.Columns["SaleRate"].Visible = true;
            dgvbatchList.Columns["SaleRate"].HeaderText = "Sale Rate";

            dgvbatchList.Columns["Quantity"].Visible = true;
            dgvbatchList.Columns["Quantity"].HeaderText = "Quantity";

            dgvbatchList.Columns["BalanceQuanity"].Visible = true;
            dgvbatchList.Columns["BalanceQuanity"].HeaderText = "Balance Quanity";

            dgvbatchList.Columns["Scheme"].Visible = true;
            dgvbatchList.Columns["Scheme"].HeaderText = "Scheme";

            dgvbatchList.KeyDown += DgvbatchList_KeyDown;
        }
    }
}
