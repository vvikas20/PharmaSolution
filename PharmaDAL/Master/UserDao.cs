using PharmaBusinessObjects.Master;
using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaDAL.Master
{
    public class UserDao : BaseDao
    {
        public UserDao(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        public List<PharmaBusinessObjects.Master.UserMaster> GetUsers(string searchText)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.Users.Where(p=>string.IsNullOrEmpty(searchText) || p.Username.ToLower().Contains(searchText.ToLower()) 
                            || p.FirstName.ToLower().Contains(searchText.ToLower()) || p.LastName.ToLower().Contains(searchText.ToLower()))
                            .Select(p => new PharmaBusinessObjects.Master.UserMaster()
                            {
                                UserId = p.UserId,
                                Username = p.Username,
                                Password = p.Password,
                                FirstName = p.FirstName,
                                LastName = p.LastName,
                                RoleID = p.RoleID ?? 0,
                                RoleName = p.Roles.RoleName,
                                IsSystemAdmin = p.IsSysAdmin,
                                CreatedBy = p.CreatedBy,
                                CreatedOn = p.CreatedOn,
                                ModifiedBy = p.ModifiedBy,
                                ModifiedOn = p.ModifiedOn,
                                Status = p.Status
                            }).ToList();
            }
        }
        
        public PharmaBusinessObjects.Master.UserMaster GetUserByUserName(string userName)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.Users.Where(p=>p.Username == userName && p.Status).Select(p => new PharmaBusinessObjects.Master.UserMaster()
                {
                    UserId = p.UserId,
                    Username = p.Username,
                    Password = p.Password,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    RoleID = p.RoleID ?? 0,
                    RoleName = p.Roles.RoleName,
                    IsSystemAdmin = p.IsSysAdmin,
                    CreatedBy = p.CreatedBy,
                    CreatedOn = p.CreatedOn,
                    ModifiedBy = p.ModifiedBy,
                    ModifiedOn = p.ModifiedOn,
                    Status = p.Status,
                    Privledges = p.Roles.RolePrivledges.Where(x=>x.Privledges.Status).Select(x=>new Privledge() {
                                PrivledgeId = x.PrivledgeId,
                                PrivledgeName = x.Privledges.PriviledgeName,
                                ControlName = x.Privledges.ControlName,
                                Status = x.Privledges.Status
                                }).ToList()
                }).FirstOrDefault();
            }
        }


        public PharmaBusinessObjects.Master.UserMaster GetUserByUserId(int userid)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.Users.Where(p => p.UserId == userid).Select(p => new PharmaBusinessObjects.Master.UserMaster()
                {
                    UserId = p.UserId,
                    Username = p.Username,
                    Password = p.Password,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    RoleID = p.RoleID ?? 0,
                    RoleName = p.Roles.RoleName,
                    IsSystemAdmin = p.IsSysAdmin,
                    CreatedBy = p.CreatedBy,
                    CreatedOn = p.CreatedOn,
                    ModifiedBy = p.ModifiedBy,
                    ModifiedOn = p.ModifiedOn,
                    Status = p.Status
                }).FirstOrDefault();
            }
        }

        public int AddUser(PharmaBusinessObjects.Master.UserMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                Entity.Users table = new Entity.Users()
                {
                    Username = p.Username,
                    Password = p.Password,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    RoleID = p.RoleID,
                    IsSysAdmin = p.IsSystemAdmin,
                    CreatedBy = this.LoggedInUser.Username,
                    CreatedOn = System.DateTime.Now,                    
                    Status = p.Status
                };

                context.Users.Add(table);
                return context.SaveChanges();
            }
        }

        public int UpdateUser(PharmaBusinessObjects.Master.UserMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                try
                {
                    var user = context.Users.Where(q => q.UserId == p.UserId).FirstOrDefault();

                    if (user != null)
                    {
                        user.Password = p.Password;
                        user.Status = p.Status;
                        user.FirstName = p.FirstName;
                        user.LastName = p.LastName;
                        user.RoleID = p.RoleID;
                        user.IsSysAdmin = p.IsSystemAdmin;
                        user.ModifiedBy =this.LoggedInUser.Username;
                        user.ModifiedOn = System.DateTime.Now;
                    }

                    return context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    throw ex;
                }
            }

        }

        public List<PharmaBusinessObjects.Master.Role> GetRoles(string searchText)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                
                List<PharmaBusinessObjects.Master.Role> roles = context.Roles.Where(p => string.IsNullOrEmpty(searchText) || p.RoleName.ToLower().Contains(searchText.ToLower())).Select(p => new PharmaBusinessObjects.Master.Role() {
                                                                RoleId = p.RoleId,
                                                                RoleName = p.RoleName,
                                                                Status = p.Status,
                                                                CreatedBy = p.CreatedBy,
                                                                CreatedOn = p.CreatedOn,
                                                                ModifiedBy = p.ModifiedBy,
                                                                ModifiedOn = p.ModifiedOn,
                                                                PrivledgeList = p.RolePrivledges.Select(x=>new PharmaBusinessObjects.Master.Privledge() {
                                                                                    PrivledgeId = x.PrivledgeId,
                                                                                    PrivledgeName = x.Privledges.PriviledgeName,
                                                                                    Status = x.Privledges.Status
                                                                                }).ToList()
                
                                            }).ToList();
                roles.ForEach(p => p.Privledges = string.Join(",", p.PrivledgeList.Select(x=>x.PrivledgeName).ToList()));
                return roles;
            }

        }

        public PharmaBusinessObjects.Master.Role GetRoleById(int roleID)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
               
                return context.Roles.Where(p => p.RoleId == roleID).Select(p => new PharmaBusinessObjects.Master.Role()
                {
                    RoleId = p.RoleId,
                    RoleName = p.RoleName,
                    Status = p.Status,
                    CreatedBy = p.CreatedBy,
                    CreatedOn = p.CreatedOn,
                    ModifiedBy = p.ModifiedBy,
                    ModifiedOn = p.ModifiedOn,
                    PrivledgeList = p.RolePrivledges.Select(x => new PharmaBusinessObjects.Master.Privledge()
                    {
                        PrivledgeId = x.PrivledgeId,
                        PrivledgeName = x.Privledges.PriviledgeName,
                        Status = x.Privledges.Status
                    }).ToList()
                }).FirstOrDefault();
                
            }

        }

        public bool AddRole(PharmaBusinessObjects.Master.Role role)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                try
                {
                    int result = 0;

                    if(context.Roles.Any(p=>p.RoleName.ToLower() == role.RoleName.ToLower()))
                    {
                        throw new Exception("Role already exists");
                    }

                    Roles roles = new Roles() {
                        RoleName = role.RoleName,
                        Status = role.Status,
                        CreatedBy = this.LoggedInUser.Username,
                        CreatedOn = DateTime.Now
                    };

                    context.Roles.Add(roles);
                    result = context.SaveChanges();

                    foreach (Privledge item in role.PrivledgeList)
                    {
                        RolePrivledges priv = new RolePrivledges();
                        priv.RoleId = roles.RoleId;
                        priv.PrivledgeId = item.PrivledgeId;
                        context.RolePrivledges.Add(priv);
                    }
                    result = result + context.SaveChanges();
                    return result > 0;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    throw ex;
                }
            }

        }

        public bool UpdateRole(PharmaBusinessObjects.Master.Role role)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                try
                {
                    int result = 0;

                    Roles roles = context.Roles.Where(p => p.RoleId == role.RoleId).FirstOrDefault();

                    if(roles != null)
                    {
                        roles.RoleName = role.RoleName;
                        roles.Status = role.Status;
                        roles.CreatedBy = this.LoggedInUser.Username;
                        roles.CreatedOn = DateTime.Now;
                    }

                    result = context.SaveChanges();

                    var privledges = context.RolePrivledges.Where(p => p.RoleId == role.RoleId).ToList();

                    privledges.ForEach(p=>context.RolePrivledges.Remove(p));

                    foreach (var item in role.PrivledgeList)
                    {
                        RolePrivledges priv = new RolePrivledges() {
                            RoleId = role.RoleId,
                            PrivledgeId = item.PrivledgeId
                        };
                    }

                    result = result + context.SaveChanges();

                    return result > 0;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    throw ex;
                }
            }

        }

        public List<PharmaBusinessObjects.Master.Privledge> GetPrivledges(string searchText)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {

                return context.Privledges.Where(p =>string.IsNullOrEmpty(searchText) || p.PriviledgeName.ToLower().Contains(searchText.ToLower())).Select(p => new PharmaBusinessObjects.Master.Privledge()
                {
                    PrivledgeId = p.PrivledgeId,
                    PrivledgeName = p.PriviledgeName,
                    Status = p.Status,
                    ControlName = p.ControlName,
                    CreatedBy = p.CreatedBy,
                    CreatedOn = p.CreatedOn,
                    ModifiedBy = p.ModifiedBy,
                    ModifiedOn = p.ModifiedOn,
                }).ToList();

            }

        }

        public PharmaBusinessObjects.Master.Privledge GetPrivledgeById(int privledgeId)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {

                return context.Privledges.Where(p => p.PrivledgeId == privledgeId).Select(p => new PharmaBusinessObjects.Master.Privledge()
                {
                    PrivledgeId = p.PrivledgeId,
                    PrivledgeName = p.PriviledgeName,
                    Status = p.Status,
                    ControlName = p.ControlName,
                    CreatedBy = p.CreatedBy,
                    CreatedOn = p.CreatedOn,
                    ModifiedBy = p.ModifiedBy,
                    ModifiedOn = p.ModifiedOn,
                }).FirstOrDefault();

            }

        }

        public bool AddPrivledge(PharmaBusinessObjects.Master.Privledge privledge)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                try
                {
                    int result = 0;

                    if (context.Privledges.Any(p => p.PriviledgeName.ToLower() == privledge.PrivledgeName.ToLower()))
                    {
                        throw new Exception("Privledge already exists");
                    }

                    Privledges priv = new Privledges()
                    {
                        PriviledgeName = privledge.PrivledgeName,
                        Status = privledge.Status,
                        ControlName = privledge.ControlName,
                        CreatedBy = this.LoggedInUser.Username,
                        CreatedOn = DateTime.Now
                    };

                    context.Privledges.Add(priv);
                    result = context.SaveChanges();

                    return result > 0;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    throw ex;
                }
            }

        }

        public bool UpdatePrivledges(PharmaBusinessObjects.Master.Privledge privledge)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                try
                {
                    int result = 0;

                    Privledges priv = context.Privledges.Where(p => p.PrivledgeId == privledge.PrivledgeId).FirstOrDefault();

                    if (priv != null)
                    {
                        priv.PriviledgeName = privledge.PrivledgeName;
                        priv.Status = privledge.Status;
                        priv.ControlName = privledge.ControlName;
                        priv.ModifiedBy = this.LoggedInUser.Username;
                        priv.ModifiedOn = DateTime.Now;
                    }

                    result = context.SaveChanges();

                    return result > 0;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    throw ex;
                }
            }

        }

        public PharmaBusinessObjects.Master.UserMaster ValidateUser(string userName, string password)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {

                string query = "select * from users where Username = '"+userName + "' AND password = '"+password + "' AND Status =1";

                SqlConnection connection = (SqlConnection)context.Database.Connection;

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = System.Data.CommandType.Text;

             
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);
              

                if (dt != null && dt.Rows.Count > 0)
                {
                    PharmaBusinessObjects.Master.UserMaster obj = new UserMaster()
                    {
                        UserId =Convert.ToInt32(dt.Rows[0]["UserId"]),
                        Username = Convert.ToString(dt.Rows[0]["Username"]),
                        Password = Convert.ToString(dt.Rows[0]["Password"]),
                        FirstName = Convert.ToString(dt.Rows[0]["FirstName"]),
                        LastName = Convert.ToString(dt.Rows[0]["LastName"]),
                        //RoleID = Convert.ToInt32(dt.Rows[0]["RoleID"]),
                        //RoleName = Convert.ToString(dt.Rows[0]["RoleName"]),
                        IsSystemAdmin = Convert.ToBoolean(dt.Rows[0]["IsSysAdmin"])
                        //CreatedBy = Convert.ToInt32(dt.Rows[0]["UserId"]),
                        //CreatedOn = p.CreatedOn,
                        //ModifiedBy = p.ModifiedBy,
                        //ModifiedOn = p.ModifiedOn,
                        //Status = p.Status

                    };

                    return obj;
                }


                return null;
            }

            //using (PharmaDBEntities context = new PharmaDBEntities())
            //{
            //    // return context.Users.Where(p => p.Username == userName && p.Password == password && p.Status == true).Any();
            //    return context.Users.Where(p => p.Username == userName && p.Password == password && p.Status == true).Select(p => new PharmaBusinessObjects.Master.UserMaster()
            //    {
            //        UserId = p.UserId,
            //        Username = p.Username,
            //        Password = p.Password,
            //        FirstName = p.FirstName,
            //        LastName = p.LastName,
            //        RoleID = p.RoleID ?? 0,
            //        RoleName = p.Roles.RoleName,
            //        IsSystemAdmin = p.IsSysAdmin,
            //        CreatedBy = p.CreatedBy,
            //        CreatedOn = p.CreatedOn,
            //        ModifiedBy = p.ModifiedBy,
            //        ModifiedOn = p.ModifiedOn,
            //        Status = p.Status
            //    }).FirstOrDefault();
            //}
        }
    }
}
