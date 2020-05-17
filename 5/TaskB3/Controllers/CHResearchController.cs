using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace TaskB3.Controllers
{
    public class CHResearchController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [OutputCache(Duration = 5)]
        public ActionResult AD()
        {
            return Content($"AD {DateTime.Now.ToLocalTime()}");
        }

        [HttpPost]
        [OutputCache(Duration = 7)]
        public ActionResult AP(int x, int y)
        {
            return Content($"AP x={x}, y={y}");
        }

        [HttpGet]
        public ActionResult AP()
        {
            return Content("Use POSTMAN and POST method to access this link");
        }
    }
}