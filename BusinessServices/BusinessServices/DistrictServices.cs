using BusinessEntity;
using BusinessServices.BusinessInterface;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;

namespace BusinessServices.BusinessServices
{
    public class DistrictServices : IDistrictMasterServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();

        public DistrictServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DistrictMasterEntity CreateDistricts(DistrictMasterEntity districtMasterEntity)
        {
            var district = new DistrictMaster
            {


                    DistrictName = districtMasterEntity.DistrictName,
                    CountryId = districtMasterEntity.CountryId,
                    StateId = districtMasterEntity.StateId,
                    CreateBy = districtMasterEntity.CreateBy,
                    CreatedDate = DateTime.Now
                    

            };
            _unitOfWork.MstDistrictMasterRepository.Insert(district);
            _unitOfWork.Save();

            return districtMasterEntity;
        }

        public IEnumerable<DistrictMasterEntity> GetAllDistricts()
        {
            var district = _context.DistrictMasters.ToList();
            List<DistrictMasterEntity> lstDistrict = Mapping(district);
            return lstDistrict;
        }

        public bool UpdateDistricts(DistrictMasterEntity districtMasterEntity)
        {
            var success = false;
            if (districtMasterEntity != null)
            {
                var district = _unitOfWork.MstDistrictMasterRepository.GetByID(districtMasterEntity.Id);
                if (district != null)
                {


                    district.DistrictName = districtMasterEntity.DistrictName;
                    district.CountryId = districtMasterEntity.CountryId;
                    district.StateId = districtMasterEntity.StateId;
                    district.ModifiedBy = districtMasterEntity.ModifiedBy;
                    district.ModifiedDate = DateTime.Now;


                    _unitOfWork.MstDistrictMasterRepository.Update(district);
                    _unitOfWork.Save();
                }

            }
            return success;
        }

        public List<DistrictMasterEntity> Mapping(List<DistrictMaster> deal)
        {
            List<DistrictMasterEntity> lstMstDistrict = new List<DistrictMasterEntity>();
            foreach (var item in deal)
            {
                DistrictMasterEntity objDistrict = new DistrictMasterEntity();
                objDistrict.Id = item.Id;
                objDistrict.DistrictName = item.DistrictName;
                objDistrict.CountryId = item.CountryId;
                objDistrict.StateId = item.StateId;
                objDistrict.CreateBy = item.CreateBy;
                objDistrict.CreatedDate = item.CreatedDate;
                objDistrict.ModifiedBy = item.ModifiedBy;
                objDistrict.ModifiedDate = item.ModifiedDate;

                CountryMaster countryMaster = item.CountryMaster;
                if (countryMaster != null)
                {
                    CountryMasterEntity objCountry = new CountryMasterEntity();
                    objCountry.Id = countryMaster.Id;
                    objCountry.CountryName = countryMaster.CountryName;

                    objDistrict.CountryMaster = objCountry;
                }

                StateMaster stateMaster = item.StateMaster;
                if (stateMaster != null)
                {
                    StateMasterEntity stateMasterEntity = new StateMasterEntity();
                    stateMasterEntity.Id = stateMaster.Id;
                    stateMasterEntity.StateName = stateMaster.StateName;

                    objDistrict.StateMaster = stateMasterEntity;
                }
               


                lstMstDistrict.Add(objDistrict);
            }
            return lstMstDistrict;
        }
    }
}
