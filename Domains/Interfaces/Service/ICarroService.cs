using Domains.Base;
using Domains.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Interfaces.Service
{
    public interface ICarroService :   IQueryableCrudService<Carro>
    {
        IQueryable<Carro> ListarPorCor(string cor);

    }
}
