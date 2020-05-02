using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5.Controllers
{
    public class MResearchController : Controller
    {
        [Route("MResearch/M01/{x:int}")]
        [Route("MResearch/M01/")]
        [Route("MResearch")]
        [Route("")]
        [Route("V2/MResearch/M01")]
        [Route("V3/MResearch/X/M01")]
        public ActionResult M01()
        {
            return Content("GET:<b>M01</b>");
        }


        [Route("V2")]
        [Route("V2/MResearch")]
        [Route("V2/MResearch/M02")]
        [Route("MResearch/M02")]
        [Route("V3/MResearch/X/M02")]
        public ActionResult M02()
        {
            return Content("GET:<b>M02</b>");
        }

        [Route("V3")]
        [Route("V3/MResearch/X")]
        [Route("V3/MResearch/X/M03")]
        public ActionResult M03()
        {
            return Content("GET:<b>M03</b>");
        }

        [Route("MResearch/MXX")]
        public ActionResult MXX()
        {
            return Content("MXX");
        }
    }
}