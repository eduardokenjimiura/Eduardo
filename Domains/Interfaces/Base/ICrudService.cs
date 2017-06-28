using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Base
{
    /// <summary>
    /// Interface genérica para os serviços de criar, aletear e deletar
    /// </summary>
    /// <typeparam name="TEntidade"></typeparam>
    public interface ICrudService<TEntidade>
    {
        #region Métodos

        void Alterar(TEntidade entidade);
        void Criar(TEntidade entidade);
        void Excluir(TEntidade entidade);

        #endregion
    }
}
