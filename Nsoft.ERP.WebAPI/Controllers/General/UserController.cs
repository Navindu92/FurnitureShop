using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NSoft.ERP.Domain.General;
using NSoft.ERP.Service.General;


namespace NSoft.ERP.WebAPI.Controllers.General
{
    public class UserController : ApiController
    {
        public IEnumerable<User> GetAllUsers()
        {
            UserService userService = new UserService();
            return userService.GetAllActiveUsers();
        }

        public IEnumerable<Location> GetAllowLocations(string username="a")
        {
            UserService userService = new UserService();
            return userService.GetUserAllowLocations(username);
        }

    }
}
