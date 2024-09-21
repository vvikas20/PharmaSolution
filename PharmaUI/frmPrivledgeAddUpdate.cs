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
    public partial class frmPrivledgeAddUpdate : Form
    {
        public int PrivledgeId { get; set; }
        public string PrivledgeName { get; set; }
        IApplicationFacade applicationFacade;

        public frmPrivledgeAddUpdate()
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetChildFormProperties(this);
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }

        public frmPrivledgeAddUpdate(int PrivledgeId)
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetChildFormProperties(this);
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
                this.PrivledgeId = PrivledgeId;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }

        public frmPrivledgeAddUpdate(string PrivledgeName)
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetChildFormProperties(this);
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
                this.PrivledgeName = PrivledgeName;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }

        private void frmPrivledgeAddUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, PrivledgeId > 0 ? "Privledge - Update" : "Privledge - Add");
                GotFocusEventRaised(this);
                KeyDownEvents(this);
                FillCombo();

                if (this.PrivledgeId > 0)
                {
                    FillFormForUpdate();
                }

                if (!string.IsNullOrEmpty(this.PrivledgeName))
                {
                    txtPrivledgeName.Text = this.PrivledgeName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
          
        }

        private void KeyDownEvents(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    KeyDownEvents(c);
                }
                else
                {
                    c.KeyDown += C_KeyDown;
                }
            }
        }

        private void FillFormForUpdate()
        {
            Privledge privledge = applicationFacade.GetPrivledgeById(this.PrivledgeId);

            if (privledge != null)
            {
                txtPrivledgeName.Text = privledge.PrivledgeName;
                cbxStatus.SelectedItem = privledge.Status ? Enums.Status.Active : Enums.Status.Inactive;
                txtControlName.Text = privledge.ControlName;
            }
        }

        private void FillCombo()
        {
            //Fill status options
            cbxStatus.DataSource = Enum.GetValues(typeof(Enums.Status));
            cbxStatus.SelectedItem = Enums.Status.Active;
        }

        private void C_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
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
                if (String.IsNullOrWhiteSpace(txtPrivledgeName.Text))
                {
                    errfrmPrivledgeAddUpdate.SetError(txtPrivledgeName, Constants.Messages.RequiredField);
                    txtPrivledgeName.SelectAll();
                    txtPrivledgeName.Focus();
                    return;
                }

                Status status;
                Privledge privledge = new Privledge();
                privledge.PrivledgeId = this.PrivledgeId;
                privledge.PrivledgeName = txtPrivledgeName.Text;
                privledge.ControlName = txtControlName.Text;
                Enum.TryParse<Status>(cbxStatus.SelectedValue.ToString(), out status);
                privledge.Status = status == Status.Active;

                bool result = this.PrivledgeId > 0 ? applicationFacade.UpdatePrivledge(privledge) : applicationFacade.AddPrivledge(privledge);

                if (result)
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
