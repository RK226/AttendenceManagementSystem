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
    public class SectionMasterServices : ISectionMasterServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();

        public SectionMasterServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SectionEntity CreateSection(SectionEntity sectionEntity)
        {
            var section = new SectionMaster
            {



                SectionName = sectionEntity.SectionName,
                ModifyBy = sectionEntity.ModifyBy,
                ModifyDate = DateTime.Now
            };
            _unitOfWork.MstSectionMasterRepository.Insert(section);
            _unitOfWork.Save();

            return sectionEntity;
        }

        public IEnumerable<SectionEntity> GetAllSection()
        {
            var section = _context.SectionMasters.ToList();
            List<SectionEntity> lstSection = Mapping(section);
            return lstSection;
        }

        public bool UpdateSection(SectionEntity sectionEntity)
        {
            var success = false;
            if (sectionEntity != null)
            {
                var section = _unitOfWork.MstSectionMasterRepository.GetByID(sectionEntity.Id);
                if (section != null)
                {


                    section.SectionName = sectionEntity.SectionName;
                    section.ModifyBy = sectionEntity.ModifyBy;
                    section.ModifyDate = DateTime.Now;


                    _unitOfWork.MstSectionMasterRepository.Update(section);
                    _unitOfWork.Save();
                }

            }
            return success;
        }

        public List<SectionEntity> Mapping(List<SectionMaster> deal)
        {
            List<SectionEntity> lstMstSection = new List<SectionEntity>();
            foreach (var item in deal)
            {
                SectionEntity objSection = new SectionEntity();
                objSection.Id = item.Id;
                objSection.SectionName = item.SectionName;
                objSection.EntryBy = item.EntryBy;
                objSection.EntryDate = item.EntryDate;
                objSection.ModifyBy = item.ModifyBy;
                objSection.ModifyDate = item.ModifyDate;


                lstMstSection.Add(objSection);
            }
            return lstMstSection;
        }
    }

}
