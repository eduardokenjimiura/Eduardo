using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// Dto da entidade carro
    /// </summary>
    public class CarroDTO : Entidade
    {
        #region Propriedades
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        #endregion
    }
}
