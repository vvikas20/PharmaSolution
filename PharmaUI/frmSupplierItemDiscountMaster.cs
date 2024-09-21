using PharmaBusiness;
using PharmaBusinessObjects;
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
    public partial class frmSupplierItemDiscountMaster : Form
    {
        IApplicationFacade applicationFacade;
        public SupplierCompanyDiscount retSupplierCopanyDiscount { get; set; }

        public frmSupplierItemDiscountMaster(SupplierCompanyDiscount supplierCompanyDiscount)
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetChildFormProperties(this);
                ExtensionMethods.FormLoad(this, "Supplier Item Discount");
                this.retSupplierCopanyDiscount = supplierCompanyDiscount;
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSupplierItemDiscountMaster_Load(object sender, EventArgs e)
        {
            try
            {
                ///Display Company name
                ///
                this.lblSelectedCompanyName.Text = retSupplierCopanyDiscount.CompanyName;

                ///Display company discount
                ///
                this.lblNormalVal.Text = Convert.ToString(retSupplierCopanyDiscount.Normal);
                this.lblBreakageVal.Text = Convert.ToString(retSupplierCopanyDiscount.Breakage);
                this.lblExpiredVal.Text = Convert.ToString(retSupplierCopanyDiscount.Expired);

                this.lblNormalVal.Font = new Font(lblNormalVal.Font, FontStyle.Bold);
                this.lblBreakageVal.Font = new Font(lblBreakageVal.Font, FontStyle.Bold);
                this.lblExpiredVal.Font = new Font(lblExpiredVal.Font, FontStyle.Bold);

                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGrid()
        {
            dgvCustomerItemDiscount.DataSource = GetMergedItemDiscountList();

            for (int i = 0; i < dgvCustomerItemDiscount.Columns.Count; i++)
            {
                dgvCustomerItemDiscount.Columns[i].Visible = false;
            }

            dgvCustomerItemDiscount.Columns["ItemName"].Visible = true;
            dgvCustomerItemDiscount.Columns["ItemName"].HeaderText = "Item Name";
            dgvCustomerItemDiscount.Columns["ItemName"].ReadOnly = true;
            dgvCustomerItemDiscount.Columns["ItemName"].DisplayIndex = 0;

            dgvCustomerItemDiscount.Columns["Normal"].Visible = true;
            dgvCustomerItemDiscount.Columns["Normal"].HeaderText = "Normal";
            dgvCustomerItemDiscount.Columns["Normal"].DisplayIndex = 1;

            dgvCustomerItemDiscount.Columns["Breakage"].Visible = true;
            dgvCustomerItemDiscount.Columns["Breakage"].DisplayIndex = 2;
            dgvCustomerItemDiscount.Columns["Breakage"].HeaderText = "Breakage";

            dgvCustomerItemDiscount.Columns["Expired"].Visible = true;
            dgvCustomerItemDiscount.Columns["Expired"].DisplayIndex = 3;
            dgvCustomerItemDiscount.Columns["Expired"].HeaderText = "Expired";

            dgvCustomerItemDiscount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomerItemDiscount.AllowUserToAddRows = false;
            dgvCustomerItemDiscount.AllowUserToDeleteRows = false;
            dgvCustomerItemDiscount.ReadOnly = false;

        }

        private List<SupplierCompanyDiscount> GetMergedItemDiscountList()
        {
            try
            {
                List<SupplierCompanyDiscount> allItemDiscountList = applicationFacade.GetAllCompanyItemDiscountByCompanyIDForSupplier(retSupplierCopanyDiscount.CompanyID);
                List<SupplierCompanyDiscount> mappedItemDiscountList = this.retSupplierCopanyDiscount.SupplierItemDiscountMapping;

                if (mappedItemDiscountList != null)
                {
                    allItemDiscountList.RemoveAll(x => mappedItemDiscountList.Any(y => y.ItemID == x.ItemID));
                    allItemDiscountList.AddRange(mappedItemDiscountList);
                }

                return allItemDiscountList.OrderBy(x => x.ItemName).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.retSupplierCopanyDiscount.SupplierItemDiscountMapping = dgvCustomerItemDiscount.Rows
                                                                                                .Cast<DataGridViewRow>()
                                                                                                .Where(r => !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["Normal"].Value))
                                                                                                            || !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["Breakage"].Value))
                                                                                                            || !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["Expired"].Value))
                                                                                                ).Select(x => new SupplierCompanyDiscount()
                                                                                                {
                                                                                                    CompanyID = (x.DataBoundItem as SupplierCompanyDiscount).CompanyID,
                                                                                                    ItemID = (x.DataBoundItem as SupplierCompanyDiscount).ItemID,
                                                                                                    ItemName = (x.DataBoundItem as SupplierCompanyDiscount).ItemName,
                                                                                                    Normal = (x.DataBoundItem as SupplierCompanyDiscount).Normal,
                                                                                                    Breakage = (x.DataBoundItem as SupplierCompanyDiscount).Breakage,
                                                                                                    Expired = (x.DataBoundItem as SupplierCompanyDiscount).Expired

                                                                                                }).ToList();

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

        private void dgvCustomerItemDiscount_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCustomerItemDiscount.CurrentRow.Cells[e.ColumnIndex].ReadOnly)
                {
                    SendKeys.Send("{tab}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Close on escape
            if (keyData == (Keys.Escape))
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvCustomerItemDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                e.SuppressKeyPress = true;

                if (e.KeyData == Keys.Enter)
                {
                    int rowIndex = dgvCustomerItemDiscount.CurrentCell.RowIndex;
                    int columnIndex = 0;
                    string columnName = dgvCustomerItemDiscount.Columns[dgvCustomerItemDiscount.CurrentCell.ColumnIndex].Name;

                    int columnDisplayIndex = dgvCustomerItemDiscount.Columns[dgvCustomerItemDiscount.CurrentCell.ColumnIndex].DisplayIndex;

                    for (int i = 0; i < dgvCustomerItemDiscount.ColumnCount; i++)
                    {
                        if (dgvCustomerItemDiscount.Columns[i].DisplayIndex == columnDisplayIndex + 1)
                        {
                            columnIndex = i;
                            break;
                        }
                    }

                    if (rowIndex == (dgvCustomerItemDiscount.Rows.Count - 1) && columnName == "Expired")
                    {
                        btnSave.Focus();

                    }
                    else if (rowIndex < (dgvCustomerItemDiscount.Rows.Count - 1) && columnName == "Expired")
                    {
                        for (int i = 0; i < dgvCustomerItemDiscount.Columns.Count - 1; i++)
                        {
                            if (dgvCustomerItemDiscount.Columns[i].DisplayIndex == 0)
                            {
                                dgvCustomerItemDiscount.CurrentCell = dgvCustomerItemDiscount[i, rowIndex + 1];
                                break;
                            }
                        }
                    }
                    else
                    {
                        dgvCustomerItemDiscount.CurrentCell = dgvCustomerItemDiscount[columnIndex, rowIndex];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCustomerItemDiscount_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                string columnName = dgvCustomerItemDiscount.Columns[dgvCustomerItemDiscount.CurrentCell.ColumnIndex].Name;

                if (columnName.Equals("ItemName")) return;

                e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
