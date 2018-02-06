using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SoftFramework.Web.App_Start;

namespace SoftFramework.Web.Installers
{
    public class SoftFrameworkInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {


            container.Register(Classes.FromAssemblyNamed("SoftFramework.Core.Domain")
                .Pick()
                .WithServiceDefaultInterfaces()
                .LifestylePerWebRequest());
            
            container.Register(Classes.FromAssemblyNamed("SoftFramework.Core.Infra")
                .Where(x => !x.Name.Contains("RepositoryBase"))
                .WithServiceDefaultInterfaces()
                .LifestylePerWebRequest());

            container.Register(Classes.FromAssemblyNamed("SoftFramework.Core.Application")
                .Pick()
                .WithServiceDefaultInterfaces().LifestylePerWebRequest());

            //container.Register(Component.For(typeof(IGenericRepository<>))
            //                .ImplementedBy(typeof(RepositoryBase<>)));

            //Mapper.AddProfile(new MapperWebProfile());

        }
    }
}