using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage_MVC_AmerAwras.DataAccessLayer;
using Garage_MVC_AmerAwras.Models;
using PagedList;

namespace Garage_MVC_AmerAwras.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private GarageContext db = new GarageContext();

        //GET: ParkedVehicles
        public ActionResult Overview(VehicleType? Type, string RegNumber = "", string Color = "", string Brand = "", string sortOrder = "", int page = 1)
        {
            // List<ParkedVehicle> vehicles = new List<ParkedVehicle>();

            var vehicleSort =
               db.Vehicles
               .Where(v => (RegNumber == "" || v.RegNumber.Contains(RegNumber)));

            switch (sortOrder)
            {
                case "RegNumber":        
                        vehicleSort = vehicleSort.OrderBy(v => v.RegNumber);                                    
                    break;
                case "Color":
                    vehicleSort = vehicleSort.OrderBy(v => v.Color);
                    break;
                case "Brand":
                    vehicleSort = vehicleSort.OrderBy(v => v.Brand);
                    break;
                case "Model":
                    vehicleSort = vehicleSort.OrderBy(v => v.Model);
                    break;
                case "Wheels":
                    vehicleSort = vehicleSort.OrderBy(v => v.NumberOfWheels);
                    break;
                case "CheckIn":
                    vehicleSort = vehicleSort.OrderBy(v => v.CheckIn);
                    break;
                case "Type":
                    vehicleSort = vehicleSort.OrderByDescending(v => v.VehicleType);
                    break;
                default:
                    vehicleSort = vehicleSort.OrderBy(v => v.RegNumber);
                    break;
            }

            int pageNumber = (page = 1);
            return View(vehicleSort);

            // (pageNumber, pageSize));
            //return View(Overview.ToPagedList(pageNumber, pageSize));
        }


        // GET: ParkedVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.Vehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create

        public ActionResult Park()
        {
            var a = new Models.ParkedVehicle();
            DateTime d = DateTime.Now;
            string sd = d.ToString("MM/dd/yyyy HH:mm");
            a.CheckIn = Convert.ToDateTime(sd);

            return View(a);
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Park([Bind(Include = "Id,RegNumber,Color,Brand,Model,CheckIn,VehicleType,NumberOfWheels")] ParkedVehicle parkedVehicle)
        {

            if (ModelState.IsValid)
            {
                db.Vehicles.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Overview");
            }

            return View(parkedVehicle);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegNumber,Color,Brand,Model,CheckIn,VehicleType")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Overview");
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public ActionResult CheckOut(int? id)
        {
            if (id == null)
            {

                return RedirectToAction("Overview");
            }
            ParkedVehicle v = db.Vehicles.Find(id);

            if (v == null)
            {
                return RedirectToAction("Overview");
            }

            VehicleCheckOut vehicle = new VehicleCheckOut(v.Id, v.RegNumber, v.CheckIn, DateTime.Now);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);

        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult VehicleReceipt(int id)
        {
            ParkedVehicle v = db.Vehicles.Find(id);
            if (v == null)
            {
                return HttpNotFound();
            }
            db.Vehicles.Remove(v);
            db.SaveChanges();

            VehicleReceipt info = new VehicleReceipt(v.Id, v.RegNumber, v.Model, v.CheckIn, DateTime.Now);
            return View(info);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //GaragePage
        public ActionResult GaragePage()
        {
            ViewBag.Message = "Welcome To Garage Application 2.0";

            return View();
        }

        //About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Search(string SearchTerm)
        {

            var vehicleSort =
                db.Vehicles
                .Where(v => (SearchTerm == "" || v.RegNumber.StartsWith(SearchTerm)));

          //  var parkedVehicles = from v in db.Vehicles select v;

            if (!String.IsNullOrEmpty(SearchTerm))
            {
                vehicleSort = vehicleSort.Where(v => v.RegNumber.ToUpper().Contains(SearchTerm) || v.Color.ToUpper().Contains(SearchTerm) || v.Model.ToUpper().Contains(SearchTerm) ||
                v.NumberOfWheels.ToString().Contains(SearchTerm));
            }
            return View("Overview");
        }
    }
}
