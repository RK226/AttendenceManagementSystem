using BusinessEntities;
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
    public class SubjectServices : ISubjectServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();

        public SubjectServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SubjectMasterEntity CreateSubjects(SubjectMasterEntity subjectMasterEntity)
        {
            var subject = new SubjectMaster
            {

                    SubjectName = subjectMasterEntity.SubjectName,
                    SubjectNo = subjectMasterEntity.SubjectNo,
                    BranchId = subjectMasterEntity.BranchId,
                    DepartmentId = subjectMasterEntity.DepartmentId,
                    SectionId = subjectMasterEntity.SectionId,
                    StandardId = subjectMasterEntity.StandardId,
                    EntryBy = subjectMasterEntity.EntryBy,
                    EntryDate = DateTime.Now
                   
            };
            _unitOfWork.MstSubjectMasterRepository.Insert(subject);
            _unitOfWork.Save();

            return subjectMasterEntity;
        }

        public IEnumerable<SubjectMasterEntity> GetAllSubjects()
        {
            var subject = _context.SubjectMasters.ToList();
            List<SubjectMasterEntity> lstSubjects = Mapping(subject);
            return lstSubjects;
        }

        public bool UpdateSubjects(SubjectMasterEntity subjectMasterEntity)
        {
            var success = false;
            if (subjectMasterEntity != null)
            {
                var subject = _unitOfWork.MstSubjectMasterRepository.GetByID(subjectMasterEntity.Id);
                if (subject != null)
                {


                    subject.SubjectName = subjectMasterEntity.SubjectName;
                    subject.SubjectNo = subjectMasterEntity.SubjectNo;
                    subject.BranchId = subjectMasterEntity.BranchId;
                    subject.DepartmentId = subjectMasterEntity.DepartmentId;
                    subject.SectionId = subjectMasterEntity.SectionId;
                    subject.StandardId = subjectMasterEntity.StandardId;
                    subject.ModifyBy = subjectMasterEntity.ModifyBy;
                    subject.ModifyDate = DateTime.Now;


                    _unitOfWork.MstSubjectMasterRepository.Update(subject);
                    _unitOfWork.Save();
                }

            }
            return success;
        }

        public List<SubjectMasterEntity> Mapping(List<SubjectMaster> deal)
        {
            List<SubjectMasterEntity> lstMstSubject = new List<SubjectMasterEntity>();
            foreach (var item in deal)
            {
                SubjectMasterEntity objSubject = new SubjectMasterEntity();
                objSubject.Id = item.Id;
                objSubject.SubjectName = item.SubjectName;
                objSubject.SubjectNo = item.SubjectNo;
                objSubject.BranchId = item.BranchId;
                objSubject.DepartmentId = item.DepartmentId;
                objSubject.SectionId = item.SectionId;
                objSubject.StandardId = item.StandardId;
                objSubject.EntryBy = item.EntryBy;
                objSubject.EntryDate = item.EntryDate;
                objSubject.ModifyBy = item.ModifyBy;
                objSubject.ModifyDate = item.ModifyDate;

                DeparmentMaster deparmentMaster = item.DeparmentMaster;
                if (deparmentMaster != null)
                {
                    DeparmentMasterEntity objDepartment = new DeparmentMasterEntity();
                    objDepartment.Id = deparmentMaster.Id;
                    objDepartment.DepartmentName = deparmentMaster.DepartmentName;

                    objSubject.DeparmentMaster = objDepartment;
                }

                StandardMaster standardMaster = item.StandardMaster;
                if (standardMaster != null)
                {
                    StandardMasterEntity standardMasterEntity = new StandardMasterEntity();
                    standardMasterEntity.Id = standardMaster.Id;
                    standardMasterEntity.StandardName = standardMaster.StandardName;
                     
                    objSubject.StandardMaster = standardMasterEntity;
                }

                BranchMaster branchMaster = item.BranchMaster;//_context.BranchMasters.Where(x => x.Id == objDepartment.BranchId).FirstOrDefault();
                if (branchMaster != null)
                {
                    BranchMasterEntity branchMasterEntity = new BranchMasterEntity();
                    branchMasterEntity.Id = branchMaster.Id;
                    branchMasterEntity.BranchName = branchMaster.BranchName;

                    objSubject.BranchMaster = branchMasterEntity;
                }

                SectionMaster sectionMaster = item.SectionMaster;
                if (sectionMaster != null)
                {
                    SectionEntity sectionEntity = new SectionEntity();
                    sectionEntity.Id = sectionMaster.Id;
                    sectionEntity.SectionName = sectionMaster.SectionName;

                    objSubject.Section = sectionEntity;
                }


                lstMstSubject.Add(objSubject);
            }
            return lstMstSubject;
        }
    }
}
