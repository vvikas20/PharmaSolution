using PharmaBusinessObjects.Master;
using PharmaDAL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness.Master
{
    internal class SupplierLedgerMasterBiz : BaseBiz
    {
        public SupplierLedgerMasterBiz(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        internal List<PharmaBusinessObjects.Master.SupplierLedgerMaster> GetSupplierLedgers(string searchText)
        {
            return new SupplierLedgerMasterDao(this.LoggedInUser).GetSupplierLedgers(searchText);
        }

        internal int AddSupplierLedger(PharmaBusinessObjects.Master.SupplierLedgerMaster p)
        {
            return new SupplierLedgerMasterDao(this.LoggedInUser).AddSupplierLedger(p);
        }

        internal int UpdateSupplierLedger(PharmaBusinessObjects.Master.SupplierLedgerMaster p)
        {
            return new SupplierLedgerMasterDao(this.LoggedInUser).UpdateSupplierLedger(p);
        }

        internal SupplierLedgerMaster GetSupplierLedgerById(int supplierId)
        {
            return new SupplierLedgerMasterDao(this.LoggedInUser).GetSupplierLedgerById(supplierId);
        }

        internal SupplierLedgerMaster GetSupplierLedgerByName(string name)
        {
            SupplierLedgerMaster master = GetSupplierLedgers(string.Empty).Where(p => p.SupplierLedgerCode.ToLower() == name.ToLower()).FirstOrDefault();

            return master;

        }

        internal List<PharmaBusinessObjects.Master.SupplierCompanyDiscount> GetCompleteCompanyDiscountListBySupplierID(int supplierLedgerID)
        {
            return new SupplierLedgerMasterDao(this.LoggedInUser).GetCompleteCompanyDiscountListBySupplierID(supplierLedgerID);
        }
    }
}
