using SharedToolBox.Application;
using SharedToolBox.Application.Interface;
using SharedToolBox.Domain.Entities;
using SharedToolBox.Domain.Interfaces.Repositories;
using SharedToolBox.Domain.Interfaces.Services;
using SharedToolBox.Domain.Services;
using SharedToolBox.Infra.Data.Repositories;
using SharedToolBox.Web.AutoMapper;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SoftFramework.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SharedToolBox.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();

            var container = new Container();

            container.Register<IRepositoryBase<Categoria>, RepositoryBase<Categoria>>(Lifestyle.Singleton);
            container.Register<ICategoriaRepository, CategoriaRepository>(Lifestyle.Singleton);
            container.Register<ICategoriaService, CategoriaService>(Lifestyle.Singleton);
            container.Register<ICategoriaAppService, CategoriaAppService>(Lifestyle.Singleton);

            container.Register<IRepositoryBase<Tipo>, RepositoryBase<Tipo>>(Lifestyle.Singleton);
            container.Register<ITipoRepository, TipoRepository>(Lifestyle.Singleton);
            container.Register<ITipoService, TipoService>(Lifestyle.Singleton);
            container.Register<ITipoAppService, TipoAppService>(Lifestyle.Singleton);

            container.Register<IRepositoryBase<Subtipo>, RepositoryBase<Subtipo>>(Lifestyle.Singleton);
            container.Register<ISubtipoRepository, SubtipoRepository>(Lifestyle.Singleton);
            container.Register<ISubtipoService, SubtipoService>(Lifestyle.Singleton);
            container.Register<ISubtipoAppService, SubtipoAppService>(Lifestyle.Singleton);

            container.Register<IRepositoryBase<Marca>, RepositoryBase<Marca>>(Lifestyle.Singleton);
            container.Register<IMarcaRepository, MarcaRepository>(Lifestyle.Singleton);
            container.Register<IMarcaService, MarcaService>(Lifestyle.Singleton);
            container.Register<IMarcaAppService, MarcaAppService>(Lifestyle.Singleton);

            container.Register<IRepositoryBase<Caracteristica>, RepositoryBase<Caracteristica>>(Lifestyle.Singleton);
            container.Register<ICaracteristicaRepository, CaracteristicaRepository>(Lifestyle.Singleton);
            container.Register<ICaracteristicaService, CaracteristicaService>(Lifestyle.Singleton);
            container.Register<ICaracteristicaAppService, CaracteristicaAppService>(Lifestyle.Singleton);

            container.Register<IRepositoryBase<Dominio>, RepositoryBase<Dominio>>(Lifestyle.Singleton);
            container.Register<IDominioRepository, DominioRepository>(Lifestyle.Singleton);
            container.Register<IDominioService, DominioService>(Lifestyle.Singleton);
            container.Register<IDominioAppService, DominioAppService>(Lifestyle.Singleton);

            container.Register<IRepositoryBase<Ferramenta>, RepositoryBase<Ferramenta>>(Lifestyle.Singleton);
            container.Register<IFerramentaRepository, FerramentaRepository>(Lifestyle.Singleton);
            container.Register<IFerramentaService, FerramentaService>(Lifestyle.Singleton);
            container.Register<IFerramentaAppService, FerramentaAppService>(Lifestyle.Singleton);

            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
