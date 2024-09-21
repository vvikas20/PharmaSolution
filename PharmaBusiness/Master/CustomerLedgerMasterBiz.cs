using PharmaBusinessObjects.Master;
using PharmaDAL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness.Master
{
    internal class CustomerLedgerMasterBiz : BaseBiz
    {
        public CustomerLedgerMasterBiz(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        internal List<PharmaBusinessObjects.Master.CustomerLedgerMaster> GetCustomerLedgers(string searchString = null)
        {
            return new CustomerLedgerMasterDao(this.LoggedInUser).GetCustomerLedgers(searchString);
        }

        internal int AddCustomerLedger(PharmaBusinessObjects.Master.CustomerLedgerMaster p)
        {
            return new CustomerLedgerMasterDao(this.LoggedInUser).AddCustomerLedger(p);
        }

        internal int UpdateCustomerLedger(PharmaBusinessObjects.Master.CustomerLedgerMaster p)
        {
            return new CustomerLedgerMasterDao(this.LoggedInUser).UpdateCustomerLedger(p);
        }

        internal List<PharmaBusinessObjects.Master.CustomerCopanyDiscount> GetCompleteCompanyDiscountList(int customerLedgerID)
        {
            return new CustomerLedgerMasterDao(this.LoggedInUser).GetCompleteCompanyDiscountList(customerLedgerID);
        }
        
        internal int DeleteCustomerLedger(int customerLedgerID)
        {
            return new CustomerLedgerMasterDao(this.LoggedInUser).DeleteCustomerLedger(customerLedgerID);
        }

        internal CustomerLedgerMaster GetCustomerLedgerByCode(string customerCode)
        {

            return new CustomerLedgerMasterDao(this.LoggedInUser).GetCustomerLedgerByCode(customerCode);
        }
    }
}
