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
using static PharmaBusinessObjects.Common.Constants;

namespace PharmaUI
{
    
    public partial class frmPurchaseHeaderAmount : Form
    {
        IApplicationFacade applicationFacade;
        PurchaseSaleBookHeader purchaseBookHeader;
        bool isDirty = false;
        public int RowIndex { get; set; }

        public PurchaseSaleBookHeader PurchaseBookHeader { get { return purchaseBookHeader; } }

        public frmPurchaseHeaderAmount(PurchaseSaleBookHeader header)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new PharmaBusiness.ApplicationFacade(ExtensionMethods.LoggedInUser);
            purchaseBookHeader = header;

        }

        private void frmPurchaseHeaderAmount_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, string.Format("Header Amount Update"));

            GotFocusEventRaised(this);
            EnterKeyDownForTabEvents(this);
            EnterKeyPress(this);

            FillFormForUpdate();

            txtAmount1.Focus();

        }

        private void EnterKeyPress(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    EnterKeyPress(c);
                }
                else
                {
                    if (c is TextBox)
                    {
                        c.KeyPress -= C_KeyPress;
                        c.KeyPress += C_KeyPress;
                    }
                }
            }
        }

        private void C_KeyPress(object sender, KeyPressEventArgs e)
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

                if (ctl.Name == "txtTotalBillAmount")
                {
                    this.Close();
                }
                else
                {                    
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
            }
        }

        private void FrmPurchaseHeaderAmount_FormClosing(object sender, FormClosingEventArgs e)
        {
            decimal amount = 0;
            decimal.TryParse(txtAmount1.Text, out amount);

            purchaseBookHeader.Amount01 = amount;

            decimal.TryParse(txtAmount2.Text, out amount);
            purchaseBookHeader.Amount02 = amount;

            decimal.TryParse(txtAmount3.Text, out amount);
            purchaseBookHeader.Amount03 = amount;

            decimal.TryParse(txtAmount4.Text, out amount);
            purchaseBookHeader.Amount04 = amount;

            decimal.TryParse(txtAmount5.Text, out amount);
            purchaseBookHeader.Amount05 = amount;

            decimal.TryParse(txtAmount6.Text, out amount);
            purchaseBookHeader.Amount06 = amount;

            decimal.TryParse(txtAmount7.Text, out amount);
            purchaseBookHeader.Amount07 = amount;

            decimal.TryParse(txtCGST1.Text, out amount);
            purchaseBookHeader.CGST01 = amount;

            decimal.TryParse(txtCGST2.Text, out amount);
            purchaseBookHeader.CGST02 = amount;

            decimal.TryParse(txtCGST3.Text, out amount);
            purchaseBookHeader.CGST03 = amount;

            decimal.TryParse(txtCGST4.Text, out amount);
            purchaseBookHeader.CGST04 = amount;

            decimal.TryParse(txtCGST5.Text, out amount);
            purchaseBookHeader.CGST05 = amount;

            decimal.TryParse(txtCGST6.Text, out amount);
            purchaseBookHeader.CGST06 = amount;

            decimal.TryParse(txtCGST7.Text, out amount);
            purchaseBookHeader.CGST07 = amount;

            decimal.TryParse(txtSGST1.Text, out amount);
            purchaseBookHeader.SGST01 = amount;

            decimal.TryParse(txtSGST2.Text, out amount);
            purchaseBookHeader.SGST02 = amount;

            decimal.TryParse(txtSGST3.Text, out amount);
            purchaseBookHeader.SGST03 = amount;

            decimal.TryParse(txtSGST4.Text, out amount);
            purchaseBookHeader.SGST04 = amount;

            decimal.TryParse(txtSGST5.Text, out amount);
            purchaseBookHeader.SGST05 = amount;

            decimal.TryParse(txtSGST6.Text, out amount);
            purchaseBookHeader.SGST06 = amount;

            decimal.TryParse(txtSGST7.Text, out amount);
            purchaseBookHeader.SGST07 = amount;

            decimal.TryParse(txtOtherAmt.Text, out amount);
            purchaseBookHeader.OtherAmount = amount;

            decimal.TryParse(txtTotalBillAmount.Text, out amount);
            purchaseBookHeader.TotalBillAmount = amount;

            applicationFacade.InsertUpdateTempPurchaseBookHeader(purchaseBookHeader);

        }

        private void FillFormForUpdate()
        {
            List<PurchaseBookAmount> amountList = applicationFacade.GetFinalAmountWithTaxForPurchase(purchaseBookHeader.PurchaseSaleBookHeaderID);

            PurchaseBookAmount amount = amountList.FirstOrDefault(p => p.PurchaseSaleTypeCode.ToUpper() == PurchaseTypeCode.PurchaseType1);

            if (amount != null)
            {
                lblAmount1.Text = amount.PurchaseSaleTypeName;
                txtAmount1.Text = amount.Amount.ToString("#.##");
                txtAmount1.Tag = amount.TaxApplicable.ToString("#.##");
                txtCGST1.Text = amount.CGST.ToString("#.##");
                txtSGST1.Text = amount.SGST.ToString("#.##");
            }

            amount = amountList.FirstOrDefault(p => p.PurchaseSaleTypeCode.ToUpper() == PurchaseTypeCode.PurchaseType2);

            if (amount != null)
            {
                lblAmount2.Text = amount.PurchaseSaleTypeName;
                txtAmount2.Text = amount.Amount.ToString("#.##");
                txtAmount2.Tag = amount.TaxApplicable.ToString("#.##");
                txtCGST2.Text = amount.CGST.ToString("#.##");
                txtSGST2.Text = amount.SGST.ToString("#.##");
            }

            amount = amountList.FirstOrDefault(p => p.PurchaseSaleTypeCode.ToUpper() == PurchaseTypeCode.PurchaseType3);

            if (amount != null)
            {
                lblAmount3.Text = amount.PurchaseSaleTypeName;
                txtAmount3.Text = amount.Amount.ToString("#.##");
                txtAmount3.Tag = amount.TaxApplicable.ToString("#.##");
                txtCGST3.Text = amount.CGST.ToString("#.##");
                txtSGST3.Text = amount.SGST.ToString("#.##");
            }

            amount = amountList.FirstOrDefault(p => p.PurchaseSaleTypeCode.ToUpper() == PurchaseTypeCode.PurchaseType4);

            if (amount != null)
            {
                lblAmount4.Text = amount.PurchaseSaleTypeName;
                txtAmount4.Text = amount.Amount.ToString("#.##");
                txtAmount4.Tag = amount.TaxApplicable.ToString("#.##");
                txtCGST4.Text = amount.CGST.ToString("#.##");
                txtSGST4.Text = amount.SGST.ToString("#.##");
            }

            amount = amountList.FirstOrDefault(p => p.PurchaseSaleTypeCode.ToUpper() == PurchaseTypeCode.PurchaseType5);

            if (amount != null)
            {
                lblAmount5.Text = amount.PurchaseSaleTypeName;
                txtAmount5.Text = amount.Amount.ToString("#.##");
                txtAmount5.Tag = amount.TaxApplicable.ToString("#.##");
                txtCGST5.Text = amount.CGST.ToString("#.##");
                txtSGST5.Text = amount.SGST.ToString("#.##");
            }

            amount = amountList.FirstOrDefault(p => p.PurchaseSaleTypeCode.ToUpper() == PurchaseTypeCode.PurchaseType6);

            if (amount != null)
            {
                lblAmount6.Text = amount.PurchaseSaleTypeName;
                txtAmount6.Text = amount.Amount.ToString("#.##");
                txtAmount6.Tag = amount.TaxApplicable.ToString("#.##");
                txtCGST6.Text = amount.CGST.ToString("#.##");
                txtSGST6.Text = amount.SGST.ToString("#.##");
            }

            amount = amountList.FirstOrDefault(p => p.PurchaseSaleTypeCode.ToUpper() == PurchaseTypeCode.PurchaseType7);

            if (amount != null)
            {
                lblAmount7.Text = amount.PurchaseSaleTypeName;
                txtAmount7.Text = amount.Amount.ToString("#.##");
                txtAmount7.Tag = amount.TaxApplicable.ToString("#.##");
                txtCGST7.Text = amount.CGST.ToString("#.##");
                txtSGST7.Text = amount.SGST.ToString("#.##");
            }

            SetTotalBillAmount();
        }

        private void SetTotalBillAmount()
        {
            decimal amount1 = 0;
            decimal.TryParse(txtAmount1.Text, out amount1);

            decimal amount2 = 0;
            decimal.TryParse(txtAmount2.Text, out amount2);

            decimal amount3 = 0;
            decimal.TryParse(txtAmount3.Text, out amount3);

            decimal amount4 = 0;
            decimal.TryParse(txtAmount4.Text, out amount4);

            decimal amount5 = 0;
            decimal.TryParse(txtAmount5.Text, out amount5);

            decimal amount6 = 0;
            decimal.TryParse(txtAmount6.Text, out amount6);

            decimal amount7 = 0;
            decimal.TryParse(txtAmount7.Text, out amount7);

            decimal CGST1 = 0;
            decimal.TryParse(txtCGST1.Text, out CGST1);

            decimal CGST2 = 0;
            decimal.TryParse(txtCGST2.Text, out CGST2);

            decimal CGST3 = 0;
            decimal.TryParse(txtCGST3.Text, out CGST3);

            decimal CGST4 = 0;
            decimal.TryParse(txtCGST4.Text, out CGST4);

            decimal CGST5 = 0;
            decimal.TryParse(txtCGST5.Text, out CGST5);

            decimal CGST6 = 0;
            decimal.TryParse(txtCGST6.Text, out CGST6);

            decimal CGST7 = 0;
            decimal.TryParse(txtCGST7.Text, out CGST7);

            decimal sgst1 = 0;
            decimal.TryParse(txtSGST1.Text, out sgst1);

            decimal sgst2 = 0;
            decimal.TryParse(txtSGST2.Text, out sgst2);

            decimal sgst3 = 0;
            decimal.TryParse(txtSGST3.Text, out sgst3);

            decimal sgst4 = 0;
            decimal.TryParse(txtSGST4.Text, out sgst4);

            decimal sgst5 = 0;
            decimal.TryParse(txtSGST5.Text, out sgst5);

            decimal sgst6 = 0;
            decimal.TryParse(txtSGST6.Text, out sgst6);

            decimal sgst7 = 0;
            decimal.TryParse(txtSGST7.Text, out sgst7);

            decimal otherAmount = 0;
            decimal.TryParse(txtOtherAmt.Text, out otherAmount);

            txtTotalBillAmount.Text = (amount1 + amount2 + amount3 + amount4 + amount5 + amount6 + amount7 + CGST1 + CGST2 + CGST3
                + CGST4 + CGST5 + CGST6 + CGST7 + sgst1 + sgst2 + sgst3 + sgst4 + sgst5 + sgst6 + sgst7 + otherAmount).ToString("#.##");
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
                        tb1.TextChanged += Tb1_TextChanged;
                    }

                    else if (c is ComboBox)
                    {
                        ComboBox tb1 = (ComboBox)c;
                        tb1.GotFocus += C_GotFocus;
                    }
                }
            }
        }

        private void Tb1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                isDirty = true;
                CalculateTax(sender, e);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void CalculateTax(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            decimal tax = 0;

            decimal.TryParse(Convert.ToString(txt.Tag), out tax);

            decimal amount = 0;

            decimal.TryParse(txt.Text, out amount);

            if (isDirty)
            {
                switch (txt.Name)
                {
                    case "txtAmount1":
                        {
                            txtCGST1.Text = tax == 0L && amount != 0L ? "0.00" : (amount * tax * (decimal).01 * (decimal)0.5).ToString("#.##");
                            txtSGST1.Text = tax == 0L && amount != 0L ? "0.00" : (amount * tax * (decimal).01 * (decimal)0.5).ToString("#.##");
                        }
                        break;
                    case "txtAmount2":
                        {
                            txtCGST2.Text = (amount * tax * (decimal).01 * (decimal)0.5).ToString("#.##");
                            txtSGST2.Text = (amount * tax * (decimal).01 * (decimal)0.5).ToString("#.##");
                        }
                        break;
                    case "txtAmount3":
                        {
                            txtCGST3.Text = (amount * tax * (decimal).01 * (decimal)0.5).ToString("#.##");
                            txtSGST3.Text = (amount * tax * (decimal).01 * (decimal)0.5).ToString("#.##");
                        }
                        break;
                    case "txtAmount4":
                        {
                            txtCGST4.Text = (amount * tax * (decimal).01 * (decimal)0.5).ToString("#.##");
                            txtSGST4.Text = (amount * tax * (decimal).01 * (decimal)0.5).ToString("#.##");
                        }
                        break;
                    case "txtAmount5":
                        {
                            txtCGST5.Text = (amount * tax * (decimal)(decimal).01 * (decimal)(decimal)0.5).ToString("#.##");
                            txtSGST5.Text = (amount * tax * (decimal)(decimal).01 * (decimal)(decimal)0.5).ToString("#.##");
                        }
                        break;
                    case "txtAmount6":
                        {
                            txtCGST6.Text = (amount * tax * (decimal)(decimal).01 * (decimal)(decimal)0.5).ToString("#.##");
                            txtSGST6.Text = (amount * tax * (decimal)(decimal).01 * (decimal)(decimal)0.5).ToString("#.##");
                        }
                        break;
                    case "txtAmount7":
                        {
                            txtCGST7.Text = (amount * tax * (decimal)(decimal).01 * (decimal)(decimal)0.5).ToString("#.##");
                            txtSGST7.Text = (amount * tax * (decimal)(decimal).01 * (decimal)(decimal)0.5).ToString("#.##");
                        }
                        break;
                }

                if (txt.Name != "txtTotalBillAmount")
                {
                    SetTotalBillAmount();
                }
            }
        }

        private void C_GotFocus(object sender, EventArgs e)
        {
            ExtensionMethods.DisableAllTextBoxAndComboBox(this, (Control)sender);
            return;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape || keyData == Keys.End)
            {
                this.Close();

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
