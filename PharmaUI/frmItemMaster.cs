using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Master;
using PharmaBusinessObjects.Common;
using System.Reflection;
using System.Threading;

namespace PharmaUI
{   
    public partial class frmItemMaster : Form
    {
        public PharmaBusinessObjects.Master.ItemMaster LastSelectedItemMaster { get; set; }
        IApplicationFacade applicationFacade;

        private bool isOpenAsChild = false;
        TypeAssistant assistant;
        private bool isAddEditFormClosed = false;
        private bool useMemoryForItem = false;
        public int RowIndex { get; set; }

        public frmItemMaster(bool _isOpenAsChild = false)
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetFormProperties(this);
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);

                txtSearch.CharacterCasing = CharacterCasing.Upper;

                isOpenAsChild = _isOpenAsChild;
                assistant = new TypeAssistant();
                assistant.Idled += Assistant_Idled;

                string value = System.Configuration.ConfigurationManager.AppSettings["UseMemoryForItemMaster"];

                if(value != null)
                {
                    useMemoryForItem = Convert.ToBoolean(value);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

       

        private void frmItemMaster_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, "Item Master");
                GotFocusEventRaised(this);
                ExtensionMethods.EnterKeyDownForTabEvents(this);

                LoadDataGrid();

                dgvItemList.CellDoubleClick += DgvItemList_CellDoubleClick;
                dgvItemList.KeyDown += DgvItemList_KeyDown;
                dgvItemList.SelectionChanged += DgvItemList_SelectionChanged;

                //if (isOpenAsChild && dgvItemList.Rows.Count > 0)
                //{                   
                //    dgvItemList.CurrentCell = dgvItemList.Rows[0].Cells[2];
                //}

