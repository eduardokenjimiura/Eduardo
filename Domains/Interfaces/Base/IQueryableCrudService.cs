using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Base
{
    /// <summary>
    /// interface com métodos  somente de listagens
    /// </summary>
    /// <typeparam name="TEntidade"></typeparam>
    public interface IQueryableCrudService<TEntidade> : ICrudService<TEntidade>
    {
        #region Métodos

        IQueryable<TEntidade> Listar();

        IQueryable<TEntidade> Listar(int id);

        #endregion

    }
}
