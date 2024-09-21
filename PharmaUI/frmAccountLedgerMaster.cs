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
    public partial class frmAccountLedgerMaster : Form
    {
        private string accountLedgerCode = string.Empty;
        private string accountLedgerName = string.Empty;
        private bool isOpenAsDialog = false;
        private string ledgerType = string.Empty;


        public bool IsInChildMode = false;
        public AccountLedgerMaster LastSelectedAccountLedger { get; set; }
        public AccountLedgerMaster NextAccountLedger { get; set; }

        public string AccountLedgerID { get { return accountLedgerCode; } }
        public string AccountLedgerName { get { return accountLedgerName; } }

        IApplicationFacade applicationFacade;

        private int selectedRowIndex = 0;    

        public frmAccountLedgerMaster()
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

        public frmAccountLedgerMaster(bool isDialog, string ledgerTypeName)
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetChildFormProperties(this);

                List<Control> allControls = ExtensionMethods.GetAllControls(this);
                allControls.ForEach(k => k.Visible = false);

                this.WindowState = FormWindowState.Normal;
                dgvAccountLedger.Visible = true;
                ledgerType = ledgerTypeName;
                isOpenAsDialog = isDialog;

                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
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

        private void frmAccountLedgerMaster_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, "Account Ledger Master");
                GotFocusEventRaised(this);
                ExtensionMethods.EnterKeyDownForTabEvents(this);

                LoadCombo();

                if (isOpenAsDialog)
                {
                    dgvAccountLedger.SelectionChanged += DgvAccountLedger_SelectionChanged;
                    AccountLedgerType master = applicationFacade.GetAccountLedgerTypeByName(ledgerType);
                    LoadDataGrid(master != null ? master.AccountLedgerTypeID : 0);
                }
                else
                {
                    LoadDataGrid(0);
                    dgvAccountLedger.CellDoubleClick += DgvAccountLedger_CellDoubleClick;
                    dgvAccountLedger.KeyDown += DgvAccountLedger_KeyDown;
                }
                
                txtSearch.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvAccountLedger_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvAccountLedger.SelectedRows != null && dgvAccountLedger.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvAccountLedger.SelectedRows[0];

                    if (row != null)
                    {
                        accountLedgerCode = Convert.ToString(row.Cells["AccountLedgerCode"].Value);
                        accountLedgerName = Convert.ToString(row.Cells["AccountLedgerName"].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void DgvAccountLedger_KeyDown(object sender, KeyEventArgs e)
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

        private void DgvAccountLedger_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    PharmaBusinessObjects.Master.AccountLedgerMaster model = (PharmaBusinessObjects.Master.AccountLedgerMaster)dgvAccountLedger.Rows[e.RowIndex].DataBoundItem;

                    OpenAddEdit(model.AccountLedgerID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void LoadCombo()
        {
            cbLedgerType.SelectedIndexChanged -= CbLedgerType_SelectedIndexChanged;

            cbLedgerType.DataSource = applicationFacade.GetAccountLedgerTypesWithAll();
            cbLedgerType.DisplayMember = "AccountLedgerTypeName";
            cbLedgerType.ValueMember = "AccountLedgerTypeID";
            cbLedgerType.SelectedIndex = 0;

            cbLedgerType.SelectedIndexChanged += CbLedgerType_SelectedIndexChanged;
        }

        private void CbLedgerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDataGrid(cbLedgerType.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void LoadDataGrid(int ledgerTypeID)
        {
            dgvAccountLedger.DataSource = applicationFacade.GetAccountLedgerByLedgerTypeIdAndSearch(ledgerTypeID).OrderBy(p => p.AccountLedgerName).ToList();
            ExtensionMethods.SetGridDefaultProperty(dgvAccountLedger);

            dgvAccountLedger.Columns["AccountLedgerCode"].Visible = true;
            dgvAccountLedger.Columns["AccountLedgerCode"].HeaderText = "Account No";
           
            dgvAccountLedger.Columns["AccountLedgerType"].Visible = true;
            dgvAccountLedger.Columns["AccountLedgerType"].HeaderText = "Ledger Type";
          
            dgvAccountLedger.Columns["AccountLedgerName"].Visible = true;
            dgvAccountLedger.Columns["AccountLedgerName"].HeaderText = "Account Name";
            
            dgvAccountLedger.Columns["AccountType"].Visible = true;
            dgvAccountLedger.Columns["AccountType"].HeaderText = "Account Type";
           
            dgvAccountLedger.Columns["OpeningBalance"].Visible = true;
            dgvAccountLedger.Columns["OpeningBalance"].HeaderText = "Opening Balance";
           
            dgvAccountLedger.Columns["DebitControlCode"].Visible = true;
            dgvAccountLedger.Columns["DebitControlCode"].HeaderText = "Debit";
           
            dgvAccountLedger.Columns["CreditControlCode"].Visible = true;
            dgvAccountLedger.Columns["CreditControlCode"].HeaderText = "Credit";

            dgvAccountLedger.Columns["StatusText"].Visible = true;
            dgvAccountLedger.Columns["StatusText"].HeaderText = "Status";

            txtSearch_TextChanged(null,null);
        }


        private void frmAccountLedgerMasterAddUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);

                LoadDataGrid((int)cbLedgerType.SelectedValue);

                frmAccountLedgerMasterAddUpdate frm = (frmAccountLedgerMasterAddUpdate)sender;

                if (dgvAccountLedger.Rows.Count > 0)
                {
                    int id = frm.AccountLedgerId;

                    foreach (DataGridViewRow row in dgvAccountLedger.Rows)
                    {
                        if (row.Cells["AccountLedgerId"].Value.ToString().Equals(frm.AccountLedgerId.ToString()))
                        {
                            dgvAccountLedger.Rows[row.Index].Selected = true;
                            
                            if(row.Index != 0)
                            {
                                dgvAccountLedger.Rows[0].Selected = false;
                            }

                            break; 

                        }
                    }                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           

        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.GridSelectionOnSearch(dgvAccountLedger,"AccountLedgerName",txtSearch.Text, this.lblSearchStatus);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void OpenAddEdit(int accountLedgerId)
        {
            frmAccountLedgerMasterAddUpdate form = new frmAccountLedgerMasterAddUpdate(accountLedgerId,txtSearch.Text);
            form.IsInChildMode = true;
            form.FormClosed -= frmAccountLedgerMasterAddUpdate_FormClosed;
            form.FormClosed += frmAccountLedgerMasterAddUpdate_FormClosed;
            form.ShowDialog();
        }

        private void btnNew_Click(object sender, EventArgs e)
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
                EditLedger();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }

        private void EditLedger()
        {
            if (dgvAccountLedger.SelectedRows.Count == 0)
                MessageBox.Show("Please select atleast one row to edit");          

            PharmaBusinessObjects.Master.AccountLedgerMaster model = (PharmaBusinessObjects.Master.AccountLedgerMaster)dgvAccountLedger.SelectedRows[0].DataBoundItem;

            selectedRowIndex = model.AccountLedgerID;           

            OpenAddEdit(model.AccountLedgerID);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    //PharmaBusinessObjects.Master.AccountLedgerMaster itemToBeRemoved = (PharmaBusinessObjects.Master.AccountLedgerMaster)dgvAccountLedger.SelectedRows[0].DataBoundItem;
                    //applicationFacade.DeleteItem(itemToBeRemoved);
                    //LoadDataGrid(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        public void ConfigureAccountLedger(AccountLedgerType model)
        {
            if (model != null)
            {
                this.cbLedgerType.Text = model.AccountLedgerTypeName;
                this.cbLedgerType.Enabled = false;
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
                EditLedger();
            }
            else if (keyData == Keys.Down)
            {
                dgvAccountLedger.Focus();
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

        private void btnClose_Click(object sender, EventArgs e)
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

        private void frmAccountLedgerMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (dgvAccountLedger.CurrentRow != null)
                {
                    this.LastSelectedAccountLedger = dgvAccountLedger.CurrentRow.DataBoundItem as AccountLedgerMaster;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
