using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TaskB1.Controllers
{
    [RoutePrefix("it")]
    public class MResearchController : Controller
    {
        public bool IsReusable
        {
            get { return false; }
        }

        [HttpGet]
        [Route("{n:int}/{str}")]
        public ActionResult M01B(int n, string str)
        {
            StringBuilder content = new StringBuilder();
            content.Append("GET:M01:/n/string</br>");
            content.Append($"{n} - целочисленное значение</br>");
            content.Append($"{str} - любая строка</br>");
            return Content(content.ToString());
        }

        [AcceptVerbs("get", "post")]
        [Route("{b:bool}/{letters:alpha}")]
        public ActionResult M02(bool b, string letters)
        {
            StringBuilder content = new StringBuilder();
            content.Append($"{Request.HttpMethod}:M02:/b/letters</br>");
            content.Append($"{b} - булево значение</br>");
            content.Append($"{letters} - строка из букв</br>");
            content.Append($"{Request.HttpMethod} - метод.</br>");
            return Content(content.ToString());
        }

        [Route("{f:float}/{str:minlength(2):maxlength(5)}")]
        [AcceptVerbs("get", "delete")]
        //[HttpDelete]
        public ActionResult M03(float f, string str)
        {
            StringBuilder content = new StringBuilder();
            content.Append($"{Request.HttpMethod}:M03:/f/string</br>");
            content.Append($"{f} - float значение</br>");
            content.Append($"{str} - строка</br>");
            content.Append($"2 <= {str.Length} <= 5</br>");
            content.Append($"{Request.HttpMethod} - метод.</br>");
            return Content(content.ToString());
        }

        [AcceptVerbs("put")]
        [Route("{letters:alpha:length(3, 4)}/{n:int}")]
        public ActionResult M04(string letters, int n)
        {
            StringBuilder content = new StringBuilder();
            content.Append($"{Request.HttpMethod}:M04:/letters/n</br>");
            content.Append($"{letters} - строка из букв</br>");
            content.Append($"3 <= {letters.Length} <= 4</br>");
            content.Append($"{n} - целочисленное значение</br>");
            content.Append($"{Request.HttpMethod} - метод.</br>");
            return Content(content.ToString());
        }

        [HttpPost]
        public ActionResult M04(string email)
        {
            return Content("M04");
        }
    }
}