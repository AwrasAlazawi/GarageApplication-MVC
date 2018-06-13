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
                parkedVehicle = parkedVehicle.OrderBy(s => s.RegNumber).ToList();
            }

            else if (sortOrder == "Descending")
            {
                parkedVehicle = parkedVehicle.OrderByDescending(s => s.RegNumber).ToList();
            }


            List<ParkedViewModel> iv = new List<ParkedViewModel>();
            foreach (ParkedVehicle e in parkedVehicle.ToList())

            {
                iv.Add(new ParkedViewModel(e));
            }
            return View(iv);
        }
        //[HttpPost]
        public ActionResult Search(string search)
        {

            List<ParkedViewModel> parkedSearch = new List<ParkedViewModel>();

            foreach (ParkedVehicle e in db.Vehicles.Where(s => s.RegNumber.Contains(search) || s.Color.Contains(search)).ToList())
            {
                parkedSearch.Add(new ParkedViewModel(e));
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

        public ActionResult Create()
        {
            var a = new Models.ParkedVehicle();
            DateTime d = DateTime.Now;
            string sd = d.ToString("MM/dd/yyyy HH:mm");
            a.CheckIn = Convert.ToDateTime(sd);

          
            {
                var fromDatabaseEF = new SelectList(cshparpEntity.MySkills.ToList(), "ID", "Name");
                ViewData["DBMySkills"] = fromDatabaseEF;
            }
            return View(a);

        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegNumber,Color,Brand,Model,CheckIn,VehicleType,NumberOfWheels")] ParkedVehicle parkedVehicle)
        {
            //db.Vehicles.Any(p => p.RegNumber == c);
            //var no = db.Vehicles.FirstOrDefault(w => w.Id == );
            //if (no == null)

            if (ModelState.IsValid)
            {
                db.Vehicles.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parkedVehicle);
        }

      
        // GET: ParkedVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            DateTime checkOutTime = DateTime.Now;
           // int price = 25;
            decimal totalPrice = 1;
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.Vehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            
            TimeSpan totalTime = checkOutTime - parkedVehicle.CheckIn;

            if (totalTime.Days == 0)
            {
                if (totalTime.Hours <=1 && totalTime.Minutes <=60)
                    {
                    sum = 25;
                }
               // else sum = totalTime.Hours * parkedVehicle.PricePerHour;
            }
            else {
                decimal hours = Convert.ToDecimal(totalTime.TotalDays * 24);
                decimal totalhours = hours + totalTime.Hours;
               // sum = totalhours * parkedVehicle.PricePerHour;    
            }
           
           //parkedVehicle.CheckOut = checkOutTime;
           //parkedVehicle.TotalTime = string.Format("{0:%d} days {0:%h} hours {0:%m} minutes", totalTime).ToString();
           // parkedVehicle.Sum = sum;

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

        //To Populate DropDown List for Vehicle Type
        public ActionResult GaragePage()
        {
            ViewBag.Message = "Welcome To Garage Application 2.0";

            return View();
        }


        //GaragePage
        public ActionResult PopulateDDL_Type()
        {
          

            return View();
        }
        //About
        public ActionResult About()
        {
              return View();
        }

        //Contact
        public ActionResult Contact()
        {
            return View();
        }

        //Overview
        public ActionResult Overview()
        {
            ViewBag.Message = "Your OverView page for all Vehicle.";

            return View(db.Vehicles.ToList());
        }
       protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

  

   

