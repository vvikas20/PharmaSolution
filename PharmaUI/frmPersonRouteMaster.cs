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

namespace PharmaUI
{
    public partial class frmPersonRouteMaster : Form
    {
        IApplicationFacade applicationFacade;
        public PersonRouteMaster LastSelectedPersonRoute { get; set; }
        public PersonRouteMaster NextPersonRoute { get; set; }
        public bool IsInChildMode = false;

        public frmPersonRouteMaster()
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetFormProperties(this);
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void frmPersonRouteMaster_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, "Person Route Master");
                GotFocusEventRaised(this);
                ExtensionMethods.EnterKeyDownForTabEvents(this);

                LoadCombo();
                LoadDataGrid(0);
                dgvPersonRoute.CellDoubleClick += DgvPersonRoute_CellDoubleClick;
                dgvPersonRoute.KeyDown += DgvPersonRoute_KeyDown;
                cbPersonRouteType.SelectedIndexChanged += CbPersonRouteType_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void CbPersonRouteType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDataGrid((int)cbPersonRouteType.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void DgvPersonRoute_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && IsInChildMode)
                {
                    this.Close();
                }
                if ((e.KeyData & Keys.KeyCode) == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                }
                else
                    base.OnKeyDown(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void DgvPersonRoute_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    PharmaBusinessObjects.Master.PersonRouteMaster model = (PharmaBusinessObjects.Master.PersonRouteMaster)dgvPersonRoute.Rows[e.RowIndex].DataBoundItem;

                    AddEditPersonRoute(model);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }

        private void LoadCombo()
        {
            cbPersonRouteType.DataSource = applicationFacade.GetRecordTypesWithAll();
            cbPersonRouteType.ValueMember = "RecordTypeId";
            cbPersonRouteType.DisplayMember = "RecordTypeName";
        }

        private void LoadDataGrid(int recordTypeId)
        {
            dgvPersonRoute.DataSource = applicationFacade.GetPersonRoutesByRecordTypeIdAndSearch(recordTypeId).OrderBy(s=>s.PersonRouteName).ToList();
            ExtensionMethods.SetGridDefaultProperty(dgvPersonRoute);

            dgvPersonRoute.Columns["PersonRouteCode"].Visible = true;
            dgvPersonRoute.Columns["PersonRouteCode"].HeaderText = "Account No";

            dgvPersonRoute.Columns["RecordTypeNme"].Visible = true;
            dgvPersonRoute.Columns["RecordTypeNme"].HeaderText = "Person/Route Type";

            dgvPersonRoute.Columns["PersonRouteName"].Visible = true;
            dgvPersonRoute.Columns["PersonRouteName"].HeaderText = "Person/Route Name";

            dgvPersonRoute.Columns["StatusText"].Visible = true;
            dgvPersonRoute.Columns["StatusText"].HeaderText = "Status";

            txtSearch_TextChanged(null, null);
        }

        private void frmPersonRouteMasterAddUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);

                //if (this.NextPersonRoute != null)
                //{
                //    LoadDataGrid((int)this.cbPersonRouteType.SelectedValue);
                //}
                //else
                //{
                //    LoadDataGrid(0);
                //}

                LoadDataGrid((int)cbPersonRouteType.SelectedValue);

                List<DataGridViewRow> filteredRow = dgvPersonRoute.Rows.OfType<DataGridViewRow>().Where(x => (int)x.Cells["PersonRouteID"].Value == (sender as frmPersonRouteMasterAddUpdate).PersonRouteID).ToList();

                if (filteredRow.Count > 0)
                {
                    dgvPersonRoute.ClearSelection();
                    filteredRow.First().Selected = true;
                    filteredRow.First().Cells["PersonRouteCode"].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }
        
        void AddEditPersonRoute(PharmaBusinessObjects.Master.PersonRouteMaster model)
        {
            frmPersonRouteMasterAddUpdate frmPersonRouteMasterAddUpdate = new frmPersonRouteMasterAddUpdate(model);
            frmPersonRouteMasterAddUpdate.IsInChildMode = true;

            frmPersonRouteMasterAddUpdate.FormClosed -= frmPersonRouteMasterAddUpdate_FormClosed;
            frmPersonRouteMasterAddUpdate.FormClosed += frmPersonRouteMasterAddUpdate_FormClosed;
            frmPersonRouteMasterAddUpdate.ShowDialog();
        }

        private void EditPersonRoute()
        {
            if (dgvPersonRoute.SelectedRows.Count == 0)
                MessageBox.Show("Please select at least one row to edit");

            PharmaBusinessObjects.Master.PersonRouteMaster model = (PharmaBusinessObjects.Master.PersonRouteMaster)dgvPersonRoute.SelectedRows[0].DataBoundItem;
                        
            AddEditPersonRoute(model);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Add
            if (keyData == (Keys.F9))
            {
                if ((cbPersonRouteType.SelectedItem as PharmaBusinessObjects.Common.RecordType).RecordTypeId != 0)
                {
                    PersonRouteMaster pmNext = new PersonRouteMaster()
                    {
                        RecordTypeNme = (cbPersonRouteType.SelectedItem as PharmaBusinessObjects.Common.RecordType).RecordTypeName,
                        RecordTypeId = (cbPersonRouteType.SelectedItem as PharmaBusinessObjects.Common.RecordType).RecordTypeId
                    };

                    AddEditPersonRoute(pmNext);
                }
                else
                {
                    AddEditPersonRoute(NextPersonRoute);
                }
            }
            else if (keyData == Keys.F3)
            {
                EditPersonRoute();
            }
            else if (keyData == Keys.Down)
            {
                dgvPersonRoute.Focus();
            }
            else if (keyData == Keys.Escape)
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

        public void ConfigurePersonRoute(PersonRouteMaster model)
        {
            if(model != null)
            {
                this.cbPersonRouteType.Text = model.RecordTypeNme;
                this.cbPersonRouteType.Enabled = false;
                {
                    this.NextPersonRoute = new PersonRouteMaster()
                    {
                        RecordTypeNme=model.RecordTypeNme,
                        RecordTypeId=(int)this.cbPersonRouteType.SelectedValue
                    };
                }
                

                List<DataGridViewRow> filteredRow = dgvPersonRoute.Rows.OfType<DataGridViewRow>().Where(x => (int)x.Cells["PersonRouteID"].Value == model.PersonRouteID).ToList();

                if (filteredRow.Count > 0)
                {
                    dgvPersonRoute.ClearSelection();
                    filteredRow.First().Selected = true;
                    filteredRow.First().Cells["PersonRouteCode"].Selected = true;
                }
                else
                {
                    if (dgvPersonRoute.RowCount > 0)
                    {
                        dgvPersonRoute.ClearSelection();
                        dgvPersonRoute.Rows.OfType<DataGridViewRow>().First().Selected = true;
                        dgvPersonRoute.Rows.OfType<DataGridViewRow>().First().Cells["PersonRouteCode"].Selected = true;
                    }
                }
            }

        }

        private void frmPersonRouteMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (dgvPersonRoute.CurrentRow != null)
                {
                    this.LastSelectedPersonRoute = dgvPersonRoute.CurrentRow.DataBoundItem as PersonRouteMaster;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }

        //Action Buttons

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            try
            {
                ExtensionMethods.GridSelectionOnSearch(dgvPersonRoute, "PersonRouteName",txtSearch.Text, this.lblSearchStatus);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if((cbPersonRouteType.SelectedItem as PharmaBusinessObjects.Common.RecordType).RecordTypeId != 0)
                {
                    PersonRouteMaster pmNext = new PersonRouteMaster()
                    {
                        RecordTypeNme = (cbPersonRouteType.SelectedItem as PharmaBusinessObjects.Common.RecordType).RecordTypeName,
                        RecordTypeId = (cbPersonRouteType.SelectedItem as PharmaBusinessObjects.Common.RecordType).RecordTypeId
                    };

                    AddEditPersonRoute(pmNext);
                }
                else
                {
                    AddEditPersonRoute(NextPersonRoute);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                EditPersonRoute();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Set focus for the controls
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
    }
}
