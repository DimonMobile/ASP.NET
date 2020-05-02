using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Task2.Controllers
{
    public class CResearchController : Controller
    {
        // GET: CResearch
        public ActionResult C01()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"Method: {Request.HttpMethod}<br/>");
            builder.Append($"QueryString: {Request.QueryString}<br/>");
            builder.Append($"Url: {Request.Url}<br/>");
            builder.Append("==========HEADERS============</br>");
            for (int i = 0; i < Request.Headers.Count; ++i)
            {
                var header = Request.Headers;
                builder.Append(header.GetKey(i) + ":" + header.Get(i) + "<br/>");
            }
            if (Request.HttpMethod == "POST")
            {
                builder.Append("========BODY======<br/>");
                var memstream = new MemoryStream();
                Request.InputStream.CopyTo(memstream);
                Request.InputStream.Position = 0;
                builder.Append(Encoding.UTF8.GetString(memstream.ToArray()));
            }

            return Content(builder.ToString());
        }

        public ActionResult C02()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"Status: {Response.StatusCode}<br/>");
            builder.Append("==========HEADERS============</br>");
            for (int i = 0; i < Request.Headers.Count; ++i)
            {
                var header = Request.Headers;
                builder.Append(header.GetKey(i) + ":" + header.Get(i) + "<br/>");
            }
            if (Request.HttpMethod == "POST")
            {
                builder.Append("========BODY======<br/>");
                var memstream = new MemoryStream();
                Request.InputStream.CopyTo(memstream);
                Request.InputStream.Position = 0;
                builder.Append(Encoding.UTF8.GetString(memstream.ToArray()));
            }

            return Content(builder.ToString());
        }
    }
}