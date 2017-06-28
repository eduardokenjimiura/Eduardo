using Application.BaseAppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.Entidades;
using System.Linq.Expressions;
using Domains.Interfaces.Service;
using Domains.Base;
using DTO;

namespace Application
{
    /// <summary>
    /// Camada que recebe os dados provindos do webapi
    /// </summary>
    public class CarroAppService : ICarroAppService
    {
        #region Propriedades
        ICarroService _servico;
        #endregion

        #region Construtores
        public CarroAppService(ICarroService service)
        {
            _servico = service;
        }

        #endregion

        #region Métodos
        public void Alterar(CarroDTO entidade)
        {
            _servico.Alterar(Util.CastDTO.castCarroDTOParaEntidade(entidade));
        }

        public void Criar(CarroDTO entidade)
        {
            _servico.Criar(Util.CastDTO.castCarroDTOParaEntidade(entidade));
        }

        public void Excluir(CarroDTO entidade)
        {
            _servico.Excluir(Util.CastDTO.castCarroDTOParaEntidade(entidade));
        }

        public IQueryable<CarroDTO> Listar()
        {
            List<CarroDTO> carrosDto = new List<CarroDTO>();
            var lista = _servico.Listar();
            foreach (var item in lista)
            {
                carrosDto.Add(Util.CastDTO.castEntidadeParaCarroDTO(item));
            }

            return carrosDto.AsQueryable();

        }
        public IQueryable<CarroDTO> Listar(int id)
        {
            List<CarroDTO> carrosDto = new List<CarroDTO>();
            var lista = _servico.Listar(id);
            foreach (var item in lista)
            {
                carrosDto.Add(Util.CastDTO.castEntidadeParaCarroDTO(item));
            }
            return carrosDto.AsQueryable();
        }
        #endregion
    }
}
