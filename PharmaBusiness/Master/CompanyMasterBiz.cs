using PharmaBusinessObjects.Master;
using PharmaDAL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness.Master
{
    internal class CompanyMasterBiz : BaseBiz
    {
        public CompanyMasterBiz(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        internal List<CompanyMaster> GetCompanies(string searchText)
        {
            return new CompanyMasterDao(this.LoggedInUser).GetCompanies(searchText);
        }

        internal PharmaBusinessObjects.Master.CompanyMaster GetCompanyById(int companyId)
        {
            PharmaBusinessObjects.Master.CompanyMaster company = new CompanyMasterDao(this.LoggedInUser).GetCompanyById(companyId);
            return company;
        }

        internal int AddCompany(PharmaBusinessObjects.Master.CompanyMaster company)
        {
            return new CompanyMasterDao(this.LoggedInUser).AddCompany(company);
        }

        internal int UpdateCompany(PharmaBusinessObjects.Master.CompanyMaster company)
        {
            return new CompanyMasterDao(this.LoggedInUser).UpdateCompany(company);
        }

        internal int DeleteCompany(int companyId)
        {
            return new CompanyMasterDao(this.LoggedInUser).DeleteCompany(companyId);
        }
    }
}
