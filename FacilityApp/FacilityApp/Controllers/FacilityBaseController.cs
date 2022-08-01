using FacilityApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace FacilityApp.Controllers
{
    public class FacilityBaseController : Controller
    {
        //protected FacilityAppDbContext _db => (FacilityAppDbContext)HttpContext.RequestServices.GetService(typeof(FacilityAppDbContext));
        
        protected dynamic AddDetais(dynamic obj)
        {
            obj.CreatedBy = HttpContext.Session.GetInt32("UserId") ?? 0;
            obj.CreatedDate = DateTime.Now;
            return obj;
        }
        protected dynamic UpdateDetails(dynamic obj)
        {
            obj.UpdatedBy = HttpContext.Session.GetInt32("UserId") ?? 0;
            obj.UpdatedDate = DateTime.Now;
            return obj;
        }
    }
}
