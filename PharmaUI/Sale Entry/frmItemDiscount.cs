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
    public partial class frmItemDiscount : Form
    {
        IApplicationFacade applicationFacade;
        PurchaseSaleBookLineItem saleLineItem;
        public int RowIndex { get; set; }
        public PurchaseSaleBookLineItem SaleLinetem { get { return saleLineItem; } }
        private string customerCode = string.Empty;

        public frmItemDiscount(PurchaseSaleBookLineItem item, string code)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new PharmaBusiness.ApplicationFacade(ExtensionMethods.LoggedInUser);
            saleLineItem = item;
            customerCode = code;
        }

        private void frmItemDiscount_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, string.Format("Item {0} {1}", saleLineItem.ItemCode, saleLineItem.ItemName));

            GotFocusEventRaised(this);
            EnterKeyDownForTabEvents(this);
            FillFormForUpdate();

        }

        private void FillFormForUpdate()
        {
            txtDiscount.Text = (saleLineItem.Discount??0).ToString("#.##");
            txtVolumeDiscount.Text = (saleLineItem.VolumeDiscount ?? 0).ToString("#.##");
            txtSpecialDiscount.Text = (saleLineItem.SpecialDiscount ?? 0).ToString("#.##");
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

        private void frmItemDiscount_FormClosing(object sender, FormClosingEventArgs e)
        {
            decimal value = 0;
            bool ischange = false;
            decimal.TryParse(txtDiscount.Text, out value);
            ischange = saleLineItem.Discount != value;
            saleLineItem.Discount = value;

            decimal.TryParse(txtSpecialDiscount.Text, out value);
            ischange = ischange || saleLineItem.SpecialDiscount != value;
            saleLineItem.SpecialDiscount = value;

            decimal.TryParse(txtVolumeDiscount.Text, out value);
            ischange = ischange || saleLineItem.VolumeDiscount != value;
            saleLineItem.VolumeDiscount = value;

            if (ischange)
            {
                frmChangeType changeType = new frmChangeType();
                changeType.FormClosed += ChangeType_FormClosed;
                changeType.Show();
                e.Cancel = true;
            }

        }

        private void ChangeType_FormClosed(object sender, FormClosedEventArgs e)
        {

            frmChangeType changeType = sender as frmChangeType;
            decimal discount;
            decimal.TryParse(txtDiscount.Text, out discount);

            decimal specialDiscount;
            decimal.TryParse(txtSpecialDiscount.Text, out specialDiscount);

            DataRow dr = StagingData.ItemList.Select("ItemCode=" + saleLineItem.ItemCode).FirstOrDefault();
            if (dr != null)
            {
                dr["SpecialDiscountRecieved"] = specialDiscount;
            }

            decimal volumeDiscount;
            decimal.TryParse(txtVolumeDiscount.Text, out volumeDiscount);

            if(changeType.ChangeType != PharmaBusinessObjects.Common.Enums.SaleEntryChangeType.TemporaryChange)
                applicationFacade.UpdateSaleDiscount(changeType.ChangeType, discount, specialDiscount, volumeDiscount, saleLineItem.ItemCode, customerCode);

            this.Close();

        }

        private void tblDiscount_Paint(object sender, PaintEventArgs e)
        {

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
                Control ctl = sender as Control;
                if (ctl.Name == "txtVolumeDiscount")
                {
                    this.Close();
                }
                else
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
