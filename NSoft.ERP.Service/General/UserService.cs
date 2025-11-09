using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Transactions;
using MoreLinq;

using NSoft.ERP.Data;
using NSoft.ERP.Domain;
using NSoft.ERP.Utility;
using NSoft.ERP.Service.General;

namespace NSoft.ERP.Domain.General
{
    public class UserService
    {
        ERPDBContext context = new ERPDBContext();
        public User CheckUserLogin(string username, string password)
        {
            return context.User.Where(u => u.Username == username && u.Password == password && u.IsActive == true && u.IsDelete == false).FirstOrDefault();
        }
        public User CheckUserLogin(string password)
        {
            return context.User.Where(u => u.Password == password && u.IsActive == true && u.IsDelete == false).FirstOrDefault();
        }
        public bool CheckUserLoginLocation(string username, string location)
        {
            bool isValid = false;
            var qry = (from u in context.User
                       join up in context.UserPrivilegesLocation on u.UserID equals up.UserID
                       join l in context.Location on up.LocationID equals l.LocationID
                       where u.Username == username && l.LocationName == location && u.IsActive == true && u.IsDelete == false
                       && up.IsAllow == true
                       select new
                       {
                           isTrue = true
                       });
            if (qry.Count(c => c.isTrue) > 0)
            {
                isValid = true;
            }


            return isValid;
        }

        public List<Location> GetUserAllowLocations(string username)
        {
            var locations = (from up in context.UserPrivilegesLocation
                             join l in context.Location on up.LocationID equals l.LocationID
                             join u in context.User on up.UserID equals u.UserID
                             where u.Username == username && u.IsDelete == false && u.IsActive == true && up.IsAllow == true
                             select new
                             {
                                 l.LocationID,
                                 l.LocationCode,
                                 l.LocationName
                             }).ToList();

            List<Location> rtnList = new List<Location>();
            foreach (var item in locations)
            {
                Location location = new Location();
                location.LocationID = item.LocationID;
                location.LocationCode = item.LocationCode;
                location.LocationName = item.LocationName;
                rtnList.Add(location);
            }
            return rtnList.ToList();
        }

        public List<UserPrivileges> GetAllPrivileges()
        {
            List<UserPrivileges> rtnList = new List<UserPrivileges>();
            var query = (from f in context.FormInfo
                         join up in context.UserPrivileges on f.FormInfoID equals up.FormInfoID into gj
                         from up in gj.DefaultIfEmpty()
                         where f.IsActive == true && f.IsDelete == false
                         select new { FormID = f.FormInfoID, FormText = f.FormText, f.FormType }).ToList().Distinct();
            foreach (var item in query)
            {
                UserPrivileges userPrivileges = new UserPrivileges();
                userPrivileges.FormInfoID = item.FormID;
                userPrivileges.FormText = item.FormText;
                userPrivileges.FormType = item.FormType;
                rtnList.Add(userPrivileges);

            }
            return rtnList.OrderBy(up => up.FormInfoID).ToList();
        }
        public List<UserPrivilegesLocation> GetAllLocationPrivileges()
        {
            List<UserPrivilegesLocation> rtnList = new List<UserPrivilegesLocation>();
            var query = (from l in context.Location
                         join up in context.UserPrivilegesLocation on l.LocationID equals up.LocationID into gj
                         from up in gj.DefaultIfEmpty()
                         where l.IsActive == true && l.IsDelete == false
                         select new { LocationID = l.LocationID, LocationName = l.LocationName }).ToList().Distinct();
            foreach (var item in query)
            {
                UserPrivilegesLocation userPrivilegesLocation = new UserPrivilegesLocation();
                userPrivilegesLocation.LocationID = item.LocationID;
                userPrivilegesLocation.LocationName = item.LocationName;
                rtnList.Add(userPrivilegesLocation);

            }
            return rtnList.OrderBy(up => up.LocationID).ToList();
        }

