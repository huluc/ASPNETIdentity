using ASPNETIdentity.Security;
using ASPNETIdentity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ASPNETIdentity.Controllers
{
    public class UserController : Controller
    {

        // GET: User
        public ActionResult Index()
        {
            var result = UserService.Obj.GetUsers();
            return View(result);
        }
    }
}