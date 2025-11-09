using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using NSoft.ERP.Domain.General;

namespace NSoft.ERP.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        string baseUrl = Properties.Settings.Default.baseUrl.Trim();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {          
            return View();
        }
        public async Task<ActionResult> UserLocations()
        {
            var result = "";
            using (var client = new HttpClient())
            {
                Uri apiUri = new Uri(baseUrl + "/api/User/GetAllowLocations");
                HttpResponseMessage message = await client.GetAsync(apiUri);
                var response = message.Content.ReadAsStringAsync();
                result = response.Result;

                var jsonObject = JsonConvert.DeserializeObject<IEnumerable<Location>>(result);
                return Json(jsonObject, JsonRequestBehavior.AllowGet);

            }
        }
    }
}