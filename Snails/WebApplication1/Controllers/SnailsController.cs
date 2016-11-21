using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SnailsController : ApiController
    {
        private readonly SnailsRepository _repository;

        public SnailsController(SnailsRepository snailsRepository)
        {
            _repository = snailsRepository;
        }

        [HttpGet]
        public Task<HttpResponseMessage> Get(int id)
        {
            var snail = _repository.Get(id);
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, snail));
        }

        [HttpPost]
        public Task<HttpResponseMessage> Create([FromBody] Snail snail)
        {
            _repository.Create(snail);
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.Created));
        }

        [HttpPut]
        public Task<HttpResponseMessage> Update([FromBody] Snail snail)
        {
            _repository.Update(snail);
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK));
        }

        [HttpDelete]
        public Task<HttpResponseMessage> Delete(int id)
        {
            _repository.Delete(id);
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK));
        }
    }
}
