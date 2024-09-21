using Microsoft.Reporting.WebForms;
using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Master;
using PharmaBusinessObjects.Transaction;
using PharmaBusinessObjects.Transaction.SaleEntry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmaUI
{
    public partial class frmSaleEntry : Form
    {
        
        private bool IsModify = false;
        private bool isDirty = false;
        private bool isBatchUpdate = false;
        private int layoutHeight = 0;
        private int layoutWidth = 0;
        private bool isCellEdit = false;
        private decimal oldQuantity = 0M;
        private decimal oldFreeQuantity = 0M;
        private string VoucherTypeCode = "";
        private long purchaseSaleBookHeaderID = 0;
        private long? oldPurchaseSaleBookHeaderID = null;

        IApplicationFacade applicationFacade;
        private PurchaseSaleBookHeader header = new PurchaseSaleBookHeader();
        // private PurchaseSaleBookLineItem lineItem = new PurchaseSaleBookLineItem();

        private int oldSelectedRowIndex = -1;
        private bool isSetGrid = false;

        public frmSaleEntry(bool isModify, string voucherTypeCode)
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetFormProperties(this);
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
                this.IsModify = isModify;
                this.VoucherTypeCode = voucherTypeCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void frmSaleEntry_Load(object sender, EventArgs e)
        {
            try
            {
                string pageHeading = VoucherTypeCode == Constants.VoucherTypeCode.SALEENTRY && IsModify ? "Sale Entry Modification" 
                                    : VoucherTypeCode == Constants.VoucherTypeCode.SALEENTRY && !IsModify ? "Sale Entry Transaction"
                                    : VoucherTypeCode == Constants.VoucherTypeCode.SALEONCHALLAN && IsModify ? "Sale Challan Transaction"
                                    : "Sale Challan Transaction";
                ExtensionMethods.FormLoad(this, pageHeading);
                ExtensionMethods.AddFooter(this);
                GotFocusEventRaised(this);
                EnterKeyDownForTabEvents(this);
                InitializeGrid();

                layoutHeight = tableLayoutPanel3.Height;
                layoutWidth = tableLayoutPanel3.Width;
                tableLayoutPanel3.Height = 0;
                tableLayoutPanel3.Width = 0;

                cbxSaleType.DataSource = applicationFacade.GetPurchaseEntryTypes();
                cbxSaleType.DisplayMember = "PurchaseTypeName";
                cbxSaleType.ValueMember = "ID";
                cbxSaleType.SelectedIndex = 0;

                lblFRate.Visible = false;
                lblDueBillAmount.Visible = false;
                lblDueBills.Visible = false;

                dtSaleDate.Text = ExtensionMethods.ConvertToAppDateFormat(DateTime.Now);
                dtSaleDate.Focus();
                dtSaleDate.Select(0, 0);

                dtSaleDate.LostFocus += DtSaleDate_LostFocus;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DtSaleDate_LostFocus(object sender, EventArgs e)
        {
            if (!ExtensionMethods.IsValidDate(dtSaleDate.Text))
            {
                errFrmSaleEntry.SetError(dtSaleDate, Constants.Messages.InValidDate);
                dtSaleDate.Focus();
            }
            else
            {
                errFrmSaleEntry.SetError(dtSaleDate, String.Empty);
            }
        }

        private void InitializeGrid()
        {
            dgvLineItem.Columns.Add("PurchaseSaleBookLineItemID", "PurchaseSaleBookLineItemID");
            dgvLineItem.Columns["PurchaseSaleBookLineItemID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseSaleBookLineItemID"].Visible = false;

            dgvLineItem.Columns.Add("SrNo", "SrNo");
            dgvLineItem.Columns["SrNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SrNo"].FillWeight = 5;
            dgvLineItem.Columns["SrNo"].ReadOnly = true;
            dgvLineItem.Columns["SrNo"].Visible = false;

            dgvLineItem.Columns.Add("ItemCode", "Item Code");
            dgvLineItem.Columns["ItemCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["ItemCode"].FillWeight = 10;
            dgvLineItem.Columns["ItemCode"].ReadOnly = true;

            dgvLineItem.Columns.Add("ItemName", "ItemName");
            dgvLineItem.Columns["ItemName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["ItemName"].FillWeight = 15;
            dgvLineItem.Columns["ItemName"].ReadOnly = true;

            dgvLineItem.Columns.Add("Batch", "Batch No");
            dgvLineItem.Columns["Batch"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Batch"].FillWeight = 10;
            dgvLineItem.Columns["Batch"].ReadOnly = true;


            dgvLineItem.Columns.Add("Quantity", "Quantity");
            dgvLineItem.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Quantity"].FillWeight = 5;

            dgvLineItem.Columns.Add("FreeQuantity", "Free Quantity");
            dgvLineItem.Columns["FreeQuantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["FreeQuantity"].FillWeight = 5;

            dgvLineItem.Columns.Add("SaleRate", "Rate");
            dgvLineItem.Columns["SaleRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SaleRate"].FillWeight = 5;

            dgvLineItem.Columns.Add("Amount", "Amount");
            dgvLineItem.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Amount"].FillWeight = 5;
            dgvLineItem.Columns["Amount"].ReadOnly = true;

            dgvLineItem.Columns.Add("PurchaseSaleBookHeaderID", "PurchaseSaleBookHeaderID");
            dgvLineItem.Columns["PurchaseSaleBookHeaderID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseSaleBookHeaderID"].Visible = false;

            dgvLineItem.Columns.Add("Scheme1", "Scheme1");
            dgvLineItem.Columns["Scheme1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Scheme1"].Visible = false;

            dgvLineItem.Columns.Add("Scheme2", "Scheme2");
            dgvLineItem.Columns["Scheme2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Scheme2"].Visible = false;

            dgvLineItem.Columns.Add("IsHalfScheme", "IsHalfScheme");
            dgvLineItem.Columns["IsHalfScheme"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["IsHalfScheme"].Visible = false;

            dgvLineItem.Columns.Add("Discount", "Discount");
            dgvLineItem.Columns["Discount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Discount"].Visible = false;

            dgvLineItem.Columns.Add("SpecialDiscount", "SpecialDiscount");
            dgvLineItem.Columns["SpecialDiscount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SpecialDiscount"].Visible = false;

            dgvLineItem.Columns.Add("BatchNew", "BatchNew");
            dgvLineItem.Columns["BatchNew"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["BatchNew"].Visible = false;

            dgvLineItem.Columns.Add("CGST", "CGST");
            dgvLineItem.Columns["CGST"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["CGST"].Visible = false;

            dgvLineItem.Columns.Add("BalanceQuantity", "BalanceQuantiity");
            dgvLineItem.Columns["BalanceQuantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["BalanceQuantity"].Visible = false;

            dgvLineItem.Columns.Add("ConversionRate", "ConversionRate");
            dgvLineItem.Columns["ConversionRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["ConversionRate"].Visible = false;

            dgvLineItem.Columns.Add("CostAmount", "CostAmount");
            dgvLineItem.Columns["CostAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["CostAmount"].Visible = false;

            dgvLineItem.Columns.Add("DiscountQuantity", "DiscountQuantity");
            dgvLineItem.Columns["DiscountQuantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["DiscountQuantity"].Visible = false;

            dgvLineItem.Columns.Add("EffecivePurchaseSaleRate", "EffecivePurchaseSaleRate");
            dgvLineItem.Columns["EffecivePurchaseSaleRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["EffecivePurchaseSaleRate"].Visible = false;

            dgvLineItem.Columns.Add("HalfSchemeRate", "HalfSchemeRate");
            dgvLineItem.Columns["HalfSchemeRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["HalfSchemeRate"].Visible = false;

            dgvLineItem.Columns.Add("IGST", "IGST");
            dgvLineItem.Columns["IGST"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["IGST"].Visible = false;

            dgvLineItem.Columns.Add("LocalCentral", "LocalCentral");
            dgvLineItem.Columns["LocalCentral"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["LocalCentral"].Visible = false;

            dgvLineItem.Columns.Add("MRP", "MRP");
            dgvLineItem.Columns["MRP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["MRP"].Visible = false;

            dgvLineItem.Columns.Add("PurchaseBillDate", "PurchaseBillDate");
            dgvLineItem.Columns["PurchaseBillDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseBillDate"].Visible = false;

            dgvLineItem.Columns.Add("PurchaseSaleTax", "PurchaseSaleTax");
            dgvLineItem.Columns["PurchaseSaleTax"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseSaleTax"].Visible = false;

            dgvLineItem.Columns.Add("PurchaseSaleTypeCode", "PurchaseSaleTypeCode");
            dgvLineItem.Columns["PurchaseSaleTypeCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseSaleTypeCode"].Visible = false;

            dgvLineItem.Columns.Add("PurchaseSrlNo", "PurchaseSrlNo");
            dgvLineItem.Columns["PurchaseSrlNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseSrlNo"].Visible = false;

            dgvLineItem.Columns.Add("PurchaseVoucherNumber", "PurchaseVoucherNumber");
            dgvLineItem.Columns["PurchaseVoucherNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseVoucherNumber"].Visible = false;

            dgvLineItem.Columns.Add("SGST", "SGST");
            dgvLineItem.Columns["SGST"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SGST"].Visible = false;

            dgvLineItem.Columns.Add("SpecialRate", "SpecialRate");
            dgvLineItem.Columns["SpecialRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SpecialRate"].Visible = false;

            dgvLineItem.Columns.Add("SurCharge", "SurCharge");
            dgvLineItem.Columns["SurCharge"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SurCharge"].Visible = false;

            dgvLineItem.Columns.Add("VolumeDiscount", "VolumeDiscount");
            dgvLineItem.Columns["VolumeDiscount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["VolumeDiscount"].Visible = false;

            dgvLineItem.Columns.Add("WholeSaleRate", "WholeSaleRate");
            dgvLineItem.Columns["WholeSaleRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["WholeSaleRate"].Visible = false;

            dgvLineItem.Columns.Add("PurchaseSaleRate", "PurchaseSaleRate");
            dgvLineItem.Columns["PurchaseSaleRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseSaleRate"].Visible = false;

            dgvLineItem.Columns.Add("ExpiryDate", "ExpiryDate");
            dgvLineItem.Columns["ExpiryDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["ExpiryDate"].Visible = false;

            dgvLineItem.Columns.Add("FifoID", "FifoID");
            dgvLineItem.Columns["FifoID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["FifoID"].Visible = false;

            dgvLineItem.Columns.Add("LineItemGroupID", "LineItemGroupID");
            dgvLineItem.Columns["LineItemGroupID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["LineItemGroupID"].Visible = false;


            dgvLineItem.KeyDown += dgvLineItem_KeyDown;
            dgvLineItem.CellBeginEdit += DgvLineItem_CellBeginEdit;
            dgvLineItem.CellEndEdit += DgvLineItem_CellEndEdit;
            dgvLineItem.CellValueChanged += DgvLineItem_CellValueChanged;
            dgvLineItem.EditingControlShowing += DgvLineItem_EditingControlShowing;
            dgvLineItem.SelectionChanged += DgvLineItem_SelectionChanged; ;
        }

        private void DgvLineItem_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvLineItem.SelectedCells.Count > 0)
                {

                    int rowIndex = dgvLineItem.SelectedCells[0].RowIndex;

                    if (oldSelectedRowIndex != rowIndex)

                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["ItemCode"].Value)))
                        {
                            long id = 0;
                            long.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["FifoID"].Value), out id);
                            SetFooterInfo(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["ItemCode"].Value), id);
                        }
                        else
                        {
                            SetFooterInfo(string.Empty, 0);
                        }
                    }

                    if (oldSelectedRowIndex != rowIndex)
                        oldSelectedRowIndex = rowIndex;
                }
                else
                {
                    SetFooterInfo(string.Empty, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgvLineItem_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                isCellEdit = false;
                oldQuantity = 0;
                decimal.TryParse(Convert.ToString(dgvLineItem.Rows[e.RowIndex].Cells["Quantity"].Value), out oldQuantity);

                oldFreeQuantity = 0;
                decimal.TryParse(Convert.ToString(dgvLineItem.Rows[e.RowIndex].Cells["FreeQuantity"].Value), out oldFreeQuantity);

                if (header.PurchaseSaleBookHeaderID == 0)
                {
                    MessageBox.Show("Please enter invoice number before adding the items");
                    dgvLineItem.CancelEdit();
                }

                string columnName = dgvLineItem.Columns[e.ColumnIndex].Name;

                if (columnName == "Quantity" || columnName == "FreeQuantity")
                {
                    int lineItemGroupID = 0;
                    Int32.TryParse(dgvLineItem.Rows[e.RowIndex].Cells["LineItemGroupID"].Value.ToString(), out lineItemGroupID);

                    int rowIndex = dgvLineItem.Rows.Cast<DataGridViewRow>().Where(p => Convert.ToString(p.Cells["ItemCode"].Value) == Convert.ToString(dgvLineItem.Rows[e.RowIndex].Cells["ItemCode"].Value) && Convert.ToInt32(p.Cells["LineItemGroupID"].Value) == lineItemGroupID).Select(p => p.Index).ToList().OrderByDescending(p => p).FirstOrDefault();

                    if (rowIndex != e.RowIndex && dgvLineItem.Rows.Cast<DataGridViewRow>().Any(p => Convert.ToInt32(p.Cells["LineItemGroupID"].Value) == lineItemGroupID && Convert.ToInt32(p.Cells["FreeQuantity"].Value) > 0))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Please edit last row of same item code");

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgvLineItem_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgvLineItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)

        {
            try
            {
                if (isCellEdit)
                {
                    int rowIndex = e.RowIndex;

                    this.BeginInvoke(new MethodInvoker(() =>
                    {
                        OpenDialogAndMoveToNextControl(e.RowIndex, e.ColumnIndex, true);
                    }));

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenDialogAndMoveToNextControl(int rowIndex, int colIndex, bool isEdit)
        {
            PurchaseSaleBookLineItem lineItem = ConvertToPurchaseBookLineItem(dgvLineItem.Rows[rowIndex]);
            string columnName = dgvLineItem.Columns[colIndex].Name;
            decimal freeQuantity = 0;

            if (columnName == "ItemCode")
            {
                string itemCode = Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["ItemCode"].Value);

                if (string.IsNullOrWhiteSpace(itemCode))
                {
                    frmItemMaster itemMaster = new frmItemMaster(true);
                    itemMaster.RowIndex = rowIndex;
                    //Set Child UI
                    ExtensionMethods.AddChildFormToPanel(this, itemMaster, ExtensionMethods.MainPanel);
                    itemMaster.WindowState = FormWindowState.Maximized;

                    itemMaster.FormClosed += ItemMaster_FormClosed;
                    itemMaster.Show();
                }
                else
                {
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["Batch"];
                }

            }
            else if (columnName == "Batch")
            {
                string batch = Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["Batch"].Value);

                if (string.IsNullOrWhiteSpace(batch))
                {
                    MessageBox.Show("Batch cannot be left blank. Please select other item");
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["Batch"];
                }
                else
                {
                    lineItem.Batch = batch;
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["Quantity"];
                }
            }
            else if (columnName == "Quantity")
            {
                decimal qty = 0;
                decimal calFreeQuantity = 0;
                decimal.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["Quantity"].Value), out qty);
                decimal.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["FreeQuantity"].Value), out freeQuantity);
                
                if (qty == 0)
                {
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["Quantity"];
                }
                else if (!IsQuantityAvailable(lineItem.PurchaseSaleBookHeaderID, lineItem.ItemCode, lineItem.PurchaseSaleBookLineItemID, qty, freeQuantity, ref calFreeQuantity))
                {
                    MessageBox.Show("Quantity entered is out of stock. Please change the quantity");
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["Quantity"];
                    dgvLineItem.Rows[rowIndex].Cells["Quantity"].Value = oldQuantity;
                }
                else
                {
                    lineItem.Quantity = qty;
                    lineItem.FreeQuantity = isEdit ? calFreeQuantity : freeQuantity;
                    dgvLineItem.Rows[rowIndex].Cells["FreeQuantity"].Value = lineItem.FreeQuantity;
                    SetFooterInfo(lineItem.ItemCode, lineItem.FifoID ?? 0);
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["FreeQuantity"];
                }
            }
            else if (columnName == "FreeQuantity")
            {
                decimal calcFreeQty = 0;
                decimal qty = 0;
                decimal.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["Quantity"].Value), out qty);

                decimal.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["FreeQuantity"].Value), out freeQuantity);

                if (!IsQuantityAvailable(lineItem.PurchaseSaleBookHeaderID, lineItem.ItemCode, lineItem.PurchaseSaleBookLineItemID, qty, freeQuantity, ref calcFreeQty))
                {
                    MessageBox.Show("Quantity entered is out of stock. Please change the quantity");
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["FreeQuantity"];
                    dgvLineItem.Rows[rowIndex].Cells["FreeQuantity"].Value = oldFreeQuantity;
                }
                else
                {
                    lineItem.FreeQuantity = freeQuantity;
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["SaleRate"];
                }
            }
            else if (columnName == "SaleRate")
            {
                DataRow dr = StagingData.ItemList.Select("ItemCode=" + lineItem.ItemCode).FirstOrDefault();

                decimal saleRate = 0;
                decimal.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["SaleRate"].Value), out saleRate);

                if (saleRate == 0)
                {
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["SaleRate"];
                }
                else
                {
                    if (lineItem.PurchaseSaleRate > saleRate)
                    {
                        if (MessageBox.Show(string.Format("Cost of this item {0} is greater than sale rate {1}. Do you want to continue?", lineItem.PurchaseSaleRate.ToString("#.##"), saleRate.ToString("#.##")), "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            dr["SaleRate"] = saleRate;
                            lineItem.SaleRate = saleRate;
                            OpenSaleRateDialog(lineItem, rowIndex);
                        }
                        else
                        {
                            dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["SaleRate"];
                        }
                    }
                    else
                    {
                        dr["SaleRate"] = saleRate;
                        lineItem.SaleRate = saleRate;
                        OpenSaleRateDialog(lineItem, rowIndex);
                    }
                }
            }
            //else
            //{
            //    if (isEdit)
            //    {
            //        InsertUpdateLineItemAndsetToGrid(lineItem);

            //        this.BeginInvoke(new MethodInvoker(() =>
            //        {
            //            OpenDialogAndMoveToNextControl(rowIndex, colIndex);
            //        }));
            //    }
            //    else
            //    {
            //        OpenDialogAndMoveToNextControl(rowIndex, colIndex);
            //    }
            //}

        }

        private bool IsQuantityAvailable(long headerID, string itemCode, long lineItemID, decimal quantity, decimal freeQuantity, ref decimal newFreeQuantity)
        {
            return applicationFacade.IsQuantityAvailable(headerID, lineItemID, itemCode, quantity, freeQuantity, ref newFreeQuantity);
        }


        private void DgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!isBatchUpdate)
                {
                    isCellEdit = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name == "Quantity"
                || dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name == "FreeQuantity"
                || dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name == "SaleRate")
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                        tb1.TextChanged += Tb1_TextChanged;
                    }
                    else if (c is MaskedTextBox)
                    {
                        MaskedTextBox tb1 = (MaskedTextBox)c;
                        tb1.GotFocus += C_GotFocus;
                        tb1.TextChanged += Tb1_TextChanged;                       
                    }
                    else if (c is ComboBox)
                    {
                        ComboBox tb1 = (ComboBox)c;
                        tb1.GotFocus += C_GotFocus;
                    }
                    else if (c is DateTimePicker)
                    {
                        DateTimePicker tb1 = (DateTimePicker)c;
                        tb1.GotFocus += C_GotFocus;
                        tb1.ValueChanged += Tb1_TextChanged;
                    }
                }
            }
        }


        private void SetSalesManCode(bool isValueChanged)
        {
            try
            {

                if (!string.IsNullOrEmpty(txtSalesManCode.Text))
                {
                    if (isValueChanged)
                    {
                        PersonRouteMaster master = applicationFacade.GetPersonRouteMasterByCode(txtSalesManCode.Text);

                        if (master != null && master.PersonRouteID > 0)
                        {
                            header.SalesManId = master.PersonRouteID;
                            lblSaleTypeCode.Text = master.PersonRouteName;

                            if (header.PurchaseSaleBookHeaderID > 0)
                            {
                                applicationFacade.InsertUpdateTempPurchaseBookHeader(header);
                            }

                            cbxSaleType.Focus();
                        }
                        else
                        {
                            lblSaleTypeCode.Text = "**No Such Code**";
                            txtSalesManCode.Focus();
                        }
                    }
                    else
                    {
                        cbxSaleType.Focus();
                    }
                }
                else
                {
                    PersonRouteMaster personRouteMaster = new PersonRouteMaster()
                    {
                        RecordTypeNme = Constants.RecordType.SALESMANDISPLAYNAME,
                        PersonRouteID = 0,
                        PersonRouteName = string.Empty
                    };

                    frmPersonRouteMaster frmPersonRouteMaster = new frmPersonRouteMaster();
                    frmPersonRouteMaster.IsInChildMode = true;
                    //Set Child UI
                    ExtensionMethods.AddChildFormToPanel(this, frmPersonRouteMaster, ExtensionMethods.MainPanel);
                    frmPersonRouteMaster.WindowState = FormWindowState.Maximized;
                    frmPersonRouteMaster.FormClosed += FrmPersonRouteMaster_FormClosed;
                    frmPersonRouteMaster.Show();
                    frmPersonRouteMaster.ConfigurePersonRoute(personRouteMaster);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Tb1_TextChanged(object sender, EventArgs e)
        {
            isDirty = true;
        }

        private void C_GotFocus(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.DisableAllTextBoxAndComboBox(this, (Control)sender);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void EnterKeyDownForTabEvents(Control control)
        {
            try
            {
                foreach (Control c in control.Controls)
                {
                    if (c.Controls.Count > 0)
                    {
                        EnterKeyDownForTabEvents(c);
                    }
                    else
                    {
                        c.KeyDown -= C_KeyDown;
                        c.KeyDown += C_KeyDown;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void C_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Left)
                {
                    SendKeys.Send("+{TAB}");
                    return;
                }
                else
                {
                    if (sender is TextBox)
                    {
                        TextBox txt = (TextBox)sender;

                        if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                        {
                            if (txt.Name == "txtSalesManCode")
                            {
                                SetSalesManCode(isDirty);
                            }
                            else if (!string.IsNullOrEmpty(txt.Text))
                            {
                                if (txt.Name == "txtCustomerCode")
                                {
                                    SetCustomerCodeFields(txtCustomerCode.Text);
                                }

                                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                            }
                            else
                            {
                                if (txt.Name == "txtCustomerCode")
                                {
                                    frmCustomerLedgerMaster ledger = new frmCustomerLedgerMaster();
                                    ledger.IsInChildMode = true;
                                    //Set Child UI

                                    ExtensionMethods.AddChildFormToPanel(this, ledger, ExtensionMethods.MainPanel);
                                    ledger.WindowState = FormWindowState.Maximized;

                                    ledger.FormClosed += CustomerLedger_Closed;
                                    ledger.Show();

                                }
                                if (txt.Name == "txtInvoiceNumber")
                                {
                                    txtSalesManCode.Focus();
                                }
                                if (txt.Name == "txtSalesManCode")
                                {
                                    txtSalesManCode.Focus();
                                }
                            }
                        }
                        else
                        {
                            e.SuppressKeyPress = true;
                        }
                    }
                    else if (sender is MaskedTextBox)
                    {
                        MaskedTextBox txt = (MaskedTextBox)sender;

                        if (txt.Name == "dtSaleDate")
                        {
                            MaskedTextBox dtPicker = (MaskedTextBox)sender;

                            if (!ExtensionMethods.IsValidDate(dtSaleDate.Text))
                            {
                                errFrmSaleEntry.SetError(dtSaleDate, Constants.Messages.InValidDate);
                                dtSaleDate.Focus();
                            }
                            else
                            {
                                errFrmSaleEntry.SetError(dtSaleDate, String.Empty);
                                DateTime dt = new DateTime();
                                dt = ExtensionMethods.ConvertToSystemDateFormat(dtPicker.Text);
                                if (dt > DateTime.Today || dt < DateTime.Today)
                                {
                                    DialogResult result = MessageBox.Show(string.Format("Date is {0} today.", dt > DateTime.Today ? "ahead of" : "less than"));

                                    if (result == DialogResult.No)
                                    {
                                        dtPicker.Text = ExtensionMethods.ConvertToAppDateFormat(DateTime.Now);
                                    }
                                    else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                                    {
                                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                                    }
                                }
                                else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                                {
                                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                                }
                            }
                        }
                    }
                    else if (sender is ComboBox)
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            if (header.PurchaseSaleBookHeaderID > 0)
                            {
                                ComboBox cb1 = (ComboBox)sender;

                                if (cb1.Name == "cbxSaleType")
                                {
                                    PharmaBusinessObjects.Transaction.PurchaseType type = (PharmaBusinessObjects.Transaction.PurchaseType)cbxSaleType.SelectedItem;
                                    if (type != null && type.PurchaseTypeName.ToLower() == "local")
                                    {
                                        AddRowToGrid();
                                    }
                                    else
                                    {
                                        cbxSaleFormType.Focus();
                                    }
                                }
                                else if (cb1.Name == "cbxSaleFormType")
                                {
                                    PharmaBusinessObjects.Transaction.PurchaseType type = (PharmaBusinessObjects.Transaction.PurchaseType)cbxSaleType.SelectedItem;

                                    if (type != null && type.PurchaseTypeName.ToLower() == "central")
                                    {
                                        AddRowToGrid();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmPersonRouteMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);

                PersonRouteMaster lastSelectedPersonRoute = (sender as frmPersonRouteMaster).LastSelectedPersonRoute;

                if (lastSelectedPersonRoute != null)
                {
                    if (lastSelectedPersonRoute.PersonRouteID > 0)
                    {
                        switch (lastSelectedPersonRoute.RecordTypeNme)
                        {

                            case Constants.RecordType.SALESMANDISPLAYNAME:
                                {
                                    txtSalesManCode.Text = lastSelectedPersonRoute.PersonRouteCode;
                                    SetSalesManCode(true);
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

        private void CustomerLedger_Closed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
                TextBox tb = null;

                frmCustomerLedgerMaster ledger = (frmCustomerLedgerMaster)sender;

                if (ledger.LastSelectedCustomerLedger != null)
                {
                    string custCode = ledger.LastSelectedCustomerLedger.CustomerLedgerCode;
                    List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding> listInvoices = new List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding>();
                    if (!string.IsNullOrEmpty(dtSaleDate.Text))
                    {
                        if (IsModify && VoucherTypeCode == Constants.VoucherTypeCode.SALEENTRY)
                        {
                            listInvoices = applicationFacade.GetAllSaleInvoiceForCustomer(custCode, dtSaleDate.Text);

                            if (listInvoices.Count > 0)
                            {
                                SetCustomerCodeFields(custCode);
                                Sale_Entry.frmAllBillForCustomer frm = new Sale_Entry.frmAllBillForCustomer(listInvoices);
                                frm.FormClosed += FrmAllBillForCustomer_FormClosed;
                                frm.ShowDialog();

                                if (dgvLineItem.Rows.Count > 0)
                                {
                                    dgvLineItem.ClearSelection();
                                    dgvLineItem.Focus();
                                    dgvLineItem.Rows[0].Selected = true;
                                    dgvLineItem.CurrentCell = dgvLineItem.Rows[0].Cells["ItemCode"];
                                    dgvLineItem.CurrentCell.Selected = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("No invoice for modification !!");
                                tb = txtCustomerCode;
                            }
                        }
                        else if ((VoucherTypeCode == Constants.VoucherTypeCode.SALEENTRY && !IsModify) || (VoucherTypeCode == Constants.VoucherTypeCode.SALEONCHALLAN && IsModify))
                        {
                            listInvoices = applicationFacade.GetSaleChallanForCustomer(custCode, dtSaleDate.Text);

                            if (listInvoices.Count > 0)
                            {
                                SetCustomerCodeFields(custCode);
                                Sale_Entry.frmAllBillForCustomer frm = new Sale_Entry.frmAllBillForCustomer(listInvoices);
                                frm.FormClosed += FrmAllBillForCustomer_FormClosed;
                                frm.ShowDialog();

                                if (dgvLineItem.Rows.Count > 0)
                                {
                                    int rowIndex = IsModify ? 0 : dgvLineItem.Rows.Count - 1;
                                    dgvLineItem.ClearSelection();
                                    dgvLineItem.Focus();
                                    dgvLineItem.Rows[rowIndex].Selected = true;
                                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["ItemCode"];
                                    dgvLineItem.CurrentCell.Selected = true;
                                }
                            }
                            else {
                                if (VoucherTypeCode == Constants.VoucherTypeCode.SALEENTRY)
                                {
                                    SetCustomerCodeFields(custCode);
                                    tb = txtSalesManCode;
                                }
                                else {
                                    MessageBox.Show("No invoice for modification !!");
                                    tb = txtCustomerCode;
                                }
                            }
                        }
                        else
                        {
                            SetCustomerCodeFields(custCode);
                            tb = txtSalesManCode;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter invoice date");
                        tb = txtCustomerCode;
                    }
                    
                
                }
                else
                {
                    tb = txtCustomerCode;
                }

                if (tb != null)
                {
                    tb.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmAllBillForCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Sale_Entry.frmAllBillForCustomer frm = (Sale_Entry.frmAllBillForCustomer)sender;

                long PurchaseSaleBookHeaderID = frm.PurchaseSaleBookHeaderID;

                if (IsModify && (VoucherTypeCode == Constants.VoucherTypeCode.SALEENTRY || VoucherTypeCode == Constants.VoucherTypeCode.SALEONCHALLAN))
                {
                    txtInvoiceNumber.Text = frm.InvoiceNumber;

                    header = applicationFacade.GetPurchaseSaleBookHeaderForModify(PurchaseSaleBookHeaderID);

                    if (header != null)
                    {

                        txtInvoiceNumber.Text = header.PurchaseBillNo;
                        string localCentral = header.LocalCentral == "L" ? "Local" : "Central";

                        int id = applicationFacade.GetPurchaseEntryTypes().Where(p => p.PurchaseTypeName.ToLower().Equals(localCentral.ToLower())).FirstOrDefault().ID;

                        cbxSaleType.SelectedValue = id;
                        purchaseSaleBookHeaderID = header.PurchaseSaleBookHeaderID;
                        oldPurchaseSaleBookHeaderID = header.OldPurchaseSaleBookHeaderID;



                        if (header.LocalCentral == "C")
                        {
                            cbxSaleFormType.DataSource = applicationFacade.GetPurchaseFormTypes(id);
                            cbxSaleFormType.DisplayMember = "FormTypeName";
                            cbxSaleFormType.ValueMember = "ID";

                            cbxSaleFormType.Visible = true;
                            cbxSaleFormType.SelectedValue = header.PurchaseEntryFormID;
                        }

                        List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> lineitems = applicationFacade.GetPurchaseSaleBookLineItemForModify(header.PurchaseSaleBookHeaderID).OrderBy(p => p.PurchaseSaleBookLineItemID).ToList();

                        InsertUpdateLineItemAndsetToGridForModify(lineitems);

                    }
                }
                else if (!IsModify && VoucherTypeCode == Constants.VoucherTypeCode.SALEENTRY)
                {
                    SaveSaleBookHeader(0, PurchaseSaleBookHeaderID);

                    if (dgvLineItem.Rows.Count == 0)
                    {
                        List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> lineitems = applicationFacade.GetSaleChallanLineItems(PurchaseSaleBookHeaderID, header.PurchaseSaleBookHeaderID).OrderBy(p => p.PurchaseSaleBookLineItemID).ToList();
                        InsertUpdateLineItemAndsetToGridForModify(lineitems);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetCustomerCodeFields(string code)
        {

            PharmaBusinessObjects.Master.CustomerLedgerMaster customer = applicationFacade.GetCustomerLedgerByCode(code);

            if (customer == null)
            {
                lblCustomerName.Text = "**No Such Code**";
                txtCustomerCode.Focus();
            }
            else
            {
                lblFRate.Visible = true;
                lblDueBillAmount.Visible = true;
                lblDueBills.Visible = true;

                lblCustomerName.Text = customer.CustomerLedgerName;
                txtCustomerCode.Text = customer.CustomerLedgerCode;
                lblSaleManName.Text = customer.SalesmanName;
                txtSalesManCode.Text = customer.SalesManCode.ToString();
                lblFRate.Text = customer.RateTypeName;
                lblDueBills.Text = customer.DueBillCount.ToString();
                lblDueBillAmount.Text = (customer.DueBillAmount ?? 0).ToString("#.##");

                SaveSaleBookHeader(customer.CustomerTypeID, null);
            }
        }

        private void SaveSaleBookHeader(int customerTypeID = 0,long? saleChallanHeaderID = null)
        {

            DateTime date;
            date = ExtensionMethods.ConvertToSystemDateFormat(dtSaleDate.Text);

            if (date == DateTime.MinValue)
            {
                header.DueDate = null;
            }
            else
            {
                header.DueDate = date;
            }

            header.CustomerTypeId = customerTypeID == 0 ? header.CustomerTypeId : customerTypeID;
            header.VoucherDate = header.DueDate ?? DateTime.Now;
            header.LedgerTypeCode = txtCustomerCode.Text;
            header.LedgerType = Constants.LedgerType.CustomerLedger;
            header.VoucherTypeCode = this.VoucherTypeCode;
            header.SaleChallanHeaderID = saleChallanHeaderID == null ? header.SaleChallanHeaderID : saleChallanHeaderID;

            PharmaBusinessObjects.Transaction.PurchaseType type = (PharmaBusinessObjects.Transaction.PurchaseType)cbxSaleType.SelectedItem;
            header.LocalCentral = (type != null && type.PurchaseTypeName.ToLower() == "central") ? "C" : "L";

            int saleFormTypeId = 0;
            Int32.TryParse(Convert.ToString(cbxSaleFormType.SelectedValue), out saleFormTypeId);
            header.PurchaseEntryFormID = saleFormTypeId;

            if (!IsModify)
            {
                header.PurchaseSaleBookHeaderID = applicationFacade.InsertUpdateTempPurchaseBookHeader(header);
            }
        }

        private void frmSaleEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLineItem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int rowIndex = dgvLineItem.CurrentCell.RowIndex;
                int columnIndex = dgvLineItem.CurrentCell.ColumnIndex;

                if (e.KeyData == Keys.Enter || e.KeyData == Keys.Right)
                {
                    e.Handled = true;
                    oldFreeQuantity = 0; oldQuantity = 0;

                    if(dgvLineItem.Rows[rowIndex].Cells["Quantity"].Value != null)
                        decimal.TryParse(dgvLineItem.Rows[rowIndex].Cells["Quantity"].Value.ToString(), out oldQuantity);

                    if (dgvLineItem.Rows[rowIndex].Cells["FreeQuantity"].Value != null)
                        decimal.TryParse(dgvLineItem.Rows[rowIndex].Cells["FreeQuantity"].Value.ToString(), out oldFreeQuantity);
                    this.BeginInvoke(new MethodInvoker(() =>
                    {
                        OpenDialogAndMoveToNextControl(rowIndex, columnIndex, false);
                    }));


                }
                else if (e.KeyData == Keys.Delete || e.KeyData == Keys.Escape)
                {
                    DeleteLineItem(rowIndex);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DeleteLineItem(int rowIndex)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    int headerID = 0;
                    int lineItemID = 0;

                    Int32.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleBookLineItemID"].Value), out lineItemID);
                    Int32.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleBookHeaderID"].Value), out headerID);
                    List<PurchaseSaleBookLineItem> allLineItemList = applicationFacade.DeleteSaleLineItem(headerID, lineItemID);

                    List<PurchaseSaleBookLineItem> lineItemList = allLineItemList.Where(p => p.PurchaseSaleBookLineItemID > 0).ToList();
                    PurchaseSaleBookLineItem totalLineItem = allLineItemList.FirstOrDefault(p => p.PurchaseSaleBookLineItemID == 0 && p.PurchaseSaleBookHeaderID > 0);

                    if (lineItemList.Count > 0)
                    {
                        foreach (PurchaseSaleBookLineItem item in lineItemList)
                        {
                            DataGridViewRow rowToBeDeleted = dgvLineItem.Rows.Cast<DataGridViewRow>().Where(p => Convert.ToString(p.Cells["PurchaseSaleBookLineItemID"].Value) == item.PurchaseSaleBookLineItemID.ToString()).FirstOrDefault();
                            dgvLineItem.Rows.Remove(rowToBeDeleted);
                        }

                        if (dgvLineItem.Rows.Count == 0)
                        {
                            dgvLineItem.Rows.Add();
                            dgvLineItem.CurrentCell = dgvLineItem.Rows[0].Cells["ItemCode"];
                            dgvLineItem.Focus();
                        }
                        else
                        {
                            dgvLineItem.CurrentCell = dgvLineItem.Rows[dgvLineItem.RowCount - 1].Cells["ItemCode"];
                        }

                        SetNetAmount(totalLineItem);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenSaleRateDialog(PurchaseSaleBookLineItem item, int rowIndex)
        {
            frmItemDiscount discount = new frmItemDiscount(item, txtCustomerCode.Text);
            discount.RowIndex = rowIndex;
            discount.FormClosed += Discount_FormClosed;
            discount.Show();
        }

        //private void OpenDialogAndMoveToNextControl(int rowIndex, int columnIndex, bool isDiscountFormClosed = false)
        //{
        //    int colIndex = columnIndex + 1;

        //    if (colIndex <= 7)
        //    {
        //        dgvLineItem.Rows[rowIndex].Selected = true;
        //        dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells[colIndex];
        //    }
        //    else
        //    {
        //        if (rowIndex == dgvLineItem.Rows.Count - 1)
        //        {
        //            dgvLineItem.Rows.Add();
        //            dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex + 1].Cells["ItemCode"];
        //        }
        //        else
        //        {
        //            dgvLineItem.Rows[rowIndex + 1].Selected = true;
        //            dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex + 1].Cells["ItemCode"];
        //        }
        //    }
        //}

        private void Discount_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmItemDiscount discountForm = sender as frmItemDiscount;
            int rowIndex = discountForm.RowIndex;

            InsertUpdateLineItemAndsetToGrid(discountForm.SaleLinetem, rowIndex);

            if (rowIndex == dgvLineItem.Rows.Count - 1)
            {
                dgvLineItem.Rows.Add();
                dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex + 1].Cells["ItemCode"];
            }
            else
            {
                dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex + 1].Cells["ItemCode"];
            }
            //else if (rowIndex < dgvLineItem.Rows.Count - 1)
            //{
            //    dgvLineItem.Rows[rowIndex + 1].Selected = true;
            //    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex + 1].Cells["ItemCode"];
            //}
        }

        private void ItemMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmItemMaster itemMaster = (frmItemMaster)sender;
                int rowIndex = -1;
                ;

                if (dgvLineItem.SelectedCells.Count > 0 && header.PurchaseSaleBookHeaderID > 0)
                {
                    rowIndex = itemMaster.RowIndex;

                    if (itemMaster.LastSelectedItemMaster != null)
                    {
                        isBatchUpdate = true;
                        int lineItemID = 0;
                        Int32.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleBookLineItemID"].Value), out lineItemID);

                        PurchaseSaleBookLineItem lineItem = applicationFacade.GetNewSaleLineItem(itemMaster.LastSelectedItemMaster.ItemCode, txtCustomerCode.Text);

                        lineItem.PurchaseSaleBookHeaderID = header.PurchaseSaleBookHeaderID;
                        lineItem.PurchaseSaleBookLineItemID = lineItemID;

                        DateTime saleDate = new DateTime();
                        saleDate = ExtensionMethods.ConvertToSystemDateFormat(dtSaleDate.Text);

                        InsertUpdateLineItemAndsetToGrid(lineItem, rowIndex);
                        SetFooterInfo(lineItem.ItemCode, lineItem.FifoID ?? 0);
                    }

                    isBatchUpdate = false;
                }

                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
                dgvLineItem.Focus();

                if (!string.IsNullOrEmpty(Convert.ToString(dgvLineItem.CurrentRow.Cells["ItemCode"].Value)))
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(dgvLineItem.CurrentRow.Cells["Batch"].Value)))
                        dgvLineItem.CurrentCell = dgvLineItem.CurrentRow.Cells["Quantity"];
                    else
                        dgvLineItem.CurrentCell = dgvLineItem.CurrentRow.Cells["Batch"];
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void InsertUpdateLineItemAndsetToGridForModify(List<PurchaseSaleBookLineItem> lineItemList) //,int srno, bool setSrNo = false)
        {
            if (lineItemList != null && lineItemList.Count > 0)
            {
                for (int i = 0; i < lineItemList.Count; i++)
                {
                    dgvLineItem.Rows.Add();

                    dgvLineItem.Rows[i].Cells["PurchaseSaleBookLineItemID"].Value = lineItemList[i].PurchaseSaleBookLineItemID;
                    dgvLineItem.Rows[i].Cells["PurchaseSaleBookHeaderID"].Value = header.PurchaseSaleBookHeaderID;
                    dgvLineItem.Rows[i].Cells["ItemCode"].Value = lineItemList[i].ItemCode;
                    dgvLineItem.Rows[i].Cells["ItemName"].Value = lineItemList[i].ItemName;
                    dgvLineItem.Rows[i].Cells["Quantity"].Value = lineItemList[i].Quantity;
                    dgvLineItem.Rows[i].Cells["FreeQuantity"].Value = lineItemList[i].FreeQuantity;
                    dgvLineItem.Rows[i].Cells["Batch"].Value = lineItemList[i].Batch;
                    dgvLineItem.Rows[i].Cells["PurchaseSaleRate"].Value = lineItemList[i].PurchaseSaleRate;
                    dgvLineItem.Rows[i].Cells["SaleRate"].Value = lineItemList[i].SaleRate;
                    //dgvLineItem.Rows[i].Cells["OldPurchaseSaleRate"].Value = lineItemList[i].OldPurchaseSaleRate;
                    dgvLineItem.Rows[i].Cells["Amount"].Value = GetLineItemAmount(Convert.ToString(lineItemList[i].Quantity), Convert.ToString(lineItemList[i].SaleRate));
                    dgvLineItem.Rows[i].Cells["Scheme1"].Value = lineItemList[i].Scheme1;
                    dgvLineItem.Rows[i].Cells["Scheme2"].Value = lineItemList[i].Scheme2;
                    dgvLineItem.Rows[i].Cells["IsHalfScheme"].Value = lineItemList[i].IsHalfScheme;
                    dgvLineItem.Rows[i].Cells["Discount"].Value = lineItemList[i].Discount;
                    dgvLineItem.Rows[i].Cells["SpecialDiscount"].Value = lineItemList[i].SpecialDiscount;
                    dgvLineItem.Rows[i].Cells["VolumeDiscount"].Value = lineItemList[i].VolumeDiscount;
                    dgvLineItem.Rows[i].Cells["MRP"].Value = lineItemList[i].MRP;
                    dgvLineItem.Rows[i].Cells["ExpiryDate"].Value = lineItemList[i].ExpiryDate;

                    dgvLineItem.Rows[i].Cells["SpecialRate"].Value = lineItemList[i].SpecialRate;
                    dgvLineItem.Rows[i].Cells["WholeSaleRate"].Value = lineItemList[i].WholeSaleRate;
                    dgvLineItem.Rows[i].Cells["PurchaseSaleTypeCode"].Value = lineItemList[i].PurchaseSaleTypeCode;
                    dgvLineItem.Rows[i].Cells["PurchaseBillDate"].Value = lineItemList[i].PurchaseBillDate;
                    dgvLineItem.Rows[i].Cells["PurchaseVoucherNumber"].Value = lineItemList[i].PurchaseVoucherNumber;
                    dgvLineItem.Rows[i].Cells["PurchaseSrlNo"].Value = lineItemList[i].PurchaseSrlNo;
                    dgvLineItem.Rows[i].Cells["BatchNew"].Value = lineItemList[i].BatchNew;
                    dgvLineItem.Rows[i].Cells["PurchaseSaleTax"].Value = lineItemList[i].PurchaseSaleTax;
                    dgvLineItem.Rows[i].Cells["LocalCentral"].Value = lineItemList[i].LocalCentral;
                    dgvLineItem.Rows[i].Cells["DiscountQuantity"].Value = lineItemList[i].DiscountQuantity;
                    dgvLineItem.Rows[i].Cells["HalfSchemeRate"].Value = lineItemList[i].HalfSchemeRate;
                    //dgvLineItem.Rows[i].Cells["OldPurchaseSaleBookLineItemID"].Value = lineItemList[i].OldPurchaseSaleBookLineItemID;
                    dgvLineItem.Rows[i].Cells["FifoID"].Value = lineItemList[i].FifoID;
                    dgvLineItem.Rows[i].Cells["SurCharge"].Value = lineItemList[i].SurCharge;
                    dgvLineItem.Rows[i].Cells["SGST"].Value = lineItemList[i].SGST;
                    dgvLineItem.Rows[i].Cells["IGST"].Value = lineItemList[i].IGST;
                    dgvLineItem.Rows[i].Cells["CGST"].Value = lineItemList[i].CGST;
                    dgvLineItem.Rows[i].Cells["ConversionRate"].Value = lineItemList[i].ConversionRate;
                    dgvLineItem.Rows[i].Cells["LineItemGroupID"].Value = lineItemList[i].LineItemGroupID;
                }
                
            }
        }

        private void InsertUpdateLineItemAndsetToGrid(PurchaseSaleBookLineItem lineItem, int rowIndex) //,int srno, bool setSrNo = false)
        {
            int currentRowIndex = rowIndex;
            int colIndex = dgvLineItem.CurrentCell.ColumnIndex;

            if (dgvLineItem.SelectedCells.Count > 0 && !string.IsNullOrEmpty(lineItem.ItemCode))
            {
                List<PurchaseSaleBookLineItem> allLineItemList = applicationFacade.InsertUpdateTempPurchaseBookLineItemForSale(lineItem);

                var existingIDlist = dgvLineItem.Rows.OfType<DataGridViewRow>()
                                                .Select(r => new
                                                {
                                                    LineItemId = Convert.ToString(r.Cells["PurchaseSaleBookLineItemID"].Value),
                                                    RwIndex = r.Index
                                                }).ToList();

                List<PurchaseSaleBookLineItem> lineItemList = allLineItemList.Where(p => p.PurchaseSaleBookLineItemID > 0 && p.PurchaseSaleBookHeaderID > 0).OrderBy(p => p.LineItemGroupID).ThenBy(p=>p.PurchaseSaleBookLineItemID).ToList();
                PurchaseSaleBookLineItem totalLineItemDetail = allLineItemList.Where(p => p.PurchaseSaleBookLineItemID == 0).FirstOrDefault();

                isSetGrid = true;

                for (int i = 0; i < lineItemList.Count; i++)
                {
                    if (!existingIDlist.Any(p => p.LineItemId == lineItemList[i].PurchaseSaleBookLineItemID.ToString()))
                    {
                        if (dgvLineItem.Rows.Count > 0 && dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name == "ItemCode")
                        {
                            rowIndex = dgvLineItem.CurrentCell.RowIndex;
                            //currentRowIndex = rowIndex;
                            //colIndex = dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Index;
                        }
                        else
                        {
                            dgvLineItem.Rows.Add();
                            rowIndex = dgvLineItem.Rows.Count - 1;
                            //colIndex = 0;
                        }
                    }
                    else
                    {
                        rowIndex = existingIDlist.FirstOrDefault(p => p.LineItemId == lineItemList[i].PurchaseSaleBookLineItemID.ToString()).RwIndex;
                        //colIndex = dgvLineItem.SelectedCells[0].ColumnIndex;
                    }

                    dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleBookLineItemID"].Value = lineItemList[i].PurchaseSaleBookLineItemID;
                    dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleBookHeaderID"].Value = header.PurchaseSaleBookHeaderID;
                    dgvLineItem.Rows[rowIndex].Cells["ItemCode"].Value = lineItemList[i].ItemCode;
                    dgvLineItem.Rows[rowIndex].Cells["ItemName"].Value = lineItemList[i].ItemName;
                    dgvLineItem.Rows[rowIndex].Cells["Quantity"].Value = lineItemList[i].Quantity;
                    dgvLineItem.Rows[rowIndex].Cells["FreeQuantity"].Value = lineItemList[i].FreeQuantity;
                    dgvLineItem.Rows[rowIndex].Cells["Batch"].Value = lineItemList[i].Batch;
                    dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleRate"].Value = lineItemList[i].PurchaseSaleRate;
                    dgvLineItem.Rows[rowIndex].Cells["SaleRate"].Value = lineItemList[i].SaleRate;
                    //dgvLineItem.Rows[rowIndex].Cells["OldPurchaseSaleRate"].Value = lineItemList[i].OldPurchaseSaleRate;
                    dgvLineItem.Rows[rowIndex].Cells["Amount"].Value = GetLineItemAmount(Convert.ToString(lineItemList[i].Quantity), Convert.ToString(lineItemList[i].SaleRate));
                    dgvLineItem.Rows[rowIndex].Cells["Scheme1"].Value = lineItemList[i].Scheme1;
                    dgvLineItem.Rows[rowIndex].Cells["Scheme2"].Value = lineItemList[i].Scheme2;
                    dgvLineItem.Rows[rowIndex].Cells["IsHalfScheme"].Value = lineItemList[i].IsHalfScheme;
                    dgvLineItem.Rows[rowIndex].Cells["Discount"].Value = lineItemList[i].Discount;
                    dgvLineItem.Rows[rowIndex].Cells["SpecialDiscount"].Value = lineItemList[i].SpecialDiscount;
                    dgvLineItem.Rows[rowIndex].Cells["VolumeDiscount"].Value = lineItemList[i].VolumeDiscount;
                    dgvLineItem.Rows[rowIndex].Cells["MRP"].Value = lineItemList[i].MRP;
                    dgvLineItem.Rows[rowIndex].Cells["ExpiryDate"].Value = lineItemList[i].ExpiryDate;

                    dgvLineItem.Rows[rowIndex].Cells["SpecialRate"].Value = lineItemList[i].SpecialRate;
                    dgvLineItem.Rows[rowIndex].Cells["WholeSaleRate"].Value = lineItemList[i].WholeSaleRate;
                    dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleTypeCode"].Value = lineItemList[i].PurchaseSaleTypeCode;
                    dgvLineItem.Rows[rowIndex].Cells["PurchaseBillDate"].Value = lineItemList[i].PurchaseBillDate;
                    dgvLineItem.Rows[rowIndex].Cells["PurchaseVoucherNumber"].Value = lineItemList[i].PurchaseVoucherNumber;
                    dgvLineItem.Rows[rowIndex].Cells["PurchaseSrlNo"].Value = lineItemList[i].PurchaseSrlNo;
                    dgvLineItem.Rows[rowIndex].Cells["BatchNew"].Value = lineItemList[i].BatchNew;
                    dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleTax"].Value = lineItemList[i].PurchaseSaleTax;
                    dgvLineItem.Rows[rowIndex].Cells["LocalCentral"].Value = lineItemList[i].LocalCentral;
                    dgvLineItem.Rows[rowIndex].Cells["DiscountQuantity"].Value = lineItemList[i].DiscountQuantity;
                    dgvLineItem.Rows[rowIndex].Cells["HalfSchemeRate"].Value = lineItemList[i].HalfSchemeRate;
                    //dgvLineItem.Rows[rowIndex].Cells["OldPurchaseSaleBookLineItemID"].Value = lineItemList[i].OldPurchaseSaleBookLineItemID;
                    dgvLineItem.Rows[rowIndex].Cells["FifoID"].Value = lineItemList[i].FifoID;
                    dgvLineItem.Rows[rowIndex].Cells["SurCharge"].Value = lineItemList[i].SurCharge;
                    dgvLineItem.Rows[rowIndex].Cells["SGST"].Value = lineItemList[i].SGST;
                    dgvLineItem.Rows[rowIndex].Cells["IGST"].Value = lineItemList[i].IGST;
                    dgvLineItem.Rows[rowIndex].Cells["CGST"].Value = lineItemList[i].CGST;
                    dgvLineItem.Rows[rowIndex].Cells["ConversionRate"].Value = lineItemList[i].ConversionRate;
                    dgvLineItem.Rows[rowIndex].Cells["LineItemGroupID"].Value = lineItemList[i].LineItemGroupID;

                }
                isSetGrid = false;

                SetNetAmount(totalLineItemDetail);

                if (rowIndex != -1)
                {
                    //dgvLineItem.Rows[rowIndex].Selected = true;


                    if (lineItemList.Count > 1)
                    {
                        dgvLineItem.Rows[rowIndex].Selected = true;
                        dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["SaleRate"];
                    }
                    else
                    {
                        dgvLineItem.Rows[rowIndex].Selected = true;
                        dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells[colIndex];
                    }
                }
            }
            else if (string.IsNullOrEmpty(lineItem.ItemCode))
            {
                MessageBox.Show("Item not in stock");
            }


        }

        private void SetNetAmount(PurchaseSaleBookLineItem totalLineItemDetail)
        {
            if (totalLineItemDetail != null)
            {
                lblTotalSchemeAmt.Text = (totalLineItemDetail.SchemeAmount ?? 0).ToString("#.##");
                lblTotalTaxAmount.Text = (totalLineItemDetail.TaxAmount ?? 0).ToString("#.##");
                lblTotalNetAmount.Text = (totalLineItemDetail.CostAmount ?? 0).ToString("#.##");
                lblTotalDiscountAmt.Text = (totalLineItemDetail.DiscountAmount ?? 0).ToString("#.##");
                lblTotalAmount.Text = (totalLineItemDetail.GrossAmount ?? 0).ToString("#.##");

            }
        }

        private decimal GetLineItemAmount(string qty, string srate)
        {
            decimal dQty = 0;
            decimal.TryParse(qty, out dQty);

            decimal dSaleRate = 0;
            decimal.TryParse(srate, out dSaleRate);

            return dQty * dSaleRate;

        }

        private PurchaseSaleBookLineItem ConvertToPurchaseBookLineItem(DataGridViewRow row)
        {
            PurchaseSaleBookLineItem item = new PurchaseSaleBookLineItem();
            int id = 0;
            decimal dValue = 0L;
            DateTime dDate = new DateTime();

            if (row != null)
            {
                Int32.TryParse(Convert.ToString(row.Cells["PurchaseSaleBookLineItemID"].Value), out id);
                item.PurchaseSaleBookLineItemID = id;

                Int32.TryParse(Convert.ToString(row.Cells["PurchaseSaleBookHeaderID"].Value), out id);
                item.PurchaseSaleBookHeaderID = header.PurchaseSaleBookHeaderID;

                item.ItemCode = Convert.ToString(row.Cells["ItemCode"].Value);
                item.ItemName = Convert.ToString(row.Cells["ItemName"].Value);
                item.Batch = Convert.ToString(row.Cells["Batch"].Value);

                decimal.TryParse(Convert.ToString(row.Cells["Quantity"].Value), out dValue);
                item.Quantity = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["FreeQuantity"].Value), out dValue);
                item.FreeQuantity = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["SaleRate"].Value), out dValue);
                item.SaleRate = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["Amount"].Value), out dValue);
                item.Amount = (item.Quantity * item.SaleRate) ?? 0;

                Int32.TryParse(Convert.ToString(row.Cells["Scheme1"].Value), out id);
                item.Scheme1 = id;

                Int32.TryParse(Convert.ToString(row.Cells["Scheme2"].Value), out id);
                item.Scheme2 = id;

                item.IsHalfScheme = Convert.ToBoolean(row.Cells["IsHalfScheme"].Value);

                decimal.TryParse(Convert.ToString(row.Cells["Discount"].Value), out dValue);
                item.Discount = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["SpecialDiscount"].Value), out dValue);
                item.SpecialDiscount = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["PurchaseSaleRate"].Value), out dValue);
                item.PurchaseSaleRate = dValue;

                int.TryParse(Convert.ToString(row.Cells["FifoID"].Value), out id);
                item.FifoID = id;

                decimal.TryParse(Convert.ToString(row.Cells["BalanceQuantity"].Value), out dValue);
                item.BalanceQuantity = dValue;

                item.BatchNew = Convert.ToString(row.Cells["BatchNew"].Value);

                decimal.TryParse(Convert.ToString(row.Cells["CGST"].Value), out dValue);
                item.CGST = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["ConversionRate"].Value), out dValue);
                item.ConversionRate = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["CostAmount"].Value), out dValue);
                item.CostAmount = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["Discount"].Value), out dValue);
                item.Discount = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["DiscountQuantity"].Value), out dValue);
                item.DiscountQuantity = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["EffecivePurchaseSaleRate"].Value), out dValue);
                item.EffecivePurchaseSaleRate = dValue;

                DateTime.TryParse(Convert.ToString(row.Cells["ExpiryDate"].Value), out dDate);
                if (dDate == DateTime.MinValue)
                    item.ExpiryDate = null;
                else
                    item.ExpiryDate = dDate;

                Int32.TryParse(Convert.ToString(row.Cells["FifoID"].Value), out id);
                item.FifoID = id;

                decimal.TryParse(Convert.ToString(row.Cells["HalfSchemeRate"].Value), out dValue);
                item.HalfSchemeRate = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["IGST"].Value), out dValue);
                item.IGST = dValue;

                item.LocalCentral = Convert.ToString(row.Cells["LocalCentral"].Value);

                decimal.TryParse(Convert.ToString(row.Cells["MRP"].Value), out dValue);
                item.MRP = dValue;

                DateTime.TryParse(Convert.ToString(row.Cells["PurchaseBillDate"].Value), out dDate);
                if (dDate == DateTime.MinValue)
                    item.PurchaseBillDate = null;
                else
                    item.PurchaseBillDate = dDate;

                decimal.TryParse(Convert.ToString(row.Cells["PurchaseSaleRate"].Value), out dValue);
                item.PurchaseSaleRate = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["PurchaseSaleTax"].Value), out dValue);
                item.PurchaseSaleTax = dValue;

                item.PurchaseSaleTypeCode = Convert.ToString(row.Cells["PurchaseSaleTypeCode"].Value);

                Int32.TryParse(Convert.ToString(row.Cells["PurchaseSrlNo"].Value), out id);
                item.PurchaseSrlNo = id;

                item.PurchaseVoucherNumber = Convert.ToString(row.Cells["PurchaseVoucherNumber"].Value);

                decimal.TryParse(Convert.ToString(row.Cells["SGST"].Value), out dValue);
                item.SGST = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["SpecialRate"].Value), out dValue);
                item.SpecialRate = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["SurCharge"].Value), out dValue);
                item.SurCharge = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["VolumeDiscount"].Value), out dValue);
                item.VolumeDiscount = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["WholeSaleRate"].Value), out dValue);
                item.WholeSaleRate = dValue;

                Int32.TryParse(Convert.ToString(row.Cells["LineItemGroupID"].Value), out id);
                item.LineItemGroupID = id;

            }

            return item;
        }

        private void AddRowToGrid(string columnName = "")
        {
            int rowIndex = 0;
            columnName = string.IsNullOrEmpty(columnName) ? "ItemCode" : columnName;

            if (dgvLineItem.Rows.Count > 0)
            {
                rowIndex = dgvLineItem.CurrentCell.RowIndex;
            }
            dgvLineItem.Focus();
            dgvLineItem.Rows.Add();
            dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells[columnName];
        }

        private void SetFooterInfo(string code, long fifoID)
        {
            if (!string.IsNullOrEmpty(code))
            {
                SaleLineItemInfo info = applicationFacade.GetSaleLineItemInfo(code, fifoID);
                lblBalance.Text = info.Balance.ToString("#.##");
                lblPacking.Text = info.Packing;
                lblSaleTypeCode.Text = info.SaleType;
                lblCaseQuantity.Text = info.CaseQty.ToString("#.##");
                lblIsHalf.Text = info.IsHalf ? "Y" : "N";
                lblDiscount.Text = dgvLineItem.SelectedCells.Count > 0 ? Convert.ToString(dgvLineItem.Rows[dgvLineItem.SelectedCells[0].RowIndex].Cells["Discount"].Value) : "0";
                lblSurharge.Text = info.Surcharge.ToString("#.##");
                lblTaxRate.Text = dgvLineItem.SelectedCells.Count > 0 ? Convert.ToString(dgvLineItem.Rows[dgvLineItem.SelectedCells[0].RowIndex].Cells["PurchaseSaleTax"].Value) : "0";//info.TaxAmount.ToString("#.##");
                lblScheme.Text = string.Concat(dgvLineItem.SelectedCells.Count > 0 ? Convert.ToString(dgvLineItem.Rows[dgvLineItem.SelectedCells[0].RowIndex].Cells["Scheme1"].Value) : "0", "+", dgvLineItem.SelectedCells.Count > 0 ? Convert.ToString(dgvLineItem.Rows[dgvLineItem.SelectedCells[0].RowIndex].Cells["Scheme2"].Value) : "0");

                if (info.LastBillInfo != null && info.LastBillInfo.BillDate != DateTime.MinValue)
                {
                    tableLayoutPanel3.Height = layoutHeight;
                    tableLayoutPanel3.Width = layoutWidth;

                    lblLBBatch.Text = info.LastBillInfo.Batch;
                    lblLBRate.Text = info.LastBillInfo.Rate.ToString("#.##");
                    lblLBScheme.Text = string.Concat(info.LastBillInfo.Scheme1.ToString("#.##"), "+", info.LastBillInfo.Scheme2.ToString("#.##"));
                    lblLBSpLDis.Text = info.LastBillInfo.SpecialDiscount.ToString("#.##");
                    lblLBTax.Text = info.LastBillInfo.Tax.ToString("#.##");
                    lblLBDis.Text = info.LastBillInfo.Discount.ToString("#.##");
                    lblLBDate.Text = info.LastBillInfo.BillDate == DateTime.MinValue ? string.Empty : info.LastBillInfo.BillDate.ToString("dd/mm/yyyy");
                }
            }
            else
            {
                lblBalance.Text = string.Empty;
                lblPacking.Text = string.Empty;
                lblSaleTypeCode.Text = string.Empty;
                lblCaseQuantity.Text = string.Empty;
                lblIsHalf.Text = string.Empty;
                lblDiscount.Text = string.Empty;
                lblSurharge.Text = string.Empty;
                lblTaxRate.Text = string.Empty;//info.TaxAmount.ToString("#.##");
                lblScheme.Text = string.Empty;

                tableLayoutPanel3.Height = 0;
                tableLayoutPanel3.Width = 0;
            }

        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == Keys.End)
                {
                    if (header != null && header.PurchaseSaleBookHeaderID > 0 && dgvLineItem.Rows.Count > 0)
                    {
                        var result = MessageBox.Show("Are you sure you want to save the sale entry", "Confirmation", MessageBoxButtons.OKCancel);
                        if (result == DialogResult.OK)
                        {
                            long purchaseHeaderId =  applicationFacade.SaveSaleEntryData(header.PurchaseSaleBookHeaderID);

                            result = MessageBox.Show("Are you sure you want to print the invoice", "Confirmation", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                            {
                                Cursor.Current = Cursors.WaitCursor;

                                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                                appPath = appPath.Replace(@"bin\Debug", string.Empty);

                                string reportPath = Path.Combine(appPath, "Reports");
                                string reportName = "GSTInvoice.rdlc";

                                LocalReport report = new LocalReport();
                                report.ReportPath = Path.Combine(reportPath, reportName);
                                //report.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SaleInvoice", applicationFacade.GetSaleInvoiceData(2)));

                                //this.reportViewer1.
                                DataTable saleInvoice = applicationFacade.GetSaleInvoiceData(purchaseHeaderId);
                                //DataTable firmProperties = applicationFacade.GetFirmProperties(2);

                                ReportDataSource dtSaleInvoice = new ReportDataSource();
                                dtSaleInvoice.Name = "GSTInvoiceResult";
                                dtSaleInvoice.Value = saleInvoice;

                                report.DataSources.Add(dtSaleInvoice);
                                Export(report);
                                Print();

                                Cursor.Current = Cursors.Default;

                                this.Close();
                               
                            }
                            else
                            {
                                this.Close();
                            }
                        }
                    }

                }
                else if (keyData == Keys.F5)
                {
                    frmSaleEntry form = new frmSaleEntry(false, this.VoucherTypeCode);
                    ExtensionMethods.AddTrasanctionFormToPanel(form, ExtensionMethods.MainPanel);
                    form.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
    
        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.27in</PageWidth>
                <PageHeight>11.69in</PageHeight>
                <MarginTop>0</MarginTop>
                <MarginLeft>0</MarginLeft>
                <MarginRight>0</MarginRight>
                <MarginBottom>0</MarginBottom>
            </DeviceInfo>";

            Warning[] warnings; 
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
       

        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
           
            PrintDocument printDoc = new PrintDocument();

            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += PrintDoc_PrintPage;
                //  printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void ReportViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void frmSaleEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (header.PurchaseSaleBookHeaderID > 0)
            {
                bool result = applicationFacade.IsTempSaleEntryExists(header.PurchaseSaleBookHeaderID);

                if (result)
                {
                    DialogResult isConfirm = MessageBox.Show("There are some unsaved changes. Do you want to close the screen", "Warning", MessageBoxButtons.YesNo);

                    if (isConfirm == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        applicationFacade.RollbackSaleEntry(header.PurchaseSaleBookHeaderID);
                        ExtensionMethods.RemoveTransactionFormToPanel(this, ExtensionMethods.MainPanel);
                    }
                }
                else
                {
                    ExtensionMethods.RemoveTransactionFormToPanel(this, ExtensionMethods.MainPanel);
                }
            }
            else
            {
                ExtensionMethods.RemoveTransactionFormToPanel(this, ExtensionMethods.MainPanel);
            }
        }

        private void cbxSaleFormType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (header.PurchaseSaleBookHeaderID > 0)
                {

                    PharmaBusinessObjects.Transaction.PurchaseType type = (PharmaBusinessObjects.Transaction.PurchaseType)cbxSaleType.SelectedItem;
                    header.LocalCentral = (type != null && type.PurchaseTypeName.ToLower() == "central") ? "C" : "L";

                    int saleFormTypeId = 0;
                    Int32.TryParse(Convert.ToString(cbxSaleFormType.SelectedValue), out saleFormTypeId);
                    header.PurchaseEntryFormID = saleFormTypeId;

                    applicationFacade.InsertUpdateTempPurchaseBookHeader(header);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxSaleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int saleTypeID = 0;
            Int32.TryParse(Convert.ToString(cbxSaleType.SelectedValue), out saleTypeID);
            cbxSaleFormType.DataSource = applicationFacade.GetPurchaseFormTypes(saleTypeID);
            cbxSaleFormType.DisplayMember = "FormTypeName";
            cbxSaleFormType.ValueMember = "ID";

            PharmaBusinessObjects.Transaction.PurchaseType type = (PharmaBusinessObjects.Transaction.PurchaseType)cbxSaleType.SelectedItem;
            if (type != null && type.PurchaseTypeName.ToLower() == "central")
            {
                cbxSaleFormType.Visible = true;
            }
            else
            {
                cbxSaleFormType.Visible = false;

                header.LocalCentral = (type != null && type.PurchaseTypeName.ToLower() == "central") ? "C" : "L";

                int saleFormTypeId = 0;
                Int32.TryParse(Convert.ToString(cbxSaleFormType.SelectedValue), out saleFormTypeId);
                header.PurchaseEntryFormID = saleFormTypeId;

                if (header.PurchaseSaleBookHeaderID > 0)
                {
                    applicationFacade.InsertUpdateTempPurchaseBookHeader(header);
                }
            }

            cbxSaleType.Focus();

        }
    }
}
