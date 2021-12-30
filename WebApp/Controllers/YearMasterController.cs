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
    public class YearMasterController : Controller
    {
        #region Private variable.

        private readonly IYearMasterServices _yearMasterServices;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();
        #endregion

        #region Public Constructor

        public YearMasterController(IYearMasterServices yearMasterServices)
        {
            _yearMasterServices = yearMasterServices;
        }
        #endregion
        // GET: YearMaster
        public ActionResult Index()
        {
            var yearMasters = _yearMasterServices.GetAllYears();
            var yearMasterEntities = yearMasters as List<YearMasterEntity> ?? yearMasters.ToList();
            return View(yearMasterEntities);
        }

        // GET: YearMaster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: YearMaster/Create
        public ActionResult CreateYears()
        {
            ViewBag.CountryId = new SelectList(_context.CountryMasters, "Id", "CountryName");
            return View();
        }

        // POST: YearMaster/Create
        [HttpPost]
        public ActionResult CreateYears(YearMasterEntity yearMasterEntity)
        {
            List<YearMasterEntity> lstYear = new List<YearMasterEntity>();
            var year = _yearMasterServices.CreateYears(yearMasterEntity);
            lstYear.Add(year);
            return RedirectToAction("Index");
            return View();
        }

        // GET: YearMaster/Edit/5
        public ActionResult UpdateYears(int id)
        {
            return View();
        }

        // POST: YearMaster/Edit/5
        [HttpPost]
        public ActionResult UpdateYears(int id, YearMasterEntity yearMasterEntity)
        {
            try
            {

                bool isUpdated = _yearMasterServices.UpdateYears(yearMasterEntity);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: YearMaster/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: YearMaster/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var yearMaster = _context.YearMasters.Find(id);
            _context.YearMasters.Remove(yearMaster);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
