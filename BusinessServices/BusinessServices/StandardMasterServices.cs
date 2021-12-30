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
    public class StandardMasterServices : IStandardMasterServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();

        public StandardMasterServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public StandardMasterEntity CreateStd(StandardMasterEntity standardMasterEntity)
        {
            var standard = new StandardMaster
            {

                    SectionId = standardMasterEntity.SectionId,
                    BranchId = standardMasterEntity.BranchId,
                    StandardName = standardMasterEntity.StandardName,
                    EntryBy = standardMasterEntity.EntryBy,
                    EntryDate = DateTime.Now
        };
            _unitOfWork.MstStandardMasterRepository.Insert(standard);
            _unitOfWork.Save();

            return standardMasterEntity;
        }

        public IEnumerable<StandardMasterEntity> GetAllStd()
        {
            var standard = _context.StandardMasters.ToList();
            List<StandardMasterEntity> lstStandard = Mapping(standard);
            return lstStandard;
        }

        public bool UpdateStd(StandardMasterEntity standardMasterEntity)
        {
            var success = false;
            if (standardMasterEntity != null)
            {
                var standard = _unitOfWork.MstStandardMasterRepository.GetByID(standardMasterEntity.Id);
                if (standard != null)
                {


                    standard.SectionId = standardMasterEntity.SectionId;
                    standard.BranchId = standardMasterEntity.BranchId;
                    standard.StandardName = standardMasterEntity.StandardName;
                    standard.ModifyBy = standardMasterEntity.ModifyBy;
                    standard.ModifyDate = DateTime.Now;


                    _unitOfWork.MstStandardMasterRepository.Update(standard);
                    _unitOfWork.Save();
                }

            }
            return success;
        }

        public List<StandardMasterEntity> Mapping(List<StandardMaster> deal)
        {
            List<StandardMasterEntity> lstMstStandard = new List<StandardMasterEntity>();
            foreach (var item in deal)
            {
                StandardMasterEntity objStandard = new StandardMasterEntity();
                objStandard.Id = item.Id;
                objStandard.SectionId = item.SectionId;
                objStandard.BranchId = item.BranchId;
                objStandard.StandardName = item.StandardName;
                objStandard.EntryBy = item.EntryBy;
                objStandard.EntryDate = item.EntryDate;
                objStandard.ModifyBy = item.ModifyBy;
                objStandard.ModifyDate = item.ModifyDate;

                SectionMaster sectionMaster = _context.SectionMasters.Where(x => x.Id == objStandard.SectionId).FirstOrDefault();
                if (sectionMaster != null)
                {
                    SectionEntity sectionEntity = new SectionEntity();
                    sectionEntity.Id = sectionMaster.Id;
                    sectionEntity.SectionName = sectionMaster.SectionName;

                    objStandard.Section = sectionEntity;
                }

                lstMstStandard.Add(objStandard);
            }
            return lstMstStandard;
        }

        
    }
}
