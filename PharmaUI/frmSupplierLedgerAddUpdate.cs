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
    public partial class frmSupplierLedgerAddUpdate : Form
    {
        IApplicationFacade applicationFacade;
        public int SupplierId { get; set; }
        private string SupplierNameNew { get; set; }
        public bool IsInChildMode = false;

        public frmSupplierLedgerAddUpdate(int supplierId,string supplierName)
        {
            try
            {

                InitializeComponent();
                ExtensionMethods.SetFormProperties(this);
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
                this.SupplierId = supplierId;
                SupplierNameNew = supplierName;
                LoadSupplierCompanyDiscountGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void LoadSupplierCompanyDiscountGrid()
        {

            List<SupplierCompanyDiscount> supplierCopanyDiscountList = applicationFacade.GetCompleteCompanyDiscountListBySupplierID(SupplierId);
            dgvCompanyDiscount.DataSource = supplierCopanyDiscountList;

            for (int i = 0; i < dgvCompanyDiscount.Columns.Count; i++)
            {
                dgvCompanyDiscount.Columns[i].Visible = false;
            }

            dgvCompanyDiscount.Columns["CompanyName"].Visible = true;
            dgvCompanyDiscount.Columns["CompanyName"].HeaderText = "Company Name";
            dgvCompanyDiscount.Columns["CompanyName"].ReadOnly = true;
            dgvCompanyDiscount.Columns["CompanyName"].DisplayIndex = 0;

            dgvCompanyDiscount.Columns["Normal"].Visible = true;
            dgvCompanyDiscount.Columns["Normal"].HeaderText = "Normal";
            dgvCompanyDiscount.Columns["Normal"].DisplayIndex = 1;

            dgvCompanyDiscount.Columns["Breakage"].Visible = true;
            dgvCompanyDiscount.Columns["Breakage"].DisplayIndex = 2;
            dgvCompanyDiscount.Columns["Breakage"].HeaderText = "Breakage";

            dgvCompanyDiscount.Columns["Expired"].Visible = true;
            dgvCompanyDiscount.Columns["Expired"].DisplayIndex = 3;
            dgvCompanyDiscount.Columns["Expired"].HeaderText = "Expired";

            dgvCompanyDiscount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            dgvCompanyDiscount.AllowUserToAddRows = false;
            dgvCompanyDiscount.AllowUserToDeleteRows = false;
            dgvCompanyDiscount.ReadOnly = false;
        }

        private void frmSupplierLedgerAddUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                ExtensionMethods.FormLoad(this, (this.SupplierId > 0) ? "Supplier Ledger Master - Update" : "Supplier Ledger Master - Add");
                GotFocusEventRaised(this);
                EnterKeyDownForTabEvents(this);

                FillCombo();

                if (this.SupplierId > 0)
                {
                    FillFormForUpdate();
                }
                else
                {
                    txtCustSupplierName.Text = SupplierNameNew;
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

        private void FillFormForUpdate()
        {
            SupplierLedgerMaster supplier = applicationFacade.GetSupplierLedgerById(this.SupplierId);

            if (supplier != null)
            {
                txtCode.Text = supplier.SupplierLedgerCode;
                txtCustSupplierName.Text = supplier.SupplierLedgerName;
                txtShortName.Text = supplier.SupplierLedgerShortName;
                txtAddress.Text = supplier.Address;
                txtContactPerson.Text = supplier.ContactPerson;
                txtEmailAddress.Text = supplier.EmailAddress;
                txtMobile.Text = supplier.Mobile;
                txtPhoneO.Text = supplier.OfficePhone;
                txtPhoneR.Text = supplier.ResidentPhone;
                cbxTaxRetail.SelectedItem = supplier.TaxRetail == "R" ? Enums.TaxRetail.R : Enums.TaxRetail.T;
                cbxStatus.SelectedItem = supplier.Status ? Enums.Status.Active : Enums.Status.Inactive;
                cbxCreditDebit.SelectedItem = supplier.CreditDebit == "C" ? Enums.TransType.C : Enums.TransType.D;
                txtOpeningBal.Text = supplier.OpeningBal.ToString();

              
                tbxArea.Tag = supplier.AreaId;
                tbxArea.Text = supplier.AreaName;
                tbxDL.Text = supplier.DLNo;
                tbxGST.Text = supplier.GSTNo;
                tbxCIN.Text = supplier.CINNo;
                tbxLIN.Text = supplier.LINNo;
                tbxServiceTax.Text = supplier.ServiceTaxNo;
                tbxPAN.Text = supplier.PANNo;

                //todo ADD SUPPLIER PURCHASE TYPE iD
                //cbxPurchaseType.SelectedValue = supplier.
            }
        }

        private void FillCombo()
        {
            ////Fill Credit/Debit options
            cbxCreditDebit.DataSource = Enum.GetValues(typeof(Enums.TransType));
            cbxCreditDebit.SelectedItem = TransType.C;

            ////Fill Credit/Debit options
            cbxTaxRetail.DataSource = Enum.GetValues(typeof(Enums.TaxRetail));
            cbxTaxRetail.SelectedItem = Enums.TaxRetail.R;

            ////Fill Status options
            cbxStatus.DataSource = Enum.GetValues(typeof(Enums.Status));
            cbxStatus.SelectedItem = Enums.Status.Active;

            //Fill Purchase type option
            cbxPurchaseType.DataSource = applicationFacade.GetAccountLedgerBySystemName("PurchaseLedger");
            cbxPurchaseType.DisplayMember = "AccountLedgerName";
            cbxPurchaseType.ValueMember = "AccountLedgerID";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrEmpty(txtCustSupplierName.Text))
                {
                    throw new Exception("Supplier Name can not be blank");
                }

                //Set the cursor to appear as busy
                Cursor.Current = Cursors.WaitCursor;

                Status status;
              //  int areaId = 0;
                decimal openingBal = 0.00M;

                SupplierLedgerMaster supplier = new SupplierLedgerMaster();
                supplier.SupplierLedgerCode = txtCode.Text;
                supplier.SupplierLedgerName = txtCustSupplierName.Text;
                supplier.SupplierLedgerShortName = txtShortName.Text;
                supplier.Address = txtAddress.Text;
                supplier.ContactPerson = txtContactPerson.Text;
                Enum.TryParse<Status>(cbxStatus.SelectedItem.ToString(), out status);
                supplier.Status = status == Status.Active;
                supplier.CreditDebit =(Enums.TransType)cbxCreditDebit.SelectedItem == Enums.TransType.C ? "C" : "D";

                supplier.AreaId =Convert.ToInt32(tbxArea.Tag);
                supplier.EmailAddress = txtEmailAddress.Text;
                supplier.Mobile = txtMobile.Text;
                supplier.OfficePhone = txtPhoneO.Text;

                int purchaseTypeId = 0;
                Int32.TryParse(Convert.ToString(cbxPurchaseType.SelectedValue), out purchaseTypeId);
                supplier.PurchaseTypeId = purchaseTypeId;

                decimal.TryParse(txtOpeningBal.Text , out openingBal);
                supplier.OpeningBal = openingBal;
                supplier.ResidentPhone = txtPhoneR.Text;
                supplier.TaxRetail =(Enums.TaxRetail)cbxTaxRetail.SelectedItem == TaxRetail.R ? "R" : "T";
                supplier.SupplierLedgerId = SupplierId;

                supplier.DLNo = tbxDL.Text;
                supplier.GSTNo = tbxGST.Text;
                supplier.CINNo = tbxCIN.Text;
                supplier.LINNo = tbxLIN.Text;
                supplier.ServiceTaxNo = tbxServiceTax.Text;
                supplier.PANNo = tbxPAN.Text;

                ///Get All the mapping for Company discount 
                ///
                supplier.SupplierCompanyDiscountList = dgvCompanyDiscount.Rows
                                                                        .Cast<DataGridViewRow>()
                                                                        .Where(r => !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["Normal"].Value))
                                                                                    || !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["Breakage"].Value))
                                                                                    || !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["Expired"].Value))
                                                                        ).Select(x => new SupplierCompanyDiscount()
                                                                        {
                                                                            CompanyID = (x.DataBoundItem as SupplierCompanyDiscount).CompanyID,
                                                                            Normal = (x.DataBoundItem as SupplierCompanyDiscount).Normal,
                                                                            Breakage = (x.DataBoundItem as SupplierCompanyDiscount).Breakage,
                                                                            Expired = (x.DataBoundItem as SupplierCompanyDiscount).Expired,
                                                                            SupplierItemDiscountMapping = (x.DataBoundItem as SupplierCompanyDiscount).SupplierItemDiscountMapping

                                                                        }).ToList();


                int result = SupplierId > 0 ? applicationFacade.UpdateSupplierLedger(supplier) : applicationFacade.AddSupplierLedger(supplier);

                //Make the Cursor to default
                Cursor.Current = Cursors.Default;

                //Close this form if operation is successful
                if (result > 0)
                {
                    this.Close();
                }
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

        private void txtOpeningBal_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Add
            if (keyData == (Keys.Escape))
            {
                if (this.ActiveControl.Name == "dgvCompanyDiscount")
                {
                    btnSave.Focus();
                }
                else if (IsInChildMode)
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
            else if (keyData == (Keys.F9))
            {

            }
            else if (keyData == (Keys.F3))
            {
                if (dgvCompanyDiscount.SelectedCells.Count > 0)
                {
                    bool DoesCompanyHaveDiscountMapping = dgvCompanyDiscount.CurrentRow != null && !(
                                                                                                String.IsNullOrWhiteSpace(Convert.ToString((dgvCompanyDiscount.CurrentRow.Cells["Normal"].Value)))
                                                                                                && String.IsNullOrWhiteSpace(Convert.ToString((dgvCompanyDiscount.CurrentRow.Cells["Breakage"].Value)))
                                                                                                && String.IsNullOrWhiteSpace(Convert.ToString((dgvCompanyDiscount.CurrentRow.Cells["Expired"].Value)))
                                                                                                );

                    ///OPen item discount mapping screen only if company discount existing 
                    if (DoesCompanyHaveDiscountMapping)
                    {
                        SupplierCompanyDiscount existingItem = (SupplierCompanyDiscount)dgvCompanyDiscount.Rows[dgvCompanyDiscount.SelectedCells[0].RowIndex].DataBoundItem;
                        frmSupplierItemDiscountMaster formSupplierItemDiscountMaster = new frmSupplierItemDiscountMaster(existingItem);
                        formSupplierItemDiscountMaster.FormClosed += FormSupplierItemDiscountMaster_FormClosed;
                        formSupplierItemDiscountMaster.Show();
                    }
                }
            }
            else if (keyData == Keys.F1)
            {
              
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FormSupplierItemDiscountMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                SupplierCompanyDiscount updatedSupplierCopanyDiscount = (sender as frmSupplierItemDiscountMaster).retSupplierCopanyDiscount;
                (dgvCompanyDiscount.Rows[dgvCompanyDiscount.SelectedCells[0].RowIndex].DataBoundItem as SupplierCompanyDiscount).SupplierItemDiscountMapping = updatedSupplierCopanyDiscount.SupplierItemDiscountMapping;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCompanyDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Up || e.KeyData == Keys.Left || e.KeyData == Keys.Right || e.KeyData == Keys.Down || e.KeyData == Keys.Tab)
                {
                    return;
                }

                e.SuppressKeyPress = true;

                if (e.KeyData == Keys.Enter)
                {
                    int rowIndex = dgvCompanyDiscount.CurrentCell.RowIndex;
                    int columnIndex = 0;
                    string columnName = dgvCompanyDiscount.Columns[dgvCompanyDiscount.CurrentCell.ColumnIndex].Name;

                    int columnDisplayIndex = dgvCompanyDiscount.Columns[dgvCompanyDiscount.CurrentCell.ColumnIndex].DisplayIndex;

                    for (int i = 0; i < dgvCompanyDiscount.ColumnCount; i++)
                    {
                        if (dgvCompanyDiscount.Columns[i].DisplayIndex == columnDisplayIndex + 1)
                        {
                            columnIndex = i;
                            break;
                        }
                    }

                    if (rowIndex == (dgvCompanyDiscount.Rows.Count - 1) && columnName == "Expired")
                    {
                        btnSave.Focus();

                    }
                    else if (rowIndex < (dgvCompanyDiscount.Rows.Count - 1) && columnName == "Expired")
                    {
                        for (int i = 0; i < dgvCompanyDiscount.Columns.Count - 1; i++)
                        {
                            if (dgvCompanyDiscount.Columns[i].DisplayIndex == 0)
                            {
                                dgvCompanyDiscount.CurrentCell = dgvCompanyDiscount[i, rowIndex + 1];
                                break;
                            }
                        }
                    }
                    else
                    {
                        dgvCompanyDiscount.CurrentCell = dgvCompanyDiscount[columnIndex, rowIndex];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCompanyDiscount_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                string columnName = dgvCompanyDiscount.Columns[dgvCompanyDiscount.CurrentCell.ColumnIndex].Name;

                if (columnName.Equals("CompanyName")) return;

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
            if (e.KeyCode == Keys.Enter)
            {
                if (sender is TextBox)
                {
                    TextBox activePersonRouteType = sender as TextBox;
                    string activePersonRouteTypeString = String.Empty;
                    bool isValidTextbox = false;

                    switch (activePersonRouteType.Name)
                    {                      
                        case "tbxArea":
                            {
                                activePersonRouteType = tbxArea;
                                activePersonRouteTypeString = Constants.RecordType.AREADISPLAYNAME;
                                isValidTextbox = true;
                            }
                            break;
                    }

                    if (isValidTextbox && String.IsNullOrWhiteSpace(activePersonRouteType.Text))
                    {
                        PersonRouteMaster personRouteMaster = new PersonRouteMaster()
                        {
                            RecordTypeNme = activePersonRouteTypeString,
                            PersonRouteID = ExtensionMethods.SafeConversionInt(Convert.ToString(activePersonRouteType.Tag)) ?? 0,
                            PersonRouteName = activePersonRouteType.Text
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
                    else
                    {
                        SendKeys.Send("{TAB}");
                    }
                }
                else
                {
                    SendKeys.Send("{TAB}");
                }
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
                            case Constants.RecordType.AREADISPLAYNAME:
                                {
                                    tbxArea.Text = lastSelectedPersonRoute.PersonRouteName;
                                    tbxArea.Tag = lastSelectedPersonRoute.PersonRouteID;
                                    dgvCompanyDiscount.Focus();
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

    }
}