        public void AddUser(User user, DataTable dtUserPrivileges, DataTable dtUserPrivilegesLocation)
        {
            //using (TransactionScope scope = new TransactionScope())
            //{
            context.User.Add(user);
            this.context.SaveChanges();
            //    var parameters = new DbParameter[]
            //        {
            //            new System.Data.SqlClient.SqlParameter { ParameterName ="@UserMasterID", Value=user.UserID},
            //            new System.Data.SqlClient.SqlParameter { ParameterName ="@TblUserPrivileges", Value=dtUserPrivileges},
            //            new System.Data.SqlClient.SqlParameter { ParameterName ="@TblUserPrivilegesLocation", Value=dtUserPrivilegesLocation}
            //        };
            //    if (CommonService.ExcecuteStoresProcedure("spSaveUserPrivileges", parameters))
            //    { scope.Complete(); }
            //}
        }
        public void UpdateUser(User user, DataTable dtUserPrivileges, DataTable dtUserPrivilegesLocation)
        {
            //using (TransactionScope scope = new TransactionScope())
            //{
            user.ModifiedUser = Common.LoggedUserName;
            user.ModifiedDate = DateTime.Now;
            this.context.Entry(user).State = EntityState.Modified;
            this.context.SaveChanges();
            //var parameters = new DbParameter[]
            //    {
            //        new System.Data.SqlClient.SqlParameter { ParameterName ="@UserMasterID", Value=user.UserID},
            //        new System.Data.SqlClient.SqlParameter { ParameterName ="@TblUserPrivileges", Value=dtUserPrivileges},
            //        new System.Data.SqlClient.SqlParameter { ParameterName ="@TblUserPrivilegesLocation", Value=dtUserPrivilegesLocation}
            //    };
            //if (CommonService.ExcecuteStoresProcedure("spSaveUserPrivileges", parameters))
            //{ scope.Complete(); }
            //}
        }
        public List<UserPrivileges> GetAllUserPrivilegesByUsername(string username)
        {
            List<UserPrivileges> rtnList = new List<UserPrivileges>();
            var query = (
                         //from up in context.UserPrivileges
                         //         join f in context.FormInfo on up.FormInfoID equals f.FormInfoID into gj
                         //         from f in gj.DefaultIfEmpty()
                         from f in context.FormInfo
                         join up in context.UserPrivileges on f.FormInfoID equals up.FormInfoID into gj
                         from up in gj.DefaultIfEmpty()
                         join u in context.User on up.UserID equals u.UserID
                         where u.Username == username && u.IsActive == true && u.IsDelete == false
                         && f.IsActive == true && f.IsDelete == false
                         select new
                         {
                             FormID = f.FormInfoID,
                             FormText = f.FormText,
                             UserID = u.UserID,
                             IsAccess = up.IsAccess,
                             IsSave = up.IsSave,
                             IsRemove = up.IsRemove,
                             FormType = f.FormType
                         }).ToList();
            foreach (var item in query)
            {
                UserPrivileges userPrivileges = new UserPrivileges();
                userPrivileges.FormInfoID = item.FormID;
                userPrivileges.FormText = item.FormText;
                userPrivileges.UserID = item.UserID;
                userPrivileges.IsAccess = item.IsAccess;
                userPrivileges.IsSave = item.IsSave;
                userPrivileges.IsRemove = item.IsRemove;
                userPrivileges.FormType = item.FormType;
                rtnList.Add(userPrivileges);

            }
            return rtnList.OrderBy(up => up.FormInfoID).ToList();
        }
        public List<UserPrivilegesLocation> GetAllUserPrivilegesLocationByUsername(string username)
        {
            List<UserPrivilegesLocation> rtnList = new List<UserPrivilegesLocation>();
            var query = (from l in context.Location
                         join up in context.UserPrivilegesLocation on l.LocationID equals up.LocationID into gj
                         from up in gj.DefaultIfEmpty()
                         join u in context.User on up.UserID equals u.UserID
                         where u.Username == username && u.IsActive == true && u.IsDelete == false
                         && l.IsActive == true && l.IsDelete == false
                         select new
                         {
                             LocationID = l.LocationID,
                             LocationName = l.LocationName,
                             UserID = u.UserID,
                             IsAllow = up.IsAllow,

                         }).ToList();
            foreach (var item in query)
            {
                UserPrivilegesLocation userPrivilegesLocations = new UserPrivilegesLocation();
                userPrivilegesLocations.LocationID = item.LocationID;
                userPrivilegesLocations.LocationName = item.LocationName;
                userPrivilegesLocations.UserID = item.UserID;
                userPrivilegesLocations.IsAllow = item.IsAllow;
                rtnList.Add(userPrivilegesLocations);

            }
            return rtnList.OrderBy(up => up.LocationID).ToList();
        }
        public List<UserGroup> GetAllUserGroups()
        {
            return context.UserGroup.Where(ug => ug.IsActive == true && ug.IsDelete == false).ToList();
        }
        public User GetUserByUsername(string username)
        {
            return context.User.Where(u => u.Username == username && u.IsDelete == false && u.IsDeveloper == false).FirstOrDefault();
        }
        public User GetUserByUsernameWithDeveloper(string username)
        {
            return context.User.Where(u => u.Username == username && u.IsDelete == false).FirstOrDefault();
        }
        public string[] GetAllUsernames()
        {
            return context.User.Where(u => u.IsDelete == false && u.IsDeveloper == false).Select(u => u.Username).ToArray();
        }
        public string[] GetAllUsernamesWithDevelopers()
        {
            return context.User.Where(u => u.IsDelete == false).Select(u => u.Username).ToArray();
        }
        public UserPrivileges GetUserPrivilegesByUserIDAndForm(long userID, FormInfo formInfo)
        {
            return context.UserPrivileges.Where(up => up.UserID == userID && up.FormInfoID == formInfo.FormInfoID).FirstOrDefault();
        }

        public UserPrivileges GetUserPrivilegesByUserIDAndForm(long userID, long formID)
        {
            return context.UserPrivileges.Where(up => up.UserID == userID && up.FormInfoID == formID).FirstOrDefault();
        }

