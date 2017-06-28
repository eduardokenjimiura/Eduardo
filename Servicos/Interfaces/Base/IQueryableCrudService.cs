using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public interface IQueryableCrudService<TEntidade> : ICrudService<TEntidade>
    {
        IQueryable<TEntidade> Listar();
    }
}
