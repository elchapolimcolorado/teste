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
            
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
