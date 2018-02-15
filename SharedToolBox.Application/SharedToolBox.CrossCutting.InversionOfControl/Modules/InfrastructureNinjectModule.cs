using Ninject.Modules;
using SharedToolBox.Infra.Data.Contexto;
using System.Data.Entity;

namespace SharedToolBox.CrossCutting.InversionOfControl.Modules
{
    public class InfrastructureNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<ProjetoModeloContext>();
        }
    }
}
