using System.Net;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Http.ModelBinding;

namespace iSnack.Web.API.Filter
{
    public class ValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;
            if (!modelState.IsValid)
            {
                JObject errors = new JObject();
                foreach (string key in modelState.Keys)
                {
                    ModelState state = modelState[key];
                    if (state.Errors.Count > 0)
                    {                        
                        errors.Add(key, state.Errors[0].ErrorMessage);
                    }
                }
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
    }
}