using BusinessEntity;
using System.Collections.Generic;
using System.Linq;
//using CountryMaster = BusinessEntity.CountryMaster;

namespace Services
{
    public interface ICountryMasterServices
    {
        IEnumerable<CountryMasterEntity> GetAllCountry();
        CountryMasterEntity CreateCountry(CountryMasterEntity countryMasterEntity);
        bool UpdateCountry(CountryMasterEntity countryMasterEntity);
       // bool GetDeleteCountry(int Id);












        //public CountryMasterEntity CreateCountry();

        //private AttendenceManagementSystemEntities _context;
        //public ICountryMasterServices()
        //{
        //    _context = new AttendenceManagementSystemEntities();

        //}


        //public IEnumerable<CountryMaster> GetAll()
        //{
        //    return (IEnumerable<CountryMaster>)_context.CountryMasters.ToList();
        //}

        //public CountryMaster GetById(int Id)
        //{
        //    return _context.CountryMasters.Find(Id);
        //}

        //public void Insert(CountryMaster countryMaster)
        //{
        //    _context.CountryMasters.Add(countryMaster);
        //    Save();
        //}

        //public void Update(CountryMaster countryMaster)
        //{
        //    _context.CountryMasters.Attach(countryMaster);
        //    Save();
        //}

        //public void Delete(int Id)
        //{
        //    CountryMaster countryMaster = _context.CountryMasters.Find(Id);
        //    _context.CountryMasters.Remove(countryMaster);
        //    Save();
        //}

        //public void Save()
        //{
        //    _context.SaveChanges();
        //}




    }
}
