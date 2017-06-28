using Application;
using Application.BaseAppService;
using Domains.Interfaces.Service;
using Domains.Servico;
using Microsoft.Practices.Unity;

using TecnoSet.Net;

namespace TecnoSet.ECM.ConfiguracaoDependencias.Padrao.Unity
{
    public static class DependenciasServicos
    {
        public static void Configure(IUnityContainer container)
        {
            container.RegisterType<ICarroService, CarroService>(DefaultLifetime);
            container.RegisterType<ICarroAppService, CarroAppService>(DefaultLifetime);
           
            DependenciasImageNow.Configure(container);
        }

        private static LifetimeManager DefaultLifetime
        {
            get
            {
               
            }
        }
    }
}