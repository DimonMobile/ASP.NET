using Ninject.Modules;
using Ninject.Web.Common;
using UtilsNET;

namespace _3.App_Code
{
    public class NIConfig : NinjectModule
    {
        public override void Load()
        {
            // or InSingletonScope(); or InThreadScope(); or InTransistentScope();
            // Bind<IPhoneDictionary>().To<BSTU.JsonRepository.Repository>().InRequestScope(); // json file
            Bind<IPhoneDictionary>().To<BSTU.SqlServerRepository.Repository>().InRequestScope(); // database
        }
    }
}