using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaBusinessObjects.Master;
using PharmaDAL.Master;
using System.Data;

namespace PharmaBusiness.Master
{
    internal class ItemMasterBiz : BaseBiz
    {
        public ItemMasterBiz(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }
               

        internal bool AddNewItem(ItemMaster newItem)
        {
            return new ItemDaoMaster(this.LoggedInUser).AddNewItem(newItem);
        }

        internal bool UpdateItem(ItemMaster existingItem)
        {
            return new ItemDaoMaster(this.LoggedInUser).UpdateItem(existingItem);
        }

        internal bool DeleteItem(ItemMaster existingItem)
        {
            return new ItemDaoMaster(this.LoggedInUser).DeleteItem(existingItem);
        }

        internal string GetNextItemCode(string companyCode)
        {
            int totalItemsFromSameCompany =  new ItemDaoMaster(this.LoggedInUser).TotalItemsFromSameCompany(companyCode);
            totalItemsFromSameCompany++;
            string getNextItemCode=String.Concat(companyCode, totalItemsFromSameCompany.ToString().PadLeft(6, '0'));
            return getNextItemCode;
        }

        internal List<CustomerCopanyDiscount> GetAllCompanyItemDiscountByCompanyIDForCustomer(int CompanyID)
        {
            List<CustomerCopanyDiscount> defaultItemDiscountByCompanyID = new List<CustomerCopanyDiscount>();
            List<ItemMaster> itemListByCompanyID = new ItemDaoMaster(this.LoggedInUser).GetAllItemByCompanyID(CompanyID);

            if (itemListByCompanyID != null)
            {
                defaultItemDiscountByCompanyID = itemListByCompanyID.Select(item => new CustomerCopanyDiscount()
                {
                    CompanyID=item.CompanyID,
                    CompanyName=item.CompanyName,
                    ItemID=item.ItemID,
                    ItemName=item.ItemName

                }).ToList();
            }
            return defaultItemDiscountByCompanyID;
        }

        internal List<SupplierCompanyDiscount> GetAllCompanyItemDiscountByCompanyIDForSupplier(int CompanyID)
        {
            List<SupplierCompanyDiscount> defaultItemDiscountByCompanyID = new List<SupplierCompanyDiscount>();
            List<ItemMaster> itemListByCompanyID = new ItemDaoMaster(this.LoggedInUser).GetAllItemByCompanyID(CompanyID);

            if (itemListByCompanyID != null)
            {
                defaultItemDiscountByCompanyID = itemListByCompanyID.Select(item => new SupplierCompanyDiscount()
                {
                    CompanyID = item.CompanyID,
                    CompanyName = item.CompanyName,
                    ItemID = item.ItemID,
                    ItemName = item.ItemName

                }).ToList();
            }
            return defaultItemDiscountByCompanyID;
        }


        internal List<PharmaBusinessObjects.Master.HSNCodes> GetAllHSNCodes()
        {
            return new ItemDaoMaster(this.LoggedInUser).GetAllHSNCodes();
        }

        internal DataTable GetAllItemsBySearch()
        {
            return new ItemDaoMaster(this.LoggedInUser).GetAllItemsBySearch();
        }

        internal List<PharmaBusinessObjects.Transaction.FifoBatches> GetFifoBatchesByItemCode(string itemCode)
        {
            return new ItemDaoMaster(this.LoggedInUser).GetFifoBatchesByItemCode(itemCode);
        }

        public int UpdateFifoBatchesByItemCode(PharmaBusinessObjects.Transaction.FifoBatches fifoBatch)
        {
            return new ItemDaoMaster(this.LoggedInUser).UpdateFifoBatchesByItemCode(fifoBatch);
        }
    }
}
