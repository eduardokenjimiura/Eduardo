using Domains.Entidades;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    /// <summary>
    /// Classe que realiza o cast de uma entidade para outra, infelizmente não deu tempo para adicionar ium automapper
    /// 
    /// </summary>
    public class CastDTO
    {
        #region Métodos
        public static Carro castCarroDTOParaEntidade(CarroDTO carroDTO)
        {
            Carro carro = new Carro();
            carro.Id = carroDTO.Id;
            carro.Ano = carroDTO.Ano;
            carro.Cor = carroDTO.Cor;
            carro.Modelo = carroDTO.Modelo;
            carro.Nome = carroDTO.Nome;
            carro.Placa = carroDTO.Placa;
            return carro;
        }
        public static CarroDTO castEntidadeParaCarroDTO(Carro carro)
        {
            CarroDTO carroDTO = new CarroDTO();
            carroDTO.Id = carro.Id;
            carroDTO.Ano = carro.Ano;
            carroDTO.Cor = carro.Cor;
            carroDTO.Modelo = carro.Modelo;
            carroDTO.Nome = carro.Nome;
            carroDTO.Placa = carro.Placa;
            return carroDTO;
        }
        #endregion
    }
}
