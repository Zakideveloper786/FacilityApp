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
    public class ParkingController : Controller
    {
        private readonly FacilityAppDbContext _db;

        public ParkingController(FacilityAppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // throw new Exception("error");
            IEnumerable<ParkingVM> list = (from p in _db.Parking
                                           join t in _db.Tenant
                    on p.TenantId equals t.TenantId
                                           select new ParkingVM
                                           {
                                               TenantName = t.Name,
                                               ParkingNumber = p.ParkingNumber,
                                                PaymentStatus = p.PaymentStatus,

                                                ParkingId = p.ParkingId,
                                                PlateNumber=p.PlateNumber,
                                                StartDate= p.StartDate,
                                                EndDate= p.EndDate
                                           }).ToList();
            return View(list);
        }
        //GET
        public IActionResult Create()
        {
            var tenants = _db.Tenant.Select(x => new { x.TenantId, x.Name }).ToList();
            tenants.Insert(0, new{ TenantId= 0, Name = "--Select--" }          );

            //var flats = _db.Flat.Select(x => new { x.FlatId, x.FlatName }).ToList();
            //flats.Insert(0, new { FlatId = 0, FlatName = "--Select--" });

            //var parkings = _db.Parking.Select(x => new { x.ParkingId, x.ParkingName }).ToList();
            //parkings.Insert(0, new { ParkingId = 0, ParkingName = "--Select--" });
            ViewBag.tenants = tenants;
            //ViewBag.flats = flats;
            //ViewBag.parkings = parkings;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Parking obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}
            if (ModelState.IsValid)
            {
                 var record= obj;
                AddDetais(record);
                _db.Parking.Add(record);
            
                _db.SaveChanges();
                TempData["success"] = "Parking saved successfully";
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
