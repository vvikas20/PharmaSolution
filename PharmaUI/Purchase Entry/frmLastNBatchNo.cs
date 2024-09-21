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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmaUI
{
    public partial class frmLastNBatchNo : Form
    {
        IApplicationFacade applicationFacade;

        public string SupplierCode { get; set; }
        public int RowIndex { get; set; }
        public PurchaseSaleBookLineItem PurchaseBookLineItem { get; set; }
        private List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> list;

        public frmLastNBatchNo(List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> _list, PurchaseSaleBookLineItem item)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
            list = _list;
            PurchaseBookLineItem = item;
        }

        private void frmLastNBatchNo_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Last 5 Batch No.");      
            
            dgvLastBatch.DataSource = list.OrderByDescending(p=>p.PurchaseBillDate).ToList();

            ExtensionMethods.SetGridDefaultProperty(dgvLastBatch);


            dgvLastBatch.Columns["ItemCode"].Visible = true;
            dgvLastBatch.Columns["ItemCode"].HeaderText = "Item";

            dgvLastBatch.Columns["PurchaseSaleRate"].Visible = true;
            dgvLastBatch.Columns["PurchaseSaleRate"].HeaderText = "Rate";

            dgvLastBatch.Columns["Batch"].Visible = true;
            dgvLastBatch.Columns["Batch"].HeaderText = "Batch No";

            dgvLastBatch.Columns["Discount"].Visible = true;
            dgvLastBatch.Columns["Discount"].HeaderText = "Discount";

            dgvLastBatch.Columns["SpecialDiscount"].Visible = true;
            dgvLastBatch.Columns["SpecialDiscount"].HeaderText = "Spl Discount";

            dgvLastBatch.Columns["VolumeDiscount"].Visible = true;
            dgvLastBatch.Columns["VolumeDiscount"].HeaderText = "Volume Discount";

            dgvLastBatch.Columns["ExpiryDate"].Visible = true;
            dgvLastBatch.Columns["ExpiryDate"].HeaderText = "Expiry Date";
    
            dgvLastBatch.KeyDown += DgvLastBatch_KeyDown;

            if (list.Count == 0)
            {
                this.Close();
            }
            else
            {
                dgvLastBatch.Rows[0].Selected = true;
            }


            this.FormClosing += FrmLastNBatchNo_FormClosing;
        }

        private void DgvLastBatch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Close();
                }
                if ((e.KeyData & Keys.KeyCode) == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                }
                else
                    base.OnKeyDown(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape || keyData == Keys.End)
            {
                this.Close();

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void FrmLastNBatchNo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dgvLastBatch.Rows.Count > 0)
            {
                PurchaseSaleBookLineItem item = (PurchaseSaleBookLineItem)dgvLastBatch.Rows[0].DataBoundItem;
                PurchaseBookLineItem.Batch = item.Batch;
                PurchaseBookLineItem.Discount = item.Discount;
                PurchaseBookLineItem.SpecialDiscount = item.SpecialDiscount;
                PurchaseBookLineItem.VolumeDiscount = item.VolumeDiscount;
                PurchaseBookLineItem.ExpiryDate = item.ExpiryDate;
                
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
