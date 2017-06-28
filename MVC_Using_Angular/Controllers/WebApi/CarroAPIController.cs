using Application.BaseAppService;
using Domains.Base;
using DTO;
using MVC_Using_Angular.Controllers.WebApi;
using MVC_Using_Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVC_Using_Angular.Controllers
{


    /// <summary>
    ///Api para a entidade de carro
    /// </summary>
    [RoutePrefix("api/CarroAPI")]
    public class CarroAPIController : BaseAPI<CarroDTO>
    {

        ICarroAppService _servico;
        public CarroAPIController(ICarroAppService servico) : base(servico)
        {
            _servico = servico;
        }

 

    }
}