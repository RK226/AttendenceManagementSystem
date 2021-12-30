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
    public class DepartmentController : Controller
    {
        #region Private variable.

        private readonly IDepartmentServices _departmentServices;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();
        #endregion

        #region Public Constructor

        public DepartmentController(IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }
        #endregion
        // GET: Department
        public ActionResult Index()
        {
            var department = _departmentServices.GetAllDepartment();
            var deparmentMasterEntities = department as List<DeparmentMasterEntity> ?? department.ToList();
            return View(deparmentMasterEntities);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Department/Create
        public ActionResult CreateDepartment()
        {
            ViewBag.CollegeId = new SelectList(_context.CollegeMasters, "Id", "CollegeName");
            ViewBag.SectionId = new SelectList(_context.SectionMasters, "Id", "SectionName");
            ViewBag.BranchId = new SelectList(_context.BranchMasters, "Id", "BranchName");
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult CreateDepartment(DeparmentMasterEntity deparmentMasterEntity)
        {
            List<DeparmentMasterEntity> lstDepartments = new List<DeparmentMasterEntity>();
            var deparment = _departmentServices.CreateDepartment(deparmentMasterEntity);
            lstDepartments.Add(deparment);
            return RedirectToAction("Index");
            return View();
        }

        // GET: Department/Edit/5
        public ActionResult UpdateDepartment(int id)
        {
            var department = _context.DeparmentMasters.Find(id);
            ViewBag.CollegeId = new SelectList(_context.CollegeMasters, "Id", "CollegeName");
            ViewBag.SectionId = new SelectList(_context.SectionMasters, "Id", "SectionName");
            ViewBag.BranchId = new SelectList(_context.BranchMasters, "Id", "BranchName");
            return View(department);
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult UpdateDepartment(int id, DeparmentMasterEntity deparmentMasterEntity)
        {
            try
            {

                bool isUpdated = _departmentServices.UpdateDepartment(deparmentMasterEntity);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Department/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var deparmentMaster = _context.DeparmentMasters.Find(id);
            _context.DeparmentMasters.Remove(deparmentMaster);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
