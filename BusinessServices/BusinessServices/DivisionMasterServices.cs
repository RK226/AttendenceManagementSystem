using BusinessEntity;
using BusinessServices.BusinessInterface;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.BusinessServices
{
    public class DivisionMasterServices : IDivisionMasterServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();

        public DivisionMasterServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DivisionMasterEntity CreateDivision(DivisionMasterEntity divisionMasterEntity)
        {
            var division = new DivisionMaster
            {

                DivisionName = divisionMasterEntity.DivisionName,
                 Status= divisionMasterEntity.Status,
                EntryBy = divisionMasterEntity.EntryBy,
                EntryDate = DateTime.Now

            };
            _unitOfWork.MstDivisionMasterRepository.Insert(division);
            _unitOfWork.Save();

            return divisionMasterEntity;
        }

        public IEnumerable<DivisionMasterEntity> GetAllDivision()
        {
            var divisions = _context.DivisionMasters.ToList();
            List<DivisionMasterEntity> lstDivision = Mapping(divisions);
            return lstDivision;
        }

        public bool UpdateDivision(DivisionMasterEntity divisionMasterEntity)
        {
            var success = false;
            if (divisionMasterEntity != null)
            {
                var division = _unitOfWork.MstDivisionMasterRepository.GetByID(divisionMasterEntity.Id);
                if (division != null)
                {


                    division.DivisionName = divisionMasterEntity.DivisionName;
                    division.Status = divisionMasterEntity.Status;
                    division.ModifyBy = divisionMasterEntity.ModifyBy;
                    division.ModifyDate = DateTime.Now;


                    _unitOfWork.MstDivisionMasterRepository.Update(division);
                    _unitOfWork.Save();
                }

            }
            return success;
        }

        public List<DivisionMasterEntity> Mapping(List<DivisionMaster> deal)
        {
            List<DivisionMasterEntity> lstMstDivision = new List<DivisionMasterEntity>();
            foreach (var item in deal)
            {
                DivisionMasterEntity objDivision = new DivisionMasterEntity();
                objDivision.Id = item.Id;
                objDivision.DivisionName = item.DivisionName;
                objDivision.Status = item.Status;
                objDivision.EntryBy = item.EntryBy;
                objDivision.EntryDate = item.EntryDate;
                objDivision.ModifyBy = item.ModifyBy;
                objDivision.ModifyDate = item.ModifyDate;


                lstMstDivision.Add(objDivision);
            }
            return lstMstDivision;
        }
    }
}
