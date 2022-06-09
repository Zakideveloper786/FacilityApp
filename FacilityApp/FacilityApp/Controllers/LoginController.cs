using FacilityApp.Data;
using FacilityApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FacilityApp.Controllers
{
    public class LoginController : Controller
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
            if (ModelState.IsValid)
            {
                var exist =  _db.Users.Where(x => x.EmailID.ToLower() == obj.EmailID.ToLower() && x.Password==obj.Password).Any();
                if (exist)
                {
                    TempData["success"] = "Login Successful";
                    return RedirectToAction("index", "User");
                }

                TempData["success"] = "Invalid Credentials";
                return RedirectToAction("index", "Login");

            }
            return View(obj);
        }

    }
}
