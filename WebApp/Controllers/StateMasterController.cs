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
    public class StateMasterController : Controller
    {
        #region Private variable.

        private readonly IStateMasterServices _stateMasterServices;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();
        #endregion

        #region Public Constructor

        public StateMasterController(IStateMasterServices stateMasterServices)
        {
            _stateMasterServices = stateMasterServices;
        }
        #endregion


        // GET: StateMaster
        public ActionResult Index()
        {
            var states = _stateMasterServices.GetAllState();
            var stateEntity = states as List<StateMasterEntity> ?? states.ToList();
            return View(stateEntity);
        }

        // GET: StateMaster/Details/5
        public ActionResult Details(int id)
        {
           
            return View();
        }

        // GET: StateMaster/Create
        public ActionResult CreateState()
        {
            ViewBag.CountryId = new SelectList(_context.CountryMasters, "Id", "CountryName");
            return View();
        }

        // POST: StateMaster/Create
        [HttpPost]
        public ActionResult CreateState(StateMasterEntity stateMasterEntity)
        {
            List<StateMasterEntity> lstState = new List<StateMasterEntity>();
            var state = _stateMasterServices.CreateState(stateMasterEntity);
            lstState.Add(state);
            return RedirectToAction("Index");
            return View();
        }

        // GET: StateMaster/Edit/5
        public ActionResult UpdateState(int id)
        {
            ViewBag.CountryId = new SelectList(_context.CountryMasters, "Id", "CountryName");
            var state = _context.StateMasters.Find(id);
            return View(state);
        }

        // POST: StateMaster/Edit/5
        [HttpPost]
        public ActionResult UpdateState(int id, StateMasterEntity stateMasterEntity)
        {
            try
            {

                bool isUpdated = _stateMasterServices.UpdateState(stateMasterEntity);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: StateMaster/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StateMaster/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var state = _context.StateMasters.Find(id);
            _context.StateMasters.Remove(state);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
