using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessEntity;
using BusinessServices.BusinessInterface;
using DataModel;

namespace WebApp.Controllers
{
    public class UserDetailsMastersController : Controller
    {
        #region Private variable.

        private readonly IUserDetailServices _userDetailServices;
        private readonly AttendenceManagementSystem1Entities db = new AttendenceManagementSystem1Entities();
        #endregion

        #region Public Constructor

        public UserDetailsMastersController(IUserDetailServices userDetailServices)
        {
            _userDetailServices = userDetailServices;
        }
        #endregion
        // GET: UserDetailsMasters
        public ActionResult Index()
        {
            var userDetails = _userDetailServices.GetAllUserDetails();
            var userDetailsMasterEntities = userDetails as List<UserDetailsMasterEntity> ?? userDetails.ToList();
            return View(userDetailsMasterEntities);
        }

        

        // GET: UserDetailsMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetailsMaster userDetailsMaster = db.UserDetailsMasters.Find(id);
            if (userDetailsMaster == null)
            {
                return HttpNotFound();
            }
            return View(userDetailsMaster);
        }

        // GET: UserDetailsMasters/Create
        public ActionResult Create()
        {
            ViewBag.BranchID = new SelectList(db.BranchMasters, "Id", "BranchName");
            ViewBag.CollegeID = new SelectList(db.CollegeMasters, "Id", "CollegeName");
            ViewBag.CountryId = new SelectList(db.CountryMasters, "Id", "CountryName");
            ViewBag.DepartmentID = new SelectList(db.DeparmentMasters, "Id", "DepartmentName");
            ViewBag.DistrictId = new SelectList(db.DistrictMasters, "Id", "DistrictName");
            ViewBag.StateId = new SelectList(db.StateMasters, "Id", "StateName");
            ViewBag.RoleID = new SelectList(db.RoleMasters, "Id", "RoleName");
            ViewBag.SectionID = new SelectList(db.SectionMasters, "Id", "SectionName");
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Enumerations.Status)));
            return View();
        }

        // POST: UserDetailsMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( UserDetailsMasterEntity userDetailsMasterEntity)
        {
            List<UserDetailsMasterEntity> lstUserDetails = new List<UserDetailsMasterEntity>();
            var userDetails = _userDetailServices.CreateUserDetails(userDetailsMasterEntity);
            lstUserDetails.Add(userDetails);
            return RedirectToAction("Index");
            return View();
        }

        // GET: UserDetailsMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetailsMaster userDetailsMaster = db.UserDetailsMasters.Find(id);
            if (userDetailsMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchID = new SelectList(db.BranchMasters, "Id", "BranchName", userDetailsMaster.BranchID);
            ViewBag.CollegeID = new SelectList(db.CollegeMasters, "Id", "CollegeName", userDetailsMaster.CollegeID);
            ViewBag.CountryId = new SelectList(db.CountryMasters, "Id", "CountryName", userDetailsMaster.CountryId);
            ViewBag.DepartmentID = new SelectList(db.DeparmentMasters, "Id", "DepartmentName", userDetailsMaster.DepartmentID);
            ViewBag.DistrictId = new SelectList(db.DistrictMasters, "Id", "DistrictName", userDetailsMaster.DistrictId);
            ViewBag.RoleID = new SelectList(db.RoleMasters, "Id", "RoleName", userDetailsMaster.RoleID);
            ViewBag.SectionID = new SelectList(db.SectionMasters, "Id", "SectionName", userDetailsMaster.SectionID);
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Enumerations.Status)));
            return View(userDetailsMaster);
        }

        // POST: UserDetailsMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CollegeID,SectionID,DepartmentID,BranchID,UniqueId,RoleID,FirstName,MiddleName,LastName,MobileNo,EmailID,Address,DistrictId,StateId,CountryId,Status,EntryBy,EntryDate,ModifyBy,ModifyDate,Gender,EduQualification")] UserDetailsMaster userDetailsMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetailsMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchID = new SelectList(db.BranchMasters, "Id", "BranchName", userDetailsMaster.BranchID);
            ViewBag.CollegeID = new SelectList(db.CollegeMasters, "Id", "CollegeName", userDetailsMaster.CollegeID);
            ViewBag.CountryId = new SelectList(db.CountryMasters, "Id", "CountryName", userDetailsMaster.CountryId);
            ViewBag.DepartmentID = new SelectList(db.DeparmentMasters, "Id", "DepartmentName", userDetailsMaster.DepartmentID);
            ViewBag.DistrictId = new SelectList(db.DistrictMasters, "Id", "DistrictName", userDetailsMaster.DistrictId);
            ViewBag.RoleID = new SelectList(db.RoleMasters, "Id", "RoleName", userDetailsMaster.RoleID);
            ViewBag.SectionID = new SelectList(db.SectionMasters, "Id", "SectionName", userDetailsMaster.SectionID);
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Enumerations.Status)));
            return View(userDetailsMaster);
        }

        // GET: UserDetailsMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetailsMaster userDetailsMaster = db.UserDetailsMasters.Find(id);
            if (userDetailsMaster == null)
            {
                return HttpNotFound();
            }
            return View(userDetailsMaster);
        }

        // POST: UserDetailsMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDetailsMaster userDetailsMaster = db.UserDetailsMasters.Find(id);
            db.UserDetailsMasters.Remove(userDetailsMaster);
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
