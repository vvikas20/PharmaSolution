using PharmaBusinessObjects;
using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Transaction;
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

namespace PharmaUI.Purchase_Entry
{
    public partial class frmLineItemScheme : Form
    {
        IApplicationFacade applicationFacade;
        PurchaseSaleBookLineItem purchaseBookLineItem;
        public int RowIndex { get; set; }

        public PurchaseSaleBookLineItem PurchaseBookLinetem { get { return purchaseBookLineItem; } }

        public frmLineItemScheme(PurchaseSaleBookLineItem lineItem)
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new PharmaBusiness.ApplicationFacade(ExtensionMethods.LoggedInUser);
            purchaseBookLineItem = lineItem;
        }

        private void frmLineItemScheme_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, string.Format("Item - {0} Update",purchaseBookLineItem.ItemName));

            GotFocusEventRaised(this);
            EnterKeyDownForTabEvents(this);

            //Fill half Scheme options
            cbxHalfScheme.DataSource = Enum.GetValues(typeof(Enums.Choice));
            cbxHalfScheme.SelectedItem = Choice.No;

            FillFormForUpdate();

            txtScheme1.Focus();

        }

        private void FillFormForUpdate()
        {
            if (purchaseBookLineItem != null)
            {
                txtScheme1.Text = Convert.ToString(purchaseBookLineItem.Scheme1);
                txtScheme2.Text = Convert.ToString(purchaseBookLineItem.Scheme2);
                cbxHalfScheme.SelectedItem = purchaseBookLineItem.IsHalfScheme ? Choice.Yes : Choice.No;
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

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Escape || keyData == Keys.End)
        //    {
        //        this.Close();

        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        //private void cbxHalfScheme_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if(e.KeyData == Keys.Enter)
        //    {
        //        this.Close();
        //    }
        //}

        private void frmLineItemScheme_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataRow dr = StagingData.ItemList.Select("ItemCode=" + purchaseBookLineItem.ItemCode).FirstOrDefault();
            if (dr != null)
            {

                decimal scheme1 = 0;
                decimal.TryParse(txtScheme1.Text, out scheme1);

                decimal scheme2 = 0;
                decimal.TryParse(txtScheme2.Text, out scheme2);

                Choice choice;
                Enum.TryParse<Choice>(cbxHalfScheme.SelectedValue.ToString(), out choice);


                purchaseBookLineItem.Scheme1 = scheme1;
                purchaseBookLineItem.Scheme2 = scheme2;
                purchaseBookLineItem.IsHalfScheme = choice == Choice.Yes;

                dr["Scheme1"] = scheme1;
                dr["Scheme2"] = scheme2;
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
                Control ctl = sender as Control;

                if (ctl.Name == "cbxHalfScheme")
                {
                    this.Close();
                }
                else
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
            }
        }

    }
}
