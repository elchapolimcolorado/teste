using SharedToolBox.Domain.Services;
using Ninject.Modules;
using SharedToolBox.Domain.Interfaces.Services;

namespace SharedToolBox.CrossCutting.InversionOfControl.Modules
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof (IServiceBase<>)).To(typeof (ServiceBase<>));

            Bind<ICategoriaService>().To<CategoriaService>();
        }
    }
}
