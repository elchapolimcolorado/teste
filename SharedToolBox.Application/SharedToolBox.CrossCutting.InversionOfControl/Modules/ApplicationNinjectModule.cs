using SharedToolBox.Application;
using Ninject.Modules;
using SharedToolBox.Application.Interface;

namespace SharedToolBox.CrossCutting.InversionOfControl.Modules
{
    public class ApplicationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoriaAppService>().To<CategoriaAppService>();
        }
    }
}
