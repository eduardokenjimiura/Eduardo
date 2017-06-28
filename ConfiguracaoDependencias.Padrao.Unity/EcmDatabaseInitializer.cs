using System.Data.Entity;
using TecnoSet.ECM.Modelo;
using System;
using TecnoSet.ECM.Dados.EntityFramework.Estrutura;
using System.Collections.Generic;
using TecnoSet.ECM.Resources;
using TecnoSet.ECM.Servicos;
using System.Security.Cryptography;
using System.Data.Entity.Migrations;
using TecnoSet.ECM.Data.Migrations.Migrations;
using System.Linq;
using System.Data.Entity.Migrations.Infrastructure;
using System.IO;
using TecnoSet.ECM.Data.Migrations;

namespace TecnoSet.ECM.Dados.EntityFramework
{
    public class EcmDatabaseInitializer : IDatabaseInitializer<EcmDbContext>
    {
        public EcmDatabaseInitializer()
        {
            
        }

        private static readonly object _initializeDatabaseLock = new object();
        public void InitializeDatabase(EcmDbContext context)
        {
            bool databaseExists = false;
            lock (_initializeDatabaseLock)
            {
                databaseExists = context.Database.Exists();
                //var migrator = MigrationHelper.CreateMigrator(context);
                //string lastMigration = migrator.GetPendingMigrations().LastOrDefault();
                //if (lastMigration != null)
                //{
                //    try
                //    {
                //        migrator.Update();
                //    }
                //    catch (System.Data.Entity.Migrations.Infrastructure.MigrationsException e)
                //    {
                //        string directory = Path.Combine(System.IO.PathUtil.GetAssemblyDirectory(System.Reflection.Assembly.GetEntryAssembly()), "App_Data/migrations/"); 
                //        string fileName =  directory + lastMigration;
                //        MigrationHelper.SaveScript(migrator, fileName);

                //        throw new Exception("Erro ao atualizar base de dados. Script disponivel em " + fileName, e);
                //    }
                //}
            }

            if (!databaseExists)
            {
                DataSeed.AdicionarAtividades(context);
                DataSeed.AdicionarDadosParaTeste(context);
            }
        }
    }

