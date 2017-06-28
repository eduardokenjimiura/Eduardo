using Microsoft.Practices.Unity;
using Repositiory.MongoDB.Anotacao;
using Repositiory.MongoDB.Anotacao.Interface;
using Repositiory.MongoDB.Documento;
using Repositiory.MongoDB.Documento.Interface;
using Domain.MongoDB;
using Domain.MongoDB.Composicoes;
using TecnoSet.ECM.Seguranca;
using TecnoSet.ECM.Servicos;
using TecnoSet.ECM.Servicos.Padrao;
using TecnoSet.ECM.Servicos.Padrao.Seguranca;
using TecnoSet.ECM.Servicos.Seguranca;
using TecnoSet.Net;

namespace TecnoSet.ECM.ConfiguracaoDependencias.Padrao.Unity
{
    public static class DependenciasImageNow
    {
        public static void Configure(IUnityContainer container)
        {

            ConfigureMocks(container);

            ConfigureImageNow(container);


           // container.RegisterType<IMapeadorTipoDocumento, MapeadorTipoDocumento>(DefaultLifetime);
        }
        
        private static void ConfigureImageNow(IUnityContainer container)
        {
            container.RegisterType<IAnotacaoRepository, AnotacaoRepository>(DefaultLifetime);
            container.RegisterType<IAnotacaoServico, AnotacaoServico>(DefaultLifetime);
            container.RegisterType<IDocumentoFavoritoRepository, DocumentoFavoritoRepository>(DefaultLifetime);

            container.RegisterType<IDocumentoFavoritoServico, DocumentoFavoritoService>(DefaultLifetime);

            container.RegisterType<IDocumentoRepository, DocumentoRepository>(DefaultLifetime);
            container.RegisterType<IDocumentoDataRepository, DocumentoDataRepository>(DefaultLifetime);
            container.RegisterType<IAnotacaoServico, AnotacaoServico>(DefaultLifetime);
            //container.RegisterType<IAnotacaoDocumentoServico, AnotacaoDocumentoServico>(DefaultLifetime);

            //container.RegisterType<ITipoDocumentoServico, SincronizadorTipoDocumentoServico>(DefaultLifetime);
        }

        private static void ConfigureMocks(IUnityContainer container)
        {
           // container.RegisterInstance<IAnotacaoServico>(new TecnoSet.ECM.Servicos.Mock.DocumentoServico());
            //container.RegisterType<IRepositorioDocumentoService, TecnoSet.ECM.Servicos.Mock.RepositorioDocumentoDrawerService>(DefaultLifetime);
        }

        private static LifetimeManager DefaultLifetime
        {
            get
            {
                return new HierarchicalLifetimeManager();
            }
        }
    }
}