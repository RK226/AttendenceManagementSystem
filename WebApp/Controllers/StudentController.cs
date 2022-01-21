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
    public class StudentController : Controller
    {
        //private AttendenceManagementSystemEntities1 _context = new AttendenceManagementSystemEntities1();
        #region Private variable.

        private readonly IStudentServices _studentServices;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();
        #endregion

        #region Public Constructor

        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        #endregion

        // GET: Student
        public ActionResult Index()
        {
            var students = _studentServices.GetAllStudent();
            var studentEntities = students as List<StudentEntity> ?? students.ToList();
            return View(studentEntities);

            //var students = _context.Students.Include(s => s.AcedemicYearMaster).Include(s => s.BranchMaster).Include(s => s.CollegeMaster).Include(s => s.CountryMaster).Include(s => s.DeparmentMaster).Include(s => s.DistrictMaster).Include(s => s.DivisionMaster).Include(s => s.SectionMaster).Include(s => s.SectionMaster1).Include(s => s.YearMaster);
            //return View(students.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = _context.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            ViewBag.AcademicYearId = new SelectList(_context.AcedemicYearMasters, "Id", "AcedemicYear");
            ViewBag.BranchId = new SelectList(_context.BranchMasters, "Id", "BranchName");
            ViewBag.CollegeId = new SelectList(_context.CollegeMasters, "Id", "CollegeName");
            ViewBag.CountryId = new SelectList(_context.CountryMasters, "Id", "CountryName");
            ViewBag.DepartmentId = new SelectList(_context.DeparmentMasters, "Id", "DepartmentName");
            ViewBag.DistrictId = new SelectList(_context.DistrictMasters, "Id", "DistrictName");
            ViewBag.StateId = new SelectList(_context.StateMasters, "Id", "StateName");
            ViewBag.DivisionId = new SelectList(_context.DivisionMasters, "Id", "DivisionName");
            ViewBag.SectionId = new SelectList(_context.SectionMasters, "Id", "SectionName");
            ViewBag.StandardId = new SelectList(_context.StandardMasters, "Id", "StandardName");
            ViewBag.YearId = new SelectList(_context.YearMasters, "Id", "YearName");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,URNNo,RollNo,CollegeId,SectionId,DepartmentId,AcademicYearId,Gender,AadharNo,LastName,FirstName,MiddleName,GrandFatherName,MotherName,ContactNo,EmailId,Religion,Caste,Nationality,DOB,Village,Taluka,DistrictId,StateId,CountryId,Pincode,StandardId,DivisionId,YearId,EntryBy,EntryDate,ModifyBy,ModifyDate,Photo,Flag,BranchId")] Student student)
        {
            //if (ModelState.IsValid)
            //{
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
           // }

            ViewBag.AcademicYearId = new SelectList(_context.AcedemicYearMasters, "Id", "AcedemicYear", student.AcademicYearId);
            ViewBag.BranchId = new SelectList(_context.BranchMasters, "Id", "BranchName", student.BranchId);
            ViewBag.CollegeId = new SelectList(_context.CollegeMasters, "Id", "CollegeName", student.CollegeId);
            ViewBag.DepartmentId = new SelectList(_context.DeparmentMasters, "Id", "DepartmentName", student.DepartmentId);
            ViewBag.StateId = new SelectList(_context.StateMasters, "Id", "StateName", student.StateId);
            ViewBag.CountryId = new SelectList(_context.CountryMasters, "Id", "CountryName", student.CountryId);
            ViewBag.DistrictId = new SelectList(_context.DistrictMasters, "Id", "DistrictName", student.DistrictId);
            ViewBag.DivisionId = new SelectList(_context.DivisionMasters, "Id", "DivisionName", student.DivisionId);
            ViewBag.SectionId = new SelectList(_context.SectionMasters, "Id", "SectionName", student.SectionId);
            ViewBag.StandardId = new SelectList(_context.StandardMasters, "Id", "StandardName", student.StandardId);
            ViewBag.YearId = new SelectList(_context.YearMasters, "Id", "YearName", student.YearId);
            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = _context.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcademicYearId = new SelectList(_context.AcedemicYearMasters, "Id", "AcedemicYear", student.AcademicYearId);
            ViewBag.BranchId = new SelectList(_context.BranchMasters, "Id", "BranchName", student.BranchId);
            ViewBag.CollegeId = new SelectList(_context.CollegeMasters, "Id", "CollegeName", student.CollegeId);
            ViewBag.DepartmentId = new SelectList(_context.DeparmentMasters, "Id", "DepartmentName", student.DepartmentId);
            ViewBag.DistrictId = new SelectList(_context.DistrictMasters, "Id", "DistrictName", student.DistrictId);
            ViewBag.StateId = new SelectList(_context.StateMasters, "Id", "StateName", student.StateId);
            ViewBag.CountryId = new SelectList(_context.CountryMasters, "Id", "CountryName", student.CountryId);
            ViewBag.DivisionId = new SelectList(_context.DivisionMasters, "Id", "DivisionName", student.DivisionId);
            ViewBag.SectionId = new SelectList(_context.SectionMasters, "Id", "SectionName", student.SectionId);
            ViewBag.StandardId = new SelectList(_context.StandardMasters, "Id", "StandardName", student.StandardId);
            ViewBag.YearId = new SelectList(_context.YearMasters, "Id", "YearName", student.YearId);
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,URNNo,RollNo,CollegeId,SectionId,DepartmentId,AcademicYearId,Gender,AadharNo,LastName,FirstName,MiddleName,GrandFatherName,MotherName,ContactNo,EmailId,Religion,Caste,Nationality,DOB,Village,Taluka,DistrictId,StateId,CountryId,Pincode,StandardId,DivisionId,YearId,EntryBy,EntryDate,ModifyBy,ModifyDate,Photo,Flag,BranchId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(student).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AcademicYearId = new SelectList(_context.AcedemicYearMasters, "Id", "AcedemicYear", student.AcademicYearId);
            ViewBag.BranchId = new SelectList(_context.BranchMasters, "Id", "BranchName", student.BranchId);
            ViewBag.CollegeId = new SelectList(_context.CollegeMasters, "Id", "CollegeName", student.CollegeId);
            ViewBag.DepartmentId = new SelectList(_context.DeparmentMasters, "Id", "DepartmentName", student.DepartmentId);
            ViewBag.StateId = new SelectList(_context.StateMasters, "Id", "StateName", student.StateId);
            ViewBag.CountryId = new SelectList(_context.CountryMasters, "Id", "CountryName", student.CountryId);
            ViewBag.DistrictId = new SelectList(_context.DistrictMasters, "Id", "DistrictName", student.DistrictId);
            ViewBag.DivisionId = new SelectList(_context.DivisionMasters, "Id", "DivisionName", student.DivisionId);
            ViewBag.SectionId = new SelectList(_context.SectionMasters, "Id", "SectionName", student.SectionId);
            ViewBag.StandardId = new SelectList(_context.StandardMasters, "Id", "StandardName", student.StandardId);
            ViewBag.YearId = new SelectList(_context.YearMasters, "Id", "YearName", student.YearId);
            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = _context.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = _context.Students.Find(id);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