    public static class DataSeed
    {
        public static void AdicionarAtividades(EcmDbContext context)
        {
            var atividades = context.Set<Atividade>();

            atividades.Add(new Atividade
            {
                Id = Claims.Seguranca.Id,
                Nome = "Segurança",
                Ordem = 1,
                Atividades = new List<Atividade>
                {
                    new Atividade { Id = Claims.Seguranca.GrupoUsuario.Id, Nome = ModelNames.GrupoUsuario, Ordem = 1, Atividades = new List<Atividade>{
                        new Atividade{ Id = Claims.Seguranca.GrupoUsuario.Ler, Nome = "Ler", Ordem = 1 },
                        new Atividade{ Id = Claims.Seguranca.GrupoUsuario.Criar, Nome = "Incluir" , Ordem = 2},
                        new Atividade{ Id = Claims.Seguranca.GrupoUsuario.Alterar, Nome = "Alterar", Ordem = 3 },
                        new Atividade{ Id = Claims.Seguranca.GrupoUsuario.Excluir, Nome = "Excluir", Ordem = 4 },
                        new Atividade { Id = Claims.Seguranca.GrupoUsuario.ConcederPermissao, Nome = "Conceder permissões", Ordem = 5 },
                        new Atividade { Id = Claims.Seguranca.GrupoUsuario.LerPermissao, Nome = "Ler permissão", Ordem = 6 },
                        new Atividade { Id = Claims.Seguranca.GrupoUsuario.AdicionarUsuario, Nome = "Adicionar usuário", Ordem = 7 },
                        new Atividade { Id = Claims.Seguranca.GrupoUsuario.RemoverUsuario, Nome = "Remover usuário", Ordem = 8 },
                    }},

                    new Atividade { Id = Claims.Seguranca.Usuario.Id, Nome = ModelNames.Usuario, Ordem = 2, Atividades = new List<Atividade>{
                        new Atividade{ Id = Claims.Seguranca.Usuario.Ler, Nome = "Ler", Ordem = 1 },
                        new Atividade{ Id = Claims.Seguranca.Usuario.Criar, Nome = "Incluir" , Ordem = 2},
                        new Atividade{ Id = Claims.Seguranca.Usuario.Alterar, Nome = "Alterar", Ordem = 3 },
                        new Atividade{ Id = Claims.Seguranca.Usuario.Excluir, Nome = "Excluir", Ordem = 4 },
                        new Atividade { Id = Claims.Seguranca.Usuario.ConcederPermissao, Nome = "Conceder permissões", Ordem = 5 },
                        new Atividade { Id = Claims.Seguranca.Usuario.LerPermissao, Nome = "Ler permissão", Ordem = 6 },
                        new Atividade { Id = Claims.Seguranca.Usuario.RedefinirSenha, Nome = "Redefinir senha", Ordem = 6 },
                    }}
                }
            });
          //  context.SaveChanges();
            atividades.Add(new Atividade
            {
                Id = Claims.Configuracao.Id,
                Nome = "Configuração",
                Ordem = 2,
                Atividades = new List<Atividade>
                {
                      new Atividade { Id = Claims.Configuracao.TipoDocumento.Id, Nome = ModelNames.TipoDocumento, Ordem = 1, Atividades = new List<Atividade>{
                        new Atividade{ Id = Claims.Configuracao.TipoDocumento.Ler, Nome = "Ler", Ordem = 1 },
                        new Atividade{ Id = Claims.Configuracao.TipoDocumento.Criar, Nome = "Incluir" , Ordem = 2},
                        new Atividade{ Id = Claims.Configuracao.TipoDocumento.Alterar, Nome = "Alterar", Ordem = 3 },
                        new Atividade{ Id = Claims.Configuracao.TipoDocumento.Excluir, Nome = "Excluir", Ordem = 4 },
                      }},
                      new Atividade { Id = Claims.Configuracao.TipoDocumento.Propriedade.Id, Nome = ModelNames.TipoDocumentoPropriedade, Ordem = 2, Atividades = new List<Atividade>{
                        new Atividade{ Id = Claims.Configuracao.TipoDocumento.Propriedade.Ler, Nome = "Ler", Ordem = 1 },
                        new Atividade{ Id = Claims.Configuracao.TipoDocumento.Propriedade.Criar, Nome = "Incluir" , Ordem = 2},
                        new Atividade{ Id = Claims.Configuracao.TipoDocumento.Propriedade.Alterar, Nome = "Alterar", Ordem = 3 },
                        new Atividade{ Id = Claims.Configuracao.TipoDocumento.Propriedade.Excluir, Nome = "Excluir", Ordem = 4 }
                    }}//,
                    //  new Atividade { Id = Claims.Configuracao.TipoDocumento.Propriedade.Id, Nome = ModelNames.Administrativo, Ordem = 3, Atividades = new List<Atividade>{
                    //    new Atividade{ Id = Claims.Configuracao.TipoDocumento.Propriedade.Ler, Nome = "Ler", Ordem = 1 },
                    //    new Atividade{ Id = Claims.Configuracao.TipoDocumento.Propriedade.Criar, Nome = "Incluir" , Ordem = 2},
                    //    new Atividade{ Id = Claims.Configuracao.TipoDocumento.Propriedade.Alterar, Nome = "Alterar", Ordem = 3 },
                    //    new Atividade{ Id = Claims.Configuracao.TipoDocumento.Propriedade.Excluir, Nome = "Excluir", Ordem = 4 }
                    //}}
                }
            });
          //  context.SaveChanges();
            atividades.Add(new Atividade
            {
                Id = Claims.Documento.Id,
                Nome = "Documentos",
                Ordem = 3,
                Atividades = new List<Atividade>
                {
                      new Atividade { Id = Claims.Documento.Lista.Id, Nome = ModelNames.Lista, Ordem = 1, Atividades = new List<Atividade>{
                        new Atividade{ Id = Claims.Documento.Lista.Ler, Nome = "Ler", Ordem = 1 },
                        new Atividade{ Id = Claims.Documento.Lista.Criar, Nome = "Incluir" , Ordem = 2},
                        new Atividade{ Id = Claims.Documento.Lista.Alterar, Nome = "Alterar", Ordem = 3 },
                        new Atividade{ Id = Claims.Documento.Lista.Excluir, Nome = "Excluir", Ordem = 4 },
                      }}
                }
            });
           // context.SaveChanges();
        }

        public static List<Atividade> ObterAtividades(Type classeDefinicaoAtividades)
        {
            throw new NotImplementedException();
        }

