using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApplication1.Filters
{
    public class SnailsAuthorizationFilterAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            IEnumerable<string> auths;
            var auth = string.Empty;
            if (actionContext.Request.Headers.TryGetValues("Snails-Authorization", out auths))
                auth = auths.FirstOrDefault();

            if (auth != "supersecret")
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "No rights to access this resource");
        }
    }
}