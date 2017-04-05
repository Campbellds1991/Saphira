using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Saphira.Models;

namespace Saphira.Controllers
{
    public class MaintenanceController : Controller
    {
        private SaphiraDB db = new SaphiraDB();

        // GET: Maintenance
        public ActionResult Index()
        {
            var maintenances = db.Maintenances.Include(m => m.employee).Include(m => m.equipment).Include(m => m.person);
            return View(maintenances.ToList());
        }

        // GET: Maintenance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintenance maintenance = db.Maintenances.Find(id);
            if (maintenance == null)
            {
                return HttpNotFound();
            }
            return View(maintenance);
        }

        // GET: Maintenance/Create
        public ActionResult Create()
        {
            ViewBag.Perso_LoggedBy = new SelectList((from emp in db.Employees select new { emp.Last, emp.First } ).AsEnumerable().Select(e => e.Last+", "+e.First),"ID");
            ViewBag.Equip_Serviced = new SelectList(db.Equipments, "Id", "Type");
            ViewBag.ServicedBy = new SelectList(db.People, "Id", "Affiliation");
            return View();
        }

        // POST: Maintenance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Perso_LoggedBy,Equip_Serviced,ServiceCode,PreServCond,PostServCond,DescOfService,ServDateIn,ServDateOut,Cost,ServicedBy")] Maintenance maintenance)
        {
            if (ModelState.IsValid)
            {
                db.Maintenances.Add(maintenance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Perso_LoggedBy = new SelectList(db.Employees, "Id", "First", maintenance.Perso_LoggedBy);
            ViewBag.Equip_Serviced = new SelectList(db.Equipments, "Id", "Type", maintenance.Equip_Serviced);
            ViewBag.ServicedBy = new SelectList(db.People, "Id", "Affiliation", maintenance.ServicedBy);
            return View(maintenance);
        }

        // GET: Maintenance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintenance maintenance = db.Maintenances.Find(id);
            if (maintenance == null)
            {
                return HttpNotFound();
            }
            ViewBag.Perso_LoggedBy = new SelectList(db.Employees, "Id", "First", maintenance.Perso_LoggedBy);
            ViewBag.Equip_Serviced = new SelectList(db.Equipments, "Id", "Type", maintenance.Equip_Serviced);
            ViewBag.ServicedBy = new SelectList(db.People, "Id", "Affiliation", maintenance.ServicedBy);
            return View(maintenance);
        }

        // POST: Maintenance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Perso_LoggedBy,Equip_Serviced,ServiceCode,PreServCond,PostServCond,DescOfService,ServDateIn,ServDateOut,Cost,ServicedBy")] Maintenance maintenance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maintenance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Perso_LoggedBy = new SelectList(db.Employees, "Id", "First", maintenance.Perso_LoggedBy);
            ViewBag.Equip_Serviced = new SelectList(db.Equipments, "Id", "Type", maintenance.Equip_Serviced);
            ViewBag.ServicedBy = new SelectList(db.People, "Id", "Affiliation", maintenance.ServicedBy);
            return View(maintenance);
        }

        // GET: Maintenance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintenance maintenance = db.Maintenances.Find(id);
            if (maintenance == null)
            {
                return HttpNotFound();
            }
            return View(maintenance);
        }

        // POST: Maintenance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maintenance maintenance = db.Maintenances.Find(id);
            db.Maintenances.Remove(maintenance);
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
    }
}