        public static void AdicionarDadosParaTeste(EcmDbContext context)
        {
            var conta = new ContaJuridica
            {
                Nome = "Teste",
                Cnpj = "12345678901234",
                Ie = "12345678901",
                Email = "empresa@dominio.com",
                Endereco = new Endereco { Cep = "15000000", Bairro = "Bairro", Rua = "Rua", Numero = 0, UfId = "SP" }
            };

            context.Set<Conta>().Add(conta);

            var owner = new Usuario
            {
                Nome = "OWNER",
                Senha = SHA512Helper.Create("admin"),
                Email = "admin",
                Sobrenome = "da Silva",
                Ativo = true,
                Owners = new List<UsuarioOwnerConta> { new UsuarioOwnerConta { Conta = conta, UsuarioId = 1 } }
            };

            owner.AssociarAConta<ContaUsuario, Usuario>(conta);

            context.Set<Usuario>().Add(owner);

            //var associacaoContaDrawer = context.Set<TecnoSet.ECM.Modelo.ImageNow.ContaDrawerImageNow>();
            //associacaoContaDrawer.Add(new Modelo.ImageNow.ContaDrawerImageNow
            //{
            //    Conta = conta,
            //    DrawerImageNowId = "321YY3Z_0006T4VBQ0001GW",
            //    DrawerImageNowNome = "TesteDesenv"
            //});


            var propriedade1 = new TipoDocumentoPropriedade { Nome = "Primeiro propriedade", Obrigatorio = true };
            var propriedade2 = new TipoDocumentoPropriedade { Nome = "Segunda", Obrigatorio = true };
            var propriedade3 = new TipoDocumentoPropriedade { Nome = "Terça", Obrigatorio = true };
            var propriedade4 = new TipoDocumentoPropriedade { Nome = "Quarta", Obrigatorio = true };
            var propriedade5 = new TipoDocumentoPropriedade { Nome = "Quinta", Obrigatorio = true };

            var tipoDocumentoDefault = new TipoDocumento
            {
                Nome = "Padrão",
                Propriedades = new List<TipoDocumentoPropriedade> { propriedade1, propriedade2, propriedade3, propriedade4, propriedade5 }
            };
            tipoDocumentoDefault.AssociarAConta<ContaTipoDocumento, TipoDocumento>(conta);

            //var associacaoTipos = context.Set<TecnoSet.ECM.Modelo.ImageNow.TipoDocumentoImageNow>();
            //associacaoTipos.Add(new Modelo.ImageNow.TipoDocumentoImageNow
            //{
            //    DocumentTypeName = "Default",
            //    DocumentTypeId = "1000184816_1738021400",
            //    TipoDocumento = tipoDocumentoDefault
            //});

            byte i = 0;
            //var posicoesKey = context.Set<TecnoSet.ECM.Modelo.ImageNow.TipoDocumentoPosicaoPropriedadeImageNow>();
            //foreach (var propriedade in tipoDocumentoDefault.Propriedades)
            //{
            //    posicoesKey.Add(new Modelo.ImageNow.TipoDocumentoPosicaoPropriedadeImageNow { Posicao = i++, TipoDocumentoPropriedade = propriedade });
            //}

           // context.SaveChanges();


            var novasAtividades = new List<Atividade>
            {
                new Atividade { Ordem = 0, Id = Claims.Documento.DoTipo(tipoDocumentoDefault.Id, Claims.ler), Nome = "Ler" },
                new Atividade { Ordem = 1, Id = Claims.Documento.DoTipo(tipoDocumentoDefault.Id, Claims.criar), Nome = "Incluir" },
                new Atividade { Ordem = 2, Id = Claims.Documento.DoTipo(tipoDocumentoDefault.Id, Claims.alterar), Nome = "Alterar" },
                new Atividade { Ordem = 3, Id = Claims.Documento.DoTipo(tipoDocumentoDefault.Id, Claims.excluir), Nome = "Excluir" },
                new Atividade { Ordem = 4, Id = Claims.Documento.DoTipo(tipoDocumentoDefault.Id, Claims.Documento.Download), Nome = "Download" }
            };
            context.Set<AtividadeTipoDocumento>().Add(new AtividadeTipoDocumento
            {
                AtividadePaiId = "doc",
                Id = string.Concat(Claims.Documento.PrefixoAtividadeTipoDoc, tipoDocumentoDefault.Id),
                TipoDocumentoId = tipoDocumentoDefault.Id,
                Atividades = novasAtividades
            });
          //  context.SaveChanges();
        }

    }
}