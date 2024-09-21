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
    public partial class frmAccountLedgerMasterAddUpdate : Form
    {
        IApplicationFacade applicationFacade;
        public int AccountLedgerId { get; set; }
        private string _accountLedgerName { get; set; }
        public bool IsInChildMode = false;

        public frmAccountLedgerMasterAddUpdate(int accountLedgerId,string ledgerName)
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetChildFormProperties(this);
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
                this.AccountLedgerId = accountLedgerId;
                this._accountLedgerName = ledgerName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        }


        private void frmAccountLedgerMasterAddUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, (this.AccountLedgerId > 0) ? "Account Ledger Master - Update" : "Account Ledger Master - Add");

                GotFocusEventRaised(this);
                ExtensionMethods.EnterKeyDownForTabEvents(this);

                if (this.AccountLedgerId > 0)
                {
                    FillFormForUpdate();
                }
                else
                {
                    FillCombo();
                    tbAccountName.Text = _accountLedgerName;
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

        private void FillFormForUpdate()
        {
            cbAccountLedgerType.SelectedIndexChanged -= CbAccountLedgerType_SelectedIndexChanged;

            cbxStatus.DataSource = Enum.GetValues(typeof(Enums.Status));
            cbxStatus.SelectedItem = Enums.Status.Active;

            var accountLedgerMaster = applicationFacade.GetAccountLedgerById(this.AccountLedgerId);

            cbAccountLedgerType.DataSource = accountLedgerMaster.AccountLedgerTypeList;
            cbAccountLedgerType.ValueMember = "AccountLedgerTypeID";
            cbAccountLedgerType.DisplayMember = "AccountLedgerTypeName";

            cbAccountType.DataSource = accountLedgerMaster.AccountTypeList;
            cbAccountType.ValueMember = "AccountTypeID";
            cbAccountType.DisplayMember = "AccountTypeDisplayName";

            if (accountLedgerMaster.AccountLedgerTypeSystemName != Constants.AccountLedgerType.ControlCodes)
            {
                var debitControlCodes = applicationFacade.GetAccountLedgerBySystemName(Constants.AccountLedgerType.ControlCodes);
                var creditControlCodes = applicationFacade.GetAccountLedgerBySystemName(Constants.AccountLedgerType.ControlCodes);

                cbDebitControlCode.DataSource = debitControlCodes;
                cbCreditControlCode.DataSource = creditControlCodes;

                cbDebitControlCode.ValueMember = "AccountLedgerID";
                cbDebitControlCode.DisplayMember = "AccountLedgerName";

                cbCreditControlCode.ValueMember = "AccountLedgerID";
                cbCreditControlCode.DisplayMember = "AccountLedgerName";

                cbCreditControlCode.SelectedValue = accountLedgerMaster.CreditControlCodeID;
                cbDebitControlCode.SelectedValue = accountLedgerMaster.DebitControlCodeID;

                gbBalanceSheet.Visible = true;
            }
            else
            {
                cbDebitControlCode.DataSource = null;
                cbCreditControlCode.DataSource = null;
                gbBalanceSheet.Visible = false;
            }

            cbAccountLedgerType.SelectedValue = accountLedgerMaster.AccountLedgerTypeId;            
            cbDebitCredit.SelectedItem = accountLedgerMaster.CreditDebit;
            cbxStatus.SelectedItem = accountLedgerMaster.Status ? Enums.Status.Active : Enums.Status.Inactive;

            tbAccountName.Text = accountLedgerMaster.AccountLedgerName;
            txtAccountLedgerCode.Text = accountLedgerMaster.AccountLedgerCode;
            tbOpeningBalance.Text = Convert.ToString(accountLedgerMaster.OpeningBalance);
            txtSalePurchaseValue.Text = Convert.ToString(accountLedgerMaster.SalePurchaseTaxValue);

            cbAccountLedgerType.Enabled = false;

            if (accountLedgerMaster.AccountLedgerTypeSystemName == Constants.AccountLedgerType.SaleLedger
                    || accountLedgerMaster.AccountLedgerTypeSystemName == Constants.AccountLedgerType.PurchaseLedger)
            {
                txtSalePurchaseValue.Enabled = true;
            }
            else
            {
                txtSalePurchaseValue.Enabled = false;
                txtSalePurchaseValue.Text = "0.00";
            }


            tbAccountName.Focus();

        }

       
        private void FillCombo()
        {
            cbxStatus.DataSource = Enum.GetValues(typeof(Enums.Status));
            cbxStatus.SelectedItem = Enums.Status.Active;

            var accountLedgerTypes = applicationFacade.GetAccountLedgerTypes();
            cbAccountLedgerType.DataSource = accountLedgerTypes;
            cbAccountLedgerType.ValueMember = "AccountLedgerTypeID";
            cbAccountLedgerType.DisplayMember = "AccountLedgerTypeName";

            cbAccountType.DataSource = applicationFacade.GetAccountTypes();
            cbAccountType.ValueMember = "AccountTypeID";
            cbAccountType.DisplayMember = "AccountTypeDisplayName";

            cbDebitCredit.SelectedItem = "C";

            if (accountLedgerTypes.FirstOrDefault().AccountLedgerTypeSystemName != Constants.AccountLedgerType.ControlCodes)
            {
                var debitControlCodes = applicationFacade.GetAccountLedgerBySystemName(Constants.AccountLedgerType.ControlCodes);
                var creditControlCodes = applicationFacade.GetAccountLedgerBySystemName(Constants.AccountLedgerType.ControlCodes);

                cbDebitControlCode.DataSource = debitControlCodes;
                cbCreditControlCode.DataSource = creditControlCodes;

                cbDebitControlCode.ValueMember = "AccountLedgerID";
                cbDebitControlCode.DisplayMember = "AccountLedgerName";

                cbCreditControlCode.ValueMember = "AccountLedgerID";
                cbCreditControlCode.DisplayMember = "AccountLedgerName";

                gbBalanceSheet.Visible = true;
            }
            else
            {
                cbDebitControlCode.DataSource = null;
                cbCreditControlCode.DataSource = null;
                gbBalanceSheet.Visible = false;
            }

            cbAccountLedgerType.SelectedIndexChanged += CbAccountLedgerType_SelectedIndexChanged;

        }

        private void CbAccountLedgerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var accountLedger = applicationFacade.GetAccountLedgerTypes().Where(p => p.AccountLedgerTypeID == (int)cbAccountLedgerType.SelectedValue).FirstOrDefault();

                if (accountLedger.AccountLedgerTypeSystemName != Constants.AccountLedgerType.ControlCodes)
                {
                   
                    var debitControlCodes = applicationFacade.GetAccountLedgerBySystemName(Constants.AccountLedgerType.ControlCodes);
                    var creditControlCodes = applicationFacade.GetAccountLedgerBySystemName(Constants.AccountLedgerType.ControlCodes);

                    cbDebitControlCode.DataSource = debitControlCodes;
                    cbCreditControlCode.DataSource = creditControlCodes;

                    cbDebitControlCode.ValueMember = "AccountLedgerID";
                    cbDebitControlCode.DisplayMember = "AccountLedgerName";

                    cbCreditControlCode.ValueMember = "AccountLedgerID";
                    cbCreditControlCode.DisplayMember = "AccountLedgerName";

                    gbBalanceSheet.Visible = true;
                }
                else
                {
                    cbDebitControlCode.DataSource = null;
                    cbCreditControlCode.DataSource = null;
                    gbBalanceSheet.Visible = false;
                }


                if (accountLedger.AccountLedgerTypeSystemName == Constants.AccountLedgerType.SaleLedger
                    || accountLedger.AccountLedgerTypeSystemName == Constants.AccountLedgerType.PurchaseLedger)
                {
                    txtSalePurchaseValue.Enabled = true;
                }
                else
                {
                    txtSalePurchaseValue.Enabled = false;
                    txtSalePurchaseValue.Text = "0.00";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(tbAccountName.Text))
                {
                    MessageBox.Show("Account Name can not be blank");
                    tbAccountName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(tbOpeningBalance.Text))
                {
                    MessageBox.Show("Account Name can not be blank");
                    tbOpeningBalance.Focus();
                    return;
                }

                Status status;

                AccountLedgerMaster model = new AccountLedgerMaster();
                model.AccountLedgerTypeId = (int)cbAccountLedgerType.SelectedValue;
                model.AccountLedgerName = tbAccountName.Text;
                model.AccountTypeId = (int)cbAccountType.SelectedValue;
                model.OpeningBalance = (decimal)ExtensionMethods.SafeConversionDecimal(tbOpeningBalance.Text);
                model.CreditDebit = cbDebitCredit.Text;
                model.AccountLedgerCode = txtAccountLedgerCode.Text;
                model.SalePurchaseTaxValue = ExtensionMethods.SafeConversionDecimal(txtSalePurchaseValue.Text);

                if (cbDebitControlCode.DataSource != null)
                {
                    model.DebitControlCodeID = (int)cbDebitControlCode.SelectedValue;
                    model.CreditControlCodeID = (int)cbCreditControlCode.SelectedValue;
                }
                model.AccountLedgerID = this.AccountLedgerId;

                Enum.TryParse<Status>(cbxStatus.SelectedValue.ToString(), out status);
                model.Status = status == Status.Active;

                var result = this.AccountLedgerId > 0 ? applicationFacade.UpdateAccountLedger(model) : applicationFacade.AddAccountLedger(model);

                if (result > 0)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }

        private void tbOpeningBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
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
    }
}