                txtSearch.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvItemList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvItemList.SelectedRows.Count > 0)
                {

                    DataGridViewRow row = dgvItemList.CurrentRow;

                   // ItemMaster selectedItem = (ItemMaster)dgvItemList.SelectedRows[0].DataBoundItem;
                    //Display selected Item data
                    lblCodeVal.Text = row.Cells["ItemCode"].Value.ToString();
                    lblStatusVal.Text = Convert.ToBoolean(row.Cells["Status"].Value) ? "ACTIVE" : "INACTIVE";
                    lblStatusVal.ForeColor = Convert.ToBoolean(row.Cells["Status"].Value) ? Color.MidnightBlue : Color.Red;
                    lblPackVal.Text = Convert.ToString(row.Cells["Packing"].Value);
                    lblLocationVal.Text = Convert.ToString(row.Cells["Location"].Value);
                    lblUPCVal.Text = Convert.ToString(row.Cells["UPC"].Value);

                    lblMRPVal.Text = Convert.ToString(row.Cells["MRP"].Value);
                    lblSchemeVal.Text = Convert.ToString(row.Cells["Scheme1"].Value) + " + " + Convert.ToString(row.Cells["Scheme2"].Value);
                    lblHalfSchemeVal.Text = Convert.ToBoolean(row.Cells["IsHalfScheme"].Value) ? "Y" : "N";
                    lblQtrSchemeVal.Text = Convert.ToBoolean(row.Cells["IsQTRScheme"].Value) ? "Y" : "N";
                    lblMaxQtyVal.Text = Convert.ToString(row.Cells["MaximumQty"].Value);
                    lblMaxDiscountVal.Text = Convert.ToString(row.Cells["MaximumDiscount"].Value);

                    lblSaleRateVal.Text = Convert.ToString(row.Cells["SaleRate"].Value);
                    lblSpecialRateVal.Text = Convert.ToString(row.Cells["SpecialRate"].Value);
                    lblWSRateVal.Text = Convert.ToString(row.Cells["WholeSaleRate"].Value);
                    lblExciseVal.Text = Convert.ToString(row.Cells["SaleExcise"].Value);
                    lblVATVal.Text = Convert.ToString(row.Cells["TaxOnSale"].Value);
                    lblSpecialDiscountVal.Text = Convert.ToString(row.Cells["SpecialDiscountOnQty"].Value);
                    lblFixedDiscountVal.Text = Convert.ToString(row.Cells["FixedDiscountRate"].Value);
                    lblSurchargeVal.Text = Convert.ToString(row.Cells["SurchargeOnSale"].Value);

                    lblPurchaseRateVal.Text = Convert.ToString(row.Cells["PurchaseRate"].Value);
                    lblPExciseVal.Text = Convert.ToString(row.Cells["SaleExcise"].Value);
                    lblPVATVal.Text = Convert.ToString(row.Cells["TaxOnPurchase"].Value);
                    lblPDiscountVal.Text = Convert.ToString(row.Cells["DiscountRecieved"].Value);
                    lblPSpecialDiscountVal.Text = Convert.ToString(row.Cells["SpecialDiscountRecieved"].Value);
                    lblPSurchargeVal.Text = Convert.ToString(row.Cells["SurchargeOnPurchase"].Value);

                    //lblPurchaseRateVal.Text = Convert.ToString(row.Cells["PurchaseRate"].Value);
                    //lblPExciseVal.Text = Convert.ToString(row.Cells["SaleExcise"].Value);
                    //lblPVATVal.Text = Convert.ToString(row.Cells["TaxOnPurchase"].Value);
                    //lblPDiscountVal.Text = Convert.ToString(row.Cells["DiscountRecieved"].Value);
                    lblMaxStockVal.Text = Convert.ToString(row.Cells["MaximumStock"].Value);
                    lblMinStockVal.Text = Convert.ToString(row.Cells["MinimumStock"].Value);

                    lblBalVal.Text = Convert.ToString(row.Cells["BalanceQuantity"].Value);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    EditItem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenItemAddUpdateForm(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenItemAddUpdateForm(int itemId)
        {
            frmItemMasterAddUpdated form = new frmItemMasterAddUpdated(itemId,txtSearch.Text);
            form.IsInChildMode = true;
            ExtensionMethods.AddChildFormToPanel(this, form, ExtensionMethods.MainPanel);
            form.WindowState = FormWindowState.Maximized;


            if (itemId > 0 && dgvItemList.SelectedRows[0] != null)
            {
              
                form.frmItemMasterAddUpdate_Fill_UsingExistingItem(GetCurrentRowItem());
            }

            form.FormClosed += FormItemMasterAddUpdated_FormClosed;
            form.Show();
        }

        private void FormItemMasterAddUpdated_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
                isAddEditFormClosed = true;
                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void LoadDataGrid()
        {
            // string searchBy = "Name";

            if (isOpenAsChild)
            {
                dgvItemList.ColumnHeadersVisible = false;
            }

            if (isAddEditFormClosed)
            {
                StagingData.SetItemListData(applicationFacade.GetAllItemsBySearch());
            }
            else if(!useMemoryForItem)
            {
                StagingData.SetItemListData(applicationFacade.GetAllItemsBySearch());
            }


            dgvItemList.DataSource = StagingData.ItemList;

           //applicationFacade.GetAllItemsBySearch(null, searchBy).OrderBy(p=>p.ItemName).ToList();
            ExtensionMethods.SetGridDefaultProperty(dgvItemList);

           dgvItemList.Columns["ItemName"].Visible = true;
          //  dgvItemList.Columns["ItemName"].HeaderText = "Item";

            dgvItemList.Columns["CompanyName"].Visible = true;

            dgvItemList.Columns["BalanceQuantity"].Visible = true;
          //  dgvItemList.Columns["CompanyName"].HeaderText = "Company";

            dgvItemList.Columns["Packing"].Visible = true;
           // dgvItemList.Columns["Packing"].HeaderText = "Pack";

            dgvItemList.Columns["QtyPerCase"].Visible = true;
          //  dgvItemList.Columns["QtyPerCase"].HeaderText = "Qty";

          //  txtSearch_TextChanged(null, null);


        }

        private void DgvItemList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && isOpenAsChild)
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

        private void Assistant_Idled(object sender, EventArgs e)
        {
            this.Invoke(
               new MethodInvoker(() =>
               {
                   ExtensionMethods.GridSelectionOnSearch(dgvItemList, "ItemName", txtSearch.Text, this.lblSearchStatus);
               }));
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {

                assistant.TextChanged();
               // ExtensionMethods.GridSelectionOnSearch(dgvItemList, "ItemName", txtSearch.Text, this.lblSearchStatus);               
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
                OpenItemAddUpdateForm(0);
                return true;
            }
            else if (keyData == Keys.F3)
            {
                EditItem();
            }
            else if(keyData == Keys.F5)
            {
                btnBatches_Click(null, null);
            }
            else if(keyData == Keys.Down)
            {
                dgvItemList.Focus();

                //int rowindex = dgvItemList.Rows.Count == dgvItemList.CurrentRow.Index + 1 ? dgvItemList.CurrentRow.Index : dgvItemList.CurrentRow.Index + 1;

                //dgvItemList.Rows[rowindex].Selected = true;
            }
            else if (keyData == Keys.Up)
            {
                dgvItemList.Focus();

                //int rowindex = dgvItemList.CurrentRow.Index  == 0 ? dgvItemList.CurrentRow.Index : dgvItemList.CurrentRow.Index - 1;

                //dgvItemList.Rows[rowindex].Selected = true;
            }
            else if (keyData == Keys.Escape)
            {
                if (isOpenAsChild)
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

            if (keyData == Keys.Enter && isOpenAsChild && dgvItemList.SelectedRows.Count > 0)
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void EditItem()
        {
            if (dgvItemList.SelectedRows.Count == 0)
                MessageBox.Show("Please select atleast one row to edit");

            // PharmaBusinessObjects.Master.ItemMaster model = (PharmaBusinessObjects.Master.ItemMaster)dgvItemList.SelectedRows[0].DataBoundItem;           

            DataGridViewRow row = dgvItemList.CurrentRow;

            OpenItemAddUpdateForm(Convert.ToInt32(row.Cells["ItemID"].Value));
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                EditItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmItemMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frmItemMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (dgvItemList.CurrentRow != null)
                {
                    this.LastSelectedItemMaster = GetCurrentRowItem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private ItemMaster GetCurrentRowItem()
        {
            DataGridViewRow row = dgvItemList.CurrentRow;

            ItemMaster existingItem = new ItemMaster()
            {
                ItemID = Convert.ToInt32(row.Cells["ItemID"].Value),
                ItemCode = Convert.ToString(row.Cells["ItemCode"].Value),
                ItemName = Convert.ToString(row.Cells["ItemName"].Value),
                CompanyName = Convert.ToString(row.Cells["CompanyName"].Value),
                CompanyID = Convert.ToInt32(row.Cells["CompanyID"].Value),
                ConversionRate = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["ConversionRate"].Value)),
                ShortName = Convert.ToString(row.Cells["ShortName"].Value),
                Packing = Convert.ToString(row.Cells["Packing"].Value),
                PurchaseRate = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["PurchaseRate"].Value)) ?? 0,
                MRP = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["MRP"].Value)) ?? 0,
                SaleRate = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["SaleRate"].Value)) ?? 0,
                SpecialRate = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["SpecialRate"].Value)) ?? 0,
                WholeSaleRate = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["WholeSaleRate"].Value)) ?? 0,
                SaleExcise = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["SaleExcise"].Value)) ?? 0,
                SurchargeOnSale = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["SurchargeOnSale"].Value)) ?? 0,
                TaxOnSale = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["TaxOnSale"].Value)) ?? 0,
                Scheme1 = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["Scheme1"].Value)) ?? 0,
                Scheme2 = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["Scheme2"].Value)) ?? 0,
                PurchaseExcise = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["PurchaseExcise"].Value)) ?? 0,
                UPC = Convert.ToString(row.Cells["UPC"].Value),
                IsHalfScheme = Convert.ToBoolean(row.Cells["IsHalfScheme"].Value),
                IsQTRScheme = Convert.ToBoolean(row.Cells["IsQTRScheme"].Value),
                SpecialDiscount = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["SpecialDiscount"].Value)) ?? 0,
                SpecialDiscountOnQty = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["SpecialDiscountOnQty"].Value)) ?? 0,
                IsFixedDiscount = Convert.ToBoolean(row.Cells["IsFixedDiscount"].Value),
                FixedDiscountRate = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["FixedDiscountRate"].Value)) ?? 0,
                MaximumQty = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["MaximumQty"].Value)) ?? 0,
                MaximumDiscount = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["MaximumDiscount"].Value)) ?? 0,
                SurchargeOnPurchase = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["SurchargeOnPurchase"].Value)) ?? 0,
                TaxOnPurchase = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["TaxOnPurchase"].Value)) ?? 0,
                DiscountRecieved = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["DiscountRecieved"].Value)) ?? 0,
                SpecialDiscountRecieved = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["SpecialDiscountRecieved"].Value)) ?? 0,
                QtyPerCase = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["QtyPerCase"].Value)) ?? 0,
                //  Location = Convert.ToString(row.Cells["Location"].Value),
                MinimumStock = ExtensionMethods.SafeConversionInt(Convert.ToString(row.Cells["MinimumStock"].Value)),
                MaximumStock = ExtensionMethods.SafeConversionInt(Convert.ToString(row.Cells["MaximumStock"].Value)),
                SaleTypeId = Convert.ToInt32(row.Cells["SaleTypeId"].Value),
                PurchaseTypeId = Convert.ToInt32(row.Cells["PurchaseTypeId"].Value),
                HSNCode = Convert.ToString(row.Cells["HSNCode"].Value),
                Status = Convert.ToBoolean(row.Cells["Status"].Value),
                PurchaseTypeCode = Convert.ToString(row.Cells["PurchaseTypeCode"].Value),
                PurchaseTypeName = Convert.ToString(row.Cells["PurchaseTypeName"].Value),
                PurchaseTypeRate = ExtensionMethods.SafeConversionDecimal(Convert.ToString(row.Cells["PurchaseTypeRate"].Value))
            };

            return existingItem;



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

        private void btnBatches_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItemList.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select atleast one row to edit batch");
                }
                else
                {                    

                    DataGridViewRow row = dgvItemList.CurrentRow;

                    frmBatches form = new frmBatches(Convert.ToString(row.Cells["ItemCode"].Value), Convert.ToString(row.Cells["ItemName"].Value));
                    ExtensionMethods.AddChildFormToPanel(this, form, ExtensionMethods.MainPanel);
                    form.WindowState = FormWindowState.Maximized;
                    form.FormClosed += FormBatch_Closed;
                    form.Show();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormBatch_Closed(object sender, FormClosedEventArgs e)
        {
            ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
        }
    }
}
