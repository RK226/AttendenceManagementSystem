using BusinessEntities;
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
    public class YearMasterServices : IYearMasterServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();

        public YearMasterServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public YearMasterEntity CreateYears(YearMasterEntity yearMasterEntity)
        {
            var year = new YearMaster
            {
                YearName = yearMasterEntity.YearName
            };
            _unitOfWork.MstYearMasterRepository.Insert(year);
            _unitOfWork.Save();

            return yearMasterEntity;
        }

        public IEnumerable<YearMasterEntity> GetAllYears()
        {
            var year = _context.YearMasters.ToList();
            List<YearMasterEntity> lstYear = Mapping(year);
            return lstYear;
        }

        public bool UpdateYears(YearMasterEntity yearMasterEntity)
        {
            var success = false;
            if (yearMasterEntity != null)
            {
                var year = _unitOfWork.MstYearMasterRepository.GetByID(yearMasterEntity.Id);
                if (year != null)
                {
                    year.YearName = yearMasterEntity.YearName;


                    _unitOfWork.MstYearMasterRepository.Update(year);
                    _unitOfWork.Save();
                }

            }
            return success;
        }

        public List<YearMasterEntity> Mapping(List<YearMaster> deal)
        {
            List<YearMasterEntity> lstYear = new List<YearMasterEntity>();
            foreach (var item in deal)
            {
                YearMasterEntity objYear = new YearMasterEntity();
                objYear.Id = item.Id;
                objYear.YearName = item.YearName;

                lstYear.Add(objYear);
            }
            return lstYear;
        }
    }
}
