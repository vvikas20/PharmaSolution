using PharmaBusinessObjects;
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
    public partial class frmChangeType : Form
    {
        IApplicationFacade applicationFacade;
        public PharmaBusinessObjects.Common.Enums.SaleEntryChangeType ChangeType { get; set; }
        public int RowIndex { get; set; }

        public frmChangeType()
        {
            InitializeComponent();
            ExtensionMethods.SetChildFormProperties(this);
            applicationFacade = new PharmaBusiness.ApplicationFacade(ExtensionMethods.LoggedInUser);
            ChangeType = PharmaBusinessObjects.Common.Enums.SaleEntryChangeType.TemporaryChange;
        }

        public void frmChangeType_Load(object sender, EventArgs e)
        {
            ExtensionMethods.FormLoad(this, "Type of Change");
            dgvChangeType.DataSource = applicationFacade.GetSaleEntryChangeTypes();
            dgvChangeType.Focus();

            if (dgvChangeType.Rows.Count > 0)
            {
                dgvChangeType.CurrentCell = dgvChangeType.Rows[0].Cells[0];
            }
            dgvChangeType.Columns["TypeID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvChangeType.Columns["TypeName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvChangeType.KeyDown += DgvChangeType_KeyDown;
        }

        private void DgvChangeType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

        private void frmChangeType_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dgvChangeType.SelectedCells.Count > 0)
            {
                int rowIndex = dgvChangeType.SelectedCells[0].RowIndex;
                PharmaBusinessObjects.Common.Enums.SaleEntryChangeType change;
                Enum.TryParse(Convert.ToString(dgvChangeType.Rows[rowIndex].Cells["TypeName"].Value), out change);
                ChangeType = change;
            }
        }
    }
}
