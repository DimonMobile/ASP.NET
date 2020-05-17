using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskB2.Controllers
{
    public class AResearchController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ActionFilter]
        public ActionResult AA()
        {
            return Content("AA");
        }

        [ResultFilter]
        public ActionResult AR()
        {
            return Content("AR");
        }

        [ExceptionFilter]
        public ActionResult AE()
        {
            throw new NotImplementedException();
            //return Content("AE");
        }

        public class ActionFilterAttribute : FilterAttribute, IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<p>Action filter</p>");
            }

            public void OnActionExecuting(ActionExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<p>Action filter executing</p>");
            }
        }

        public class ResultFilterAttribute : FilterAttribute, IResultFilter
        {
            public void OnResultExecuted(ResultExecutedContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<p>Result filter</p>");
            }

            public void OnResultExecuting(ResultExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Write("<p>Result filter executing</p>");
            }
        }

        public class ExceptionFilterAttribute : FilterAttribute, IExceptionFilter
        {
            public void OnException(ExceptionContext filterContext)
            {
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Write("<p>EXCEPTION filter</p>");
            }
        }
    }
}