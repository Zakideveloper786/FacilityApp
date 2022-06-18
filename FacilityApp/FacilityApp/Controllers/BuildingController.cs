using FacilityApp.Data;
using FacilityApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using FacilityApp.ViewModels;

namespace FacilityApp.Controllers
{
    public class BuildingController : FacilityBaseController
    {
        private readonly FacilityAppDbContext _db;

        public BuildingController(FacilityAppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // throw new Exception("error");
            IEnumerable<BuildingVM> list = (from b in _db.Building join u in _db.Users on b.UserId equals u.UserId

                                          select new BuildingVM { BuildingId = b.BuildingId, Name = b.Name, UserName = u.UserName }).ToList();
         
            return View(list);
        }
        //GET
        public IActionResult Create()
        {
            var roles = _db.UserRole.Select(x => new { x.RoleId, x.RoleName }).ToList();
            roles.Insert(0, new{ RoleId= 0, RoleName= "--Select--" }          );
            var users = _db.Users.Where(x=>x.RoleId==2).Select(x => new { x.UserId, x.UserName }).ToList();
            users.Insert(0, new { UserId = 0, UserName = "--Select--" });
            ViewBag.Roles = roles;
            ViewBag.users = users;

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
        public IActionResult Create(Building obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}
            if (ModelState.IsValid)
            {
                 var record= obj;
                AddDetais(record);
                _db.Building.Add(record);
    
                _db.SaveChanges();
                TempData["success"] = "Building  created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //private  dynamic AddDetais(dynamic obj)
        //{
        //    obj.CreatedBy = (int)HttpContext.Session.GetInt32("UserId"); ;
        //    obj.CreatedDate = DateTime.Now;
        //    return obj;
        //}
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Building.Find(id);
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
        public IActionResult Edit(Building obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}
            if (ModelState.IsValid)
            {
                _db.Building.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Building updated successfully";
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
            var categoryFromDb = _db.Building.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Building.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Building.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Building deleted successfully";
            return RedirectToAction("Index");

        }
    
    }
}
