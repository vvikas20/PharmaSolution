using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PharmaDAL.Entity;
using log4net;
using System.Reflection;

namespace PharmaDataMigration.Master
{
    public class PersonalLedgerMaster
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private DBFConnectionManager dbConnection;

        public PersonalLedgerMaster()
        {
            dbConnection = new DBFConnectionManager(Common.DataDirectory);
        }

        public int InsertPersonalLedgerMasterData()
        {
            try
            {
                string query = "select * from ACM where slcd = 'PD'";

                DataTable dtPersonalLedgerMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.PersonalLedger> listPersonalLedgerMaster = new List<PharmaDAL.Entity.PersonalLedger>();

                int _result = 0;
                
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var maxPersonalLedgerID = context.PersonalLedger.Count();

                    if (dtPersonalLedgerMaster != null && dtPersonalLedgerMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtPersonalLedgerMaster.Rows)
                        {
                            try
                            {
                                maxPersonalLedgerID++;

                                string personalLedgerCode = "P" + maxPersonalLedgerID.ToString().PadLeft(6, '0');
                                string originalPersonalLedgerCode = Convert.ToString(dr["ACNO"]).Trim();
                                Common.personalLedgerCodeMap.Add(new PersonalLedgerCodeMap() { OriginalPersonalLedgerCode = originalPersonalLedgerCode, MappedPersonalLedgerCode = personalLedgerCode });

                                PharmaDAL.Entity.PersonalLedger newPersonalLedgerMaster = new PharmaDAL.Entity.PersonalLedger()
                                {
                                    PersonalLedgerCode = personalLedgerCode,
                                    PersonalLedgerName = Convert.ToString(dr["ACName"]).Trim(),
                                    PersonalLedgerShortName = Convert.ToString(dr["Alt_name_1"]).Trim(),
                                    Address = string.Concat(Convert.ToString(dr["ACAD1"]).Trim(), " ", Convert.ToString(dr["ACAD2"]).Trim(), " ", Convert.ToString(dr["ACAD3"]).Trim()),
                                    ContactPerson = Convert.ToString(dr["ACAD4"]).Trim(),
                                    Mobile = Convert.ToString(dr["Mobile"]).Trim(),
                                    //Pager = Convert.ToString(dr["Pager"]).Trim(),
                                    //Fax = Convert.ToString(dr["Fax"]).Trim(),
                                    OfficePhone = Convert.ToString(dr["Telo"]).Trim(),
                                    ResidentPhone = Convert.ToString(dr["Telr"]).Trim(),
                                    EmailAddress = Convert.ToString(dr["Email"]).Trim(),
                                    Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                    CreatedBy = "admin",
                                    CreatedOn = DateTime.Now,
                                    PersonalLedgerShortDesc = Convert.ToString(dr["Alt_name_2"]).Trim()
                                };

                                listPersonalLedgerMaster.Add(newPersonalLedgerMaster);
                            }
                            catch(Exception)
                            {
                                log.Info("PERSONAL LEDGER : Error in ACName --> " + Convert.ToString(dr["ACName"]).Trim());
                            }
                        }
                    }

                    context.PersonalLedger.AddRange(listPersonalLedgerMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
