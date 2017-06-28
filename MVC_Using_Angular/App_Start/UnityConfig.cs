using Ioc;
using Microsoft.Practices.Unity;
using System;
using System.Web.Http;
using System.Web.Mvc;
using Unity.WebApi;

namespace MVC_Using_Angular
{
    public static class UnityConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //container Unity
            var container = new UnityContainer();
            ///configura��o  das depend�ncias
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            ///adi��o das classes a serem inhjetadas
            DependenciasServicos.Configure(container);
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }

}