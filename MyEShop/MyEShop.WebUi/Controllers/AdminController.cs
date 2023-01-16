using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEShop.WebUi.Controllers
{
    //[Authorize]
    //[Authorize(Users ="leomasg@gmail.com")]
    [Authorize(Roles = "Admin")]

    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}