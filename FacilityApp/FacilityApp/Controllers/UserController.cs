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
            IEnumerable<User> list = _db.Users;
            return View(list);
        }
        //GET
        public IActionResult Create()
        {
            var roles = _db.UserRole.Select(x => new { x.RoleId, x.RoleName }).ToList();
            roles.Insert(0, new{ RoleId= 0, RoleName= "--Select--" }          );

            //var flats = _db.Flat.Select(x => new { x.FlatId, x.FlatName }).ToList();
            //flats.Insert(0, new { FlatId = 0, FlatName = "--Select--" });

            //var parkings = _db.Parking.Select(x => new { x.ParkingId, x.ParkingName }).ToList();
            //parkings.Insert(0, new { ParkingId = 0, ParkingName = "--Select--" });
            ViewBag.Roles = roles;
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
            if (ModelState.IsValid)
            {
                 var tenant= obj;
                AddDetais(tenant);
                _db.Users.Add(tenant);
            
                _db.SaveChanges();
                TempData["success"] = "User  created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        private static dynamic AddDetais(dynamic obj)
        {
            obj.CreatedBy = "admin";
            obj.CreatedDate = DateTime.Now;
            return obj;
        }
    }
}
