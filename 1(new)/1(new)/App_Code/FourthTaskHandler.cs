using System;
using System.Collections.Generic;
using System.Web;

namespace _1_new_.App_Code
{
    public class FourthTaskHandler : IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            int x = Int32.Parse(request.Params["x"]);
            int y = Int32.Parse(request.Params["y"]);

            response.Write(x + y);
        }
    }
}