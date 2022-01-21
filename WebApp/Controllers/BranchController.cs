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
    
    public class BranchController : Controller
    {
        #region Private variable.

        private readonly IBranchMasterServices _branchMasterServices;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();
        #endregion

        #region Public Constructor

        public BranchController(IBranchMasterServices branchMasterServices)
        {
            _branchMasterServices = branchMasterServices;
        }
        #endregion
        // GET: Branch
        public ActionResult Index()
        {
            var branches = _branchMasterServices.GetAllBranch();
            var branches1 = branches as List<BranchMasterEntity> ?? branches.ToList();
            return View(branches1);
        }

        // GET: Branch/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Branch/Create
        public ActionResult CreateBranch()
        {
            ViewBag.CollegeId = new SelectList(_context.CollegeMasters, "Id", "CollegeName");
            return View();
        }

        // POST: Branch/Create
        [HttpPost]
        public ActionResult CreateBranch(BranchMasterEntity branchMasterEntity)
        {
            if (ModelState.IsValid)
            {
                List<BranchMasterEntity> lstBranchs = new List<BranchMasterEntity>();
                var branch = _branchMasterServices.CreateBranch(branchMasterEntity);
                lstBranchs.Add(branch);
                return RedirectToAction("Index");
            }
               
            return View();
        }

        // GET: Branch/Edit/5
        public ActionResult UpdateBranch(int id)
        {
            return View();
        }

        // POST: Branch/Edit/5
        [HttpPost]
        public ActionResult UpdateBranch(int id, BranchMasterEntity branchMasterEntity)
        {
            try
            {

                bool isUpdated = _branchMasterServices.UpdateBranch(branchMasterEntity);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Branch/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Branch/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var branchMaster = _context.BranchMasters.Find(id);
            _context.BranchMasters.Remove(branchMaster);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
