using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    /// <summary>
    /// Adicionei esta classe para que as entidades possuam a propriedade Id
    /// </summary>
    public class Entidade:IIdEntidade
    {
        public virtual int Id { get; set; }
    }
}