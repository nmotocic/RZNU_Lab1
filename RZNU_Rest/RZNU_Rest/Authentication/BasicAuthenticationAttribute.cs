using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Text;




namespace RZNU_Rest.Authentication
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {  

        public override void OnAuthorization(HttpActionContext actionContext) {

             if (actionContext.Request.Headers.Authorization != null)
            {
                var authToken = actionContext.Request.Headers.Authorization.Parameter;

                var decodingToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));

                var arrUserNameAndPassword = decodingToken.Split(':');
                string username = arrUserNameAndPassword[0];
                string password = arrUserNameAndPassword[1];
                    
                if (IsAuthorizedUser(username, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                    
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            else {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        public bool IsAuthorizedUser(string username, string password)
        {
            return username == "nmotocic" && password == "1234";
        }
    }
}
