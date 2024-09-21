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
    public partial class frmRoleAddUpdate : Form
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        IApplicationFacade applicationFacade;

        public frmRoleAddUpdate()
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

        public frmRoleAddUpdate(int RoleId)
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetChildFormProperties(this);
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
                this.RoleId = RoleId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        public frmRoleAddUpdate(string RoleName)
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetChildFormProperties(this);
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
                this.RoleName = RoleName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void frmRoleAddUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, RoleId > 0 ? "Role - Update" : "Role - Add");
                GotFocusEventRaised(this);
                KeyDownEvents(this);
                FillCombo();

                if (this.RoleId > 0)
                {
                    FillFormForUpdate();
                }

                if (!string.IsNullOrEmpty(this.RoleName))
                {
                    txtRoleName.Text = this.RoleName;
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
            Role role = applicationFacade.GetRoleById(this.RoleId);

            if (role != null)
            {
                txtRoleName.Text = role.RoleName;
                cbxStatus.SelectedItem = role.Status ? Enums.Status.Active : Enums.Status.Inactive;

                if (role.PrivledgeList != null)
                {
                    for (int i = 0; i < chkPrivledgeList.Items.Count; i++)
                    { 
                        Privledge priv = (Privledge)chkPrivledgeList.Items[i];

                        if(role.PrivledgeList.Any(x=> x.PrivledgeId  == priv.PrivledgeId))
                            this.chkPrivledgeList.SetItemChecked(i, true);
                    }
                }

            }
        }

        private void FillCombo()
        {
            //Fill status options
            cbxStatus.DataSource = Enum.GetValues(typeof(Enums.Status));
            cbxStatus.SelectedItem = Enums.Status.Active;

            //Fill privledge option
            ((ListBox)chkPrivledgeList).DataSource = applicationFacade.GetActivePrivledges();
            ((ListBox)chkPrivledgeList).DisplayMember = "PrivledgeName";
            ((ListBox)chkPrivledgeList).ValueMember = "PrivledgeId";

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
                if (String.IsNullOrWhiteSpace(txtRoleName.Text))
                {
                    errFrmRoleAddUpdate.SetError(txtRoleName, Constants.Messages.RequiredField);
                    txtRoleName.SelectAll();
                    txtRoleName.Focus();
                    return;
                }

                Status status;
                Role role = new Role();
                role.RoleId = this.RoleId;
                role.RoleName = txtRoleName.Text;
                Enum.TryParse<Status>(cbxStatus.SelectedValue.ToString(), out status);
                role.Status = status == Status.Active;
                role.PrivledgeList = new List<Privledge>();

                for (int i = 0; i < chkPrivledgeList.Items.Count; i++)
                {
                    if (chkPrivledgeList.GetItemChecked(i))
                        role.PrivledgeList.Add(new Privledge() { PrivledgeId = ((Privledge)chkPrivledgeList.Items[i]).PrivledgeId });
                }
                bool result = this.RoleId > 0 ? applicationFacade.UpdateRole(role) : applicationFacade.AddRole(role);

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
