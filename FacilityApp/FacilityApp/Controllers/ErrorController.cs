using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FacilityApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionFeature != null)
            {
                ViewBag.ErrorMessage = exceptionFeature.Error.Message;
                ViewBag.RouteOfException = exceptionFeature.Path;
            }
            
         bool ajaxRequest = HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if(ajaxRequest)
            {
                HttpContext.Response.StatusCode =(int) System.Net.HttpStatusCode.InternalServerError;
                
                return  Json    (new {message= ViewBag.ErrorMessag }); 
            }

            return View();
        }
    }
}
