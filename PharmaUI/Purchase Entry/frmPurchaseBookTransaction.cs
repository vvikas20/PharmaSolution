using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmaUI
{
    public partial class frmPurchaseBookTransaction : Form
    {
        private long purchaseSaleBookHeaderID = 0;
        private long? oldPurchaseSaleBookHeaderID = null;
        private bool isBatchUpdate = false;
        private bool isDirty = false;
        private bool isCellEdit = true;
        private bool IsModify = false;
      
        IApplicationFacade applicationFacade;
        public frmPurchaseBookTransaction(bool isModify)
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetFormProperties(this);
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
                this.IsModify = isModify; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmPurchaseBookTransaction_Load(object sender, EventArgs e)
        {
            try
            {
                string pageHeading = IsModify ? "Purchase Entry Modification" : "Purchase Entry Transaction";
                ExtensionMethods.FormLoad(this, pageHeading);
                //                ExtensionMethods.AddFooter(this);
                GotFocusEventRaised(this);
                EnterKeyDownForTabEvents(this);
                FillCombo();
                InitializeGrid();
               
                dtPurchaseDate.Text = ExtensionMethods.ConvertToAppDateFormat(DateTime.Now);
                dtPurchaseDate.Focus();
                dtPurchaseDate.Select(0, 0);

                dtPurchaseDate.LostFocus += DtPurchaseDate_LostFocus;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DtPurchaseDate_LostFocus(object sender, EventArgs e)
        {
            if (!ExtensionMethods.IsValidDate(dtPurchaseDate.Text))
            {
                errFrmPurchaseBookHeader.SetError(dtPurchaseDate, Constants.Messages.InValidDate);
                dtPurchaseDate.Focus();
            }
            else
            {
                errFrmPurchaseBookHeader.SetError(dtPurchaseDate, String.Empty);
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

            dgvLineItem.Columns.Add("Quantity", "Quantity");
            dgvLineItem.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Quantity"].FillWeight = 5;

            dgvLineItem.Columns.Add("FreeQuantity", "Free Quantity");
            dgvLineItem.Columns["FreeQuantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["FreeQuantity"].FillWeight = 5;

            dgvLineItem.Columns.Add("PurchaseSaleRate", "Rate");
            dgvLineItem.Columns["PurchaseSaleRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseSaleRate"].FillWeight = 5;

            dgvLineItem.Columns.Add("Amount", "Amount");
            dgvLineItem.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["Amount"].FillWeight = 5;

            dgvLineItem.Columns.Add("OldPurchaseSaleRate", "OldPurchaseSaleRate");
            dgvLineItem.Columns["OldPurchaseSaleRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["OldPurchaseSaleRate"].Visible = false;

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

            dgvLineItem.Columns.Add("VolumeDiscount", "VolumeDiscount");
            dgvLineItem.Columns["VolumeDiscount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["VolumeDiscount"].Visible = false;

            dgvLineItem.Columns.Add("MRP", "MRP");
            dgvLineItem.Columns["MRP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["MRP"].Visible = false;

            dgvLineItem.Columns.Add("ExpiryDate", "ExpiryDate");
            dgvLineItem.Columns["ExpiryDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["ExpiryDate"].Visible = false;

            dgvLineItem.Columns.Add("SaleRate", "SaleRate");
            dgvLineItem.Columns["SaleRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SaleRate"].Visible = false;

            dgvLineItem.Columns.Add("WholeSaleRate", "WholeSaleRate");
            dgvLineItem.Columns["WholeSaleRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["WholeSaleRate"].Visible = false;

            dgvLineItem.Columns.Add("SpecialRate", "SpecialRate");
            dgvLineItem.Columns["SpecialRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SpecialRate"].Visible = false;

            dgvLineItem.Columns.Add("PurchaseSaleTypeCode", "PurchaseSaleTypeCode");
            dgvLineItem.Columns["PurchaseSaleTypeCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseSaleTypeCode"].Visible = false;

            dgvLineItem.Columns.Add("PurchaseSaleTax", "PurchaseSaleTax");
            dgvLineItem.Columns["PurchaseSaleTax"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["PurchaseSaleTax"].Visible = false;

            dgvLineItem.Columns.Add("LocalCentral", "LocalCentral");
            dgvLineItem.Columns["LocalCentral"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["LocalCentral"].Visible = false;

            dgvLineItem.Columns.Add("ConversionRate", "ConversionRate");
            dgvLineItem.Columns["ConversionRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["ConversionRate"].Visible = false;

            dgvLineItem.Columns.Add("TotalDiscountAmount", "TotalDiscountAmount");
            dgvLineItem.Columns["TotalDiscountAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["TotalDiscountAmount"].Visible = false;

            dgvLineItem.Columns.Add("SurchargeAmount", "SurchargeAmount");
            dgvLineItem.Columns["SurchargeAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SurchargeAmount"].Visible = false;

            dgvLineItem.Columns.Add("SchemeAmount", "SchemeAmount");
            dgvLineItem.Columns["SchemeAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SchemeAmount"].Visible = false;

            dgvLineItem.Columns.Add("TaxAmount", "TaxAmount");
            dgvLineItem.Columns["TaxAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["TaxAmount"].Visible = false;

            dgvLineItem.Columns.Add("GrossAmount", "GrossAmount");
            dgvLineItem.Columns["GrossAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["GrossAmount"].Visible = false;

            dgvLineItem.Columns.Add("VolumeDiscountAmount", "VolumeDiscountAmount");
            dgvLineItem.Columns["VolumeDiscountAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["VolumeDiscountAmount"].Visible = false;

            dgvLineItem.Columns.Add("SpecialDiscountAmount", "SpecialDiscountAmount");
            dgvLineItem.Columns["SpecialDiscountAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["SpecialDiscountAmount"].Visible = false;

            dgvLineItem.Columns.Add("DiscountAmount", "DiscountAmount");
            dgvLineItem.Columns["DiscountAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["DiscountAmount"].Visible = false;

            dgvLineItem.Columns.Add("CostAmount", "CostAmount");
            dgvLineItem.Columns["CostAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["CostAmount"].Visible = false;

            dgvLineItem.Columns.Add("UsedQuantity", "UsedQuantity");
            dgvLineItem.Columns["UsedQuantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["UsedQuantity"].Visible = false;

            dgvLineItem.Columns.Add("BalanceQuantity", "BalanceQuantity");
            dgvLineItem.Columns["BalanceQuantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["BalanceQuantity"].Visible = false;

            dgvLineItem.Columns.Add("OldPurchaseSaleBookLineItemID", "OldPurchaseSaleBookLineItemID");
            dgvLineItem.Columns["OldPurchaseSaleBookLineItemID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["OldPurchaseSaleBookLineItemID"].Visible = false;

            dgvLineItem.Columns.Add("FifoID", "FifoID");
            dgvLineItem.Columns["FifoID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["FifoID"].Visible = false;


            dgvLineItem.Columns.Add("MfgDate", "MfgDate");
            dgvLineItem.Columns["MfgDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLineItem.Columns["MfgDate"].Visible = false;


            dgvLineItem.CellBeginEdit += DgvLineItem_CellBeginEdit;
            dgvLineItem.CellEndEdit += DgvLineItem_CellEndEdit;
            dgvLineItem.CellValueChanged += DgvLineItem_CellValueChanged;
            dgvLineItem.EditingControlShowing += DgvLineItem_EditingControlShowing;
            dgvLineItem.SelectionChanged += DgvLineItem_SelectionChanged;
            dgvLineItem.SelectionMode = DataGridViewSelectionMode.CellSelect;

        }

        private void DgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!isBatchUpdate)
            {
                isCellEdit = true;
            }
        }

        private void DgvLineItem_SelectionChanged(object sender, EventArgs e)
        {
            SetLables();
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

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name == "Quantity"
                || dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name == "FreeQuantity"
                || dgvLineItem.Columns[dgvLineItem.CurrentCell.ColumnIndex].Name == "PurchaseSaleRate")
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
              
       

        private void DgvLineItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (isCellEdit)
                {
                    int rowIndex = e.RowIndex;
                    int columnIndex = e.ColumnIndex;

                    this.BeginInvoke(new MethodInvoker(() =>
                    {
                        OpenDialogAndMoveToNextControl(columnIndex, rowIndex);
                    }));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void OpenSchemeDialog(PurchaseSaleBookLineItem lineItem,int rowIndex)
        {
            PharmaUI.Purchase_Entry.frmLineItemScheme updateForm = new PharmaUI.Purchase_Entry.frmLineItemScheme(lineItem);
            updateForm.RowIndex = rowIndex;
            updateForm.FormClosed += frmLineItemScheme_FormClosed;
            updateForm.ShowDialog();
        }

        private void DgvLineItem_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                isCellEdit = false;

                if (purchaseSaleBookHeaderID == 0)
                {
                    MessageBox.Show("Please enter invoice number before adding the items");
                    dgvLineItem.CancelEdit();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Batch_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmLastNBatchNo batch = (frmLastNBatchNo)sender;

                int rowIndex = -1;
                if (dgvLineItem.SelectedCells.Count > 0)
                {
                    isBatchUpdate = true;
                    rowIndex = batch.RowIndex;
                  
                    PurchaseSaleBookLineItem item = batch.PurchaseBookLineItem;
                    // dgvLineItem.CurrentRow.Cells[dgvLineItem.CurrentRow.Cells["Batch"].ColumnIndex].Value = batch.BatchNumber;
                    InsertUpdateLineItemAndsetToGrid(item,rowIndex);

                }

                isBatchUpdate = false;

                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
                dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["Quantity"];


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void FillCombo()
        {

            cbxPurchaseType.DataSource = applicationFacade.GetPurchaseEntryTypes();
            cbxPurchaseType.DisplayMember = "PurchaseTypeName";
            cbxPurchaseType.ValueMember = "ID";
            cbxPurchaseType.SelectedIndexChanged += cbxPurchaseType_SelectedIndexChanged;
            cbxPurchaseType.SelectedIndex = 0;
        }

        private void cbxPurchaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int purchaseTypeID = 0;
                Int32.TryParse(Convert.ToString(cbxPurchaseType.SelectedValue), out purchaseTypeID);
                cbxPurchaseFormType.DataSource = applicationFacade.GetPurchaseFormTypes(purchaseTypeID);
                cbxPurchaseFormType.DisplayMember = "FormTypeName";
                cbxPurchaseFormType.ValueMember = "ID";

                PharmaBusinessObjects.Transaction.PurchaseType type = (PharmaBusinessObjects.Transaction.PurchaseType)cbxPurchaseType.SelectedItem;
                if (type != null && type.PurchaseTypeName.ToLower() == "central")
                {
                    cbxPurchaseFormType.Visible = true;
                }
                else
                {
                    cbxPurchaseFormType.Visible = false;
                }

                cbxPurchaseType.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void cbxPurchaseFormType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (purchaseSaleBookHeaderID > 0)
                {
                    PurchaseSaleBookHeader header = new PurchaseSaleBookHeader();
                    bool result = GetPurchaseBookHeader(ref header);

                    if (result)
                    {
                        applicationFacade.InsertUpdateTempPurchaseBookHeader(header);
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
                        tb1.Leave += Tb1_Leave;
                    }
                    else if (c is MaskedTextBox)
                    {
                        MaskedTextBox tb1 = (MaskedTextBox)c;
                        tb1.GotFocus += C_GotFocus;
                        tb1.TextChanged += Tb1_TextChanged;
                        tb1.Leave += Tb1_Leave;
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
                        tb1.LostFocus += Tb1_Leave;

                    }
                }
            }
        }

        private void Tb1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (isDirty)
                {
                    Control text = (Control)sender;

                    switch (text.Name)
                    {
                        case "txtInvoiceNumber":
                            {
                                PurchaseSaleBookHeader header = new PurchaseSaleBookHeader();
                                bool result = GetPurchaseBookHeader(ref header);

                                if (result && isDirty)
                                {
                                    purchaseSaleBookHeaderID = applicationFacade.InsertUpdateTempPurchaseBookHeader(header);
                                }                               
                            }

                            break;
                        case "txtSupplierCode":
                            {
                                if (isDirty && !string.IsNullOrEmpty(txtSupplierCode.Text))
                                {
                                    PharmaBusinessObjects.Master.SupplierLedgerMaster master = applicationFacade.GetSupplierLedgerByName(txtSupplierCode.Text);

                                    if (master == null)
                                    {
                                        lblSupplierName.Text = "**No Such Code**";
                                        txtSupplierCode.Focus();
                                    }
                                    else
                                    {
                                        lblSupplierName.Text = master.SupplierLedgerName;

                                        if (purchaseSaleBookHeaderID > 0)
                                        {
                                            PurchaseSaleBookHeader header = new PurchaseSaleBookHeader();
                                            bool result = GetPurchaseBookHeader(ref header);

                                            if (result)
                                            {
                                                applicationFacade.InsertUpdateTempPurchaseBookHeader(header);

                                            }
                                        }
                                    }
                                }
                            }

                            break;
                        case "dtPurchaseDate":
                            {
                                MaskedTextBox dtPicker = (MaskedTextBox)sender;
                                if (!ExtensionMethods.IsValidDate(dtPurchaseDate.Text))
                                {
                                    errFrmPurchaseBookHeader.SetError(dtPurchaseDate, Constants.Messages.InValidDate);
                                    dtPurchaseDate.Focus();
                                }
                                else
                                {
                                    errFrmPurchaseBookHeader.SetError(dtPurchaseDate, String.Empty);
                                    DateTime dt = new DateTime();
                                    dt = ExtensionMethods.ConvertToSystemDateFormat(dtPicker.Text);
                                    if (dt > DateTime.Today || dt < DateTime.Today)
                                    {
                                        DialogResult result = MessageBox.Show(string.Format("Date is {0} today.", dt > DateTime.Today ? "ahead of" : "less than"));

                                        if (result == DialogResult.No)
                                            dtPicker.Text = ExtensionMethods.ConvertToAppDateFormat(DateTime.Now);

                                    }
                                }
                            }
                            break;
                    }

                    isDirty = false;
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

        private void Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                TextBox tb;

                frmSupplierLedger ledger = (frmSupplierLedger)sender;

                if (ledger.LastSelectedSupplier != null)
                {
                    lblSupplierName.Text = ledger.LastSelectedSupplier.SupplierLedgerName;
                    txtSupplierCode.Text = ledger.LastSelectedSupplier.SupplierLedgerCode;
                    tb = txtInvoiceNumber;
                }
                else
                {
                    tb = txtSupplierCode;
                }

                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);

                if(tb != null)
                {
                    tb.Focus();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool GetPurchaseBookHeader(ref PurchaseSaleBookHeader header)
        {
            DateTime purchaseDate = new DateTime();
            purchaseDate = ExtensionMethods.ConvertToSystemDateFormat(dtPurchaseDate.Text);
            if (purchaseDate == DateTime.MinValue)
            {
                errFrmPurchaseBookHeader.SetError(dtPurchaseDate, Constants.Messages.RequiredField);
                dtPurchaseDate.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSupplierCode.Text))
            {
                errFrmPurchaseBookHeader.SetError(txtSupplierCode, Constants.Messages.RequiredField);
                txtSupplierCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtInvoiceNumber.Text))
            {
                errFrmPurchaseBookHeader.SetError(txtInvoiceNumber, Constants.Messages.RequiredField);
                txtInvoiceNumber.Focus();
                return false;
            }

            int purchaseFormTypeID = 0;

            header = new PurchaseSaleBookHeader();
            header.PurchaseSaleBookHeaderID = purchaseSaleBookHeaderID;          

            header.VoucherDate = purchaseDate;
            header.PurchaseBillNo = txtInvoiceNumber.Text;
            header.LedgerTypeCode = txtSupplierCode.Text;
            header.LedgerType = Constants.LedgerType.SupplierLedger;
            header.VoucherTypeCode = Constants.VoucherTypeCode.PURCHASEENTRY;
            header.TotalTaxAmount = 0;

            PharmaBusinessObjects.Transaction.PurchaseType type = (PharmaBusinessObjects.Transaction.PurchaseType)cbxPurchaseType.SelectedItem;
            header.LocalCentral = (type != null && type.PurchaseTypeName.ToLower() == "central") ? "C" : "L";

            Int32.TryParse(Convert.ToString(cbxPurchaseFormType.SelectedValue), out purchaseFormTypeID);
            header.PurchaseEntryFormID = purchaseFormTypeID;

            return true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == Keys.End)
                {
                    if (purchaseSaleBookHeaderID > 0 && dgvLineItem.Rows.Count > 0)
                    {
                        PurchaseSaleBookHeader header = new PurchaseSaleBookHeader();
                        GetPurchaseBookHeader(ref header);

                        if (header.LocalCentral == "L")
                        {
                            frmPurchaseHeaderAmount amount = new frmPurchaseHeaderAmount(header);
                            amount.FormClosed += Amount_FormClosed;
                            amount.ShowDialog();
                        }
                        else {
                            frmPurchaseHeaderCentralAmount amount = new frmPurchaseHeaderCentralAmount(header);
                            amount.FormClosed += Amount_FormClosed;
                            amount.ShowDialog();
                        }
                    }

                }

                else if (keyData == Keys.F5)
                {
                    frmPurchaseBookTransaction form = new frmPurchaseBookTransaction(false);
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

        private void Amount_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //frmPurchaseHeaderAmount amount = (frmPurchaseHeaderAmount)sender;
                dgvLineItem.CurrentCell = dgvLineItem.CurrentCell;
                var result = MessageBox.Show("Are you sure you want to save the purchase entry", "Confirmation", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    applicationFacade.SavePurchaseData(purchaseSaleBookHeaderID);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLineItemScheme_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Purchase_Entry.frmLineItemScheme lineItemScheme = (Purchase_Entry.frmLineItemScheme)sender;
                int rowIndex = -1;               

                if (dgvLineItem.SelectedCells.Count > 0)
                {
                    rowIndex = lineItemScheme.RowIndex;
                   
                    if (lineItemScheme.PurchaseBookLinetem != null)
                    {
                       isBatchUpdate = true;
                        PurchaseSaleBookLineItem lineItem = lineItemScheme.PurchaseBookLinetem;
                        InsertUpdateLineItemAndsetToGrid(lineItem,rowIndex);
                    }

                   isBatchUpdate = false;
                }

                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);

                dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleRate"];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ItemMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmItemMaster itemMaster = (frmItemMaster)sender;
                int rowIndex = -1;
               
                if (dgvLineItem.SelectedCells.Count > 0)
                {
                    rowIndex = itemMaster.RowIndex;                  

                    if (itemMaster.LastSelectedItemMaster != null)
                    {
                        isBatchUpdate = true;
                        int lineItemID = 0;
                        Int32.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleBookLineItemID"].Value), out lineItemID);

                        PurchaseSaleBookLineItem lineItem = itemMaster.LastSelectedItemMaster.ToPurchaseBookLineItem();
                        lineItem.PurchaseSaleBookHeaderID = purchaseSaleBookHeaderID;
                        lineItem.PurchaseSaleBookLineItemID = lineItemID;

                        DateTime purchaseDate = new DateTime();
                        purchaseDate = ExtensionMethods.ConvertToSystemDateFormat(dtPurchaseDate.Text);
                      
                        PharmaBusinessObjects.Transaction.PurchaseType type = (PharmaBusinessObjects.Transaction.PurchaseType)cbxPurchaseType.SelectedItem;
                        lineItem.LocalCentral = (type != null && type.PurchaseTypeName.ToLower() == "central") ? "C" : "L";

                        //int srno = dgvLineItem.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["SrNo"].Value));

                        InsertUpdateLineItemAndsetToGrid(lineItem,rowIndex);
                    }

                    isBatchUpdate = false;
                }

                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);

                if (rowIndex != -1)
                {
                    dgvLineItem.Focus();

                   if(!IsModify)
                    {
                        var list = applicationFacade.GetLastNBatchNoForSupplierItem(txtSupplierCode.Text, Convert.ToString(dgvLineItem.CurrentRow.Cells["ItemCode"].Value));
                        if (list != null && list.Count > 0)
                        {
                            OpenBatchDialog(list,rowIndex);
                        }
                        else
                        {
                            dgvLineItem.CurrentCell = dgvLineItem.CurrentRow.Cells["Batch"];
                        }
                    }
                    else
                    {
                        dgvLineItem.CurrentCell = dgvLineItem.CurrentRow.Cells["Batch"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLineItemBriefDiscount_FormClosed (object sender, FormClosedEventArgs e)
        {
            try
            {
                frmLineItemBriefDiscount lineItemUpdate = (frmLineItemBriefDiscount)sender;
                int rowIndex = -1;               

                if (dgvLineItem.SelectedCells.Count > 0)
                {
                    rowIndex = lineItemUpdate.RowIndex;                   

                    if (lineItemUpdate.PurchaseBookLinetem != null)
                    {
                       isBatchUpdate = true;

                        int lineItemID = 0;
                        Int32.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleBookLineItemID"].Value), out lineItemID);

                        PurchaseSaleBookLineItem lineItem = lineItemUpdate.PurchaseBookLinetem;

                        InsertUpdateLineItemAndsetToGrid(lineItem,rowIndex);                     
                    }

                    isBatchUpdate = false;
                }

                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLineItemDiscount_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmLineItemDiscount lineItemUpdate = (frmLineItemDiscount)sender;
                int rowIndex = -1;
              
                if (dgvLineItem.SelectedCells.Count > 0)
                {
                    rowIndex = lineItemUpdate.RowIndex;
                    
                    if (lineItemUpdate.PurchaseBookLinetem != null)
                    {
                        isBatchUpdate = true;
                       
                        PurchaseSaleBookLineItem lineItem = lineItemUpdate.PurchaseBookLinetem;

                        InsertUpdateLineItemAndsetToGrid(lineItem,rowIndex);

                        dgvLineItem.CurrentRow.Cells["OldPurchaseSaleRate"].Value = lineItem.PurchaseSaleRate;
                    }

                    isBatchUpdate = false;
                }

                ExtensionMethods.RemoveChildFormToPanel(this, (Control)sender, ExtensionMethods.MainPanel);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        private void frmPurchaseBookTransaction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private PurchaseSaleBookLineItem ConvertToPurchaseBookLineItem(DataGridViewRow row)
        {
            PurchaseSaleBookLineItem item = new PurchaseSaleBookLineItem();
            int id = 0;
            decimal dValue = 0L;

            if (row != null)
            {
                Int32.TryParse(Convert.ToString(row.Cells["PurchaseSaleBookLineItemID"].Value), out id);
                item.PurchaseSaleBookLineItemID = id;

                Int32.TryParse(Convert.ToString(row.Cells["PurchaseSaleBookHeaderID"].Value), out id);
                item.PurchaseSaleBookHeaderID = id;

                item.ItemCode = Convert.ToString(row.Cells["ItemCode"].Value);
                item.ItemName = Convert.ToString(row.Cells["ItemName"].Value);
                item.Batch = Convert.ToString(row.Cells["Batch"].Value);

                decimal.TryParse(Convert.ToString(row.Cells["Quantity"].Value), out dValue);
                item.Quantity = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["FreeQuantity"].Value), out dValue);
                item.FreeQuantity = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["PurchaseSaleRate"].Value), out dValue);
                item.PurchaseSaleRate = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["OldPurchaseSaleRate"].Value), out dValue);
                item.OldPurchaseSaleRate = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["Amount"].Value), out dValue);
                item.Amount = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["Scheme1"].Value), out dValue);
                item.Scheme1 = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["Scheme2"].Value), out dValue);
                item.Scheme2 = dValue;

                item.IsHalfScheme = Convert.ToBoolean(row.Cells["IsHalfScheme"].Value);

                decimal.TryParse(Convert.ToString(row.Cells["Discount"].Value), out dValue);
                item.Discount = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["SpecialDiscount"].Value), out dValue);
                item.SpecialDiscount = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["VolumeDiscount"].Value), out dValue);
                item.VolumeDiscount = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["MRP"].Value), out dValue);
                item.MRP = dValue;

                DateTime date = DateTime.MinValue;
                DateTime.TryParse(Convert.ToString(row.Cells["ExpiryDate"].Value), out date);
                if (date == DateTime.MinValue)
                    item.ExpiryDate = null;
                else
                    item.ExpiryDate = date;


                date = DateTime.MinValue;
                DateTime.TryParse(Convert.ToString(row.Cells["MfgDate"].Value), out date);
                if (date == DateTime.MinValue)
                    item.MfgDate = null;
                else
                    item.MfgDate = date;

                decimal.TryParse(Convert.ToString(row.Cells["WholeSaleRate"].Value), out dValue);
                item.WholeSaleRate = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["SpecialRate"].Value), out dValue);
                item.SpecialRate = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["SaleRate"].Value), out dValue);
                item.SaleRate = dValue;
                
                item.PurchaseSaleTypeCode = Convert.ToString(row.Cells["PurchaseSaleTypeCode"].Value);

                decimal.TryParse(Convert.ToString(row.Cells["PurchaseSaleTax"].Value), out dValue);
                item.PurchaseSaleTax = dValue;

                //---------------------------------------
                decimal.TryParse(Convert.ToString(row.Cells["CostAmount"].Value), out dValue);
                item.CostAmount = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["DiscountAmount"].Value), out dValue);
                item.DiscountAmount = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["SpecialDiscountAmount"].Value), out dValue);
                item.SpecialDiscountAmount = dValue;
                
                decimal.TryParse(Convert.ToString(row.Cells["VolumeDiscountAmount"].Value), out dValue);
                item.VolumeDiscountAmount = dValue;
                
                decimal.TryParse(Convert.ToString(row.Cells["GrossAmount"].Value), out dValue);
                item.GrossAmount = dValue;
                
                decimal.TryParse(Convert.ToString(row.Cells["TaxAmount"].Value), out dValue);
                item.TaxAmount = dValue;
                
                decimal.TryParse(Convert.ToString(row.Cells["SchemeAmount"].Value), out dValue);
                item.SchemeAmount = dValue;
                
                decimal.TryParse(Convert.ToString(row.Cells["TotalDiscountAmount"].Value), out dValue);
                item.TotalDiscountAmount = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["SurchargeAmount"].Value), out dValue);
                item.SurchargeAmount = dValue;

                
                PharmaBusinessObjects.Transaction.PurchaseType type = (PharmaBusinessObjects.Transaction.PurchaseType)cbxPurchaseType.SelectedItem;
                item.LocalCentral = (type != null && type.PurchaseTypeName.ToLower() == "central") ? "C" : "L";

                decimal.TryParse(Convert.ToString(row.Cells["UsedQuantity"].Value), out dValue);
                item.UsedQuantity = dValue;

                decimal.TryParse(Convert.ToString(row.Cells["BalanceQuantity"].Value), out dValue);
                item.BalanceQuantity = dValue;

                int.TryParse(Convert.ToString(row.Cells["OldPurchaseSaleBookLineItemID"].Value), out id);
                item.OldPurchaseSaleBookLineItemID = id;


                int.TryParse(Convert.ToString(row.Cells["FifoID"].Value), out id);
                item.FifoID = id;

               }

            return item;
        }

        private decimal GetLineItemAmount(PurchaseSaleBookLineItem item)
        {
            decimal? amount = 0L;
            amount = item.Quantity * item.PurchaseSaleRate;
            return amount ?? 0;
        }

        private void dgvLineItem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int rowIndex = dgvLineItem.CurrentRow.Index;
                int columnIndex = dgvLineItem.CurrentCell.ColumnIndex;

                if (e.KeyData == Keys.Enter || e.KeyData == Keys.Right)
                {
                    e.Handled = true;

                    this.BeginInvoke(new MethodInvoker(() =>
                    {
                        OpenDialogAndMoveToNextControl(columnIndex, rowIndex);
                    }));
                    
                }
                else if (e.KeyData == Keys.Delete || e.KeyData == Keys.Escape)
                {
                    DeleteLineItem(rowIndex);
                }               
                //else if(e.KeyData == Keys.Insert)
                //{
                //    int rindex = dgvLineItem.CurrentRow.Index;

                //    if(rindex >=0)
                //    {
                //        dgvLineItem.Rows.Insert(rindex, 1);
                //        dgvLineItem.CurrentCell = dgvLineItem.Rows[rindex].Cells["ItemCode"];
                //    }

                //}

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

                    decimal usedQuantity = 0;
                    decimal.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["UsedQuantity"].Value), out usedQuantity);

                    if (usedQuantity > 0)
                    {
                        MessageBox.Show("Item can not be delete as it is already used.");
                        return;
                    }


                    PurchaseSaleBookLineItem lineItem = ConvertToPurchaseBookLineItem(dgvLineItem.CurrentRow);
                    //int rowIndex = dgvLineItem.CurrentRow.Index;
                    dgvLineItem.Rows.RemoveAt(rowIndex);

                    List<PurchaseBookAmount> amounts = applicationFacade.DeleteTempPurchaseBookLineItem(lineItem);
                    PurchaseBookAmount amountTotal = null;

                    if (amounts != null && amounts.Count > 0)
                    {
                        amountTotal = amounts.Where(p => p.PurchaseSaleBookLineItemID == 0).FirstOrDefault();
                    }

                    if (amountTotal == null)
                    {
                        amountTotal = new PurchaseBookAmount();
                    }

                    SetHeaderLabels(amountTotal);

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenBatchDialog(List<PurchaseSaleBookLineItem> list,int rowIndex)
        {
            if (list != null && list.Count > 0)
            {
                PurchaseSaleBookLineItem lineItem = ConvertToPurchaseBookLineItem(dgvLineItem.CurrentRow);
                frmLastNBatchNo batch = new frmLastNBatchNo(list, lineItem);
                batch.RowIndex = rowIndex;
                batch.FormClosed += Batch_FormClosed;
                batch.ShowDialog();
            }
        }

        private void OpenDialogAndMoveToNextControl(int columnIndex,int rowIndex)
        {
            string columnName = dgvLineItem.Columns[columnIndex].Name;
            PurchaseSaleBookLineItem lineItem = ConvertToPurchaseBookLineItem(dgvLineItem.Rows[rowIndex]);

            if (columnName == "ItemCode")
            {
                string itemCode = Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["Quantity"].Value);

                if (string.IsNullOrWhiteSpace(itemCode))
                {
                    frmItemMaster itemMaster = new frmItemMaster(true);
                    itemMaster.RowIndex = rowIndex;
                    //Set Child UI
                    ExtensionMethods.AddChildFormToPanel(this, itemMaster, ExtensionMethods.MainPanel);
                    itemMaster.WindowState = FormWindowState.Maximized;

                    itemMaster.FormClosed += ItemMaster_FormClosed; ;
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
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["Batch"];
                }
                else
                {
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["Quantity"];
                }
            }
            else if (columnName == "Quantity")
            {
                decimal val = 0;
                decimal.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["Quantity"].Value), out val);

                if (val == 0)
                {
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["Quantity"];
                    dgvLineItem.BeginEdit(true);
                }
                else
                {

                    if (IsModify)
                    {
                        decimal usedQuantity = 0;
                        decimal.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["UsedQuantity"].Value), out usedQuantity);

                        decimal balanceQuantity = 0;
                        decimal.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["BalanceQuantity"].Value), out balanceQuantity);

                        if (val < usedQuantity)
                        {
                            MessageBox.Show("Quantity can not be less than used quantity. Used Quantity is --> " + usedQuantity);
                            dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells[columnIndex];
                            dgvLineItem.Rows[rowIndex].Cells[columnIndex].Value = usedQuantity + balanceQuantity;
                        }
                        else
                        {
                            decimal amount = GetLineItemAmount(lineItem);
                            dgvLineItem.Rows[rowIndex].Cells["Amount"].Value = amount;
                            lineItem.Amount = amount;
                            InsertUpdateLineItemAndsetToGrid(lineItem, rowIndex);
                            dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["FreeQuantity"];
                        }
                    }
                    else
                    {
                        if (val == 0)
                        {
                            dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["Quantity"];
                            dgvLineItem.BeginEdit(true);
                        }
                        else
                        {
                            InsertUpdateLineItemAndsetToGrid(lineItem, rowIndex);
                            dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["FreeQuantity"];
                            dgvLineItem.BeginEdit(true);
                        }
                    }
                }
            }
            else if (columnName == "FreeQuantity")
            {
                decimal qty = 0;
                decimal.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["FreeQuantity"].Value), out qty);

                if (qty > 0)
                {
                    lineItem.FreeQuantity = qty;
                    InsertUpdateLineItemAndsetToGrid(lineItem,rowIndex);
                    OpenSchemeDialog(lineItem,rowIndex);
                }
                else
                {
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleRate"];
                    dgvLineItem.BeginEdit(true);
                }
            }
            else if (columnName == "PurchaseSaleRate")
            {
                decimal rate = 0;
                decimal.TryParse(Convert.ToString(dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleRate"].Value), out rate);

                if (rate == 0)
                {
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleRate"];
                    dgvLineItem.BeginEdit(true);
                }
                else
                {
                    decimal newRate = 0L;
                    decimal oldRate = 0L;

                    decimal.TryParse(Convert.ToString(dgvLineItem["OldPurchaseSaleRate", rowIndex].Value), out oldRate);
                    decimal.TryParse(Convert.ToString(dgvLineItem["PurchaseSaleRate", rowIndex].Value), out newRate);

                    if (oldRate != newRate)
                    {
                        lineItem.PurchaseSaleRate = newRate;
                        InsertUpdateLineItemAndsetToGrid(lineItem,rowIndex);
                        frmLineItemDiscount updateForm = new frmLineItemDiscount(lineItem);
                        updateForm.RowIndex = rowIndex;
                        updateForm.FormClosed += frmLineItemDiscount_FormClosed;
                        updateForm.ShowDialog();

                    }
                    else
                    {
                        frmLineItemBriefDiscount updateForm = new frmLineItemBriefDiscount(lineItem);
                        updateForm.RowIndex = rowIndex;
                        updateForm.FormClosed += frmLineItemBriefDiscount_FormClosed;
                        updateForm.ShowDialog();
                    }

                    if (rowIndex == dgvLineItem.Rows.Count - 1)
                    {
                        dgvLineItem.Rows.Add();
                        dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex + 1].Cells["ItemCode"];
                    }
                    else
                    {
                        dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex + 1].Cells["ItemCode"];
                    }

                }

            }
            else
            {
                //int colIndex = columnIndex + 1;

                //if (colIndex <= 8)
                //{
                //    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells[colIndex];
                //}
                //else
                //{
                //    if (rowIndex == dgvLineItem.Rows.Count - 1)
                //    {
                //        dgvLineItem.Rows.Add();
                //        dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex + 1].Cells["ItemCode"];
                //    }
                //    else
                //    {
                //        dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex + 1].Cells["ItemCode"];
                //    }
                //}
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPurchaseBookTransaction_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ExtensionMethods.RemoveTransactionFormToPanel(this, ExtensionMethods.MainPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void EnterKeyDownForTabEvents(Control control)
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

        private void C_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{TAB}");
                return;
            }

            if (sender is TextBox)
            {
                TextBox txt = (TextBox)sender;

                if (e.KeyCode == Keys.Enter)
                {                    
                    if (txt.Name == "txtInvoiceNumber" && !string.IsNullOrEmpty(dtPurchaseDate.Text) && IsModify && string.IsNullOrEmpty(txtInvoiceNumber.Text))
                    {
                        Purchase_Entry.frmAllBillForSupplier frm = new Purchase_Entry.frmAllBillForSupplier(txtSupplierCode.Text, dtPurchaseDate.Text);
                        frm.FormClosed += AllBillForSuppier_FormClosed;
                        frm.ShowDialog();

                        if (dgvLineItem.Rows.Count > 0)
                        {
                            //dgvLineItem.Rows[0].Selected = false;

                            //dgvLineItem.Focus();
                            //dgvLineItem.CurrentCell = dgvLineItem.Rows[0].Cells["ItemCode"];
                        }
                        else
                        {
                            txtInvoiceNumber.Focus();
                        }

                    }
                    else if (!string.IsNullOrEmpty(txt.Text))
                    {
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    }
                    else
                    {
                        if (txt.Name == "txtSupplierCode")
                        {
                            frmSupplierLedger ledger = new frmSupplierLedger(true);
                            //Set Child UI

                            ExtensionMethods.AddChildFormToPanel(this, ledger, ExtensionMethods.MainPanel);
                            ledger.WindowState = FormWindowState.Maximized;

                            ledger.FormClosed += Ledger_FormClosed;
                            ledger.Show();

                        }
                    }
                }
            }
            else if (sender is MaskedTextBox)
            {
                MaskedTextBox txt = (MaskedTextBox)sender;

                if (e.KeyCode == Keys.Enter && txt.Text != "  /  /")
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
            }
            else if (sender is ComboBox)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (purchaseSaleBookHeaderID > 0)
                    {
                        Control control = (Control)sender;

                        if (control is ComboBox)
                        {
                            ComboBox cb1 = (ComboBox)control;

                            if (cb1.Name == "cbxPurchaseType")
                            {
                                PharmaBusinessObjects.Transaction.PurchaseType type = (PharmaBusinessObjects.Transaction.PurchaseType)cbxPurchaseType.SelectedItem;
                                if (type != null && type.PurchaseTypeName.ToLower() == "local" && dgvLineItem.Rows.Count == 0)
                                {
                                    dgvLineItem.Rows.Add();
                                    dgvLineItem.CurrentCell = dgvLineItem.Rows[0].Cells["ItemCode"];
                                    dgvLineItem.Focus();
                                }
                                else
                                {
                                    dgvLineItem.CurrentCell = dgvLineItem.Rows[0].Cells["ItemCode"];
                                    dgvLineItem.Focus();
                                }
                            }
                            else if (cb1.Name == "cbxPurchaseFormType")
                            {
                                PharmaBusinessObjects.Transaction.PurchaseType type = (PharmaBusinessObjects.Transaction.PurchaseType)cbxPurchaseType.SelectedItem;

                                if (type != null && type.PurchaseTypeName.ToLower() == "central" && dgvLineItem.Rows.Count == 0)
                                {
                                    dgvLineItem.Rows.Add();
                                    dgvLineItem.CurrentCell = dgvLineItem.Rows[0].Cells["ItemCode"];
                                    dgvLineItem.Focus();
                                }
                                else
                                {
                                    dgvLineItem.CurrentCell = dgvLineItem.Rows[0].Cells["ItemCode"];
                                    dgvLineItem.Focus();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void AllBillForSuppier_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Purchase_Entry.frmAllBillForSupplier frm = (Purchase_Entry.frmAllBillForSupplier)sender;

                long PurchaseSaleBookHeaderID = frm.PurchaseSaleBookHeaderID;

                PharmaBusinessObjects.Transaction.PurchaseSaleBookHeader header = applicationFacade.GetPurchaseSaleBookHeaderForModify(PurchaseSaleBookHeaderID);

                if(header !=null)
                {
                    txtInvoiceNumber.Text = header.PurchaseBillNo;
                    string localCentral = header.LocalCentral == "L" ? "Local" : "Central";

                    int id = applicationFacade.GetPurchaseEntryTypes().Where(p => p.PurchaseTypeName.ToLower().Equals(localCentral.ToLower())).FirstOrDefault().ID;

                    cbxPurchaseType.SelectedValue = id;
                    purchaseSaleBookHeaderID = header.PurchaseSaleBookHeaderID;
                    oldPurchaseSaleBookHeaderID = header.OldPurchaseSaleBookHeaderID;

                    if(header.LocalCentral == "C")
                    {

                        cbxPurchaseFormType.DataSource = applicationFacade.GetPurchaseFormTypes(id);
                        cbxPurchaseFormType.DisplayMember = "FormTypeName";
                        cbxPurchaseFormType.ValueMember = "ID";

                        cbxPurchaseFormType.Visible = true;
                        cbxPurchaseFormType.SelectedValue = header.PurchaseEntryFormID;
                    }

                    List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> lineitems = applicationFacade.GetPurchaseSaleBookLineItemForModify(header.PurchaseSaleBookHeaderID);

                    FillGridWithLineItems(lineitems);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillGridWithLineItems(List<PurchaseSaleBookLineItem> lineitems)
        {
            if (lineitems != null && lineitems.Count > 0)
            {
                int rowIndex = 0;

                foreach (var lineItem in lineitems)
                {                    
                    dgvLineItem.Rows.Add();

                    rowIndex = dgvLineItem.Rows.Count - 1;

                    //dgvLineItem.Rows[rowIndex].Selected = true;
                    dgvLineItem.CurrentCell = dgvLineItem.Rows[rowIndex].Cells["ItemCode"];
                    InsertUpdateLineItemAndsetToGrid(lineItem,rowIndex);

                    rowIndex++;
                }

               // dgvLineItem.Rows[0].Selected = true;
                dgvLineItem.CurrentCell = dgvLineItem.Rows[0].Cells["ItemCode"];
                dgvLineItem.Focus();

            }

        }

        private void SetLables()
        {
            PurchaseSaleBookLineItem lineItem = ConvertToPurchaseBookLineItem(dgvLineItem.CurrentRow);

            lblSaleRate.Text = lineItem.SaleRate.ToString();
            lblDiscountPercente.Text = Convert.ToString(ExtensionMethods.SafeConversionDecimal(Convert.ToString(lineItem.Discount)));
            lblDiscountAmount.Text = Convert.ToString(ExtensionMethods.SafeConversionDecimal(Convert.ToString(lineItem.DiscountAmount)));
            lblMRP.Text = Convert.ToString(ExtensionMethods.SafeConversionDecimal(Convert.ToString(lineItem.MRP)));           
            lblTaxPercent.Text = lineItem.PurchaseSaleTax.ToString();
            lblTaxAmount.Text = Convert.ToString(ExtensionMethods.SafeConversionDecimal(Convert.ToString(lineItem.TaxAmount)));
            lblInvoiceAmount.Text = (lineItem.Amount + lineItem.TaxAmount - lineItem.TotalDiscountAmount).ToString();
            lblBonus.Text = lineItem.Scheme1.ToString() + " + " + lineItem.Scheme2.ToString();
            lblSplDiscountPercent.Text = Convert.ToString(ExtensionMethods.SafeConversionDecimal(Convert.ToString(lineItem.SpecialDiscount)));
            lblSplDisAmount.Text = Convert.ToString(ExtensionMethods.SafeConversionDecimal(Convert.ToString(lineItem.SpecialDiscountAmount)));
            lblVolumeDis.Text = Convert.ToString(ExtensionMethods.SafeConversionDecimal(Convert.ToString(lineItem.VolumeDiscount)));
            lblVolumeDiscountAmount.Text = Convert.ToString(ExtensionMethods.SafeConversionDecimal(Convert.ToString(lineItem.VolumeDiscountAmount)));
            lblSchemeAmount.Text= Convert.ToString(ExtensionMethods.SafeConversionDecimal(Convert.ToString(lineItem.SchemeAmount)));

        }

        private void InsertUpdateLineItemAndsetToGrid(PurchaseSaleBookLineItem lineItem,int rowIndex) //,int srno, bool setSrNo = false)
        {
            if (dgvLineItem.SelectedCells.Count > 0)
            {
                decimal amt = GetLineItemAmount(lineItem);
                lineItem.Amount = amt;

                List<PurchaseBookAmount>  amounts = applicationFacade.InsertUpdateTempPurchaseBookLineItem(lineItem);

                if (amounts != null && amounts.Count > 0)
                {
                    lineItem.PurchaseSaleBookLineItemID = amounts.Where(p => p.PurchaseSaleBookLineItemID > 0).FirstOrDefault().PurchaseSaleBookLineItemID;


                    PurchaseBookAmount amountTotal = amounts.Where(p => p.PurchaseSaleBookLineItemID == 0).FirstOrDefault();
                    if (amountTotal == null)
                    {
                        amountTotal = new PurchaseBookAmount();
                    }

                    PurchaseBookAmount amountLineItem = amounts.Where(p => p.PurchaseSaleBookLineItemID > 0).FirstOrDefault();

                    if (amountLineItem == null)
                    {
                        amountLineItem = new PurchaseBookAmount();
                    }

                    dgvLineItem.Rows[rowIndex].Cells["CostAmount"].Value = amountLineItem.CostAmount;
                    dgvLineItem.Rows[rowIndex].Cells["DiscountAmount"].Value = amountLineItem.DiscountAmount;
                    dgvLineItem.Rows[rowIndex].Cells["SpecialDiscountAmount"].Value = amountLineItem.SpecialDiscountAmount;
                    dgvLineItem.Rows[rowIndex].Cells["VolumeDiscountAmount"].Value = amountLineItem.VolumeDiscountAmount;
                    dgvLineItem.Rows[rowIndex].Cells["GrossAmount"].Value = amountLineItem.GrossAmount;
                    dgvLineItem.Rows[rowIndex].Cells["TaxAmount"].Value = amountLineItem.TaxAmount;
                    dgvLineItem.Rows[rowIndex].Cells["SchemeAmount"].Value = amountLineItem.SchemeAmount;
                    dgvLineItem.Rows[rowIndex].Cells["SurchargeAmount"].Value = lineItem.SurchargeAmount;
                    dgvLineItem.Rows[rowIndex].Cells["TotalDiscountAmount"].Value = amountLineItem.TotalDiscountAmount;

                    SetHeaderLabels(amountTotal);
                }


                //if (setSrNo)
                //{
                //    dgvLineItem.Rows[rowIndex].Cells["SrNo"].Value = srno + 1;
                //}

                dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleBookLineItemID"].Value = lineItem.PurchaseSaleBookLineItemID;               
                dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleBookHeaderID"].Value = purchaseSaleBookHeaderID;
                dgvLineItem.Rows[rowIndex].Cells["ItemCode"].Value = lineItem.ItemCode;
                dgvLineItem.Rows[rowIndex].Cells["ItemName"].Value = lineItem.ItemName;
                dgvLineItem.Rows[rowIndex].Cells["Quantity"].Value = lineItem.Quantity;
                dgvLineItem.Rows[rowIndex].Cells["FreeQuantity"].Value = lineItem.FreeQuantity;
                dgvLineItem.Rows[rowIndex].Cells["Batch"].Value = lineItem.Batch;
                dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleRate"].Value = lineItem.PurchaseSaleRate;
                dgvLineItem.Rows[rowIndex].Cells["OldPurchaseSaleRate"].Value = lineItem.OldPurchaseSaleRate;
                dgvLineItem.Rows[rowIndex].Cells["Amount"].Value = amt;
                dgvLineItem.Rows[rowIndex].Cells["Scheme1"].Value = lineItem.Scheme1;
                dgvLineItem.Rows[rowIndex].Cells["Scheme2"].Value = lineItem.Scheme2;
                dgvLineItem.Rows[rowIndex].Cells["IsHalfScheme"].Value = lineItem.IsHalfScheme;
                dgvLineItem.Rows[rowIndex].Cells["Discount"].Value = lineItem.Discount;
                dgvLineItem.Rows[rowIndex].Cells["SpecialDiscount"].Value = lineItem.SpecialDiscount;
                dgvLineItem.Rows[rowIndex].Cells["VolumeDiscount"].Value = lineItem.VolumeDiscount;
                dgvLineItem.Rows[rowIndex].Cells["MRP"].Value = lineItem.MRP;
                dgvLineItem.Rows[rowIndex].Cells["ExpiryDate"].Value = lineItem.ExpiryDate;
                dgvLineItem.Rows[rowIndex].Cells["MfgDate"].Value = lineItem.MfgDate;
                dgvLineItem.Rows[rowIndex].Cells["SaleRate"].Value = lineItem.SaleRate;
                dgvLineItem.Rows[rowIndex].Cells["SpecialRate"].Value = lineItem.SpecialRate;
                dgvLineItem.Rows[rowIndex].Cells["WholeSaleRate"].Value = lineItem.WholeSaleRate;
                dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleTypeCode"].Value = lineItem.PurchaseSaleTypeCode;
                dgvLineItem.Rows[rowIndex].Cells["PurchaseSaleTax"].Value = lineItem.PurchaseSaleTax;
                dgvLineItem.Rows[rowIndex].Cells["LocalCentral"].Value = lineItem.LocalCentral;
                dgvLineItem.Rows[rowIndex].Cells["UsedQuantity"].Value = lineItem.UsedQuantity;
                dgvLineItem.Rows[rowIndex].Cells["BalanceQuantity"].Value = lineItem.BalanceQuantity;
                dgvLineItem.Rows[rowIndex].Cells["OldPurchaseSaleBookLineItemID"].Value = lineItem.OldPurchaseSaleBookLineItemID;
                dgvLineItem.Rows[rowIndex].Cells["FifoID"].Value = lineItem.FifoID;


            }
        }

        private void SetHeaderLabels(PurchaseBookAmount amountTotal)
        {
            lblTotalDiscountAmt.Text = Convert.ToString(amountTotal.TotalDiscountAmount);
            lblTotalSchemeAmt.Text = Convert.ToString(amountTotal.SchemeAmount);
            lblTotalTaxAmount.Text = Convert.ToString(amountTotal.TaxAmount);
            lblTotalAmount.Text = Convert.ToString(amountTotal.GrossAmount);
            lblTotalNetAmount.Text = Convert.ToString(amountTotal.BillAmount + amountTotal.TaxAmount);
        }

        private void frmPurchaseBookTransaction_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (purchaseSaleBookHeaderID > 0)
            {
                bool result = applicationFacade.IsTempPurchaseHeaderExists(purchaseSaleBookHeaderID);

                if (result)
                {
                    DialogResult isConfirm = MessageBox.Show("There are some unsaved changes. Do you want to close the screen", "Warning", MessageBoxButtons.YesNo);

                    if (isConfirm == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        applicationFacade.DeleteUnSavedData(purchaseSaleBookHeaderID);
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
