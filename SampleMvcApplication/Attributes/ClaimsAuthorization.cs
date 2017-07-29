using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace SampleMvcApplication.Attributes
{
    public class ClaimsAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        private string claimType;
        private string claimValue;
        public ClaimsAuthorizeAttribute(string type, string value)
        {
            this.claimType = type;
            this.claimValue = value;
        }
        public override void OnAuthorization(HttpActionContext filterContext)
        {
            var user = filterContext.RequestContext.Principal as ClaimsPrincipal;
            if (user != null && user.HasClaim(claimType, claimValue))
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}