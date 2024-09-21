using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PharmaBusinessObjects.Common.Enums;

namespace PharmaUI
{
    public partial class frmCustomerLedgerMasterAddUpdate : Form
    {
        IApplicationFacade applicationFacade;
        private bool isInEditMode { get; set; }
        private int customerLedgerID { get; set; }
        public bool IsInChildMode = false;

        public frmCustomerLedgerMasterAddUpdate(bool isInEditMode = false)
        {
            try
            {
                InitializeComponent();
                ExtensionMethods.SetFormProperties(this);
                ExtensionMethods.FormLoad(this, isInEditMode ? "Customer Ledger -Update" : "Customer Ledger - Add");
                this.isInEditMode = isInEditMode;
                this.customerLedgerID = 0;
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
                LoadCombo();

                if (!isInEditMode)
                    LoadCustomerCompanyDiscountGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCombo()
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

            ////Fill Costumer Type options
            cbxCustomerType.DataSource = applicationFacade.GetCustomerTypes();
            cbxCustomerType.DisplayMember = "CustomerTypeName";
            cbxCustomerType.ValueMember = "CustomerTypeId";

            cbxCustomerType.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxCustomerType.AutoCompleteMode = AutoCompleteMode.Suggest;

            ////Fill Rate Type options
            cbxRateType.DataSource = applicationFacade.GetInterestTypes();
            cbxRateType.DisplayMember = "RateTypeName";
            cbxRateType.ValueMember = "RateTypeId";

            ////Fill Less Excise options
            cbxLessExcise.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbxLessExcise.SelectedItem = Choice.No;


            ////Fill Follow condition strictly options
            cbxFollowConditionStrictly.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbxFollowConditionStrictly.SelectedItem = Choice.No;

            ////Fill discount strictly options
            cbxLocaLCentral.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbxLocaLCentral.SelectedItem = Choice.No;

            ///Fill Local/Central options
            ///
            cbxLocaLCentral.DataSource = Enum.GetValues(typeof(Enums.LocalCentral));
            cbxLocaLCentral.SelectedItem = LocalCentral.L;
        }

        public void LoadCustomerCompanyDiscountGrid()
        {

            List<CustomerCopanyDiscount> customerCopanyDiscountList = applicationFacade.GetCompleteCompanyDiscountListByCustomerID(customerLedgerID);
            dgvCompanyDiscount.DataSource = customerCopanyDiscountList;

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

        private void frmCustomerLedgerMasterAddUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                GotFocusEventRaised(this);
                EnterKeyDownForTabEvents(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void frmCustomerLedgerMasterAddUpdate_Fill_UsingExistingItem(CustomerLedgerMaster customerLedgerMaster)
        {
            if (customerLedgerMaster != null)
            {

                ///Set CustomerId
                ///
                this.customerLedgerID = customerLedgerMaster.CustomerLedgerId;

                ///Fill user control data
                ///
                txtCode.Text = customerLedgerMaster.CustomerLedgerCode;
                txtCustSupplierName.Text = customerLedgerMaster.CustomerLedgerName;
                txtShortName.Text = customerLedgerMaster.CustomerLedgerShortName;
                txtAddress.Text = customerLedgerMaster.Address;
                txtContactPerson.Text = customerLedgerMaster.ContactPerson;
                txtTelephone.Text = customerLedgerMaster.Telephone;
                txtMobile.Text = customerLedgerMaster.Mobile;
                txtPhoneO.Text = customerLedgerMaster.OfficePhone;
                txtPhoneR.Text = customerLedgerMaster.ResidentPhone;
                txtEmailAddress.Text = customerLedgerMaster.EmailAddress;
                txtOpeningBal.Text = Convert.ToString(customerLedgerMaster.OpeningBal);
                cbxCreditDebit.SelectedItem = customerLedgerMaster.CreditDebit == "C" ? Enums.TransType.C : Enums.TransType.D;
                cbxTaxRetail.SelectedItem = customerLedgerMaster.TaxRetail == "T" ? Enums.TaxRetail.T : Enums.TaxRetail.R;
                cbxStatus.SelectedItem = customerLedgerMaster.Status ? Enums.Status.Active : Enums.Status.Inactive;

                tbxZSM.Text = customerLedgerMaster.ZSMName;
                tbxZSM.Tag = customerLedgerMaster.ZSMId;

                tbxRSM.Text = customerLedgerMaster.RSMName;
                tbxRSM.Tag = customerLedgerMaster.RSMId;

                tbxASM.Text = customerLedgerMaster.ASMName;
                tbxASM.Tag = customerLedgerMaster.ASMId;

                tbxSalesman.Text = customerLedgerMaster.SalesmanName;
                tbxSalesman.Tag = customerLedgerMaster.SalesManId;

                tbxArea.Text = customerLedgerMaster.AreaName;
                tbxArea.Tag = customerLedgerMaster.AreaId;

                tbxRoute.Text = customerLedgerMaster.RouteName;
                tbxRoute.Tag = customerLedgerMaster.RouteId;

                tbxDL.Text = customerLedgerMaster.DLNo;
                tbxGST.Text = customerLedgerMaster.GSTNo;
                tbxCIN.Text = customerLedgerMaster.CINNo;
                tbxLIN.Text = customerLedgerMaster.LINNo;
                tbxServiceTax.Text = customerLedgerMaster.ServiceTaxNo;
                tbxPAN.Text = customerLedgerMaster.PANNo;

                tbxCredtLimit.Text = Convert.ToString(customerLedgerMaster.CreditLimit);
                cbxCustomerType.SelectedValue = customerLedgerMaster.CustomerTypeID;
                cbxLessExcise.SelectedItem = customerLedgerMaster.IsLessExcise ? Choice.Yes : Choice.No;
                cbxRateType.SelectedValue = customerLedgerMaster.InterestTypeID;
                tbxSaleBillFormat.Text = customerLedgerMaster.SaleBillFormat;
                tbxMaxOSAmount.Text = Convert.ToString(customerLedgerMaster.MaxOSAmount);
                tbxMaxBillAmmount.Text = Convert.ToString(customerLedgerMaster.MaxBillAmount);
                tbxMaxNumberOfOSBill.Text = Convert.ToString(customerLedgerMaster.MaxNumOfOSBill);
                tbxMaxGracePeriod.Text = Convert.ToString(customerLedgerMaster.MaxGracePeriod);
                cbxFollowConditionStrictly.SelectedItem = customerLedgerMaster.IsFollowConditionStrictly ? Choice.Yes : Choice.No;
                tbxDiscount.Text = Convert.ToString(customerLedgerMaster.Discount);
                cbxLocaLCentral.SelectedItem = customerLedgerMaster.CentralLocal == "L" ? LocalCentral.L : LocalCentral.C;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Set the cursor to appear as busy
                Cursor.Current = Cursors.WaitCursor;

                Choice choice;
                LocalCentral localCentral;
                CustomerLedgerMaster customerLedgerMaster = new CustomerLedgerMaster();

                if (String.IsNullOrWhiteSpace(txtCustSupplierName.Text))
                {
                    MessageBox.Show("Customer Name " + Constants.Messages.RequiredField);
                    return;
                }

                customerLedgerMaster.CustomerLedgerId = this.customerLedgerID;

                //values from User Control
                customerLedgerMaster.CustomerLedgerName = txtCustSupplierName.Text;
                customerLedgerMaster.CustomerLedgerShortName = txtShortName.Text;
                customerLedgerMaster.Address = txtAddress.Text;
                customerLedgerMaster.ContactPerson = txtContactPerson.Text;
                customerLedgerMaster.Telephone = txtTelephone.Text;
                customerLedgerMaster.Mobile = txtMobile.Text;
                customerLedgerMaster.OfficePhone = txtPhoneO.Text;
                customerLedgerMaster.ResidentPhone = txtPhoneR.Text;
                customerLedgerMaster.EmailAddress = txtEmailAddress.Text;
                customerLedgerMaster.OpeningBal = ExtensionMethods.SafeConversionDecimal(txtOpeningBal.Text);
                customerLedgerMaster.CreditDebit = Convert.ToString(cbxCreditDebit.SelectedItem);
                customerLedgerMaster.TaxRetail = Convert.ToString(cbxTaxRetail.SelectedItem);
                customerLedgerMaster.Status = Convert.ToBoolean(cbxStatus.SelectedItem);

                //values from User this form
                customerLedgerMaster.ZSMId = String.IsNullOrWhiteSpace(tbxZSM.Text) ? null : (int?)tbxZSM.Tag;
                customerLedgerMaster.RSMId = String.IsNullOrWhiteSpace(tbxRSM.Text) ? null : (int?)tbxRSM.Tag;
                customerLedgerMaster.ASMId = String.IsNullOrWhiteSpace(tbxASM.Text) ? null : (int?)tbxASM.Tag;
                customerLedgerMaster.AreaId = String.IsNullOrWhiteSpace(tbxSalesman.Text) ? null : (int?)tbxSalesman.Tag;
                customerLedgerMaster.SalesManId = String.IsNullOrWhiteSpace(tbxArea.Text) ? null : (int?)tbxArea.Tag;
                customerLedgerMaster.RouteId = String.IsNullOrWhiteSpace(tbxRoute.Text) ? null : (int?)tbxRoute.Tag;

                customerLedgerMaster.DLNo = tbxDL.Text;
                customerLedgerMaster.GSTNo = tbxGST.Text;
                customerLedgerMaster.CINNo = tbxCIN.Text;
                customerLedgerMaster.LINNo = tbxLIN.Text;
                customerLedgerMaster.ServiceTaxNo = tbxServiceTax.Text;
                customerLedgerMaster.PANNo = tbxPAN.Text;
                customerLedgerMaster.CreditLimit = ExtensionMethods.SafeConversionInt(tbxCredtLimit.Text) ?? default(int);
                customerLedgerMaster.CustomerTypeID = (cbxCustomerType.SelectedItem as CustomerType).CustomerTypeId;

                Enum.TryParse<Choice>(cbxLessExcise.SelectedValue.ToString(), out choice);
                customerLedgerMaster.IsLessExcise = choice == Choice.Yes;

                customerLedgerMaster.InterestTypeID = (cbxRateType.SelectedItem as RateType).RateTypeId;

                customerLedgerMaster.SaleBillFormat = tbxSaleBillFormat.Text;

                customerLedgerMaster.MaxOSAmount = ExtensionMethods.SafeConversionDecimal(tbxMaxOSAmount.Text);
                customerLedgerMaster.MaxBillAmount = ExtensionMethods.SafeConversionDecimal(tbxMaxBillAmmount.Text);
                customerLedgerMaster.MaxNumOfOSBill = ExtensionMethods.SafeConversionInt(tbxMaxNumberOfOSBill.Text);
                customerLedgerMaster.MaxGracePeriod = ExtensionMethods.SafeConversionInt(tbxMaxGracePeriod.Text);

                Enum.TryParse<Choice>(cbxFollowConditionStrictly.SelectedValue.ToString(), out choice);
                customerLedgerMaster.IsFollowConditionStrictly = choice == Choice.Yes;

                customerLedgerMaster.Discount = ExtensionMethods.SafeConversionDecimal(tbxDiscount.Text);

                Enum.TryParse<LocalCentral>(cbxLocaLCentral.SelectedValue.ToString(), out localCentral);
                customerLedgerMaster.CentralLocal = localCentral == LocalCentral.L ? "L" : "C";

                ///Get All the mapping for Company discount 
                ///
                customerLedgerMaster.CustomerCopanyDiscountList = dgvCompanyDiscount.Rows
                                                                                    .Cast<DataGridViewRow>()
                                                                                    .Where(r => !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["Normal"].Value))
                                                                                                || !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["Breakage"].Value))
                                                                                                || !String.IsNullOrWhiteSpace(Convert.ToString(r.Cells["Expired"].Value))
                                                                                    ).Select(x => new CustomerCopanyDiscount()
                                                                                    {
                                                                                        CompanyID = (x.DataBoundItem as CustomerCopanyDiscount).CompanyID,
                                                                                        Normal = (x.DataBoundItem as CustomerCopanyDiscount).Normal,
                                                                                        Breakage = (x.DataBoundItem as CustomerCopanyDiscount).Breakage,
                                                                                        Expired = (x.DataBoundItem as CustomerCopanyDiscount).Expired,
                                                                                        CustomerItemDiscountMapping = (x.DataBoundItem as CustomerCopanyDiscount).CustomerItemDiscountMapping

                                                                                    }).ToList();


                int _result = 0;

                if (isInEditMode)
                {
                    _result = applicationFacade.UpdateCustomerLedger(customerLedgerMaster);
                }
                else
                {
                    _result = applicationFacade.AddCustomerLedger(customerLedgerMaster);
                }

                //Make the Cursor to default
                Cursor.Current = Cursors.Default;

                if (_result > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show(Constants.Messages.ErrorOccured);
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
                errorProviderCustomerLedger.Clear();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCustomerLedgerMasterAddUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            case Constants.RecordType.ZSMDISPLAYNAME:
                                {
                                    tbxZSM.Text = lastSelectedPersonRoute.PersonRouteName;
                                    tbxZSM.Tag = lastSelectedPersonRoute.PersonRouteID;
                                    tbxRSM.Focus();
                                }
                                break;

                            case Constants.RecordType.RSMDISPLAYNAME:
                                {
                                    tbxRSM.Text = lastSelectedPersonRoute.PersonRouteName;
                                    tbxRSM.Tag = lastSelectedPersonRoute.PersonRouteID;
                                    tbxASM.Focus();
                                }
                                break;

                            case Constants.RecordType.ASMDISPLAYNAME:
                                {
                                    tbxASM.Text = lastSelectedPersonRoute.PersonRouteName;
                                    tbxASM.Tag = lastSelectedPersonRoute.PersonRouteID;
                                    tbxSalesman.Focus();
                                }
                                break;

                            case Constants.RecordType.SALESMANDISPLAYNAME:
                                {
                                    tbxSalesman.Text = lastSelectedPersonRoute.PersonRouteName;
                                    tbxSalesman.Tag = lastSelectedPersonRoute.PersonRouteID;
                                    tbxArea.Focus();
                                }
                                break;

                            case Constants.RecordType.AREADISPLAYNAME:
                                {
                                    tbxArea.Text = lastSelectedPersonRoute.PersonRouteName;
                                    tbxArea.Tag = lastSelectedPersonRoute.PersonRouteID;
                                    tbxRoute.Focus();
                                }
                                break;

                            case Constants.RecordType.ROUTEDISPLAYNAME:
                                {
                                    tbxRoute.Text = lastSelectedPersonRoute.PersonRouteName;
                                    tbxRoute.Tag = lastSelectedPersonRoute.PersonRouteID;
                                    tbxMaxOSAmount.Focus();
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Add
            if (keyData == (Keys.Escape))
            {
                if(this.ActiveControl.Name == "dgvCompanyDiscount")
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
                        CustomerCopanyDiscount existingItem = (CustomerCopanyDiscount)dgvCompanyDiscount.Rows[dgvCompanyDiscount.SelectedCells[0].RowIndex].DataBoundItem;
                        frmCustomerItemDiscountMaster form = new frmCustomerItemDiscountMaster(existingItem);
                        form.FormClosed += FormCustomerItemDiscount_FormClosed;
                        form.Show();
                    }
                }
            }
            else if (keyData == Keys.F1)
            {
                ///DO NOT REMOVE BELOW CODE AS ITS WORKING FUNCTIONALITY
                ///

                //TextBox activePersonRouteType = new TextBox();
                //string activePersonRouteTypeString = String.Empty;

                //switch (this.ActiveControl.Name)
                //{
                //    case "tbxZSM":
                //        {
                //            activePersonRouteType = tbxZSM;
                //            activePersonRouteTypeString = Constants.RecordType.ZSMDISPLAYNAME;
                //        }
                //        break;

                //    case "tbxRSM":
                //        {
                //            activePersonRouteType = tbxRSM;
                //            activePersonRouteTypeString = Constants.RecordType.RSMDISPLAYNAME;
                //        }
                //        break;

                //    case "tbxASM":
                //        {
                //            activePersonRouteType = tbxASM;
                //            activePersonRouteTypeString = Constants.RecordType.ASMDISPLAYNAME;
                //        }
                //        break;
                //    case "tbxSalesman":
                //        {
                //            activePersonRouteType = tbxSalesman;
                //            activePersonRouteTypeString = Constants.RecordType.SALESMANDISPLAYNAME;
                //        }
                //        break;
                //    case "tbxArea":
                //        {
                //            activePersonRouteType = tbxArea;
                //            activePersonRouteTypeString = Constants.RecordType.AREADISPLAYNAME;
                //        }
                //        break;
                //    case "tbxRoute":
                //        {
                //            activePersonRouteType = tbxRoute;
                //            activePersonRouteTypeString = Constants.RecordType.ROUTEDISPLAYNAME;
                //        }
                //        break;
                //}

                //if (!String.IsNullOrWhiteSpace(activePersonRouteTypeString))
                //{
                //    PersonRouteMaster personRouteMaster = new PersonRouteMaster()
                //    {
                //        RecordTypeNme = activePersonRouteTypeString,
                //        PersonRouteID = ExtensionMethods.SafeConversionInt(Convert.ToString(activePersonRouteType.Tag)) ?? 0,
                //        PersonRouteName = activePersonRouteType.Text
                //    };

                //    frmPersonRouteMaster frmPersonRouteMaster = new frmPersonRouteMaster();
                //    //Set Child UI
                //    ExtensionMethods.AddChildFormToPanel(this, frmPersonRouteMaster, ExtensionMethods.MainPanel);
                //    frmPersonRouteMaster.WindowState = FormWindowState.Maximized;

                //    frmPersonRouteMaster.FormClosed += FrmPersonRouteMaster_FormClosed;
                //    frmPersonRouteMaster.Show();
                //    frmPersonRouteMaster.ConfigurePersonRoute(personRouteMaster);
                //}
            }

            return base.ProcessCmdKey(ref msg, keyData);
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
                        case "tbxZSM":
                            {
                                activePersonRouteType = tbxZSM;
                                activePersonRouteTypeString = Constants.RecordType.ZSMDISPLAYNAME;
                                isValidTextbox = true;
                            }
                            break;
                        case "tbxRSM":
                            {
                                activePersonRouteType = tbxRSM;
                                activePersonRouteTypeString = Constants.RecordType.RSMDISPLAYNAME;
                                isValidTextbox = true;
                            }
                            break;

                        case "tbxASM":
                            {
                                activePersonRouteType = tbxASM;
                                activePersonRouteTypeString = Constants.RecordType.ASMDISPLAYNAME;
                                isValidTextbox = true;
                            }
                            break;
                        case "tbxSalesman":
                            {
                                activePersonRouteType = tbxSalesman;
                                activePersonRouteTypeString = Constants.RecordType.SALESMANDISPLAYNAME;
                                isValidTextbox = true;
                            }
                            break;
                        case "tbxArea":
                            {
                                activePersonRouteType = tbxArea;
                                activePersonRouteTypeString = Constants.RecordType.AREADISPLAYNAME;
                                isValidTextbox = true;
                            }
                            break;
                        case "tbxRoute":
                            {
                                activePersonRouteType = tbxRoute;
                                activePersonRouteTypeString = Constants.RecordType.ROUTEDISPLAYNAME;
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

        private void FormCustomerItemDiscount_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                CustomerCopanyDiscount updatedCustomerCopanyDiscount = (sender as frmCustomerItemDiscountMaster).retCustomerCopanyDiscount;
                (dgvCompanyDiscount.Rows[dgvCompanyDiscount.SelectedCells[0].RowIndex].DataBoundItem as CustomerCopanyDiscount).CustomerItemDiscountMapping = updatedCustomerCopanyDiscount.CustomerItemDiscountMapping;
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

        private void dgvCompanyDiscount_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCompanyDiscount.CurrentRow.Cells[e.ColumnIndex].ReadOnly)
                {
                    SendKeys.Send("{tab}");
                }
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

        public void ConfigureCustomerLedger(CustomerLedgerMaster model)
        {
            txtCustSupplierName.Text = model.CustomerLedgerName;
        }


    }
}
