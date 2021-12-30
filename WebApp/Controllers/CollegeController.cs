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
    public class CollegeController : Controller
    {
        #region Private variable.

        private readonly ICollegeMasterServices _collegeMasterServices;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();
        #endregion

        #region Public Constructor

        public CollegeController(ICollegeMasterServices collegeMasterServices)
        {
            _collegeMasterServices = collegeMasterServices;
        }
        #endregion


        // GET: College
        public ActionResult Index()
        {
            var college = _collegeMasterServices.GetAllCollege();
            var collegeMasterEntities = college as List<CollegeMasterEntity> ?? college.ToList();
            return View(collegeMasterEntities);
        }

        // GET: College/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: College/Create
        public ActionResult CreateCollege()
        {
            ViewBag.DistrictId = new SelectList(_context.DistrictMasters, "Id", "DistrictName");
            ViewBag.StateId = new SelectList(_context.StateMasters, "Id", "StateName");
            ViewBag.CountryId = new SelectList(_context.CountryMasters, "Id", "CountryName");
            return View();
        }

        // POST: College/Create
        [HttpPost]
        public ActionResult CreateCollege(CollegeMasterEntity collegeMasterEntity)
        {
            List<CollegeMasterEntity> lstCollege = new List<CollegeMasterEntity>();
            var college = _collegeMasterServices.CreateCollege(collegeMasterEntity);
            lstCollege.Add(college);
            return RedirectToAction("Index");
            return View();

            //var districtList = _context.DistrictMasters.ToList();
            
        }

        // GET: College/Edit/5
        public ActionResult UpdateCollege(int id)
        {
            var college = _context.CollegeMasters.Find(id);
            return View(college);
        }

        // POST: College/Edit/5
        [HttpPost]
        public ActionResult UpdateCollege(int id, CollegeMasterEntity collegeMasterEntity)
        {
            try
            {

                bool isUpdated = _collegeMasterServices.UpdateCollege(collegeMasterEntity);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: College/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: College/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var college = _context.CollegeMasters.Find(id);
            _context.CollegeMasters.Remove(college);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
