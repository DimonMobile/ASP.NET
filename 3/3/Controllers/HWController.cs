using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3.Controllers
{
    public class HWController : Controller
    {
        Models.HW_DB db = new Models.HW_DB();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.getall = db.GetAll();
            ViewBag.find2 = db.Find(2);
            return View();
        }

        public ActionResult Insert(int id, string name, string spec, int syear, DateTime bdate)
        {
            if (db.Insert(new Models.Data { Id = id, Name = name, Spec = spec, SYear = syear, BDate = bdate }))
                ViewBag.message = "Insert OK";
            else
                ViewBag.message = "Insert fails";

            ViewBag.getall = db.GetAll();
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult Delete()
        {
            return null;
        }
    }
}