using Ninject.Modules;
using UtilsNET;

namespace _3.App_Code
{
    public class NIConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<IPhoneDictionary>().To<BSTU.JsonRepository.Repository>();
        }
    }
}