namespace RepositoryEntity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntityModelo : DbContext
    {
        public EntityModelo()
            : base("name=EntityModelo")
        {
        }

        public virtual DbSet<CARRO> CARRO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CARRO>()
            .Property(e => e.Modelo)
            .IsUnicode(false);

            modelBuilder.Entity<CARRO>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<CARRO>()
                .Property(e => e.Ano)
                .IsUnicode(false);

            modelBuilder.Entity<CARRO>()
                .Property(e => e.Cor)
                .IsUnicode(false);

            modelBuilder.Entity<CARRO>()
                .Property(e => e.PLACA)
                .IsUnicode(false);
        }
    }
}
