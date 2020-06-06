using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UtilsNET;
using BSTU.SqlServerRepository;
using _8.Models;

namespace _8.Controllers
{
    public class DictController : Controller
    {
        private readonly ILogger<DictController> _logger;
        IPhoneDictionary db;

        public DictController(ILogger<DictController> logger, Models.Repository dictionary)
        {
            _logger = logger;
            this.db = dictionary;
        }

        [HttpGet]
        public ActionResult Index()
        {
            Data[] arr = db.GetAll();
            Array.Sort(arr, new DataSorter());
            ViewBag.getall = arr;
            ViewBag.find2 = db.Find(2);
            return View();
        }

        public ActionResult Insert(int id, string name, string spec, int syear, DateTime bdate)
        {
            if (db.Insert(new Data { Id = id, Name = name, Spec = spec, SYear = syear, BDate = bdate }))
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
        public ActionResult DeleteSave(int id)
        {
            Data dt = new Data();
            dt.Id = id;
            db.Delete(dt);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSave(int id, string name, string spec, int syear, DateTime bdate)
        {
            db.Insert(new Data { Id = id, Name = name, Spec = spec, SYear = syear, BDate = bdate });
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Data dat = db.Find(id);
            ViewBag.data = dat;
            ViewBag.date = dat.BDate.ToString("yyyy-MM-dd");
            return View();
        }

        [HttpPost]
        public ActionResult UpdateSave(int id, string name, string spec, int syear, DateTime bdate)
        {
            db.Update(new Data { Id = id, Name = name, Spec = spec, SYear = syear, BDate = bdate });
            return RedirectToAction("index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
