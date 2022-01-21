using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataModel;

namespace WebApp.Controllers
{
    public class StandardMastersController : Controller
    {
        private AttendenceManagementSystem1Entities db = new AttendenceManagementSystem1Entities();

        // GET: StandardMasters
        public ActionResult Index()
        {
            var standardMasters = db.StandardMasters.Include(s => s.BranchMaster).Include(s => s.SectionMaster);
            return View(standardMasters.ToList());
        }

        // GET: StandardMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StandardMaster standardMaster = db.StandardMasters.Find(id);
            if (standardMaster == null)
            {
                return HttpNotFound();
            }
            return View(standardMaster);
        }

        // GET: StandardMasters/Create
        public ActionResult CreateStandard()
        {
            ViewBag.BranchId = new SelectList(db.BranchMasters, "Id", "BranchName");
            ViewBag.SectionId = new SelectList(db.SectionMasters, "Id", "SectionName");
            return View();
        }

        // POST: StandardMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStandard([Bind(Include = "Id,SectionId,BranchId,StandardName,EntryBy,EntryDate,ModifyBy,ModifyDate")] StandardMaster standardMaster)
        {
            if (ModelState.IsValid)
            {
                db.StandardMasters.Add(standardMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.BranchMasters, "Id", "BranchName", standardMaster.BranchId);
            ViewBag.SectionId = new SelectList(db.SectionMasters, "Id", "SectionName", standardMaster.SectionId);
            return View(standardMaster);
        }

        // GET: StandardMasters/Edit/5
        public ActionResult UpdateStandard(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StandardMaster standardMaster = db.StandardMasters.Find(id);
            if (standardMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.BranchMasters, "Id", "BranchName", standardMaster.BranchId);
            ViewBag.SectionId = new SelectList(db.SectionMasters, "Id", "SectionName", standardMaster.SectionId);
            return View(standardMaster);
        }

        // POST: StandardMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStandard([Bind(Include = "Id,SectionId,BranchId,StandardName,EntryBy,EntryDate,ModifyBy,ModifyDate")] StandardMaster standardMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(standardMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.BranchMasters, "Id", "BranchName", standardMaster.BranchId);
            ViewBag.SectionId = new SelectList(db.SectionMasters, "Id", "SectionName", standardMaster.SectionId);
            return View(standardMaster);
        }

        // GET: StandardMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StandardMaster standardMaster = db.StandardMasters.Find(id);
            if (standardMaster == null)
            {
                return HttpNotFound();
            }
            return View(standardMaster);
        }

        // POST: StandardMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StandardMaster standardMaster = db.StandardMasters.Find(id);
            db.StandardMasters.Remove(standardMaster);
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
