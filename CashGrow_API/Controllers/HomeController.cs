using CashGrow_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CashGrow_API.Controllers
{
     
    public class HomeController : Controller
    {
        private ApiDbContext db = new ApiDbContext();
        public ActionResult Index()
        {
            ViewBag.Title = "CashGrow API | Beth Olmo";

            return View();
        }
    }
}
