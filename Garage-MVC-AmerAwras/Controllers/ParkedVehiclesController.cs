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
using PagedList;

namespace Garage_MVC_AmerAwras.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private GarageContext db = new GarageContext();

        //GET: ParkedVehicles
        public ActionResult Index(string searchparam, string sortOrder, int? page, string currentFilter)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.RegnrSortParm = String.IsNullOrEmpty(sortOrder) ? "RegNr_decs" : "";
            ViewBag.ColorSortParm = String.IsNullOrEmpty(sortOrder) ? "Color" : "";
            ViewBag.BrandSortParm = String.IsNullOrEmpty(sortOrder) ? "Brand" : "";
            ViewBag.ModelSortParm = String.IsNullOrEmpty(sortOrder) ? "Model" : "";
            ViewBag.WheelsSortParm = String.IsNullOrEmpty(sortOrder) ? "Wheels" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "CheckIn";
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "Type" : "";

            if (searchparam != null)
            {
                page = 1;
            }
            else
            {
                searchparam = currentFilter;
            }
            ViewBag.currentFilter = searchparam;

            var parkedVehicles = from v in db.Vehicles select v;

            if (!String.IsNullOrEmpty(searchparam))
            {
                parkedVehicles = parkedVehicles.Where(v => v.RegNumber.ToUpper().Contains(searchparam) ||  v.Color.ToUpper().Contains(searchparam) || v.Model.ToUpper().Contains(searchparam)||
                v.NumberOfWheels.ToString().Contains(searchparam));
            }
            switch (sortOrder)
            {
                case "RegNr_decs":
                    parkedVehicles = parkedVehicles.OrderByDescending(v => v.RegNumber);
                    break;
                case "Color":
                    parkedVehicles = parkedVehicles.OrderBy(v => v.Color);
                    break;
                case "Brand":
                    parkedVehicles = parkedVehicles.OrderBy(v => v.Brand);
                    break;
                case "Model":
                    parkedVehicles = parkedVehicles.OrderBy(v => v.Model);
                    break;
                case "Wheels":
                    parkedVehicles = parkedVehicles.OrderBy(v => v.NumberOfWheels);
                    break;
                case "CheckIn":
                    parkedVehicles = parkedVehicles.OrderBy(v => v.CheckIn);
                    break;
                case "Type":
                    parkedVehicles = parkedVehicles.OrderByDescending(v => v.VehicleType);
                    break;
                default:
                    parkedVehicles = parkedVehicles.OrderBy(v => v.RegNumber);
                    break;

            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            
            return View(parkedVehicles.ToPagedList(pageNumber, pageSize));
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
            DateTime checkOutTime = DateTime.Now;
            int price = 25;
            double sum = 1;
           
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
                if (totalTime.Hours <=1)
                    {
                    sum = 25;
                }
                else sum = totalTime.Hours * price;
            }
            else {
                double hours = totalTime.TotalDays * 24;
                double totalhours = hours + totalTime.Hours;
                sum = totalhours * price;    
            }
          
            parkedVehicle.CheckOut = checkOutTime;
           parkedVehicle.TotalTime = totalTime.ToString();
            parkedVehicle.Sum = sum;

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

        //Overview
        public ActionResult Overview()
        {
            ViewBag.Message = "Your OverView page for all Vehicle.";

            return View(db.Vehicles.ToList());
        }
        //public ActionResult GetSearchRecord(string searchText)
        //{
        // //   List<ParkedVehicle> list = db.Vehicles.Where(x=> x.RegNumber.Contains(searchText)|| x.Color.Contains(searchText)).Select(x => new ParkedVehicle { VehicleType = x.VehicleType, RegNumber = x.RegNumber, Model = x.Model, Color = x.Color }).ToList();
        //    return PartialView("SearchPartial", list);
        //}
    }
}

  

   

