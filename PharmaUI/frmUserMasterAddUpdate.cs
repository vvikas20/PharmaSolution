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
    public partial class frmUserMasterAddUpdate : Form
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        IApplicationFacade applicationFacade;

        public frmUserMasterAddUpdate()
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

        public frmUserMasterAddUpdate(int userId)
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetChildFormProperties(this);
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
                this.UserId = userId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        public frmUserMasterAddUpdate(string userName)
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetChildFormProperties(this);
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
                this.UserName = userName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void frmUserMasterAddUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, UserId > 0 ? "User - Update" : "User - Add");
                GotFocusEventRaised(this);
                KeyDownEvents(this);
                FillCombo();

                if (this.UserId > 0)
                {
                    FillFormForUpdate();
                }

                if (!string.IsNullOrEmpty(this.UserName))
                {
                    txtUserName.Text = this.UserName;
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
            UserMaster userMaster = applicationFacade.GetUserByUserId(this.UserId);

            if (userMaster != null)
            {
                txtUserName.Text = userMaster.Username;
                txtPassword.Text = userMaster.Password;
                txtFirstName.Text = userMaster.FirstName;
                txtLastName.Text = userMaster.LastName;
                cbxRole.SelectedValue = userMaster.RoleID;
                cbxStatus.SelectedItem = userMaster.Status ? Enums.Status.Active : Enums.Status.Inactive;

            }
        }

        private void FillCombo()
        {
            //Fill status options
            cbxStatus.DataSource = Enum.GetValues(typeof(Enums.Status));
            cbxStatus.SelectedItem = Enums.Status.Active;

            //Fill Roles option
            cbxRole.DataSource = applicationFacade.GetActiveRoles();
            cbxRole.ValueMember = "RoleId";
            cbxRole.DisplayMember = "RoleName";
            
        }

        private void C_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
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
                if (String.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    errFrmUserAddUpdate.SetError(txtUserName, Constants.Messages.RequiredField);
                    txtUserName.SelectAll();
                    txtUserName.Focus();
                    return;
                }

                if (String.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    errFrmUserAddUpdate.SetError(txtPassword, Constants.Messages.InValidEmail);
                    txtPassword.SelectAll();
                    txtPassword.Focus();
                    return;
                }

                Status status;
                int roleId = 0;
                UserMaster user = new UserMaster();
                user.UserId = this.UserId;
                user.Username = txtUserName.Text;
                user.FirstName = txtFirstName.Text;
                user.LastName = txtLastName.Text;
                user.Password = txtPassword.Text;
                Int32.TryParse(Convert.ToString(cbxRole.SelectedValue), out roleId);
                user.RoleID = roleId;

                Enum.TryParse<Status>(cbxStatus.SelectedValue.ToString(), out status);
                user.Status = status == Status.Active;

                int result = this.UserId > 0 ? applicationFacade.UpdateUser(user) : applicationFacade.AddUser(user);

                if (result > 0)
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
