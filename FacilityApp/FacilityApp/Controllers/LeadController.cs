using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FacilityApp.Data;

using FacilityApp.Models;

namespace FacilityApp.Controllers
{
    public class LeadController : Controller
    {
        private readonly FacilityAppDbContext _db;

        public LeadController(FacilityAppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // throw new Exception("error");
            IEnumerable<Lead> list = _db.Lead;
            return View(list);
        }
        //GET
        public IActionResult Create()
        {
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
        public IActionResult Create(Lead obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}
            if (ModelState.IsValid)
            {
                var tenant = obj;
                AddDetais(tenant);
                _db.Lead.Add(tenant);

                _db.SaveChanges();
                TempData["success"] = "Lead  created successfully";
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
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var buildings = _db.Building.Select(x => new { x.BuildingId, x.Name }).ToList();
            buildings.Insert(0, new { BuildingId = 0, Name = "--Select--" });
              ViewBag.buildings = buildings;
            var record = _db.Lead.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (record == null)
            {
                return NotFound();
            }

            return View(record);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Lead obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}
            if (ModelState.IsValid)
            {
                _db.Lead.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Lead updated successfully";
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

            var buildings = _db.Building.Select(x => new { x.BuildingId, x.Name }).ToList();
            buildings.Insert(0, new { BuildingId = 0, Name = "--Select--" });
            ViewBag.buildings = buildings;
            var record = _db.Lead.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (record == null)
            {
                return NotFound();
            }

            return View(record);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Lead.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Lead.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Lead deleted successfully";
            return RedirectToAction("Index");

        }

    }
}