        public List<FormInfo> GetAllAccessPrivilegesByUserName(string username)
        {
            var qry = (from u in context.User
                       join up in context.UserPrivileges on u.UserID equals up.UserID
                       join f in context.FormInfo on up.FormInfoID equals f.FormInfoID
                       where u.Username == username && up.IsAccess == true && u.IsActive == true && u.IsDelete == false
                       && f.IsActive == true && f.IsDelete == false
                       select new
                       {
                           f.FormInfoID,
                           f.FormName
                       });
            List<FormInfo> privileges = new List<FormInfo>();
            foreach (var item in qry)
            {
                FormInfo formIfo = new FormInfo();
                formIfo.FormInfoID = item.FormInfoID;
                formIfo.FormName = item.FormName;
                privileges.Add(formIfo);
            }
            return privileges;
        }
        public void DeleteUser(User user)
        {
            user.ModifiedUser = Common.LoggedUserName;
            user.ModifiedDate = DateTime.Now;
            user.IsDelete = true;
            this.context.Entry(user).State = EntityState.Modified;
            this.context.UserPrivileges.Where(up => up.UserID == user.UserID).ForEach(x => { x.IsDelete = true; x.ModifiedUser = Common.LoggedUserName; x.ModifiedDate = DateTime.Now; });
            this.context.UserPrivilegesLocation.Where(up => up.UserID == user.UserID).ForEach(x => { x.IsDelete = true; x.ModifiedUser = Common.LoggedUserName; x.ModifiedDate = DateTime.Now; });
            this.context.SaveChanges();

        }

        public void UpdateUserPrivilegeLocations(Location location)
        {
            var userList = context.User.Where(u => u.IsDelete == false).ToList();
            foreach (var item in userList)
            {
                var privilege = context.UserPrivilegesLocation.Any(up => up.LocationID == location.LocationID && up.UserID == item.UserID);
                if (!privilege)
                {
                    UserPrivilegesLocation userPrivilegesLocation = new UserPrivilegesLocation();
                    userPrivilegesLocation.UserID = item.UserID;
                    userPrivilegesLocation.LocationID = location.LocationID;
                    userPrivilegesLocation.IsAllow = false;
                    userPrivilegesLocation.IsDelete = false;
                    userPrivilegesLocation.CreatedUser = location.CreatedUser;
                    userPrivilegesLocation.CreatedDate = location.CreatedDate;
                    userPrivilegesLocation.ModifiedUser = location.ModifiedUser;
                    userPrivilegesLocation.ModifiedDate = location.ModifiedDate;
                    context.UserPrivilegesLocation.Add(userPrivilegesLocation);
                    context.SaveChanges();
                }

            }

        }
        public void AddUserPrivilege(UserPrivileges userPrivileges)
        {
            context.UserPrivileges.Add(userPrivileges);
            this.context.SaveChanges();
        }

        public void UpdateUserPrivilege(UserPrivileges userPrivileges)
        {
            userPrivileges.ModifiedUser = Common.LoggedUserName;
            userPrivileges.ModifiedDate = DateTime.Now;
            this.context.Entry(userPrivileges).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public void AddUserPrivilegeLocation(UserPrivilegesLocation userPrivilegesLocation)
        {
            context.UserPrivilegesLocation.Add(userPrivilegesLocation);
            this.context.SaveChanges();
        }

        public void UpdateUserPrivilegeLocation(UserPrivilegesLocation userPrivilegesLocation)
        {
            userPrivilegesLocation.ModifiedUser = Common.LoggedUserName;
            userPrivilegesLocation.ModifiedDate = DateTime.Now;
            this.context.Entry(userPrivilegesLocation).State = EntityState.Modified;
            this.context.SaveChanges();
        }
        public UserPrivileges GetUserPrivilegeByUserAndFormID(User user, long formInfoID)
        {
            return context.UserPrivileges.Where(up => up.UserID == user.UserID && up.FormInfoID == formInfoID).FirstOrDefault();
        }
        public UserPrivilegesLocation GetUserPrivilegeLocationByUserAndLocationID(User user, long locationID)
        {
            return context.UserPrivilegesLocation.Where(up => up.UserID == user.UserID && up.LocationID == locationID).FirstOrDefault();
        }
        public List<User> GetAllActiveUsers()
        {
            return context.User.Where(u => u.IsDelete == false && u.IsActive == true && u.IsDeveloper == false).ToList();
        }

        public List<FormInfo> GetAllPOSAccessPrivilegesByUserName(string username)
        {
            var qry = (from u in context.User
                       join up in context.UserPrivileges on u.UserID equals up.UserID
                       join f in context.FormInfo on up.FormInfoID equals f.FormInfoID
                       where u.Username == username && up.IsAccess == true && u.IsActive == true && u.IsDelete == false
                       && f.IsActive == true && f.IsDelete == false && f.FormType == 4
                       select new
                       {
                           f.FormInfoID,
                           f.FormName
                       });
            List<FormInfo> privileges = new List<FormInfo>();
            foreach (var item in qry)
            {
                FormInfo formIfo = new FormInfo();
                formIfo.FormInfoID = item.FormInfoID;
                formIfo.FormName = item.FormName;
                privileges.Add(formIfo);
            }
            return privileges;
        }

    }
}
