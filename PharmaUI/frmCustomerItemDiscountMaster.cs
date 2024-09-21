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
    public partial class frmCustomerItemDiscountMaster : Form
    {
        IApplicationFacade applicationFacade;
        public CustomerCopanyDiscount retCustomerCopanyDiscount { get; set; }


        public frmCustomerItemDiscountMaster(CustomerCopanyDiscount CustomerCopanyDiscount)
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetChildFormProperties(this);
                ExtensionMethods.FormLoad(this, "Customer Item Discount");

                this.retCustomerCopanyDiscount = CustomerCopanyDiscount;
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCustomerItemDiscountMaster_Load(object sender, EventArgs e)
        {
            try
            {
                ///Display Company name
                ///
                this.lblSelectedCompanyName.Text = retCustomerCopanyDiscount.CompanyName;

                ///Display company discount
                ///
                this.lblNormalVal.Text = Convert.ToString(retCustomerCopanyDiscount.Normal);
                this.lblBreakageVal.Text = Convert.ToString(retCustomerCopanyDiscount.Breakage);
                this.lblExpiredVal.Text = Convert.ToString(retCustomerCopanyDiscount.Expired);

                this.lblNormalVal.Font= new Font(lblNormalVal.Font, FontStyle.Bold);
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

        private List<CustomerCopanyDiscount> GetMergedItemDiscountList()
        {
            try
            {
                List<CustomerCopanyDiscount> allItemDiscountList = applicationFacade.GetAllCompanyItemDiscountByCompanyIDForCustomer(retCustomerCopanyDiscount.CompanyID);
                List<CustomerCopanyDiscount> mappedItemDiscountList = this.retCustomerCopanyDiscount.CustomerItemDiscountMapping;

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

        private void frmCustomerItemDiscountMaster_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.retCustomerCopanyDiscount.CustomerItemDiscountMapping = dgvCustomerItemDiscount.Rows
                                                                                                .Cast<DataGridViewRow>()
                                                                                                .Where(r => !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["Normal"].Value))
                                                                                                            || !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["Breakage"].Value))
                                                                                                            || !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["Expired"].Value))
                                                                                                ).Select(x => new CustomerCopanyDiscount()
                                                                                                {
                                                                                                    CompanyID = (x.DataBoundItem as CustomerCopanyDiscount).CompanyID,
                                                                                                    ItemID = (x.DataBoundItem as CustomerCopanyDiscount).ItemID,
                                                                                                    ItemName = (x.DataBoundItem as CustomerCopanyDiscount).ItemName,
                                                                                                    Normal = (x.DataBoundItem as CustomerCopanyDiscount).Normal,
                                                                                                    Breakage = (x.DataBoundItem as CustomerCopanyDiscount).Breakage,
                                                                                                    Expired = (x.DataBoundItem as CustomerCopanyDiscount).Expired

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
    }
}
