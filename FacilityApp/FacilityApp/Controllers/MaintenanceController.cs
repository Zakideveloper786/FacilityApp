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
    public class MaintenanceController : Controller
    {
        private readonly FacilityAppDbContext _db;

        public MaintenanceController(FacilityAppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // throw new Exception("error");
            IEnumerable<MaintenanceVM> list = (from m in _db.Maintanance
                                             join t in _db.Tenant
                   on m.TenantId equals t.TenantId
                                             join i in _db.IssueTypes on m.IssueTypeId equals i.IssueTypeId
                                             join u in _db.Users on m.UserId equals u.UserId
                                             select new MaintenanceVM
                                             {
                                                 MaintananceId = m.MaintananceId,
                                                 TenantName = t.Name,
                                                 IssueType = i.Name,
                                                 ImagePath = m.ImagePath,
                                                 IssueDetails = m.IssueDetails,
                                                 Status = i.Status,
                                                 UserName = (u.Name ?? "")

                                             }).ToList();
            return View(list);
        }
        //GET
        public IActionResult Create()
        {

            var tenants = _db.Tenant.Select(x => new { x.TenantId, x.Name }).ToList();
            tenants.Insert(0, new { TenantId = 0, Name = "--Select--" });
            var users = _db.Users.Select(x => new { x.UserId, x.Name }).ToList();
            users.Insert(0, new{ UserId = 0, Name = "--Select--" }          );
            var issues = _db.IssueTypes.Select(x => new { x.IssueTypeId, x.Name }).ToList();
            issues.Insert(0, new { IssueTypeId = 0, Name = "--Select--" });
            ViewBag.tenants = tenants;
            ViewBag.users = users;
            ViewBag.issues = issues;

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
        public IActionResult Create(Maintenance obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}
            if (ModelState.IsValid)
            {
                 var record= obj;
                AddDetais(record);
                _db.Maintanance.Add(record);
            
                _db.SaveChanges();
                TempData["success"] = "Tenant Issue saved successfully";
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


            var tenants = _db.Tenant.Select(x => new { x.TenantId, x.Name }).ToList();
            tenants.Insert(0, new { TenantId = 0, Name = "--Select--" });
            var users = _db.Users.Select(x => new { x.UserId, x.Name }).ToList();
            users.Insert(0, new { UserId = 0, Name = "--Select--" });
            var issues = _db.IssueTypes.Select(x => new { x.IssueTypeId, x.Name }).ToList();
            issues.Insert(0, new { IssueTypeId = 0, Name = "--Select--" });
            ViewBag.tenants = tenants;
            ViewBag.users = users;
            ViewBag.issues = issues;
            var record = _db.Maintanance.Find(id);
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
        public IActionResult Edit(Maintenance obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}
            if (ModelState.IsValid)
            {
                _db.Maintanance.Update(obj);
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

            var tenants = _db.Tenant.Select(x => new { x.TenantId, x.Name }).ToList();
            tenants.Insert(0, new { TenantId = 0, Name = "--Select--" });
            var users = _db.Users.Select(x => new { x.UserId, x.Name }).ToList();
            users.Insert(0, new { UserId = 0, Name = "--Select--" });
            var issues = _db.IssueTypes.Select(x => new { x.IssueTypeId, x.Name }).ToList();
            issues.Insert(0, new { IssueTypeId = 0, Name = "--Select--" });
            ViewBag.tenants = tenants;
            ViewBag.users = users;
            ViewBag.issues = issues;
            var record = _db.Maintanance.Find(id);
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
            var obj = _db.Maintanance.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Maintanance.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Lead deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
