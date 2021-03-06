using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FacilityApp.Data;

using FacilityApp.Models;
using FacilityApp.ViewModels;
using System.Net.Mail;
using System.Net;

namespace FacilityApp.Controllers
{
    public class TenantController : FacilityBaseController
    {
        private readonly FacilityAppDbContext _db;

        public TenantController(FacilityAppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // throw new Exception("error");
            IEnumerable<Tenant> list = _db.Tenant;
            return View(list);
        }
        //GET
        public IActionResult Create()
        {
            var flattypes = _db.FlatTypes.Select(x => new { x.FlatTypeId, x.Name }).ToList();
            flattypes.Insert(0, new { FlatTypeId = 0, Name = "--Select--" });

            ViewBag.flattypes = flattypes;
            var buildings = _db.Building.Select(x => new { x.BuildingId, x.Name }).ToList();
            buildings.Insert(0, new { BuildingId = 0, Name = "--Select--" });
            ViewBag.buildings = buildings;
            var flats = _db.Flat.Select(x => new { x.FlatId, x.Name }).ToList();
            flats.Insert(0, new { FlatId = 0, Name = "--Select--" });
            ViewBag.flats = flats;
            var frequency = _db.Frequency.Select(x => new { x.FrequencyId, x.Name }).ToList();
            frequency.Insert(0, new { FrequencyId = 0, Name = "--Select--" });
            ViewBag.frequency = frequency;
            //var parkings = _db.Parking.Select(x => new { x.ParkingId, x.ParkingName }).ToList();
            //parkings.Insert(0, new { ParkingId = 0, ParkingName = "--Select--" });

            //ViewBag.parkings = parkings;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TenantRegistration obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}
           
            //if (ModelState.IsValid)
            //{
                var tenant = obj.Tenant;
                AddDetais(tenant);
                _db.Tenant.Add(tenant);
            _db.SaveChanges();
            var details = obj.TenantFlatDetails;
                details.TenantId = tenant.TenantId;
            AddDetais(details);
            _db.TenantFlatDetails.Add(details);

                _db.SaveChanges();
 

            if(tenant.FaciltyAppAccess==true)
            {
                var flatName = _db.Flat.Where(x => x.FlatId == details.FlatId).Select(x => x.Name).FirstOrDefault();
                var buildingCode = _db.Building.Where(x => x.BuildingId == details.BuildingId).Select(x => x.BuildingCode).FirstOrDefault();
                TenantUser tuser = new TenantUser();
                tuser.BuildingId = details.BuildingId;
                tuser.UserName = buildingCode+"-"+ flatName;
                tuser.Password = "password";
                AddDetais(tuser);
                _db.tenantUsers.Add(tuser);
                _db.SaveChanges();
                if (!string.IsNullOrWhiteSpace(tenant.EmailId))
                    sendEmail(tenant.EmailId, tuser.UserName);
            }
                TempData["success"] = "Tenant  created successfully";
                return RedirectToAction("Index");
            //}
            return View(obj);
        }

        private bool sendEmail(string email, string username)
        {
            string emailid = "zaki.developer786@gmail.com";

            using (MailMessage mm = new MailMessage(email, email))
            {
                mm.Subject = $"Welcome to Facility App";
                mm.Body = $"Hello Tenant, <br/> Your Username is : {username} and Password is : <b>facility123</b> <br/><br/>Thank you,<br/><br/>Facility App Team";
                //if (model.Attachment.Length > 0)
                //{
                //    string fileName = Path.GetFileName(model.Attachment.FileName);
                //    mm.Attachments.Add(new Attachment(model.Attachment.OpenReadStream(), fileName));
                //}
                mm.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(emailid, "qszspkfqzdbfaqdj");
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);

                }
                return true;

            }
        }
        //private static dynamic AddDetais(dynamic obj)
        //{
        //    obj.CreatedBy = "admin";
        //    obj.CreatedDate = DateTime.Now;
        //    return obj;
        //}

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            TenantRegistration registration = new TenantRegistration();
            registration.Tenant = _db.Tenant.Where(x => x.TenantId == id).FirstOrDefault();

            if(registration.Tenant !=null)
            {
                registration.TenantFlatDetails = _db.TenantFlatDetails.Where(x => x.TenantId == id).FirstOrDefault();
            }

            var flattypes = _db.FlatTypes.Select(x => new { x.FlatTypeId, x.Name }).ToList();
            flattypes.Insert(0, new { FlatTypeId = 0, Name = "--Select--" });

            ViewBag.flattypes = flattypes;
            var buildings = _db.Building.Select(x => new { x.BuildingId, x.Name }).ToList();
            buildings.Insert(0, new { BuildingId = 0, Name = "--Select--" });
            ViewBag.buildings = buildings;
          
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (registration.Tenant ==null)
            {
                return NotFound();
            }

            return View(registration);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var flattypes = _db.FlatTypes.Select(x => new { x.FlatTypeId, x.Name }).ToList();
            flattypes.Insert(0, new { FlatTypeId = 0, Name = "--Select--" });

            ViewBag.flattypes = flattypes;
            var buildings = _db.Building.Select(x => new { x.BuildingId, x.Name }).ToList();
            buildings.Insert(0, new { BuildingId = 0, Name = "--Select--" });
            ViewBag.buildings = buildings;
            var categoryFromDb = _db.Tenant.Find(id);
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
            var obj = _db.Tenant.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Tenant.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Tenant deleted successfully";
            return RedirectToAction("Index");

        }

    }
}
