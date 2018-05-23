using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage_MVC_AmerAwras.DataAccessLayer;
using Garage_MVC_AmerAwras.Models;

namespace Garage_MVC_AmerAwras.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private GarageContext db = new GarageContext();
       
        //GET: ParkedVehicles
        public ActionResult Index(string sortOrder)
        {
            ViewBag.RegnrSortParm = String.IsNullOrEmpty(sortOrder) ? "RegNr_decs" : "";
            ViewBag.ColorSortParm = String.IsNullOrEmpty(sortOrder) ? "Color" : "";
            ViewBag.BrandSortParm = String.IsNullOrEmpty(sortOrder) ? "Brand" : "";
            ViewBag.ModelSortParm = String.IsNullOrEmpty(sortOrder) ? "Model" : "";
            ViewBag.WheelsSortParm = String.IsNullOrEmpty(sortOrder) ? "Wheels" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_decs" : "Date";

          //  ViewBag.TypeSortParm = sortOrder== "VehicleType" ? "VehicleType": "VehicleType";
            var vehicles = from v in db.Vehicles select v;
            switch (sortOrder)
            {
                case "RegNr_decs":
                    vehicles = vehicles.OrderByDescending(v => v.RegNumber);
                    break;
                case "Color":
                    vehicles = vehicles.OrderBy(v => v.Color);
                    break;
                case "Brand":
                    vehicles = vehicles.OrderBy(v => v.Brand);
                    break;
                case "Model":
                    vehicles = vehicles.OrderBy(v => v.Model);
                    break;
                case "Wheels":
                    vehicles = vehicles.OrderBy(v => v.NumberOfWheels);
                    break;
                case "Date":
                    vehicles = vehicles.OrderBy(v => v.CheckIn);
                    break;
               case "VehicleType":
                    vehicles = vehicles.OrderByDescending(v => v.VehicleType);
                    break;
                default:
                    vehicles = vehicles.OrderBy(v => v.RegNumber);
                    break;
               
            }
            return View(db.Vehicles.ToList());
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
        
            public ActionResult Create()
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
        public ActionResult Create([Bind(Include = "Id,RegNumber,Color,Brand,Model,CheckIn,VehicleType,NumberOfWheels")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ParkedVehicle parkedVehicle = db.Vehicles.Find(id);
        //    if (parkedVehicle == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(parkedVehicle);
        //}

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegNumber,Color,Brand,Model,CheckIn,VehicleType")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(parkedVehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
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
        //public ActionResult GetSearchRecord(string searchText)
        //{
        // //   List<ParkedVehicle> list = db.Vehicles.Where(x=> x.RegNumber.Contains(searchText)|| x.Color.Contains(searchText)).Select(x => new ParkedVehicle { VehicleType = x.VehicleType, RegNumber = x.RegNumber, Model = x.Model, Color = x.Color }).ToList();
        //    return PartialView("SearchPartial", list);
        //}
    }
}
