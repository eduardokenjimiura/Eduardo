using Domains.Entidades;
using RepositoryEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    /// <summary>
    /// Classe que realiza o cast de uma entidade para outra, infelizmente não deu tempo para adicionar ium automapper
    /// </summary>

    public class CastEntidadeBancoToModel
    {
        #region Métodos
        public static Carro castCarroEntidadeBancoParaEntidade(CARRO carroRep)
        {
            Carro carro = new Carro();
            carro.Id = carroRep.ID;
            carro.Ano = carroRep.Ano;
            carro.Cor = carroRep.Cor;
            carro.Nome = carroRep.Nome;
            carro.Modelo = carroRep.Modelo;
            carro.Placa = carroRep.PLACA;
            return carro;
        }
        public static CARRO castEntidadeParaCarroEntidadeBanco(Carro carro)
        {
            CARRO carroBD = new CARRO();
            carroBD.ID = carro.Id;
            carroBD.Ano = carro.Ano;
            carroBD.Cor = carro.Cor;
            carroBD.Nome = carro.Nome;
            carroBD.Modelo = carro.Modelo;
            carroBD.PLACA = carro.Placa;


            return carroBD;
        }
        #endregion
    }
}
