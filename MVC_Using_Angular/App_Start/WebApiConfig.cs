using Ioc;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity.WebApi;

namespace MVC_Using_Angular
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ///container IOC do unity
            var container = new UnityContainer();
            ///configura a injeção dos serviços 
            DependenciasServicos.Configure(container);
            ///configura a injeção dos dados 
            DependenciasDados.Configure(container);
            config.DependencyResolver = new UnityDependencyResolver(container);
            ///rotas
            config.Routes.MapHttpRoute(
               name: "ControllerActionIdApi",
               routeTemplate: "api/{controller}/{action}/{id}",
               defaults: new { },
               constraints: new { id = @"\d+" }
           );

            config.Routes.MapHttpRoute(
                name: "ControllerIdApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { },
                constraints: new { id = @"\d+" }
            );

            config.Routes.MapHttpRoute(
                name: "ControllerActionApi",
                routeTemplate: "api/{controller}/{action}"
            );

            config.Routes.MapHttpRoute(
                name: "ControllerApi",
                routeTemplate: "api/{controller}"
            );
        }
    }
}
