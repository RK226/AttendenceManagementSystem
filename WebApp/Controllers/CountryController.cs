using BusinessEntities;
using BusinessEntity;
using DataModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Services;

namespace WebApp.Controllers
{
    public class CountryController : Controller
    {
        #region Private variable.

        private readonly ICountryMasterServices _countryMasterServices;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();
        #endregion

        #region Public Constructor

        public CountryController(ICountryMasterServices countryMasterServices)
        {
            _countryMasterServices = countryMasterServices;
        }
        #endregion
        
        public ActionResult Index()
        {
            
            var country = _countryMasterServices.GetAllCountry();
            var currencyEntities = country as List<CountryMasterEntity> ?? country.ToList();
            return View(currencyEntities);
        }



        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            var country = _context.CountryMasters.Find(id);
            return View(country);
        }

        // GET: Country/Create
        public ActionResult CreateCountry()
        {
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        public ActionResult CreateCountry(CountryMasterEntity countryMasterEntity)
        {
            
            List<CountryMasterEntity> lstCountry = new List<CountryMasterEntity>();
            var country = _countryMasterServices.CreateCountry(countryMasterEntity);
            lstCountry.Add(country);
            return RedirectToAction("Index");
            return View();
            

        }

        // GET: Country/Edit/5
        public ActionResult UpdateCountry(int id)
        {
            var country = _context.CountryMasters.Find(id);
            return View(country);
        }

        // POST: Country/Edit/5
        [HttpPost]
        public ActionResult UpdateCountry(int id, CountryMasterEntity countryMasterEntity)
        {
            try
            {
                
               bool isUpdated = _countryMasterServices.UpdateCountry(countryMasterEntity);
                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            var country = _context.CountryMasters.Find(id);
            _context.CountryMasters.Remove(country);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

     }
}
