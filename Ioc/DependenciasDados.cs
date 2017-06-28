using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using RepositoryEntity.Repository;
using RepositoryEntity.Interface;
using Domains.Interfaces.Repository;
using Repository;

namespace Ioc
{
    public static class DependenciasDados
    {
        #region propriedades
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
            container.RegisterType<IRepositoryEntityCarro, RepositoryEntityCarro>(DefaultLifetime);
            container.RegisterType<ICarroRepository, RepositoryCarro>(DefaultLifetime);
        }

        private static void CriarBanco(IUnityContainer container)
        {

        }
        #endregion

    }
}