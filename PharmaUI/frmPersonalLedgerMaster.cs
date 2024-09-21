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
    public partial class frmPersonalLedgerMaster : Form
    {
        IApplicationFacade applicationFacade;
        public bool IsInChildMode = false;

        public frmPersonalLedgerMaster()
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


        private void frmPersonalLedgerMaster_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, "Personal Diary");
                GotFocusEventRaised(this);
                ExtensionMethods.EnterKeyDownForTabEvents(this);

                LoadDataGrid();
                dgvPersonalLedger.CellDoubleClick += dgvPersonalLedger_CellDoubleClick;
                dgvPersonalLedger.KeyDown += DgvPersonalLedger_KeyDown;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvPersonalLedger_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && dgvPersonalLedger.SelectedRows.Count > 0)
                {
                    if (DialogResult.Yes == MessageBox.Show(Constants.Messages.DeletePrompt, Constants.Messages.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        //PersonalLedgerMaster itemToBeRemoved = (PersonalLedgerMaster)dgvPersonalLedger.SelectedRows[0].DataBoundItem;
                        //applicationFacade.DeletePersonalLedger(itemToBeRemoved);
                        //LoadDataGrid();
                    }
                }
                else if ((e.KeyData & Keys.KeyCode) == Keys.Enter)
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

        private void LoadDataGrid()
        {
            dgvPersonalLedger.DataSource = applicationFacade.GetPersonalLedgers(null).OrderBy(s=>s.PersonalLedgerName).ToList();
            ExtensionMethods.SetGridDefaultProperty(dgvPersonalLedger);

            dgvPersonalLedger.Columns["PersonalLedgerCode"].Visible = true;
            dgvPersonalLedger.Columns["PersonalLedgerCode"].HeaderText = "Account No";            
                        
            dgvPersonalLedger.Columns["PersonalLedgerName"].Visible = true;
            dgvPersonalLedger.Columns["PersonalLedgerName"].HeaderText = "Account Name";
            
            dgvPersonalLedger.Columns["Address"].Visible = true;
            dgvPersonalLedger.Columns["Address"].HeaderText = "Address";
            
            dgvPersonalLedger.Columns["ContactPerson"].Visible = true;
            dgvPersonalLedger.Columns["ContactPerson"].HeaderText = "Contact Person";
            
            dgvPersonalLedger.Columns["EmailAddress"].Visible = true;
            dgvPersonalLedger.Columns["EmailAddress"].HeaderText = "Email";

            txtSearch_TextChanged(null, null);
        }

      
        void OpenAddEdit(int personLedgerId)
        {
            var form = new frmPersonalLedgerMasterAddUpdate(personLedgerId,txtSearch.Text);
            form.IsInChildMode = true;

            form.FormClosed -= Form_FormClosed;
            form.FormClosed += Form_FormClosed;

            if (personLedgerId > 0 && dgvPersonalLedger.SelectedRows[0] != null)
            {
                PersonalLedgerMaster existingItem = (PersonalLedgerMaster)dgvPersonalLedger.SelectedRows[0].DataBoundItem;
                form.frmPersonalLedgerMasterAddUpdate_Fill_UsingExistingItem(existingItem);
            }

            form.ShowDialog();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }



        private void dgvPersonalLedger_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    EditPersonLedger();
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
            if (keyData == (Keys.F9))
            {
                OpenAddEdit(0);
                return true;
            }
            else if (keyData == Keys.F3)
            {
                EditPersonLedger();

            }
            else if (keyData == Keys.Down)
            {
                dgvPersonalLedger.Focus();
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

        void EditPersonLedger()
        {
            if (dgvPersonalLedger.SelectedRows.Count == 0)
                MessageBox.Show("Please select atleast one row to edit");

            PharmaBusinessObjects.Master.PersonalLedgerMaster model = (PharmaBusinessObjects.Master.PersonalLedgerMaster)dgvPersonalLedger.SelectedRows[0].DataBoundItem;

            OpenAddEdit(model.PersonalLedgerId);
        }


        ///Action button
        ///

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.GridSelectionOnSearch(dgvPersonalLedger, "PersonalLedgerName",txtSearch.Text,this.lblSearchStatus);
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
                OpenAddEdit(0);
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
                EditPersonLedger();
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
