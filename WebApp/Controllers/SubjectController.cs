using BusinessEntities;
using BusinessEntity;
using DataModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Services;
using BusinessServices.BusinessInterface;

namespace WebApp.Controllers
{
    public class SubjectController : Controller
    {
        #region Private variable.

        private readonly ISubjectServices _subjectServices;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();
        #endregion

        #region Public Constructor

        public SubjectController(ISubjectServices subjectServices)
        {
            _subjectServices = subjectServices;
        }
        #endregion
        // GET: Subject
        public ActionResult Index()
        {
            var subjects = _subjectServices.GetAllSubjects();
            var subjectMasterEntities = subjects as List<SubjectMasterEntity> ?? subjects.ToList();
            return View(subjectMasterEntities);
        }

        // GET: Subject/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Subject/Create
        public ActionResult CreateSubjects()
        {
            ViewBag.BranchId = new SelectList(_context.BranchMasters, "Id", "BranchName");
            ViewBag.DepartmentId = new SelectList(_context.DeparmentMasters, "Id", "DepartmentName");
            ViewBag.SectionId = new SelectList(_context.SectionMasters, "Id", "SectionName");
            ViewBag.StandardId = new SelectList(_context.StandardMasters, "Id", "StandardName");
            return View();
        }

        // POST: Subject/Create
        [HttpPost]
        public ActionResult CreateSubjects(SubjectMasterEntity subjectMasterEntity)
        {
            List<SubjectMasterEntity> lstsubjectMasterEntities = new List<SubjectMasterEntity>();
            var subject = _subjectServices.CreateSubjects(subjectMasterEntity);
            lstsubjectMasterEntities.Add(subject);
            return RedirectToAction("Index");
            ViewBag.BranchId = new SelectList(_context.BranchMasters, "Id", "BranchName");
            ViewBag.DepartmentId = new SelectList(_context.DeparmentMasters, "Id", "DepartmentName");
            ViewBag.SectionId = new SelectList(_context.SectionMasters, "Id", "SectionName");
            ViewBag.StandardId = new SelectList(_context.StandardMasters, "Id", "StandardName");
            return View();
        }

        // GET: Subject/Edit/5
        public ActionResult UpdateSubjects(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectMaster subject = _context.SubjectMasters.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(_context.BranchMasters, "Id", "BranchName", subject.BranchId);
            ViewBag.DepartmentId = new SelectList(_context.CountryMasters, "Id", "CountryName", subject.DepartmentId);
            ViewBag.DepartmentId = new SelectList(_context.DeparmentMasters, "Id", "DepartmentName", subject.DepartmentId);
            ViewBag.SectionId = new SelectList(_context.SectionMasters, "Id", "SectionName", subject.SectionId);
            ViewBag.StandardId = new SelectList(_context.StandardMasters, "Id", "StandardName", subject.StandardId);
            return View(subject);
        }

        // POST: Subject/Edit/5
        [HttpPost]
        public ActionResult UpdateSubjects(int id, SubjectMasterEntity subjectMasterEntity)
        {
            try
            {

                bool isUpdated = _subjectServices.UpdateSubjects(subjectMasterEntity);
                return RedirectToAction("Index");
                //ViewBag.BranchId = new SelectList(_context.BranchMasters, "Id", "BranchName", subject.BranchId);
                //ViewBag.DepartmentId = new SelectList(_context.CountryMasters, "Id", "CountryName", subject.DepartmentId);
                //ViewBag.DepartmentId = new SelectList(_context.DeparmentMasters, "Id", "DepartmentName", subject.DepartmentId);
                //ViewBag.SectionId = new SelectList(_context.SectionMasters, "Id", "SectionName", subject.SectionId);
                //ViewBag.StandardId = new SelectList(_context.SectionMasters, "Id", "SectionName", subject.StandardId);

            }
            catch
            {
                return View();
            }
        }

        // GET: Subject/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Subject/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
