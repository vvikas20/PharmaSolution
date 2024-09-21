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
    public partial class frmPersonalLedgerMasterAddUpdate : Form
    {
        IApplicationFacade applicationFacade;

        private int _personLedgerid;
        private string _personLedgerName;
        public bool IsInChildMode = false;

        public frmPersonalLedgerMasterAddUpdate(int personLedgerid , string personLedgerName)
        {
            try
            {

                InitializeComponent();
                ExtensionMethods.SetChildFormProperties(this);
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
                _personLedgerid = personLedgerid;
                _personLedgerName = personLedgerName;
                LoadCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadCombo()
        {
            //Fill status options
            cbxStatus.DataSource = Enum.GetValues(typeof(Enums.Status));
            cbxStatus.SelectedItem = Status.Active;
        }

        private void frmPersonalLedgerMasterAddUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, _personLedgerid > 0 ? "Personal Diary - Update" : "Personal Diary - Add");
                ExtensionMethods.EnterKeyDownForTabEvents(this);
                GotFocusEventRaised(this);

                if (_personLedgerid == 0)
                {
                    tbxPersonalLedgerName.Text = _personLedgerName;
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
                if (String.IsNullOrWhiteSpace(tbxPersonalLedgerName.Text))
                {
                    errorProviderPerLedger.SetError(tbxPersonalLedgerName, Constants.Messages.RequiredField);
                    tbxPersonalLedgerName.SelectAll();
                    tbxPersonalLedgerName.Focus();
                    return;
                }

                if (String.IsNullOrWhiteSpace(tbxEmailAddress.Text) || !ExtensionMethods.IsValidEmail(tbxEmailAddress.Text))
                {
                    errorProviderPerLedger.SetError(tbxEmailAddress, Constants.Messages.InValidEmail);
                    tbxPersonalLedgerName.SelectAll();
                    tbxPersonalLedgerName.Focus();
                    return;
                }

                Status status;
                Enum.TryParse<Status>(cbxStatus.SelectedValue.ToString(), out status);
                
                PersonalLedgerMaster personalLedgerMaster = new PersonalLedgerMaster()
                {
                    PersonalLedgerName=tbxPersonalLedgerName.Text,
                    PersonalLedgerShortName=tbxPersonalLedgerShortName.Text,
                    Address=tbxAddress.Text,
                    ContactPerson=tbxContactPerson.Text,
                    Mobile=tbxMobile.Text,
                    Pager=tbxPager.Text,
                    Fax=tbxFax.Text,
                    OfficePhone=tbxOfficePhone.Text,
                    ResidentPhone=tbxResidentPhone.Text,
                    EmailAddress=tbxEmailAddress.Text,
                    Status = status == Status.Active
                };

                int actionResult = 0;
                // if form is in Edit mode then udate item , else add item 
                if (_personLedgerid == 0)
                {
                    actionResult = applicationFacade.AddPersonalLedger(personalLedgerMaster);
                }
                else
                {
                    personalLedgerMaster.PersonalLedgerId = _personLedgerid;                    
                    actionResult = applicationFacade.UpdatePersonalLedger(personalLedgerMaster);
                }

                //Close this form if operation is successful
                if (actionResult > 0)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void frmPersonalLedgerMasterAddUpdate_Fill_UsingExistingItem(PersonalLedgerMaster existingItem)
        {
            try
            {
                if (existingItem != null)
                {
                    tbxPersonalLedgerName.Text = existingItem.PersonalLedgerName;
                    tbxPersonalLedgerShortName.Text = existingItem.PersonalLedgerShortName;
                    tbxAddress.Text = existingItem.Address;
                    tbxContactPerson.Text = existingItem.ContactPerson;
                    tbxMobile.Text = existingItem.Mobile;
                    tbxPager.Text = existingItem.Pager;
                    tbxFax.Text = existingItem.Fax;
                    tbxOfficePhone.Text = existingItem.OfficePhone;
                    tbxResidentPhone.Text = existingItem.ResidentPhone;
                    tbxEmailAddress.Text = existingItem.EmailAddress;
                    cbxStatus.SelectedItem = existingItem.Status ? Status.Active : Status.Inactive;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxLedgerName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(tbxPersonalLedgerName.Text))
                {
                    errorProviderPerLedger.SetError((sender as Control), Constants.Messages.RequiredField);
                    (sender as TextBox).SelectAll();
                }
                else
                {
                    errorProviderPerLedger.SetError((sender as Control), String.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void tbxEmailAddress_Vaidating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!ExtensionMethods.IsValidEmail(tbxEmailAddress.Text))
                {
                    errorProviderPerLedger.SetError((sender as Control), Constants.Messages.InValidEmail);
                    (sender as TextBox).SelectAll();
                }
                else
                {
                    errorProviderPerLedger.SetError((sender as Control), String.Empty);
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
