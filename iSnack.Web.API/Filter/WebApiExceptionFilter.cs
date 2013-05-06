using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Net;
using iSnack.Common.Exception;

namespace iSnack.Web.API.Filter
{
    public class WebApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            iSnackException iSnackException = actionExecutedContext.Exception as iSnackException;
            string strErrorMsg = string.Empty;

            if (iSnackException != null)
            {
                //TODO: translate Error Message From I18N
                strErrorMsg = iSnackException.Code;
            }

            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.BadRequest, strErrorMsg);
        }
    }
}