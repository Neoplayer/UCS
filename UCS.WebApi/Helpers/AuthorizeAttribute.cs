using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UCS.DbProvider.Models;
using UCS.WebApi.Models;

namespace UCS.WebApi.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private ERole? RequiredRole = null;
        
        public AuthorizeAttribute()
        {
            
        }
        public AuthorizeAttribute(ERole role)
        {
            RequiredRole = role;
        }
        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];
            if (user == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }
            
            if (RequiredRole != null && !user.Roles.Any(x => x.Id == (int) RequiredRole))
            {
                // wrong role
                context.Result = new JsonResult(new { message = "Role Access Denied" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
