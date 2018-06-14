using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Garage_MVC_AmerAwras.DataAccessLayer;
using Garage_MVC_AmerAwras.Models;
using PagedList;

namespace Garage_MVC_AmerAwras.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private GarageContext db = new GarageContext();

        //GET: ParkedVehicles

        public ActionResult Index(string sortOrder)

        {
            var parkedVehicle = db.Vehicles.ToList();

            if (sortOrder == "Ascending")
            {
                parkedVehicle = parkedVehicle.OrderBy(s => s.Regnr).ToList();
            }

            else if (sortOrder == "Descending")
            {
                parkedVehicle = parkedVehicle.OrderByDescending(s => s.Regnr).ToList();
            }


            List<ParkedVehicleViewModel> iv = new List<ParkedVehicleViewModel>();
            foreach (ParkedVehicle e in parkedVehicle.ToList())

            {
                iv.Add(new ParkedVehicleViewModel(e));
            }
            return View(iv);
        }
        //[HttpPost]
        public ActionResult Search(string search)
        {

            List<ParkedVehicleViewModel> parkedSearch = new List<ParkedVehicleViewModel>();

            foreach (ParkedVehicle e in db.Vehicles.Where(s => s.Regnr.Contains(search) || s.Color.Contains(search)).ToList())
            {
                parkedSearch.Add(new ParkedVehicleViewModel(e));
            }

            return View("Index", parkedSearch);
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
            var a = new ParkedVehicle();
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
                return RedirectToAction("Index");
            }

            return View(parkedVehicle);
        }



        // GET: ParkedVehicles/Delete/5
        public ActionResult Checkout(int? id)
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

            VehicleCheckOut vehicle = new VehicleCheckOut(v.Id, v.Regnr, v.VehicleType, DateTime.Today, DateTime.Now);
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

            VehicleReceipt info = new VehicleReceipt(v.Id, v.Regnr, v.Model, v.CheckIn, DateTime.Now);
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

            return View();
        }
        //About


        //Contact
        public ActionResult Contact()
        {
            return View();
        }

        //Overview
        public ActionResult Overview()
        {
            var temp = db.Vehicles.ToList();
            return View(temp);
        }

    }
}





