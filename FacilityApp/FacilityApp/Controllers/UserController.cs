using FacilityApp.Data;
using FacilityApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc.Rendering;

using System;

namespace FacilityApp.Controllers
{
    public class UserController : Controller
    {
        private readonly FacilityAppDbContext _db;

        public UserController(FacilityAppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // throw new Exception("error");
            IEnumerable<User> list = _db.Users.Where(x => x.Status == Core.Statics.RecordState.Active);
            return View(list);
        }
        //GET
        public IActionResult Create()
        {
            var roles = _db.UserRole.Where(x=>!x.RoleName.Contains("Tenant")).Select(x => new { x.RoleId, x.RoleName }).ToList();
            roles.Insert(0, new{ RoleId= 0, RoleName= "--Select--" }          );
            ViewBag.roles = roles;
            var buildings = _db.Building.Select(x => new { x.BuildingId, x.Name }).ToList();
            buildings.Insert(0, new { BuildingId = 0, Name = "--Select--" });
            ViewBag.buildings = buildings;
            //var flats = _db.Flat.Select(x => new { x.FlatId, x.FlatName }).ToList();
            //flats.Insert(0, new { FlatId = 0, FlatName = "--Select--" });

            //var parkings = _db.Parking.Select(x => new { x.ParkingId, x.ParkingName }).ToList();
            //parkings.Insert(0, new { ParkingId = 0, ParkingName = "--Select--" });
            //ViewBag.flats = flats;
            //ViewBag.parkings = parkings;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}
            //if (ModelState.IsValid)
            //{
                 var tenant= obj;
                AddDetais(tenant);

            var password = BCrypt.Net.BCrypt.HashPassword(tenant.Password);
            tenant.Password = password;
            _db.Users.Add(tenant);
                
                _db.SaveChanges();
                TempData["success"] = "User  created successfully";
                return RedirectToAction("Index");
          //  }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var roles = _db.UserRole.Select(x => new { x.RoleId, x.RoleName }).ToList();
            roles.Insert(0, new { RoleId = 0, RoleName = "--Select--" });
            ViewBag.roles = roles;
            var buildings = _db.Building.Select(x => new { x.BuildingId, x.Name }).ToList();
            buildings.Insert(0, new { BuildingId = 0, Name = "--Select--" });
            ViewBag.buildings = buildings;
            var categoryFromDb = _db.Users.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}
            if (ModelState.IsValid)
            {
                _db.Users.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "User Details updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Users.Find(id);
            var buildings = _db.Building.Select(x => new { x.BuildingId, x.Name }).ToList();
            buildings.Insert(0, new { BuildingId = 0, Name = "--Select--" });
            ViewBag.buildings = buildings;
            var roles = _db.UserRole.Select(x => new { x.RoleId, x.RoleName }).ToList();
            roles.Insert(0, new { RoleId = 0, RoleName = "--Select--" });
            ViewBag.roles = roles;

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Users.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            obj.Status = Core.Statics.RecordState.Deleted;
            _db.Users.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "User deleted successfully";
            return RedirectToAction("Index");

        }

    
    private  dynamic AddDetais(dynamic obj)
        {
            obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            obj.CreatedDate = DateTime.Now;
            return obj;
        }
    }
}
