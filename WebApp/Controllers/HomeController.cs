using BusinessEntities;
//using BusinessServices.BusinessInterface;
using DataModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            return View();

        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}