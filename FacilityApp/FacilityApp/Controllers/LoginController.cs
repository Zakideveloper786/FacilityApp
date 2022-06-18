using FacilityApp.Data;
using FacilityApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FacilityApp.Controllers
{
    public class LoginController : FacilityBaseController
    {
        private readonly FacilityAppDbContext _db;



        public LoginController(FacilityAppDbContext db)
        {
            _db = db;
    
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostLogin(LoginVM obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}
            //if (ModelState.IsValid)
            //{
            var user = _db.Users.Where(x => x.MobileNo == obj.MobileNo && x.Password == obj.Password).FirstOrDefault();
                if (user!=null)
                {
                    TempData["success"] = "Login Successful";
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetInt32("BuilidngId", user.BuildingId??0);

                HttpContext.Session.SetString("UserName", user.Name);

                return RedirectToAction("index", "User");
                }

                TempData["success"] = "Invalid Credentials";
                return RedirectToAction("index", "Login");

         //   }
            return View(obj);
        }

    }
}
