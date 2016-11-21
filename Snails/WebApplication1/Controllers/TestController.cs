using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {

        [HttpPost]
        public IHttpActionResult Get([FromBody] string id)
        {
            return Ok(new {Property1 = 1, Property2 = id});
        }
    }
}
