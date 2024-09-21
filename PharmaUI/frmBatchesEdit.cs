using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static PharmaBusinessObjects.Common.Enums;

namespace PharmaUI
{
    public partial class frmBatchesEdit : Form
    {
        IApplicationFacade applicationFacade;
        FifoBatches FifoBatches { get; set; }

        public frmBatchesEdit(FifoBatches _fifoBatches)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
            FifoBatches = _fifoBatches;
        }

        private void frmBatchesEdit_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Batch - Update");

            GotFocusEventRaised(this);
            FillCombo();
            FillData();

            ExtensionMethods.EnterKeyDownForTabEvents(this);
        }

        private void FillData()
        {
            try
            {
                txtBatch.Text = FifoBatches.Batch;
                txtQuantity.Text = Convert.ToString(FifoBatches.Quantity);
                txtScheme.Text = Convert.ToString(FifoBatches.Scheme);
                txtPurchaseBill.Text = Convert.ToString(FifoBatches.PurchaseBillNo);
                txtPurchaseRate.Text = Convert.ToString(FifoBatches.PurchaseRate);
                txtCost.Text = Convert.ToString(FifoBatches.EffectivePurchaseRate);
                txtSaleRate.Text = Convert.ToString(FifoBatches.SaleRate);
                txtWSRate.Text = Convert.ToString(FifoBatches.WholeSaleRate);
                txtSplRate.Text = Convert.ToString(FifoBatches.SpecialRate);
                txtMRP.Text = Convert.ToString(FifoBatches.MRP);
                txtMfgDate.Text = FifoBatches.MfgDate == null ? "" : ExtensionMethods.ConvertToAppDateFormat((DateTime)FifoBatches.MfgDate);
                txtExpiryDate.Text = FifoBatches.ExpiryDate == null ? "" : ExtensionMethods.ConvertToAppDateFormat((DateTime)FifoBatches.ExpiryDate);
                cbOnHold.SelectedItem = (bool)FifoBatches.IsOnHold ? Enums.Choice.Yes : Enums.Choice.No;
                txtOnHoldRemark.Text = FifoBatches.OnHoldRemarks;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    else if (c is MaskedTextBox)
                    {
                        MaskedTextBox tb1 = (MaskedTextBox)c;
                        tb1.GotFocus += C_GotFocus;
                        tb1.TextChanged += Tb1_TextChanged;
                        tb1.Leave += Tb1_Leave;
                    }
                    else if (c is ComboBox)
                    {
                        ComboBox tb1 = (ComboBox)c;
                        tb1.GotFocus += C_GotFocus;
                    }
                }
            }
        }

        private void Tb1_Leave(object sender, EventArgs e)
        {
            Control text = (Control)sender;

            switch (text.Name)
            {
                case "txtMfgDate":
                    {

                        txtMfgDate.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        if (!string.IsNullOrWhiteSpace(txtMfgDate.Text))
                        {

                            txtMfgDate.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            DateTime date = new DateTime();
                            DateTime.TryParse(txtMfgDate.Text, out date);

                            MaskedTextBox dtPicker = (MaskedTextBox)sender;
                            if (!ExtensionMethods.IsValidDate(txtMfgDate.Text))
                            {
                                errFrmPurchaseBookHeader.SetError(txtMfgDate, Constants.Messages.InValidDate);
                                txtMfgDate.Focus();
                            }
                            else
                            {
                                errFrmPurchaseBookHeader.SetError(txtMfgDate, String.Empty);
                                DateTime dt = new DateTime();
                                dt = ExtensionMethods.ConvertToSystemDateFormat(dtPicker.Text);
                            }
                        }
                    }
                    break;
                case "txtExpiryDate":
                    {

                        txtExpiryDate.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        if (!string.IsNullOrWhiteSpace(txtExpiryDate.Text))
                        {
                            txtExpiryDate.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            DateTime date = new DateTime();
                            DateTime.TryParse(txtExpiryDate.Text, out date);

                            MaskedTextBox dtPicker = (MaskedTextBox)sender;
                            if (!ExtensionMethods.IsValidDate(txtExpiryDate.Text))
                            {
                                errFrmPurchaseBookHeader.SetError(txtExpiryDate, Constants.Messages.InValidDate);
                                txtExpiryDate.Focus();
                            }
                            else
                            {
                                errFrmPurchaseBookHeader.SetError(txtMfgDate, String.Empty);
                                DateTime dt = new DateTime();
                                dt = ExtensionMethods.ConvertToSystemDateFormat(dtPicker.Text);
                            }
                        }
                    }
                    break;
            }

        }

        private void Tb1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void FillCombo()
        {
            //Fill Yes/No option
            cbOnHold.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbOnHold.SelectedItem = Enums.Choice.Yes;
        }


        private void C_GotFocus(object sender, EventArgs e)
        {
            ExtensionMethods.DisableAllTextBoxAndComboBox(this, (Control)sender);
            return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                FifoBatches.Batch = txtBatch.Text;
                FifoBatches.Quantity = (decimal)ExtensionMethods.SafeConversionDecimal(txtQuantity.Text);
                FifoBatches.Scheme = txtScheme.Text;
                FifoBatches.PurchaseBillNo = txtPurchaseBill.Text;
                FifoBatches.PurchaseRate = (decimal)ExtensionMethods.SafeConversionDecimal(txtPurchaseRate.Text);
                FifoBatches.EffectivePurchaseRate = (decimal)ExtensionMethods.SafeConversionDecimal(txtCost.Text);
                FifoBatches.SaleRate = (decimal)ExtensionMethods.SafeConversionDecimal(txtSaleRate.Text);
                FifoBatches.WholeSaleRate = (decimal)ExtensionMethods.SafeConversionDecimal(txtWSRate.Text);
                FifoBatches.SpecialRate = (decimal)ExtensionMethods.SafeConversionDecimal(txtSplRate.Text);
                FifoBatches.MRP = (decimal)ExtensionMethods.SafeConversionDecimal(txtMRP.Text);

                txtMfgDate.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                txtExpiryDate.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (string.IsNullOrWhiteSpace(txtMfgDate.Text))
                {
                    FifoBatches.MfgDate = null;
                }
                else
                {
                    txtMfgDate.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    FifoBatches.MfgDate = ExtensionMethods.ConvertToSystemDateFormat(txtMfgDate.Text);
                }

                if (string.IsNullOrWhiteSpace(txtExpiryDate.Text))
                {
                    FifoBatches.ExpiryDate = null;
                }
                else
                {
                    txtExpiryDate.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    FifoBatches.ExpiryDate = ExtensionMethods.ConvertToSystemDateFormat(txtExpiryDate.Text);
                }

                Choice choice;
                Enum.TryParse<Choice>(cbOnHold.SelectedValue.ToString(), out choice);
                FifoBatches.IsOnHold = choice == Choice.Yes;
                
                FifoBatches.OnHoldRemarks = txtOnHoldRemark.Text;

                int res= applicationFacade.UpdateFifoBatchesByItemCode(FifoBatches);
                if(res > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Batch updation failed !!");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
