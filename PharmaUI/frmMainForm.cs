using PharmaBusiness;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
using PharmaUI.ReceiptPayment;
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
    public partial class frmMainForm : Form
    {
        IApplicationFacade applicationFacade;

        public frmMainForm()
        {
            try
            {
                InitializeComponent();
                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
                ExtensionMethods.MainPanel = pnlMain;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            try
            {
                pnlMain.Dock = DockStyle.Fill;

                List<Control> allControls = ExtensionMethods.GetAllControls(this);
                allControls.ForEach(k => k.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, ExtensionMethods.FontSize));
                              
               
                // ToggleMenuItems(menuStrip1.Items);
                frmDefault form = new frmDefault();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();

                StagingData.SetItemListData(applicationFacade.GetAllItemsBySearch());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }


        private void accountLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmAccountLedgerMaster form = new frmAccountLedgerMaster();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void companyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmCompany form = new frmCompany();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void itemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmItemMaster form = new frmItemMaster();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          

        }       

        private void personalDiaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmPersonalLedgerMaster form = new frmPersonalLedgerMaster();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void supplierLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmSupplierLedger form = new frmSupplierLedger();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void customerLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomerLedgerMaster form = new frmCustomerLedgerMaster();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void personRouteMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmPersonRouteMaster form = new frmPersonRouteMaster();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void userMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmUserMaster form = new frmUserMaster();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }


        private void ToggleMenuItems(ToolStripItemCollection collection)
        {
            try
            {
                foreach (ToolStripMenuItem item in collection)
                {
                    if (item.Text.ToLower() == "exit" || ExtensionMethods.LoggedInUser.Privledges.Any(x => x.PrivledgeName.ToLower() == item.Text.ToLower()))
                    {
                        continue;
                    }
                    else
                    {
                        item.Visible = false;
                        item.ShortcutKeys = Keys.None;

                        if (item.HasDropDownItems) // if subMenu has children
                        {
                            ToggleMenuItems(item.DropDownItems); // Call recursive Method.
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }


        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmDefault form = new frmDefault();
                ExtensionMethods.AddFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

      

        private void purchaseTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmPurchaseBookTransaction form = new frmPurchaseBookTransaction(false);
                ExtensionMethods.AddTrasanctionFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void saleEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmSaleEntry form = new frmSaleEntry(false,Constants.VoucherTypeCode.SALEENTRY);
                ExtensionMethods.AddTrasanctionFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void receiptFromCustTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmReceiptFromCustomer form = new frmReceiptFromCustomer();
                ExtensionMethods.AddTrasanctionFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmPaymentToSupplier form = new frmPaymentToSupplier();
                ExtensionMethods.AddTrasanctionFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificationPurchaseEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmPurchaseBookTransaction form = new frmPurchaseBookTransaction(true);
                ExtensionMethods.AddTrasanctionFormToPanel(form, pnlMain);
                //frmReportViewer form = new frmReportViewer();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void receiptFromCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmSaleEntry form = new frmSaleEntry(true,Constants.VoucherTypeCode.SALEENTRY);
                ExtensionMethods.AddTrasanctionFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmReceiptFromCustomer formReceipt = new frmReceiptFromCustomer();
                ExtensionMethods.AddTrasanctionFormToPanel(formReceipt, pnlMain);
                formReceipt.ConfigureUIForModification();
                formReceipt.Show();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modifyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                frmPaymentToSupplier formPayment = new frmPaymentToSupplier();
                ExtensionMethods.AddTrasanctionFormToPanel(formPayment, pnlMain);
                formPayment.ConfigureUIForModification();
                formPayment.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saleEntryChallanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmSaleEntry form = new frmSaleEntry(false, Constants.VoucherTypeCode.SALEONCHALLAN);
                ExtensionMethods.AddTrasanctionFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void modificationSaleChallanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmSaleEntry form = new frmSaleEntry(true, Constants.VoucherTypeCode.SALEONCHALLAN);
                ExtensionMethods.AddTrasanctionFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void saleReportToolStripMenuItem_Click(object sender, EventArgs e)
		{
            try
            {
                frmReportViewer form = new frmReportViewer() { StartPosition=FormStartPosition.CenterScreen};
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void gSTInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
		{
            try
            {
                frmSaleEntry form = new frmSaleEntry(true, Constants.VoucherTypeCode.SALEONCHALLAN);
                ExtensionMethods.AddTrasanctionFormToPanel(form, pnlMain);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
	}
}
