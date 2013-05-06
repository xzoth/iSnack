using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace iSnack.Web.API.Attribute
{
    /// <summary>
    /// 安全连接特性
    /// 指定此定性以强制要求安全连接
    /// </summary>
    public class RequireHTTPSAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            if (!request.IsSecureConnection)
            {
                string strSSLUri = string.Format("https://{0}{1}",
                                                 request.Url.Host,
                                                 request.Url.PathAndQuery);
                
                //filterContext.HttpContext.Response.Status = HttpStatusCode.SwitchingProtocols.ToString();

                filterContext.HttpContext.Response.Redirect(strSSLUri);
            }
        }
    }
}