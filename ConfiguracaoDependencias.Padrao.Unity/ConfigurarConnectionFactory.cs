using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoSet.ECM.ConfiguracaoDependencias.Padrao.Unity
{
    public class ConfigurarConnectionFactory : IDbConnectionFactory
    {
        private IDbConnectionFactory _internalFactory;

        public ConfigurarConnectionFactory()
        {
            _internalFactory = new System.Data.Entity.Infrastructure.SqlConnectionFactory();
        }
        public ConfigurarConnectionFactory(string nameOrConnectionString)
        {
            _internalFactory = new System.Data.Entity.Infrastructure.SqlConnectionFactory(nameOrConnectionString);
        }

        public System.Data.Common.DbConnection CreateConnection(string nameOrConnectionString)
        {
            //DependenciasDados.ConfigurarEntidadesBanco();
            return _internalFactory.CreateConnection(nameOrConnectionString);
        }
    }
}
