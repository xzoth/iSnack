using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace iSnack.Web.API.Attribute
{
    /// <summary>
    /// HTTP基本认证特性
    /// 添加此标记以在请求时要求认证
    /// </summary>
    public class HTTPBasicAuthorizeAttribute : global::System.Web.Http.AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization != null)
            {
                string userInfo = Encoding.Default.GetString(Convert.FromBase64String(actionContext.Request.Headers.Authorization.Parameter));
                //用户验证逻辑
                if (string.Equals(userInfo, string.Format("{0}:{1}", "aa", "aa")))
                {
                    IsAuthorized(actionContext);
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
            else
            {
                HandleUnauthorizedRequest(actionContext);
            }
        }
        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var challengeMessage = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            challengeMessage.Headers.Add("WWW-Authenticate", "Basic");
            actionContext.Response = challengeMessage;
            //throw new System.Web.Http.HttpResponseException(challengeMessage);
        }
    }
}
