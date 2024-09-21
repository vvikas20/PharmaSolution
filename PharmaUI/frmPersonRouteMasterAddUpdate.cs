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
    public partial class frmPersonRouteMasterAddUpdate : Form
    {
        IApplicationFacade applicationFacade;
        private PersonRouteMaster PersonRouteMaster { get; set; }
        public int PersonRouteID { get; set; }
        public bool IsInChildMode = false;

        private void SetUIForSpecificRecordType()
        {
            try
            {
                if (this.PersonRouteMaster != null && !String.IsNullOrWhiteSpace(this.PersonRouteMaster.RecordTypeNme))
                {
                    tbPersonRouteName.Text = this.PersonRouteMaster.PersonRouteName;
                    cbPersonRouteType.SelectedIndex = cbPersonRouteType.FindString(this.PersonRouteMaster.RecordTypeNme);
                    cbPersonRouteType.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public frmPersonRouteMasterAddUpdate(PersonRouteMaster personRouteMaster)
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetChildFormProperties(this);

                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
                if (personRouteMaster != null)
                {
                    this.PersonRouteMaster = personRouteMaster;
                }
                else
                {
                    this.PersonRouteMaster = new PersonRouteMaster();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmPersonRouteMasterAddUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                //ExtensionMethods.FormLoad(this, "Person Route Master  - Add");
                GotFocusEventRaised(this);
                ExtensionMethods.FormLoad(this, (this.PersonRouteMaster.PersonRouteID > 0) ? "Person Route Master - Update" : "Person Route Master - Add");
                ExtensionMethods.EnterKeyDownForTabEvents(this);

                if (this.PersonRouteMaster.PersonRouteID > 0)
                {
                    FillFormForUpdate();
                }
                else
                {
                    FillCombo();
                    cbxStatus.SelectedItem = Enums.Status.Active;
                    if (this.PersonRouteMaster != null)
                    {
                        SetUIForSpecificRecordType();
                    }
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

        private void FillCombo()
        {
            cbxStatus.DataSource = Enum.GetValues(typeof(Enums.Status));

            cbPersonRouteType.DataSource = applicationFacade.GetRecordTypes();
            cbPersonRouteType.ValueMember = "RecordTypeId";
            cbPersonRouteType.DisplayMember = "RecordTypeName";
        }

        private void FillFormForUpdate()
        {
            FillCombo();

            tbPersonRouteName.Text = this.PersonRouteMaster.PersonRouteName;
            txtPersonRouteCode.Text = this.PersonRouteMaster.PersonRouteCode;
            cbPersonRouteType.SelectedValue = this.PersonRouteMaster.RecordTypeId;
            cbxStatus.SelectedItem = this.PersonRouteMaster.Status ? Enums.Status.Active : Enums.Status.Inactive;
            cbPersonRouteType.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PersonRouteMaster model = new PersonRouteMaster();

                model.PersonRouteID = this.PersonRouteMaster.PersonRouteID;
                model.RecordTypeId = (int)cbPersonRouteType.SelectedValue;

                Status status;
                Enum.TryParse<Status>(cbxStatus.SelectedValue.ToString(), out status);
                model.Status = status == Status.Active;

                model.PersonRouteName = tbPersonRouteName.Text;
                model.PersonRouteCode = this.PersonRouteMaster.PersonRouteCode;

                var result = this.PersonRouteMaster.RecordTypeId > 0 && this.PersonRouteMaster.PersonRouteID > 0 ? applicationFacade.UpdatePersonRoute(model) : applicationFacade.AddPersonRoute(model);

                if (result > 0)
                {
                    this.PersonRouteID = result;
                }

                this.Close();
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
