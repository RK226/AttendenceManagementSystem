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
    public class DepartmentServices : IDepartmentServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();

        public DepartmentServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DeparmentMasterEntity CreateDepartment(DeparmentMasterEntity deparmentMasterEntity)
        {
            var dept = new DeparmentMaster
            {



                    DepartmentName = deparmentMasterEntity.DepartmentName,
                    CollegeId = deparmentMasterEntity.CollegeId,
                    SectionId = deparmentMasterEntity.SectionId,
                    BranchId = deparmentMasterEntity.BranchId,
                    EntryBy = deparmentMasterEntity.EntryBy,
                    EntryDate = DateTime.Now
            };
            _unitOfWork.MstDeparmentMasterRepository.Insert(dept);
            _unitOfWork.Save();

            return deparmentMasterEntity;
        }

        public IEnumerable<DeparmentMasterEntity> GetAllDepartment()
        {
            var department = _context.DeparmentMasters.ToList();
            //var department = from d in _context.DeparmentMasters
            //                 join s in _context.SectionMasters
            //                 on d.SectionId equals s.Id
            //                 into section
            //                 from s in section.DefaultIfEmpty()
            //                 join b in _context.BranchMasters
            //                 on d.BranchId equals b.Id
            //                 into branch
            //                 from b in branch.DefaultIfEmpty()
            //                 join c in _context.CollegeMasters
            //                 on d.CollegeId equals c.Id
            //                 into college
            //                 from c in college.DefaultIfEmpty()
            //                 select new DeparmentMaster
            //                 {
            //                     Id = d.Id,
            //                     DepartmentName = d.DepartmentName,
            //                     CollegeId = d.CollegeId,
            //                     SectionId = d.SectionId,
            //                     BranchId = d.BranchId,

            //                     //CollegeName = c== null?"":c.CollegeName 

            //                 };


            List <DeparmentMasterEntity> lstDpt = Mapping(department);
            return lstDpt;
        }

        public bool UpdateDepartment(DeparmentMasterEntity deparmentMasterEntity)
        {
            var success = false;
            if (deparmentMasterEntity != null)
            {
                var dept = _unitOfWork.MstDeparmentMasterRepository.GetByID(deparmentMasterEntity.Id);
                if (dept != null)
                {


                    dept.DepartmentName = deparmentMasterEntity.DepartmentName;
                    dept.CollegeId = deparmentMasterEntity.CollegeId;
                    dept.SectionId = deparmentMasterEntity.SectionId;
                    dept.BranchId = deparmentMasterEntity.BranchId;
                    dept.ModifyBy = deparmentMasterEntity.ModifyBy;
                    dept.ModifyDate = DateTime.Now;

                   

                    _unitOfWork.MstDeparmentMasterRepository.Update(dept);
                    _unitOfWork.Save();
                }

            }
            return success;
        }

        public List<DeparmentMasterEntity> Mapping(List<DeparmentMaster> deal)
        {
            List<DeparmentMasterEntity> lstMstDept = new List<DeparmentMasterEntity>();
            foreach (var item in deal)
            {
                DeparmentMasterEntity objDepartment = new DeparmentMasterEntity();
                objDepartment.Id = item.Id;
                objDepartment.DepartmentName = item.DepartmentName;
                objDepartment.CollegeId = item.CollegeId;
                objDepartment.SectionId = item.SectionId;
                objDepartment.BranchId = item.BranchId;
                objDepartment.EntryBy = item.EntryBy;
                objDepartment.EntryDate = item.EntryDate;
                objDepartment.ModifyBy = item.ModifyBy;
                objDepartment.ModifyDate = item.ModifyDate;

                CollegeMaster collegeMaster = _context.CollegeMasters.Where(x => x.Id == objDepartment.CollegeId).FirstOrDefault();//item.CollegeMaster;
                if (collegeMaster != null)
                {
                    CollegeMasterEntity collegeMasterEntity = new CollegeMasterEntity();
                    collegeMasterEntity.Id = collegeMaster.Id;
                    collegeMasterEntity.CollegeName = collegeMaster.CollegeName;
                    collegeMasterEntity.Address = collegeMaster.Address;
                    collegeMasterEntity.Taluka = collegeMaster.Taluka;
                    collegeMasterEntity.DistrictId = collegeMaster.DistrictId;
                    collegeMasterEntity.StateId = collegeMaster.StateId;
                    collegeMasterEntity.PinCode = collegeMaster.PinCode;

                    objDepartment.CollegeMaster = collegeMasterEntity;
                }

                BranchMaster branchMaster = _context.BranchMasters.Where(x => x.Id == objDepartment.BranchId).FirstOrDefault();
                if (branchMaster != null)
                {
                    BranchMasterEntity branchMasterEntity = new BranchMasterEntity();
                    branchMasterEntity.Id = branchMaster.Id;
                    branchMasterEntity.BranchName = branchMaster.BranchName;

                    objDepartment.BranchMaster = branchMasterEntity;
                }

                //SectionMaster sectionMaster = _context.SectionMasters.Where(x => x.Id == objDepartment.SectionId).FirstOrDefault();
                //if (sectionMaster != null)
                //{
                //    SectionEntity sectionEntity = new SectionEntity();
                //    sectionEntity.Id = sectionMaster.Id;
                //    sectionEntity.SectionName = sectionMaster.SectionName;

                //    objDepartment.SectionMaster = sectionEntity;
                //}

                lstMstDept.Add(objDepartment);
            }
            return lstMstDept;
        }
    }
}
