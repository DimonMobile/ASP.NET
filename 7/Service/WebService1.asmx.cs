using BSTU.SqlServerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using UtilsNET;

namespace Service
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://plot.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        Repository r = new Repository();

        [WebMethod(Description = "Hello world test method")]
        public string HelloWorld()
        {
            return "Hello World";
            
        }

        [WebMethod(Description = "Returns all phone dictionary elements")]
        public Data[] GetDict()
        {
            return r.GetAll();
        }

        [WebMethod(Description = "Add element")]
        public void AddDict(Data data)
        {
            r.Insert(data);
        }

        [WebMethod(Description = "Update existing element")]
        public void UdpDict(Data data)
        {
            r.Update(data);
        }

        [WebMethod(Description = "Delete existing element")]
        public void DelDict(Data data)
        {
            r.Delete(data);
        }
    }
}
