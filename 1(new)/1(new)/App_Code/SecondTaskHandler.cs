using System;
using System.Web;

namespace _1_new_.App_Code
{
    public class SecondTaskHandler : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;
            HttpRequest request = context.Request;

            string paramA = request.Params["ParamA"];
            string paramB = request.Params["ParamB"];

            response.Write($"POST-Http-PDA:ParamA = {paramA}, ParamB = {paramB}");
        }

        #endregion
    }
}
