using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public interface ICrudService<TEntidade>
    {
        void Alterar(TEntidade entidade);
        void Criar(TEntidade entidade);
        void Excluir(TEntidade entidade);
    }
}
