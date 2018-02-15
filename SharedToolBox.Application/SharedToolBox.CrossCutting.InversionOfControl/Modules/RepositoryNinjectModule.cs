using Ninject.Modules;
using SharedToolBox.Domain.Interfaces.Repositories;
using SharedToolBox.Infra.Data.Repositories;

namespace SharedToolBox.CrossCutting.InversionOfControl.Modules
{
    public class RepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof (IRepositoryBase<>)).To(typeof (RepositoryBase<>));

            Bind<ICategoriaRepository>().To<CategoriaRepository>();
        }
    }
}
