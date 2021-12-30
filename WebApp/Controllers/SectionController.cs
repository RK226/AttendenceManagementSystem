using BusinessEntities;
using BusinessEntity;
using BusinessServices.BusinessInterface;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class SectionController : Controller
    {
        #region Private variable.

        private readonly ISectionMasterServices _sectionMasterServices;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();
        #endregion

        #region Public Constructor

        public SectionController(ISectionMasterServices sectionMasterServices)
        {
            _sectionMasterServices = sectionMasterServices;
        }
        #endregion


        // GET: College
        public ActionResult Index()
        {
            var sections = _sectionMasterServices.GetAllSection();
            var sectionEntities = sections as List<SectionEntity> ?? sections.ToList();
            return View(sectionEntities);
        }

        // GET: College/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: College/Create
        public ActionResult CreateSection()
        {
            ViewBag.DistrictId = new SelectList(_context.DistrictMasters, "Id", "DistrictName");
            ViewBag.StateId = new SelectList(_context.StateMasters, "Id", "StateName");
            return View();
        }

        // POST: College/Create
        [HttpPost]
        public ActionResult CreateSection(SectionEntity sectionEntity)
        {
            List<SectionEntity> lstSection = new List<SectionEntity>();
            var section = _sectionMasterServices.CreateSection(sectionEntity);
            lstSection.Add(section);
            return RedirectToAction("Index");
            return View();

            //var districtList = _context.DistrictMasters.ToList();

        }

        // GET: College/Edit/5
        public ActionResult UpdateSection(int id)
        {
            var section = _context.SectionMasters.Find(id);
            return View(section);
        }

        // POST: College/Edit/5
        [HttpPost]
        public ActionResult UpdateSection(int id, SectionEntity sectionEntity)
        {
            try
            {

                bool isUpdated = _sectionMasterServices.UpdateSection(sectionEntity);
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
        public ActionResult Delete(int id, SectionEntity sectionEntity)
        {
            var section = _context.SectionMasters.Find(id);
            _context.SectionMasters.Remove(section);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}