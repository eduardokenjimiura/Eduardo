using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TecnoSet.Data;
using TecnoSet.Data.EntityFramework;
using TecnoSet.ECM.Dados;
using TecnoSet.ECM.Dados.EntityFramework;
using TecnoSet.ECM.Dados.EntityFramework.Estrutura;
using TecnoSet.ECM.Dados.EntityFramework.Repositorios;
using TecnoSet.ECM.Dados.EntityFramework.Repositorios.Views;
using TecnoSet.ECM.Modelo;
using TecnoSet.ECM.Modelo.Views;
using TecnoSet.Model;
using Repositiory.MongoDB.Documento;
using Repositiory.MongoDB.Documento.Interface;
using static TecnoSet.ECM.Modelo.Views.Lista;

namespace TecnoSet.ECM.ConfiguracaoDependencias.Padrao.Unity
{
    public static class DependenciasDados
    {
        public static void Configurar(IUnityContainer container)
        {
            container.RegisterType(typeof(IRepository<>), typeof(EntityFrameworkRepository<>), DefaultLifetime());

            container.RegisterType<IAtividadeRepositorio, AtividadeRepositorio>(DefaultLifetime());
            container.RegisterType<IUsuarioGlobalRepositorio, UsuarioGlobalRepositorio>(DefaultLifetime());

            container.RegistrarRepositorioPorConta<TipoDocumento, ContaTipoDocumento>();
            container.RegisterType<IRepository<TipoDocumentoPropriedade>, TipoDocumentoPropriedadeRepositorio>(DefaultLifetime());
            container.RegistrarRepositorioPorConta<Usuario, ContaUsuario>();

            container.RegistrarRepositorioPorConta<Lista, ContaLista>();


            container.RegisterType<IHistoricoAprovacoesRepository, HistoricoAprovacoesRepository>(DefaultLifetime());
            container.RegisterType<IlogEntidadesRepository, LogEntidadesRepositorio>(DefaultLifetime());
            container.RegisterType<IlogRepository, LogRepositorio>(DefaultLifetime());
            
                     container.RegisterType<IConfiguracaoEmailRepository, ConfiguracaoEmailRepository>(DefaultLifetime());
            container.RegisterType<IStateGrupoUsuarioRepository, StateGrupoUsuarioRepository>(DefaultLifetime());
            container.RegisterType<IMensagemRepository, MensagemRepository>(DefaultLifetime());
            container.RegisterType<IMensagemUsuarioRepository, UsuarioMensagemRepository>(DefaultLifetime());
            container.RegisterType<IHistoricoAcessDocumentoRepository, HistoricoAcessDocumentoRepository>(DefaultLifetime());


            container.RegisterType<IUsuarioRepositorio, UsuarioRepositorio>(DefaultLifetime());
            container.RegisterType<IRepository<UsuarioPermissaoAtividade>, UsuarioPermissaoAtividadeRepositorio>(DefaultLifetime());
            container.RegistrarRepositorioPorConta<GrupoUsuario, ContaGrupoUsuario>();
            container.RegisterType<IRepository<GrupoUsuarioUsuario>, GrupoUsuarioUsuarioRepositorio>();

            container.RegisterType<IListaConfiguracaoRePOSITORIO, ListaConfiguracaorRepositorio>();
            container.RegisterType<IPermissaoRepositorio, PermissaoRepositorio>();
            container.RegisterType<IGrupoRepositorio, GrupoRepositorio>();
            container.RegisterType<IContaRepositorio, ContaRepositorio>(DefaultLifetime());
            container.RegisterType<IDocumentoFavoritoRepository, DocumentoFavoritoRepository>(DefaultLifetime());

            container.RegisterType<IDocumentoDataUsuarioRepository, DocumentoDataUsuarioRepository>(DefaultLifetime());
            container.RegisterType<IRepository<ListaFiltro>, ListaFiltroRepositorio>(DefaultLifetime());
            container.RegisterType<IRepository<ListaFiltroGrupo>, ListaFiltroGrupoRepositorio>(DefaultLifetime());
            container.RegisterType<IListaFiltroGrupoRepositorio, ListaFiltroGrupoRepositorio>(DefaultLifetime());

            container.RegisterType<IPropriedadeListaItemRepository, PropriedadeListaItemRepository>(DefaultLifetime());
            container.RegisterType<IPropriedadeListaRepository, PropriedadeListaRepository>(DefaultLifetime());
            container.RegisterType<IWorkFlowRepository, WorkFlowRepositorio>(DefaultLifetime());
            container.RegisterType<IMalhaStatusRepository, MalhaStatusRepositorio>(DefaultLifetime());
            container.RegisterType<IStatusRepositorio, StatusRepositorio>(DefaultLifetime());





            TecnoSet.ECM.Data.Migrations.TodasDbContext.ConfigurarEntidadesImageNow();

            ConfigurarBanco(container);
            //CriarBanco(container);

            IgnorarOtimizacaoParaQueADllDoEntityFiqueNaPasta();
        }

        private static void CriarBanco(IUnityContainer container)
        {
            new EcmDatabaseInitializer().InitializeDatabase(container.Resolve<EcmDbContext>());
        }


        public static void IgnorarOtimizacaoParaQueADllDoEntityFiqueNaPasta()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public static void RegistrarRepositorioPorConta<T, TRelacao>(this IUnityContainer container)
            where T : class, IEntidadeDeContas<T, TRelacao>
            where TRelacao : class, IPertenceAConta, IRelacaoContaEntidade<T>, new()
        {
            container.RegisterType<IRepository<T>, RepositorioPorConta<T, TRelacao>>(DefaultLifetime());
        }

        private static void ConfigurarBanco(IUnityContainer container)
        {
            Database.SetInitializer(new EcmDatabaseInitializer());

            MsSql2008EnUsMessageParser.Initialize(TecnoSet.ECM.Resources.MensagensBanco.ResourceManager);
            container.RegisterInstance<ISqlMessageParser>(MsSql2008EnUsMessageParser.Instance);
        }



        private static LifetimeManager DefaultLifetime()
        {
            return new HierarchicalLifetimeManager();
        }
    }
}