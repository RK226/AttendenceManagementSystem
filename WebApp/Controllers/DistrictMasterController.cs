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
    public class DistrictMasterController : Controller
    {
        #region Private variable.

        private readonly IDistrictMasterServices _districtMasterServices;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();
        #endregion

        #region Public Constructor

        public DistrictMasterController(IDistrictMasterServices districtMasterServices)
        {
            _districtMasterServices = districtMasterServices;
        }
        #endregion

        // GET: DistrictMaster
        public ActionResult Index()
        {
            var districts = _districtMasterServices.GetAllDistricts();
            var districtMasterEntities = districts as List<DistrictMasterEntity> ?? districts.ToList();
            return View(districtMasterEntities);
        }

        // GET: DistrictMaster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DistrictMaster/Create
        public ActionResult CreateDistricts()
        {
            ViewBag.StateId = new SelectList(_context.StateMasters, "Id", "StateName");
            ViewBag.CountryId = new SelectList(_context.CountryMasters, "Id", "CountryName");
            return View();
        }

        // POST: DistrictMaster/Create
        [HttpPost]
        public ActionResult CreateDistricts(DistrictMasterEntity districtMasterEntity)
        {
            List<DistrictMasterEntity> lstDistricts = new List<DistrictMasterEntity>();
            var district = _districtMasterServices.CreateDistricts(districtMasterEntity);
            lstDistricts.Add(district);
            return RedirectToAction("Index");
            return View();
        }

        // GET: DistrictMaster/Edit/5
        public ActionResult UpdateDistricts(int id)
        {
            var district = _context.DistrictMasters.Find(id);
            return View(district);
        }

        // POST: DistrictMaster/Edit/5
        [HttpPost]
        public ActionResult UpdateDistricts(int id, DistrictMasterEntity districtMasterEntity)
        {
            try
            {
                ViewBag.StateId = new SelectList(_context.StateMasters, "Id", "StateName");
                ViewBag.CountryId = new SelectList(_context.CountryMasters, "Id", "CountryName");

                bool isUpdated = _districtMasterServices.UpdateDistricts(districtMasterEntity);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: DistrictMaster/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DistrictMaster/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var districts = _context.DistrictMasters.Find(id);
            _context.DistrictMasters.Remove(districts);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
