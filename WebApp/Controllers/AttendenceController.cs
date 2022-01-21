using BusinessEntities;
using BusinessEntity;
using DataModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Services;
using BusinessServices.BusinessInterface;
using System;

namespace WebApp.Controllers
{
    public class AttendenceController : Controller
    {
        #region Private variable.

        private readonly IStudentServices _studentServices;
        private readonly IAttendenceServices _attendenceServices;
        private readonly AttendenceManagementSystem1Entities db = new AttendenceManagementSystem1Entities();
        #endregion

        #region Public Constructor

        public AttendenceController(IStudentServices studentServices, IAttendenceServices attendenceServices)
        {
            _studentServices = studentServices;
            _attendenceServices = attendenceServices;
        }
        #endregion

        // GET: Attendence
        public ActionResult Index()
        {
            //var students = _studentServices.GetAllStudent();
            List<StudentEntity> stud = new List<StudentEntity>();
             stud = TempData["student"] as List<StudentEntity>;//students as List<StudentEntity> ?? students.ToList();
            return View(stud);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(StudentAttendenceEntity studentEntity)
        {
            List<StudentAttendenceEntity> lstStudentAttendences = new List<StudentAttendenceEntity>();
            var studentAttendence = _attendenceServices.CreateAttendence(studentEntity);
            lstStudentAttendences.Add(studentAttendence);
            return RedirectToAction("Index");
            return View();

            //var students = _studentServices.GetAllStudent();
            //List<StudentEntity> stud = new List<StudentEntity>();
            //stud = TempData["student"] as List<StudentEntity>;//students as List<StudentEntity> ?? students.ToList();
            //return View(stud);
        }

        public ActionResult GetAttendence()
        {
            ViewBag.BranchID = new SelectList(db.BranchMasters, "Id", "BranchName");
            ViewBag.CollegeID = new SelectList(db.CollegeMasters, "Id", "CollegeName");
            ViewBag.StandardId = new SelectList(db.StandardMasters, "Id", "StandardName");
            ViewBag.DivisionId = new SelectList(db.DivisionMasters, "Id", "DivisionName");
            ViewBag.DepartmentID = new SelectList(db.DeparmentMasters, "Id", "DepartmentName");
            ViewBag.SectionID = new SelectList(db.SectionMasters, "Id", "SectionName");
            ViewBag.SubjectId = new SelectList(db.SubjectMasters, "Id", "SubjectName");
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Enumerations.Status)));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetAttendence(int CollegeID, int StandardId, int DivisionId, int SectionID)
        {
            
            var students = _studentServices.GetAttendence(CollegeID, StandardId, DivisionId, SectionID);
            var studentEntities1 = students as List<StudentEntity> ?? students.ToList();
            if (studentEntities1.Any())
            {
                TempData["student"]= studentEntities1;
                return RedirectToAction("Index");
            }
            return View(studentEntities1);
        }
    }
}