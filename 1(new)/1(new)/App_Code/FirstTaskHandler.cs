using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_new_.App_Code
{
    public class FirstTaskHandler : IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            // string paramA = request.QueryString["ParamA"];
            // string paramB = request.QueryString["ParamB"];

            string paramA = request.Params["ParamA"];
            string paramB = request.Params["ParamB"];

            response.Write($"Get-Http-PDA:ParamA = {paramA}, ParamB = {paramB}");
        }
    }
}