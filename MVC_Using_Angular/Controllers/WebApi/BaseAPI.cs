
using DTO; 
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_Using_Angular.Controllers.WebApi
{
    public abstract class BaseAPI<T> : System.Web.Http.ApiController
    where T : class, IIdEntidade, new()
    {

     
        public BaseAPI(Domains.Base.IQueryableCrudService<T> servico)
        {
            CrudService = servico;
        }

        protected Domains.Base.IQueryableCrudService<T> CrudService { get; set; }


        public virtual IQueryable<T> Get()
        {
            return CrudService.Listar();
        }
        
        [HttpGet]
        public virtual T Get(int id)
        {
            var retornosssss = Get();
            var retorno = Get().FirstOrDefault(g => g.Id == id);
            return retorno;
        }

        [HttpPut]
        public virtual HttpResponseMessage Put(int id, [FromBody]T entidade)
        {
            CrudService.Alterar(entidade);
            return Request.CreateResponse(HttpStatusCode.OK, entidade);
        }

        [HttpPost]
        public virtual HttpResponseMessage Post([FromBody]T entidade)
        {
            CrudService.Criar(entidade);
            return Request.CreateResponse(HttpStatusCode.Created, entidade);
        }

        [HttpDelete]
        public virtual HttpResponseMessage Delete(int id)
        {
            var entity = new T();
            entity.Id = id;
            CrudService.Excluir(entity);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}