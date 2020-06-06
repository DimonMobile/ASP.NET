using BSTU.SqlServerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilsNET;

namespace Service.Controllers
{
    public class ApiController : Controller
    {
        Repository r = new Repository();

        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("TS")]
        [HttpGet]
        public ActionResult GetAll()
        {
            return Json(r.GetAll(), JsonRequestBehavior.AllowGet);
        }

        [Route("TS")]
        [HttpPost]
        public ActionResult Insert(Data data)
        {
            return Content(r.Insert(data).ToString());
        }

        [Route("TS")]
        [HttpPut]
        public ActionResult Update(Data data)
        {
            return Content(r.Update(data).ToString());
        }

        [Route("TS")]
        [HttpDelete]
        public ActionResult Delete(Data data)
        {
            return Content(r.Delete(data).ToString());
        }
    }
}