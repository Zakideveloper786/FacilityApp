


using FacilityApp.Controllers.api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace  FacilityApp.Core;
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        bool authorized = false;
        var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        if (token != null)
        {
            var id = Util.ValidateToken(token);
            if (id != null)
            {
                authorized = true;
                context.HttpContext.Items["userid"] = id;
                Statics.Userid = Convert.ToInt32(id.Item1);
                Statics.RoleName=Convert.ToString(id.Item2);
            }
        }
        if(!authorized)
        {
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
        
    }

 
}