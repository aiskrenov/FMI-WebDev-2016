using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RacesController : ApiController
    {
        private readonly RacesRepository _repository;

        public RacesController(RacesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public Task<HttpResponseMessage> Get(int id)
        {
            var snail = _repository.Get(id);
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, snail));
        }

        [HttpPost]
        public Task<HttpResponseMessage> Create([FromBody] Race race)
        {
            _repository.Create(race);
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.Created));
        }

        [HttpPut]
        public Task<HttpResponseMessage> Update([FromBody] Race race)
        {
            _repository.Update(race);
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK));
        }

        [HttpPost]
        [Route("api/races/{id}/snails")]
        public Task<HttpResponseMessage> SetSnails(int id, [FromBody] List<Snail> snails)
        {
            _repository.SetSnails(id, snails);
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
