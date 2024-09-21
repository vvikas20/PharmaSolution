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
    public partial class frmUserMaster : Form
    {
        IApplicationFacade applicationFacade;

        public frmUserMaster()
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

        private void frmUserMaster_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, "User Master");

                LoadUserGrid();
                dgvUser.DoubleClick += DgvUser_DoubleClick;
                dgvUser.KeyDown += DgvUser_KeyDown;
                dgvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                LoadRoleGrid();
                dgvRole.DoubleClick += DgvRole_DoubleClick; ;
                dgvRole.KeyDown += DgvRole_KeyDown;
                dgvRole.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                LoadPrivledgeGrid();
                dgvPrivledge.DoubleClick += DgvPrivledge_DoubleClick;
                dgvPrivledge.KeyDown += DgvPrivledge_KeyDown;
                dgvPrivledge.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          

        }

        private void DgvPrivledge_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F3)
                {
                    DataGridViewRow row = dgvPrivledge.SelectedRows[0];

                    if (row != null)
                    {
                        int privledgeId = 0;

                        Int32.TryParse(Convert.ToString(row.Cells["PrivledgeId"].Value), out privledgeId);
                        frmPrivledgeAddUpdate form = new frmPrivledgeAddUpdate(privledgeId);
                        form.FormClosed -= Form_PrivledgeFormClosed;
                        form.FormClosed += Form_PrivledgeFormClosed;
                        form.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }

        private void DgvPrivledge_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvUser.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvPrivledge.SelectedRows[0];

                    if (row != null)
                    {
                        int privledgeId = 0;

                        Int32.TryParse(Convert.ToString(row.Cells["PrivledgeId"].Value), out privledgeId);
                        frmPrivledgeAddUpdate form = new frmPrivledgeAddUpdate(privledgeId);
                        form.FormClosed -= Form_PrivledgeFormClosed;
                        form.FormClosed += Form_PrivledgeFormClosed;
                        form.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void LoadRoleGrid()
        {
            dgvRole.DataSource = applicationFacade.GetRoles(txtRoleSearch.Text);

            for (int i = 0; i < dgvRole.Columns.Count; i++)
            {
                dgvRole.Columns[i].Visible = false;
            }

            dgvRole.Columns["RoleName"].Visible = true;
            dgvRole.Columns["RoleName"].HeaderText = "Role Name";
            dgvRole.Columns["RoleName"].FillWeight = 40;
            dgvRole.Columns["RoleName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvRole.Columns["Status"].Visible = true;
            dgvRole.Columns["Status"].HeaderText = "Status";
            dgvRole.Columns["Status"].FillWeight = 10;
            dgvRole.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvRole.Columns["Privledges"].Visible = true;
            dgvRole.Columns["Privledges"].HeaderText = "Privledges";
            dgvRole.Columns["Privledges"].FillWeight = 30;
            dgvRole.Columns["Privledges"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void LoadPrivledgeGrid()
        {
            dgvPrivledge.DataSource = applicationFacade.GetPrivledges(txtPrivledgeSearch.Text);

            for (int i = 0; i < dgvPrivledge.Columns.Count; i++)
            {
                dgvPrivledge.Columns[i].Visible = false;
            }

            dgvPrivledge.Columns["PrivledgeName"].Visible = true;
            dgvPrivledge.Columns["PrivledgeName"].HeaderText = "Privledge Name";
            dgvPrivledge.Columns["PrivledgeName"].FillWeight = 40;
            dgvPrivledge.Columns["PrivledgeName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvPrivledge.Columns["ControlName"].Visible = true;
            dgvPrivledge.Columns["ControlName"].HeaderText = "Control Name";
            dgvPrivledge.Columns["ControlName"].FillWeight = 20;
            dgvPrivledge.Columns["ControlName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvPrivledge.Columns["Status"].Visible = true;
            dgvPrivledge.Columns["Status"].HeaderText = "Status";
            dgvPrivledge.Columns["Status"].FillWeight = 10;
            dgvPrivledge.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void DgvRole_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F3)
                {
                    DataGridViewRow row = dgvRole.SelectedRows[0];

                    if (row != null)
                    {
                        int roleId = 0;

                        Int32.TryParse(Convert.ToString(row.Cells["RoleId"].Value), out roleId);
                        frmRoleAddUpdate form = new frmRoleAddUpdate(roleId);
                        form.FormClosed -= Form_RoleFormClosed;
                        form.FormClosed += Form_RoleFormClosed;
                        form.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }

        private void DgvRole_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvRole.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvRole.SelectedRows[0];

                    if (row != null)
                    {
                        int roleId = 0;

                        Int32.TryParse(Convert.ToString(row.Cells["RoleId"].Value), out roleId);
                        frmRoleAddUpdate form = new frmRoleAddUpdate(roleId);
                        form.FormClosed -= Form_RoleFormClosed;
                        form.FormClosed += Form_RoleFormClosed;
                        form.ShowDialog();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            try
            {
                frmUserMasterAddUpdate frm = new frmUserMasterAddUpdate();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           

        }

        private void DgvUser_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F3)
                {
                    DataGridViewRow row = dgvUser.SelectedRows[0];

                    if (row != null)
                    {
                        int userId = 0;

                        Int32.TryParse(Convert.ToString(row.Cells["UserId"].Value), out userId);
                        frmUserMasterAddUpdate form = new frmUserMasterAddUpdate(userId);
                        form.FormClosed -= Form_FormClosed;
                        form.FormClosed += Form_FormClosed;
                        form.ShowDialog();
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
                LoadUserGrid();

                if (dgvUser.Rows.Count == 0)
                {
                    if (DialogResult.Yes == MessageBox.Show(string.Format(Constants.Messages.NotExists, "User"), Constants.Messages.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        frmUserMasterAddUpdate form = new frmUserMasterAddUpdate(txtSearch.Text);
                        form.FormClosed += Form_FormClosed;
                        form.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void LoadUserGrid()
        {
            dgvUser.DataSource = applicationFacade.GetUsers(txtSearch.Text);
            for (int i = 0; i < dgvUser.Columns.Count; i++)
            {
                dgvUser.Columns[i].Visible = false;
            }
            dgvUser.Columns["UserName"].Visible = true;
            dgvUser.Columns["UserName"].HeaderText = "User Name";
            dgvUser.Columns["UserName"].FillWeight = 20;
            dgvUser.Columns["UserName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvUser.Columns["FirstName"].Visible = true;
            dgvUser.Columns["FirstName"].HeaderText = "First Name";
            dgvUser.Columns["FirstName"].FillWeight = 20;
            dgvUser.Columns["FirstName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvUser.Columns["LastName"].Visible = true;
            dgvUser.Columns["LastName"].HeaderText = "Last Name";
            dgvUser.Columns["LastName"].FillWeight = 20;
            dgvUser.Columns["LastName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvUser.Columns["IsSystemAdmin"].Visible = true;
            dgvUser.Columns["IsSystemAdmin"].HeaderText = "System Admin";
            dgvUser.Columns["IsSystemAdmin"].FillWeight = 10;
            dgvUser.Columns["IsSystemAdmin"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvUser.Columns["Status"].Visible = true;
            dgvUser.Columns["Status"].HeaderText = "Status";
            dgvUser.Columns["Status"].FillWeight = 10;
            dgvUser.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvUser.Columns["RoleName"].Visible = true;
            dgvUser.Columns["RoleName"].HeaderText = "Role";
            dgvUser.Columns["RoleName"].FillWeight = 20;
            dgvUser.Columns["RoleName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


        }

        private void buttonAddNewUser_Click(object sender, EventArgs e)
        {
            try
            {
                frmUserMasterAddUpdate form = new frmUserMasterAddUpdate();
                form.FormClosed += Form_FormClosed;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                LoadUserGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void DgvUser_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvUser.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvUser.SelectedRows[0];

                    if (row != null)
                    {
                        int userId = 0;

                        Int32.TryParse(Convert.ToString(row.Cells["UserId"].Value), out userId);
                        frmUserMasterAddUpdate form = new frmUserMasterAddUpdate(userId);
                        form.FormClosed -= Form_FormClosed;
                        form.FormClosed += Form_FormClosed;
                        form.ShowDialog();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void btnAddPrivledge_Click(object sender, EventArgs e)
        {
            try
            {
                frmPrivledgeAddUpdate form = new frmPrivledgeAddUpdate();
                form.FormClosed += Form_PrivledgeFormClosed;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void Form_PrivledgeFormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                LoadPrivledgeGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void txtPrivledgeSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadPrivledgeGrid();

                if (dgvPrivledge.Rows.Count == 0)
                {
                    if (DialogResult.Yes == MessageBox.Show(string.Format(Constants.Messages.NotExists, "Privledge"), Constants.Messages.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        frmPrivledgeAddUpdate form = new frmPrivledgeAddUpdate(txtPrivledgeSearch.Text);
                        form.FormClosed += Form_PrivledgeFormClosed;
                        form.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            try
            {
                frmRoleAddUpdate form = new frmRoleAddUpdate();
                form.FormClosed += Form_RoleFormClosed;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void Form_RoleFormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                LoadRoleGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void txtRoleSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadRoleGrid();

                if (dgvRole.Rows.Count == 0)
                {
                    if (DialogResult.Yes == MessageBox.Show(string.Format(Constants.Messages.NotExists, "Role"), Constants.Messages.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        frmRoleAddUpdate form = new frmRoleAddUpdate(txtRoleSearch.Text);
                        form.FormClosed += Form_RoleFormClosed;
                        form.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void dgvPrivledge_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                var dataGridView = sender as DataGridView;
                if (dataGridView != null)
                {
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }
    }
}
