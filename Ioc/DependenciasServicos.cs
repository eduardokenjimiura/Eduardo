using Application;
using Application.BaseAppService;
using Domains.Interfaces.Service;
using Domains.Servico;
using Microsoft.Practices.Unity;


namespace Ioc
{
    /// <summary>
    /// Configura as dependêcias do serviço para o unity
    /// </summary>
    public static class DependenciasServicos
    {
        #region Propriedades
        private static LifetimeManager DefaultLifetime
        {
            get
            {
                return new HierarchicalLifetimeManager();
            }
        }
        #endregion
       
        #region Métodos

        public static void Configure(IUnityContainer container)
        {
            container.RegisterType<ICarroService, CarroService>(DefaultLifetime);
            container.RegisterType<ICarroAppService, CarroAppService>(DefaultLifetime);
        }
        #endregion
        
    }
}