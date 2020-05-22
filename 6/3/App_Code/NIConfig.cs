using Ninject.Modules;
using Ninject.Web.Common;
using UtilsNET;

namespace _3.App_Code
{
    public class NIConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<IPhoneDictionary>().To<BSTU.SqlServerRepository.Repository>().InRequestScope(); // or InSingletonScope(); or InThreadScope(); or InTransistentScope();
        }
    }
}