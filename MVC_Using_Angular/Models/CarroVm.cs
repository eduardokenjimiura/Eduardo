 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Using_Angular.Models
{
    /// <summary>
    /// View model da entidade carros
    /// </summary>
    public class CarroVm 
    {
        #region Construtor
        public CarroVm() { }
        #endregion

        #region Propriedades
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public string Cor { get; set; }
        #endregion
    }
}