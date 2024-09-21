using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Master;
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

namespace PharmaUI
{
    public partial class frmItemMasterAddUpdated : Form
    {
        IApplicationFacade applicationFacade;
        private int _itemId = 0;
        private string _itemName = "";
        public bool IsInChildMode = false;

        public frmItemMasterAddUpdated(int itemId , string itemName)
        {
            try
            {
                InitializeComponent();
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
                ExtensionMethods.SetFormProperties(this);
                _itemId = itemId;
                _itemName = itemName;
                LoadCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCombo()
        {
            cbxFixedDiscount.SelectedIndexChanged += CbxFixedDiscount_SelectedIndexChanged;

            //Fill half Scheme options
            cbxHalfScheme.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbxHalfScheme.SelectedItem = Choice.No;

            //Fill qtr Scheme options
            cbxQtrScheme.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbxQtrScheme.SelectedItem = Choice.No;

            //Fill fixed discount options
            cbxFixedDiscount.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbxFixedDiscount.SelectedItem = Choice.No;

            //Fill status options
            cbxStatus.DataSource = Enum.GetValues(typeof(Enums.Status));
            cbxStatus.SelectedItem = Status.Active;

            //Fill sale type list
            cbxSaleType.DataSource = applicationFacade.GetAccountLedgerBySystemName("SaleLedger");
            cbxSaleType.DisplayMember = "AccountLedgerName";
            cbxSaleType.ValueMember = "AccountLedgerID";

            //Fill purchase type list
            cbxPurchaseType.DataSource = applicationFacade.GetAccountLedgerBySystemName("PurchaseLedger");
            cbxPurchaseType.DisplayMember = "AccountLedgerName";
            cbxPurchaseType.ValueMember = "AccountLedgerID";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (String.IsNullOrWhiteSpace(tbxItemName.Text))
                {
                    errorProviderItem.SetError(tbxItemName, Constants.Messages.RequiredField);
                    tbxItemName.SelectAll();
                    tbxItemName.Focus();
                    return;
                }

                Choice choice;
                Status status;

                ItemMaster item = new ItemMaster();
                item.ItemCode = tbxItemCode.Text;
                item.ItemName = tbxItemName.Text;
                item.CompanyID =(int)tbxCompany.Tag;
                item.ConversionRate = ExtensionMethods.SafeConversionDecimal(tbxConvRate.Text);
                item.ShortName = tbxShortName.Text;
                item.Packing = tbxPacking.Text;
                item.PurchaseRate = ExtensionMethods.SafeConversionDecimal(tbxPurchaseRate.Text);
                item.MRP = ExtensionMethods.SafeConversionDecimal(tbxMRP.Text) ?? default(decimal);
                item.SaleRate = ExtensionMethods.SafeConversionDecimal(tbxSaleRate.Text);
                item.SpecialRate = ExtensionMethods.SafeConversionDecimal(tbxSpecialRate.Text);
                item.WholeSaleRate = ExtensionMethods.SafeConversionDecimal(tbxWholeSaleRate.Text);
                item.SaleExcise = ExtensionMethods.SafeConversionDecimal(tbxSaleExcise.Text);
                item.SurchargeOnSale = ExtensionMethods.SafeConversionDecimal(tbxSCOnSale.Text);
                item.TaxOnSale = (cbxSaleType.SelectedItem as AccountLedgerMaster).SalePurchaseTaxValue;
                item.Scheme1 = ExtensionMethods.SafeConversionDecimal(tbxScheme1.Text);
                item.Scheme2 = ExtensionMethods.SafeConversionDecimal(tbxScheme2.Text);
                item.PurchaseExcise = ExtensionMethods.SafeConversionDecimal(tbxPurchaseExcise.Text);
                item.UPC = tbxUPC.Text;
                Enum.TryParse<Choice>(cbxHalfScheme.SelectedValue.ToString(), out choice);
                item.IsHalfScheme = choice == Choice.Yes;
                Enum.TryParse<Choice>(cbxQtrScheme.SelectedValue.ToString(), out choice);
                item.IsQTRScheme = choice == Choice.Yes;
                item.SpecialDiscount = ExtensionMethods.SafeConversionDecimal(tbxSpecialDiscount.Text);
                item.SpecialDiscountOnQty = ExtensionMethods.SafeConversionDecimal(tbxSpecialDiscountOnQty.Text);
                Enum.TryParse<Choice>(cbxFixedDiscount.SelectedValue.ToString(), out choice);
                item.IsFixedDiscount = choice == Choice.Yes;
                item.FixedDiscountRate = ExtensionMethods.SafeConversionDecimal(tbxFixedDiscountRate.Text);
                item.MaximumQty = ExtensionMethods.SafeConversionDecimal(tbxMaxQty.Text);
                item.MaximumDiscount = ExtensionMethods.SafeConversionDecimal(tbxMaxDiscount.Text);
                item.SurchargeOnPurchase = ExtensionMethods.SafeConversionDecimal(tbxSCOnPurchase.Text);
                item.TaxOnPurchase = (cbxPurchaseType.SelectedItem as AccountLedgerMaster).SalePurchaseTaxValue;
                item.DiscountRecieved = ExtensionMethods.SafeConversionDecimal(tbxDiscountRecieved.Text);
                item.SpecialDiscountRecieved = ExtensionMethods.SafeConversionDecimal(tbxSpecialDiscountRecieved.Text);
                item.QtyPerCase = ExtensionMethods.SafeConversionDecimal(tbxQtyPerCase.Text);
                item.Location = tbxLocation.Text;
                item.MinimumStock = ExtensionMethods.SafeConversionInt(tbxMinimumStock.Text);
                item.MaximumStock = ExtensionMethods.SafeConversionInt(tbxMaximumStock.Text);
                item.SaleTypeId = (cbxSaleType.SelectedItem as AccountLedgerMaster).AccountLedgerID;
                item.PurchaseTypeId = (cbxPurchaseType.SelectedItem as AccountLedgerMaster).AccountLedgerID;
                Enum.TryParse<Status>(cbxStatus.SelectedValue.ToString(), out status);
                item.Status = status == Status.Active;
                item.HSNCode =tbxHSNCode.Text;

                bool actionResult = false;
                // if form is in Edit mode then udate item , else add item 
                if (_itemId == 0)
                {
                    actionResult = applicationFacade.AddNewItem(item);
                }
                else
                {
                    actionResult = applicationFacade.UpdateItem(item);
                }

                //Close this form if operation is successful
                if (actionResult)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void frmItemMasterAddUpdatedNew_Load(object sender, EventArgs e)
        {
            try
            {

                ExtensionMethods.FormLoad(this, _itemId > 0 ? "Item Master - Update" : "Item Master - Add");
                GotFocusEventRaised(this);
                EnterKeyDownForTabEvents(this);

                if (_itemId == 0)
                {
                    tbxItemName.Text = _itemName;
                }
                else
                {
                    tbxCompany.Enabled = false;
                }

                tbxItemName.Focus();

                //Event to allow only decimal entry
                {
                    tbxConvRate.KeyPress += TbxAllowDecimal_KeyPress;
                   // tbxPacking.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxPurchaseRate.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxMRP.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxSaleRate.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxSpecialRate.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxWholeSaleRate.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxSaleExcise.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxSCOnSale.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxScheme1.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxScheme2.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxPurchaseExcise.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxSpecialDiscount.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxSpecialDiscountOnQty.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxFixedDiscountRate.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxMaxQty.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxMaxDiscount.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxSCOnPurchase.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxTaxOnPurchase.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxDiscountRecieved.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxSpecialDiscountRecieved.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxQtyPerCase.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxMinimumStock.KeyPress += TbxAllowDecimal_KeyPress;
                    tbxMaximumStock.KeyPress += TbxAllowDecimal_KeyPress;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void CbxFixedDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cbxFixedDiscount.SelectedItem == null) return;

                Choice choice;
                Enum.TryParse<Choice>(cbxFixedDiscount.SelectedItem.ToString(), out choice);

                if (choice == Choice.Yes)
                {
                    tbxFixedDiscountRate.ReadOnly = false;
                }
                else
                {
                    tbxFixedDiscountRate.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbxComanyCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbxComanyCode.SelectedItem == null) return;

            //Company selectedCompany = cbxComanyCode.SelectedItem as Company;

            //if (selectedCompany != null && !isInEditMode)
            //{
            //    tbxItemCode.Text = applicationFacade.GetNextItemCode(Convert.ToString(selectedCompany.CompanyCode));
            //}

            //int index = cbxComanyCode.FindString(cbxComanyCode.Text);
            //if (index < 0)
            //{
            //    DialogResult result = MessageBox.Show("Comany does not exist. Do you want to add new company ?", Constants.Messages.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //    if (result == DialogResult.Yes)
            //    {

            //    }
            //    else
            //    {
            //        cbxComanyCode.SelectedIndex = 1;
            //        return;
            //    }
            //}

            //ExtensionMethods.DisableAllTextBoxAndComboBox(cbxComanyCode, tbxItemCode);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                errorProviderItem.Clear();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        public void frmItemMasterAddUpdate_Fill_UsingExistingItem(ItemMaster existingItem)
        {

           

            if (existingItem != null)
            {
                tbxItemCode.Text = existingItem.ItemCode;
                tbxItemName.Text = existingItem.ItemName;

                tbxCompany.Text = existingItem.CompanyName;
                tbxCompany.Tag = existingItem.CompanyID;

                tbxConvRate.Text = Convert.ToString(existingItem.ConversionRate);
                tbxShortName.Text = existingItem.ShortName;
                tbxPacking.Text = existingItem.Packing;
                tbxPurchaseRate.Text = Convert.ToString(existingItem.PurchaseRate);
                tbxMRP.Text = Convert.ToString(existingItem.MRP);
                tbxSaleRate.Text = Convert.ToString(existingItem.SaleRate);
                tbxSpecialRate.Text = Convert.ToString(existingItem.SpecialRate);
                tbxWholeSaleRate.Text = Convert.ToString(existingItem.WholeSaleRate);
                tbxSaleExcise.Text = Convert.ToString(existingItem.SaleExcise);
                tbxSCOnSale.Text = Convert.ToString(existingItem.SurchargeOnSale);
                tbxTaxOnSale.Text = Convert.ToString(existingItem.TaxOnSale);
                tbxScheme1.Text = Convert.ToString(existingItem.Scheme1);
                tbxScheme2.Text = Convert.ToString(existingItem.Scheme2);
                tbxPurchaseExcise.Text = Convert.ToString(existingItem.PurchaseExcise);
                tbxUPC.Text = existingItem.UPC;
                cbxHalfScheme.SelectedItem = existingItem.IsHalfScheme ? Choice.Yes : Choice.No;
                cbxQtrScheme.SelectedItem = existingItem.IsQTRScheme ? Choice.Yes : Choice.No;
                tbxSpecialDiscount.Text = Convert.ToString(existingItem.SpecialDiscount);
                tbxSpecialDiscountOnQty.Text = Convert.ToString(existingItem.SpecialDiscountOnQty);
                cbxFixedDiscount.SelectedItem = existingItem.IsFixedDiscount ? Choice.Yes : Choice.No;
                tbxFixedDiscountRate.Text = Convert.ToString(existingItem.FixedDiscountRate);
                tbxMaxQty.Text = Convert.ToString(existingItem.MaximumQty);
                tbxMaxDiscount.Text = Convert.ToString(existingItem.MaximumDiscount);
                tbxSCOnPurchase.Text = Convert.ToString(existingItem.SurchargeOnPurchase);
                tbxTaxOnPurchase.Text = Convert.ToString(existingItem.TaxOnPurchase);
                tbxDiscountRecieved.Text = Convert.ToString(existingItem.DiscountRecieved);
                tbxSpecialDiscountRecieved.Text = Convert.ToString(existingItem.SpecialDiscountRecieved);
                tbxQtyPerCase.Text = Convert.ToString(existingItem.QtyPerCase);
                tbxLocation.Text = Convert.ToString(existingItem.Location);
                tbxMinimumStock.Text = Convert.ToString(existingItem.MinimumStock);
                tbxMaximumStock.Text = Convert.ToString(existingItem.MaximumStock);
                cbxSaleType.SelectedValue = existingItem.SaleTypeId;
                cbxPurchaseType.SelectedValue = existingItem.PurchaseTypeId;
                tbxHSNCode.Text = existingItem.HSNCode;
                cbxStatus.SelectedItem = existingItem.Status ? Status.Active : Status.Inactive;
            }
        }

        private void TbxAllowDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxItemName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbxItemName.Text))
                {
                    errorProviderItem.SetError((sender as Control), Constants.Messages.RequiredField);
                    (sender as TextBox).SelectAll();
                }
                else
                {
                    errorProviderItem.SetError((sender as Control), String.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                if ((sender is TextBox) && (sender as TextBox).Name == "tbxCompany")
                {
                    TextBox activeCompanyControl = sender as TextBox;
                  
                    if (String.IsNullOrWhiteSpace(activeCompanyControl.Text))
                    {
                        frmCompany frmCompanyMaster = new frmCompany();
                        frmCompanyMaster.IsInChildMode = true;
                        //Set Child UI
                        ExtensionMethods.AddChildFormToPanel(this, frmCompanyMaster, ExtensionMethods.MainPanel);
                        frmCompanyMaster.WindowState = FormWindowState.Maximized;
                        frmCompanyMaster.Show();
                        frmCompanyMaster.FormClosed += FrmCompanyMaster_FormClosed;
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

        private void FrmCompanyMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
                CompanyMaster lastSelectedCompany = (sender as frmCompany).LastSelectedCompany;
                if (lastSelectedCompany != null)
                {
                    if (lastSelectedCompany.CompanyId > 0)
                    {
                        tbxCompany.Text = lastSelectedCompany.CompanyName;
                        tbxCompany.Tag = lastSelectedCompany.CompanyId;

                        tbxShortName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Add
            if (keyData == Keys.Escape)
            {
                if (IsInChildMode)
                {
                    if (DialogResult.Yes == MessageBox.Show(Constants.Messages.ClosePrompt, Constants.Messages.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void cbxPurchaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cbxSaleType.Items.Count > 0)
                {
                    decimal? purchaseTaxValue = (cbxPurchaseType.SelectedItem as AccountLedgerMaster).SalePurchaseTaxValue;
                    if (purchaseTaxValue != null)
                    {
                        int gstSaleTypeID = cbxSaleType.Items.Cast<AccountLedgerMaster>().Where(x => x.SalePurchaseTaxValue == purchaseTaxValue).Select(x => x.AccountLedgerID).First();
                        cbxSaleType.SelectedValue = gstSaleTypeID;
                    }
                    else
                    {
                        cbxSaleType.SelectedValue = 0;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
