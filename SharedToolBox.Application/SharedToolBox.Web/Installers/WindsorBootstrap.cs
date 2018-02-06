using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
//using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SoftFramework.Web.Installers;
using SoftFramework.Web.App_Start;

//[assembly: WebActivator.PostApplicationStartMethod(typeof(WindsorBootstrap), "Start")]
namespace SoftFramework.Web.Installers
{
    public static class WindsorBootstrap
    {
        public static void Start()
        {
            //var container = Fabrica.Instancia.Container;

            //RegisterAllInstalers(container);
            //RegisterControllerFactory(container);
            //RegisterServiceLocator(container);
           // RegistarGlobalFilters(container);
        }

        private static void RegisterAllInstalers(IWindsorContainer container)
        {

            container.Install(new SoftFrameworkInstaller());


            container.Register(Classes.FromThisAssembly()
                       .BasedOn<IController>()
                       .LifestylePerWebRequest());

        }

        private static void RegisterControllerFactory(IWindsorContainer container)
        {
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        private static void RegisterServiceLocator(IWindsorContainer container)
        {
            //ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
        }

        private static void RegistarGlobalFilters(IWindsorContainer container)
        {
            //GlobalFilters.Filters.Add(
            //    new LogonAuthorizeAttribute(() => (ServicoLogin)container.Resolve<IServicoLogin>()));
            //GlobalFilters.Filters.Add(
            //    new AdminAuthorizeAttribute(() => (ServicoLogin)container.Resolve<IServicoLogin>()));
            //GlobalFilters.Filters.Add(new JsonExceptionFilterAttribute("Atenção!"));
        }
    }
}