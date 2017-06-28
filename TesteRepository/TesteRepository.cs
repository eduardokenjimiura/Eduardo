using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryEntity;
using RepositoryEntity.Repository;

namespace TesteRepository
{
    [TestClass]
    public class TesteRepository
    {
        [TestMethod]
        public void TesteBuscarTodos()
        {
            RepositoryEntityCarro rep = new RepositoryEntityCarro();
            Assert.IsNotNull(rep.All(), "ok");
        }

        [TestMethod]
        public void Inserir()
        {
            RepositoryEntityCarro rep = new RepositoryEntityCarro();
            CARRO carro = new CARRO();
            carro.Ano = "2017";
            carro.Cor = "Cor";
            carro.PLACA = "Placa";
            carro.Nome = "Nome";

            var carroDb = rep.Get(carro.ID) ;
            Assert.IsNotNull(carroDb,"ok");
        }

 


    }
}
