namespace RepositoryEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CARRO")]
    public partial class CARRO
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [StringLength(200)]
        public string Nome { get; set; }

   
        [StringLength(200)]
        public string Ano { get; set; }

        [StringLength(200)]
        public string Cor { get; set; }

        [StringLength(200)]
        public string PLACA { get; set; }


        [StringLength(200)]
        public string Modelo { get; set; }

    }
}
