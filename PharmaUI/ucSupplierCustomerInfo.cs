using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PharmaBusinessObjects.Common;
using static PharmaBusinessObjects.Common.Enums;

namespace PharmaUI
{
    public partial class ucSupplierCustomerInfo : UserControl
    {
        #region Properties
        public string Code {
            get {
                return txtCode.Text;
            } set {
                txtCode.Text = value;
            }
        }

        public string CustomerSupplierName
        {
            get
            {
                return txtCustSupplierName.Text;
            }
            set
            {
                txtCustSupplierName.Text = value;
            }
        }

        public string ShortName
        {
            get
            {
                return txtShortName.Text;
            }
            set
            {
                txtShortName.Text = value;
            }
        }

        public string Address
        {
            get
            {
                return txtAddress.Text;
            }
            set
            {
                txtAddress.Text = value;
            }
        }

        public string ContactPerson
        {
            get
            {
                return txtContactPerson.Text;
            }
            set
            {
                txtContactPerson.Text = value;
            }
        }

        public string Mobile
        {
            get
            {
                return txtMobile.Text;
            }
            set
            {
                txtMobile.Text = value;
            }
        }

        public string Telephone
        {
            get
            {
                return txtTelephone.Text;
            }
            set
            {
                txtTelephone.Text = value;
            }
        }

        public string EmailAddress
        {
            get
            {
                return txtEmailAddress.Text;
            }
            set
            {
                txtEmailAddress.Text = value;
            }
        }

        public string OfficePhone
        {
            get
            {
                return txtPhoneO.Text;
            }
            set
            {
                txtPhoneO.Text = value;
            }
        }

        public string ResidentPhone
        {
            get
            {
                return txtPhoneR.Text;
            }
            set
            {
                txtPhoneR.Text = value;
            }
        }

        public string OpeningBal
        {
            get
            {
                return txtOpeningBal.Text;
            }
            set
            {
                txtOpeningBal.Text = value;
            }
        }

        public Enums.TransType CreditDebit
        {
            get
            {
                return cbxCreditDebit.SelectedItem == null ? Enums.TransType.C : (Enums.TransType)cbxCreditDebit.SelectedItem;
            }
            set
            {
                cbxCreditDebit.SelectedItem = value;
            }
        }

        public Enums.TaxRetail TaxRetail
        {
            get
            {
                return cbxTaxRetail.SelectedItem == null ? Enums.TaxRetail.R : (Enums.TaxRetail)cbxTaxRetail.SelectedItem;
            }
            set
            {
                cbxTaxRetail.SelectedItem = value;
            }
        }

        public Enums.Status Status
        {
            get
            {
                return cbxStatus.SelectedValue == null ? Enums.Status.Active : (Enums.Status)cbxStatus.SelectedValue;
            }
            set
            {
                cbxStatus.SelectedItem = value;
            }
        }

        public object StatusDataSource
        {
            set
            {
                cbxStatus.DataSource = value;
            }
        }
        #endregion

        public ucSupplierCustomerInfo()
        {
            InitializeComponent();
            CustomerSupplierName = String.Empty;
            FillCombo();

            
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
        }

        public void SetFocus()
        {
            txtCustSupplierName.Focus();
        }

    }
}
