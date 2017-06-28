using Domains.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.Entidades;
using System.Linq.Expressions;
using RepositoryEntity.Interface;

namespace Repository
{
    /// <summary>
    /// classe que faz a comunicação com a especificação do framework de manipulação de dados, neste caso 
    /// a comunicação será feita com o projeto Repository Entity que é uma implementaçaõ do entityFramework
    /// </summary>
    public class RepositoryCarro : ICarroRepository
    {
        #region Propriedades

        IRepositoryEntityCarro _repository;
        #endregion

        #region Construtores


        public RepositoryCarro(IRepositoryEntityCarro repository)
        {
            _repository = repository;
        }
        #endregion

        #region Métodos

         
        public void Adicionar(Carro entity)
        {
            _repository.Add(Util.CastEntidadeBancoToModel.castEntidadeParaCarroEntidadeBanco(entity));
        }

         
        public void Alterar(Carro entity)
        {
            _repository.Update((Util.CastEntidadeBancoToModel.castEntidadeParaCarroEntidadeBanco(entity)));
        }

        public Carro buscar(int id)
        {
            return Util.CastEntidadeBancoToModel.castCarroEntidadeBancoParaEntidade(_repository.Get(id));
        }

        public IEnumerable<Carro> buscarEspecifico(Expression<Func<Carro, bool>> predicate, bool @readonly = false)
        {
            throw new NotImplementedException();
        }
               /// <summary>
        /// delega a  busca de todos os registros de carro
        /// </summary>
        /// <param name="readonly"></param>
        /// <returns></returns>
 
        public IEnumerable<Carro> buscarTodos(bool @readonly = false)
        {
            List<Carro> carros = new List<Carro>();
            ///carro que vem do banco
            var retorno = _repository.All();

            foreach (var carro in retorno)
            {
                carros.Add(Util.CastEntidadeBancoToModel.castCarroEntidadeBancoParaEntidade(carro));

            }

            return carros;

        }

        public void Deletar(Carro entity)
        {
            _repository.Delete(Util.CastEntidadeBancoToModel.castEntidadeParaCarroEntidadeBanco(entity));
        }

         public IEnumerable<Carro> Find(Expression<Func<Carro, bool>> predicate, bool @readonly = false)
        {
            throw new NotImplementedException();

        }

  
        #endregion
    }
}
