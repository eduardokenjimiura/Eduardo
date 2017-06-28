
using Domains.Base;
using Domains.Entidades;
using Domains.Interfaces.Repository;
using Domains.Interfaces.Service;
using Domains.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Servico
{
    /// <summary>
    ///Classe de serviço responsável por manter a entidade carro
    /// </summary>
    public class CarroService : ICarroService
    {
        #region Variaveis
        /// <summary>
        /// Variável que será injetada, responsável pelo repositorio
        /// </summary>
        ICarroRepository _repoCarro;
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor da classe que fará recebe a entidade de repository
        /// </summary>
        /// <param name="repoCarro"></param>
        public CarroService(ICarroRepository repoCarro)
        {
            _repoCarro = repoCarro;
        }
        #endregion

        #region Métodos

        /// <summary>
        /// altera a entidade Carro
        /// </summary>
        /// <param name="entidade"></param>
        public void Alterar(Carro entidade)
        {
            _repoCarro.Alterar(entidade);
        }

        /// <summary>
        /// Cria uma nova entidade carro
        /// </summary>
        /// <param name="entidade"></param>
        public void Criar(Carro entidade)
        {
            _repoCarro.Adicionar(entidade);
        }

        /// <summary>
        /// exclui uma entidade carro
        /// </summary>
        /// <param name="entidade"></param>
        public void Excluir(Carro entidade)
        {
            _repoCarro.Deletar(entidade);
        }

        /// <summary>
        /// Lista todos os carros já persistidos
        /// </summary>
        /// <returns></returns>
        public IQueryable<Carro> Listar()
        {
            var retorno = _repoCarro.buscarTodos().AsQueryable();
            return retorno;
        }


        /// <summary>
        /// 
        /// lista por id
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<Carro> Listar(int id)
        {
            var retorno = _repoCarro.buscarEspecifico(_s => _s.Id == id).AsQueryable();
            return retorno;
        }

        /// <summary>
        /// lista por cor
        /// </summary>
        /// <param name="cor"></param>
        /// <returns></returns>
        public IQueryable<Carro> ListarPorCor(string cor)
        {
            var retorno = _repoCarro.buscarEspecifico(_s => _s.Cor.Equals(cor)).AsQueryable();
            return retorno;
        }
        #endregion

    }
}
