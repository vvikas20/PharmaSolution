using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaBusinessObjects;
using PharmaBusinessObjects.Master;
using PharmaBusiness.Master;
using PharmaBusiness.Common;
using PharmaBusinessObjects.Transaction;
using PharmaBusiness.Transaction;
using PharmaBusinessObjects.Transaction.ReceiptPayment;
using PharmaBusinessObjects.Transaction.SaleEntry;
using System.Data;

namespace PharmaBusiness
{
    public class ApplicationFacade : IApplicationFacade
    {
        PharmaBusinessObjects.Master.UserMaster LoggedInUser { get; set; }
        public ApplicationFacade(PharmaBusinessObjects.Master.UserMaster loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
        }


        #region Item Master

           /// <summary>
        /// Add new item to ItemMaster
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns>true if added successfully</returns>
        public bool AddNewItem(ItemMaster newItem)
        {
            try
            {
                return new ItemMasterBiz(this.LoggedInUser).AddNewItem(newItem);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<PharmaBusinessObjects.Master.HSNCodes> GetAllHSNCodes()
        {
            try
            {
                return new ItemMasterBiz(this.LoggedInUser).GetAllHSNCodes();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update an existing item from ItemMaster
        /// </summary>
        /// <param name="existingItem"></param>
        /// <returns>True if updated is succesfull</returns>
        public bool UpdateItem(ItemMaster existingItem)
        {
            try
            {
                return new ItemMasterBiz(this.LoggedInUser).UpdateItem(existingItem);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete an existing item from ItemMaster
        /// </summary>
        /// <param name="existingItem"></param>
        /// <returns>True if deletion is successfull</returns>
        public bool DeleteItem(ItemMaster existingItem)
        {
            try
            {
                return new ItemMasterBiz(this.LoggedInUser).DeleteItem(existingItem);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get next item code based on the company code
        /// </summary>
        /// <param name="companyCode"></param>
        /// <returns>next item code</returns>
        public string GetNextItemCode(string companyCode)
        {
            try
            {
                return new ItemMasterBiz(this.LoggedInUser).GetNextItemCode(companyCode);
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        public DataTable GetAllItemsBySearch()
        {
            try
            {
                return new ItemMasterBiz(this.LoggedInUser).GetAllItemsBySearch();
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public List<PharmaBusinessObjects.Transaction.FifoBatches> GetFifoBatchesByItemCode(string itemCode)
        {
            return new ItemMasterBiz(this.LoggedInUser).GetFifoBatchesByItemCode(itemCode);
        }

        public int UpdateFifoBatchesByItemCode(PharmaBusinessObjects.Transaction.FifoBatches fifoBatch)
        {
            return new ItemMasterBiz(this.LoggedInUser).UpdateFifoBatchesByItemCode(fifoBatch);
        }



        #endregion

        #region Company Master

        /// <summary>
        /// Add new company to CompanyMaster
        /// </summary>
        /// <returns>List of companies</returns>
        public List<CompanyMaster> GetCompanies(string searchText)
        {
            try
            {
                return new CompanyMasterBiz(this.LoggedInUser).GetCompanies(searchText);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PharmaBusinessObjects.Master.CompanyMaster GetCompanyById(int companyID)
        {
            try
            {
                return new CompanyMasterBiz(this.LoggedInUser).GetCompanyById(companyID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int AddCompany(PharmaBusinessObjects.Master.CompanyMaster company)
        {

            try
            {
                return new CompanyMasterBiz(this.LoggedInUser).AddCompany(company);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int UpdateCompany(PharmaBusinessObjects.Master.CompanyMaster company)
        {
            try
            {
                return new CompanyMasterBiz(this.LoggedInUser).UpdateCompany(company);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int DeleteCompany(int companyId)
        {
            try
            {
                return new CompanyMasterBiz(this.LoggedInUser).DeleteCompany(companyId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get default item discount for company
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public List<CustomerCopanyDiscount> GetAllCompanyItemDiscountByCompanyIDForCustomer(int CompanyID)
        {
            try
            {
                return new ItemMasterBiz(this.LoggedInUser).GetAllCompanyItemDiscountByCompanyIDForCustomer(CompanyID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get default item discount for company
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public List<SupplierCompanyDiscount> GetAllCompanyItemDiscountByCompanyIDForSupplier(int CompanyID)
        {
            try
            {
                return new ItemMasterBiz(this.LoggedInUser).GetAllCompanyItemDiscountByCompanyIDForSupplier(CompanyID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Account Ledger Master

        public List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgers()
        {
            try
            {
                return new AccountLedgerMasterBiz(this.LoggedInUser).GetAccountLedgers();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public PharmaBusinessObjects.Master.AccountLedgerMaster GetAccountLedgerById(int accountLedgerID)
        {
            try
            {
                return new AccountLedgerMasterBiz(this.LoggedInUser).GetAccountLedgerById(accountLedgerID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgerByLedgerTypeIdAndSearch(int ledgerTypeID, string searchString = null)
        {
            try
            {
                return new AccountLedgerMasterBiz(this.LoggedInUser).GetAccountLedgerByLedgerTypeIdAndSearch(ledgerTypeID, searchString);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public int AddAccountLedger(PharmaBusinessObjects.Master.AccountLedgerMaster p)
        {

            try
            {
                return new AccountLedgerMasterBiz(this.LoggedInUser).AddAccountLedger(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int UpdateAccountLedger(PharmaBusinessObjects.Master.AccountLedgerMaster p)
        {
            try
            {
                return new AccountLedgerMasterBiz(this.LoggedInUser).UpdateAccountLedger(p);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgerBySystemName(string systemName)
        {
            try
            {
                return new AccountLedgerMasterBiz(this.LoggedInUser).GetAccountLedgerBySystemName(systemName);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PharmaBusinessObjects.Master.AccountLedgerMaster GetAccountLedgerByCode(string code)
        {
            try
            {
                return new AccountLedgerMasterBiz(this.LoggedInUser).GetAccountLedgerByCode(code);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Common
        public PharmaBusinessObjects.Common.AccountLedgerType GetAccountLedgerTypeByName(string name)
        {
            return new CommonBiz().GetAccountLedgerTypeByName(name);
        }

        public List<PharmaBusinessObjects.Common.AccountLedgerType> GetAccountLedgerTypesWithAll()
        {
            return new CommonBiz().GetAccountLedgerTypesWithAll();
        }

        public List<PharmaBusinessObjects.Common.AccountType> GetAccountTypes()
        {
            return new CommonBiz().GetAccountTypes();
        }

        public List<PharmaBusinessObjects.Common.AccountLedgerType> GetAccountLedgerTypes()
        {
            return new CommonBiz().GetAccountLedgerTypes();
        }

        public List<PharmaBusinessObjects.Common.CustomerType> GetCustomerTypes()
        {
            return new CommonBiz().GetCustomerTypes();
        }

        public List<PharmaBusinessObjects.Common.RateType> GetInterestTypes()
        {
            return new CommonBiz().GetInterestTypes();
        }

        public List<PharmaBusinessObjects.Common.PersonLedgerType> GetPersonLedgerTypes()
        {
            return new CommonBiz().GetPersonLedgerTypes();
        }

        public List<PharmaBusinessObjects.Common.RecordType> GetRecordTypes()
        {
            return new CommonBiz().GetRecordTypes();
        }

        public List<PharmaBusinessObjects.Common.RecordType> GetRecordTypesWithAll()
        {
            return new CommonBiz().GetRecordTypesWithAll();
        }





        #endregion

        #region Personal Ledger Master

        public List<PharmaBusinessObjects.Master.PersonalLedgerMaster> GetPersonalLedgers(string searchString)
        {
            try
            {
                return new PersonalLedgerMasterBiz(this.LoggedInUser).GetPersonalLedgers(searchString);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int AddPersonalLedger(PharmaBusinessObjects.Master.PersonalLedgerMaster p)
        {
            try
            {
                return new PersonalLedgerMasterBiz(this.LoggedInUser).AddPersonalLedger(p);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int UpdatePersonalLedger(PharmaBusinessObjects.Master.PersonalLedgerMaster p)
        {
            try
            {
                return new PersonalLedgerMasterBiz(this.LoggedInUser).UpdatePersonalLedger(p);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int DeletePersonalLedger(PharmaBusinessObjects.Master.PersonalLedgerMaster p)
        {
            try
            {
                return new PersonalLedgerMasterBiz(this.LoggedInUser).DeletePersonalLedger(p);
            }
            catch (Exception)
            {

                throw;
            }

        }


        #endregion

        #region  Supplier Ledger Master

        public List<SupplierLedgerMaster> GetSupplierLedgers(string searchText)
        {
            try
            {
                return new SupplierLedgerMasterBiz(this.LoggedInUser).GetSupplierLedgers(searchText);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SupplierLedgerMaster GetSupplierLedgerById(int supplierId)
        {
            try
            {
                return new SupplierLedgerMasterBiz(this.LoggedInUser).GetSupplierLedgerById(supplierId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public SupplierLedgerMaster GetSupplierLedgerByName(string name)
        {
            try
            {
                return new SupplierLedgerMasterBiz(this.LoggedInUser).GetSupplierLedgerByName(name);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int AddSupplierLedger(SupplierLedgerMaster p)
        {
            try
            {
                return new SupplierLedgerMasterBiz(this.LoggedInUser).AddSupplierLedger(p);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int UpdateSupplierLedger(SupplierLedgerMaster p)
        {
            try
            {
                return new SupplierLedgerMasterBiz(this.LoggedInUser).UpdateSupplierLedger(p);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<PharmaBusinessObjects.Master.SupplierCompanyDiscount> GetCompleteCompanyDiscountListBySupplierID(int supplierLedgerID)
        {
            try
            {
                return new SupplierLedgerMasterBiz(this.LoggedInUser).GetCompleteCompanyDiscountListBySupplierID(supplierLedgerID);
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        #region Person Route Master

        public List<PersonRouteMaster> GetPersonRoutes()
        {
            try
            {
                return new PersonRouteMasterBiz(this.LoggedInUser).GetPersonRoutes();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AddPersonRoute(PersonRouteMaster p)
        {
            try
            {
                return new PersonRouteMasterBiz(this.LoggedInUser).AddPersonRoute(p);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdatePersonRoute(PersonRouteMaster p)
        {
            try
            {
                return new PersonRouteMasterBiz(this.LoggedInUser).UpdatePersonRoute(p);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PharmaBusinessObjects.Master.PersonRouteMaster> GetPersonRoutesByRecordTypeIdAndSearch(int recordTypeID, string searchString = null)
        {
            try
            {
                return new PersonRouteMasterBiz(this.LoggedInUser).GetPersonRoutesByRecordTypeIdAndSearch(recordTypeID, searchString);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<PersonRouteMaster> GetPersonRoutesBySystemName(string systemName)
        {
            try
            {
                return new PersonRouteMasterBiz(this.LoggedInUser).GetPersonRoutesBySystemName(systemName);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public PersonRouteMaster GetPersonRouteMasterByCode(string personRouteCode)
        {
            try
            {
                return new PersonRouteMasterBiz(this.LoggedInUser).GetPersonRouteMasterByCode(personRouteCode);

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Customer Ledger Master

        public List<CustomerLedgerMaster> GetCustomerLedgers(string searchString = null)
        {
            try
            {
                return new CustomerLedgerMasterBiz(this.LoggedInUser).GetCustomerLedgers(searchString);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AddCustomerLedger(CustomerLedgerMaster p)
        {
            try
            {
                return new CustomerLedgerMasterBiz(this.LoggedInUser).AddCustomerLedger(p);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdateCustomerLedger(CustomerLedgerMaster p)
        {
            try
            {
                return new CustomerLedgerMasterBiz(this.LoggedInUser).UpdateCustomerLedger(p);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<PharmaBusinessObjects.Master.CustomerCopanyDiscount> GetCompleteCompanyDiscountListByCustomerID(int customerLedgerID)
        {
            try
            {
                return new CustomerLedgerMasterBiz(this.LoggedInUser).GetCompleteCompanyDiscountList(customerLedgerID);
            }
            catch (Exception)
            {
                throw;
            }
        }



        public int DeleteCustomerLedger(int customerLedgerID)
        {
            try
            {
                return new CustomerLedgerMasterBiz(this.LoggedInUser).DeleteCustomerLedger(customerLedgerID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public CustomerLedgerMaster GetCustomerLedgerByCode(string code)
        {
            try
            {
                return new CustomerLedgerMasterBiz(this.LoggedInUser).GetCustomerLedgerByCode(code);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region User Master

        public List<PharmaBusinessObjects.Master.UserMaster> GetUsers(string searchText)        {
            return new UserBiz(this.LoggedInUser).GetUsers(searchText);
        }
        public PharmaBusinessObjects.Master.UserMaster GetUserByUserName(string userName)
        {
            return new UserBiz(this.LoggedInUser).GetUserByUserName(userName);
        }
        public PharmaBusinessObjects.Master.UserMaster GetUserByUserId(int userid)
        {
            return new UserBiz(this.LoggedInUser).GetUserByUserId(userid);
        }
        public int AddUser(PharmaBusinessObjects.Master.UserMaster p)
        {
            return new UserBiz(this.LoggedInUser).AddUser(p);
        }
        public int UpdateUser(PharmaBusinessObjects.Master.UserMaster p)
        {
            return new UserBiz(this.LoggedInUser).UpdateUser(p);
        }
        public List<PharmaBusinessObjects.Master.Role> GetRoles(string searchText)
        {
            return new UserBiz(this.LoggedInUser).GetRoles(searchText);
        }
        public List<PharmaBusinessObjects.Master.Role> GetActiveRoles()
        {
            return new UserBiz(this.LoggedInUser).GetActiveRoles();
        }
        public PharmaBusinessObjects.Master.Role GetRoleById(int userid)
        {
            return new UserBiz(this.LoggedInUser).GetRoleById(userid);
        }
        public bool AddRole(PharmaBusinessObjects.Master.Role p)
        {
            return new UserBiz(this.LoggedInUser).AddRole(p);
        }
        public bool UpdateRole(PharmaBusinessObjects.Master.Role p)
        {
            return new UserBiz(this.LoggedInUser).UpdateRole(p);
        }
        public List<PharmaBusinessObjects.Master.Privledge> GetPrivledges(string searchText)
        {
            return new UserBiz(this.LoggedInUser).GetPrivledges(searchText);
        }
        public List<PharmaBusinessObjects.Master.Privledge> GetActivePrivledges()
        {
            return new UserBiz(this.LoggedInUser).GetActivePrivledges();
        }
        public PharmaBusinessObjects.Master.Privledge GetPrivledgeById(int userid)
        {
            return new UserBiz(this.LoggedInUser).GetPrivledgeById(userid);
        }
        public bool AddPrivledge(PharmaBusinessObjects.Master.Privledge p)
        {
            return new UserBiz(this.LoggedInUser).AddPrivledge(p);
        }
        public bool UpdatePrivledge(PharmaBusinessObjects.Master.Privledge p)
        {
            return new UserBiz(this.LoggedInUser).UpdatePrivledge(p);
        }

        public PharmaBusinessObjects.Master.UserMaster ValidateUser(string userName, string password)
        {
            return new UserBiz(this.LoggedInUser).ValidateUser(userName, password);
        }

        #endregion

        #region Purchase Entry     

        public long InsertUpdateTempPurchaseBookHeader(PurchaseSaleBookHeader header)
        {
            return new Transaction.PurchaseBookBiz(this.LoggedInUser).InsertUpdateTempPurchaseBookHeader(header);
        }        

        public List<PharmaBusinessObjects.Transaction.PurchaseType> GetPurchaseEntryTypes()
        {
            return new Transaction.PurchaseBookBiz(this.LoggedInUser).GetPurchaseEntryTypes();
        }

        public List<PharmaBusinessObjects.Transaction.PurchaseFormType> GetPurchaseFormTypes(int purchaseTypeID)
        {
            return new Transaction.PurchaseBookBiz(this.LoggedInUser).GetPurchaseFormTypes(purchaseTypeID);
        }
               
        public List<PurchaseBookAmount> InsertUpdateTempPurchaseBookLineItem(PurchaseSaleBookLineItem lineItem)
        {
            return new Transaction.PurchaseBookBiz(this.LoggedInUser).InsertUpdateTempPurchaseBookLineItem(lineItem);
        }

        public bool IsTempPurchaseHeaderExists(long purchaseBookHeaderID)
        {
            return new Transaction.PurchaseBookBiz(this.LoggedInUser).IsTempPurchaseHeaderExists(purchaseBookHeaderID);
        }

        public List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> GetLastNBatchNoForSupplierItem(string supplierCode, string itemCode)
        {
            return new Transaction.PurchaseBookBiz(this.LoggedInUser).GetLastNBatchNoForSupplierItem(supplierCode,itemCode);
        }

        public bool SavePurchaseData(long purchaseBookHeaderID)
        {
            return new Transaction.PurchaseBookBiz(this.LoggedInUser).SavePurchaseData(purchaseBookHeaderID);
        }

        public List<PharmaBusinessObjects.Transaction.PurchaseBookAmount> GetFinalAmountWithTaxForPurchase(long purchaseBookHeaderID)
        {
            return new Transaction.PurchaseBookBiz(this.LoggedInUser).GetFinalAmountWithTaxForPurchase(purchaseBookHeaderID);
        }

        public List<PurchaseBookAmount> DeleteTempPurchaseBookLineItem(PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem lineItem)
        {
            return new Transaction.PurchaseBookBiz(this.LoggedInUser).DeleteTempPurchaseBookLineItem(lineItem);
        }

        public List<BillOutstanding> GetAllPurchaseInvoiceForSuppier(string supplierCode, string date)
        {
            return new Transaction.PurchaseBookBiz(this.LoggedInUser).GetAllPurchaseInvoiceForSuppier(supplierCode,date);
        }

        public List<BillOutstanding> GetAllSaleInvoiceForCustomer(string customerCode, string invoiceDate)
        {
            return new Transaction.SaleBiz(this.LoggedInUser).GetAllSaleInvoiceForCustomer(customerCode, invoiceDate);
        }


        public List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> GetPurchaseSaleBookLineItemForModify(long purchaseSaleBookHeaderID)
        {
            return new Transaction.PurchaseBookBiz(this.LoggedInUser).GetPurchaseSaleBookLineItemForModify(purchaseSaleBookHeaderID);
        }

        public List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> GetSaleChallanLineItems(long saleChallanHeaderID, long purchaseSaleBookHeaderID)
        {
            return new SaleBiz(this.LoggedInUser).GetSaleChallanLineItems(saleChallanHeaderID, purchaseSaleBookHeaderID);
        }

        public PharmaBusinessObjects.Transaction.PurchaseSaleBookHeader GetPurchaseSaleBookHeaderForModify(long purchaseSaleBookHeaderID)
        {
            return new Transaction.PurchaseBookBiz(this.LoggedInUser).GetPurchaseSaleBookHeaderForModify(purchaseSaleBookHeaderID);
        }

        public bool DeleteUnSavedData(long purchaseSaleBookHeaderID)
        {
            return new Transaction.PurchaseBookBiz(this.LoggedInUser).DeleteUnSavedData(purchaseSaleBookHeaderID);
        }


        #endregion

        #region ReceiptPayment 

        public List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding> GetAllBillOutstandingForLedger(TransactionEntity transactionEntity)
        {
            try
            {
                return new ReceiptPaymentBiz(this.LoggedInUser).GetAllBillOutstandingForLedger(transactionEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillAdjusted> GetAllTempBillAdjustmentForLedger(TransactionEntity transactionEntity)
        {
            try
            {
                return new ReceiptPaymentBiz(this.LoggedInUser).GetAllTempBillAdjustmentForLedger(transactionEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        public List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillAdjusted> GetAllInitialBillAdjustmentForLedger(TransactionEntity transactionEntity)
        {
            try
            {
                return new ReceiptPaymentBiz(this.LoggedInUser).GetAllInitialBillAdjustmentForLedger(transactionEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public long InsertUpdateTempReceiptPayment(PharmaBusinessObjects.Transaction.ReceiptPayment.ReceiptPaymentItem receiptPayment)
        {
            try
            {
                return new ReceiptPaymentBiz(this.LoggedInUser).InsertUpdateTempReceiptPayment(receiptPayment);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public PharmaBusinessObjects.Transaction.ReceiptPayment.ReceiptPaymentItem GetTransactionByTransactionID(long transactionID)
        {
            try
            {
                return new ReceiptPaymentBiz(this.LoggedInUser).GetTransactionByTransactionID(transactionID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertTempBillAdjustment(List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillAdjusted> billAdjustmentList)
        {
            try
            {
                 new ReceiptPaymentBiz(this.LoggedInUser).InsertTempBillAdjustment(billAdjustmentList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ClearTempBillAdjustment(TransactionEntity transactionEntity)
        {
            try
            {
                new ReceiptPaymentBiz(this.LoggedInUser).ClearTempBillAdjustment(transactionEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void ClearTempTransaction(TransactionEntity transactionEntity)
        {
            try
            {
                new ReceiptPaymentBiz(this.LoggedInUser).ClearTempTransaction(transactionEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ClearUnsavedReceiptPayment(List<int> unsavedReceiptPaymentIDs)
        {
            try
            {
                new ReceiptPaymentBiz(this.LoggedInUser).ClearUnsavedReceiptPayment(unsavedReceiptPaymentIDs);
            }
            catch (Exception)
            {
                throw;
            }
        }
        

        public void SaveAllTempTransaction(List<long> tempReceiptPaymentList)
        {
            try
            {
                new ReceiptPaymentBiz(this.LoggedInUser).SaveAllTempTransaction(tempReceiptPaymentList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PharmaBusinessObjects.Transaction.ReceiptPayment.ReceiptPaymentItem> GetAllTransactionForParticularDate(DateTime transDate , string transactionEntityType)
        {
            try
            {
                return new ReceiptPaymentBiz(this.LoggedInUser).GetAllTransactionForParticularDate(transDate, transactionEntityType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Sale Entry

        public List<SaleChangeType> GetSaleEntryChangeTypes()
        {
            try
            {
                return new SaleBiz(this.LoggedInUser).GetTypeOfChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public PurchaseSaleBookLineItem GetNewSaleLineItem(string itemCode, string customerCode)
        {
            try
            {
                return new SaleBiz(this.LoggedInUser).GetNewSaleLineItem(itemCode, customerCode);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SaleLineItemInfo GetSaleLineItemInfo(string code, long fifoID)
        {
            try
            {
                return new SaleBiz(this.LoggedInUser).GetSaleLineItemInfo(code, fifoID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> InsertUpdateTempPurchaseBookLineItemForSale(PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem lineItem)
        {
            try
            {
                return new SaleBiz(this.LoggedInUser).InsertUpdateTempPurchaseBookLineItemForSale(lineItem);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateSaleDiscount(PharmaBusinessObjects.Common.Enums.SaleEntryChangeType changeType, decimal discount, decimal specialDiscount, decimal volumeDiscount,string itemCode, string customerCode)
        {
            try
            {
                new SaleBiz(this.LoggedInUser).UpdateSaleDiscount(changeType, discount, specialDiscount, volumeDiscount, itemCode, customerCode);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> DeleteSaleLineItem(int saleBookHeaderID, int saleBookLineItemID)
        {
            return new SaleBiz(this.LoggedInUser).DeleteSaleLineItem(saleBookHeaderID, saleBookLineItemID);
        }

        public bool IsQuantityAvailable(long headerID, long lineItemID, string itemCode, decimal quantity, decimal freeQuantity, ref decimal calcFreeQuantity)
        {
            return new SaleBiz(this.LoggedInUser).IsQuantityAvailable(headerID, lineItemID, itemCode, quantity, freeQuantity, ref calcFreeQuantity);
        }

        public long SaveSaleEntryData(long purchaseBookHeaderID)
        {
            return new SaleBiz(this.LoggedInUser).SaveSaleEntryData(purchaseBookHeaderID);
        }

        public bool IsTempSaleEntryExists(long purchaseSaleBookHeaderID)
        {
            return new SaleBiz(this.LoggedInUser).IsTempSaleEntryExists(purchaseSaleBookHeaderID);
        }

        public void RollbackSaleEntry(long purchaseSaleBookHeaderID)
        {
            new SaleBiz(this.LoggedInUser).RollbackSaleEntry(purchaseSaleBookHeaderID);
        }

        public List<BillOutstanding> GetSaleChallanForCustomer(string customerCode, string invoiceDate)
        {
            return new SaleBiz(this.LoggedInUser).GetSaleChallanForCustomer(customerCode, invoiceDate);
        }
            #endregion
            #region "Reports"

            public DataTable GetSaleInvoiceData(long purchaseSaleBookHeaderID)
        {
            return new ReportBiz(LoggedInUser).GetSaleInvoiceData(purchaseSaleBookHeaderID);

        }

        public DataTable GetFirmProperties(int purchaseSaleBookHeaderID)
        {
            return new ReportBiz(LoggedInUser).GetFirmProperties(purchaseSaleBookHeaderID);
        }

        #endregion

    }
}
