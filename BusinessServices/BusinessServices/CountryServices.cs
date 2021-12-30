using BusinessEntity;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;

namespace Services.BusinessServices
{
    public class CountryServices : ICountryMasterServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();

        public CountryServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CountryMasterEntity CreateCountry(CountryMasterEntity countryMasterEntity)
        {
           
               var country = new CountryMaster
               {


                        CountryName = countryMasterEntity.CountryName,
                        CreatedBy = countryMasterEntity.CreatedBy,
                        CreatedDate = DateTime.Now
               };
                    _unitOfWork.MstCountryMasterRepository.Insert(country);
                    _unitOfWork.Save();

                    return countryMasterEntity;
            
        }

        public bool UpdateCountry(CountryMasterEntity countryMasterEntity)
        {
            var success = false;
            if (countryMasterEntity != null)
            {
                   var country = _unitOfWork.MstCountryMasterRepository.GetByID(countryMasterEntity.Id);
                    if (country != null)
                    {


                         country.CountryName = countryMasterEntity.CountryName;
                         country.ModifyBy = countryMasterEntity.CreatedBy;
                         country.ModifiedDate = DateTime.Now;


                        _unitOfWork.MstCountryMasterRepository.Update(country);
                        _unitOfWork.Save();
                    }
                
            }
            return success;
        }

        


        public IEnumerable<CountryMasterEntity> GetAllCountry()
        {

            var country = _context.CountryMasters.ToList();
            List<CountryMasterEntity> lstCountry = Mapping(country);
            return lstCountry;


        }

        public List<CountryMasterEntity> Mapping(List<CountryMaster> deal)
        {
            List<CountryMasterEntity> lstMstCountry = new List<CountryMasterEntity>();
            foreach (var item in deal)
            {
                CountryMasterEntity objCountry = new CountryMasterEntity();
                objCountry.Id = item.Id;
                objCountry.CountryName = item.CountryName;
                objCountry.CreatedBy = item.CreatedBy;
                objCountry.CreatedDate = item.CreatedDate;
                objCountry.ModifyBy = item.ModifyBy;
                objCountry.ModifiedDate = item.ModifiedDate;


                lstMstCountry.Add(objCountry);
            }
            return lstMstCountry;
        }

        public CountryMasterEntity MappingSingleObject(CountryMaster item)
        {
            CountryMasterEntity objCountry = new CountryMasterEntity();
            objCountry.Id = item.Id;
            objCountry.CountryName = item.CountryName;
            objCountry.CreatedBy = item.CreatedBy;
            objCountry.CreatedDate = item.CreatedDate;
            objCountry.ModifyBy = item.ModifyBy;
            objCountry.ModifiedDate = item.ModifiedDate;

            return objCountry;
        }

        
    }
}
