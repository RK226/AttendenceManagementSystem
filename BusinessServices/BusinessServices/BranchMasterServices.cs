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
    public class BranchMasterServices : IBranchMasterServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();

        public BranchMasterServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public BranchMasterEntity CreateBranch(BranchMasterEntity branchMasterEntity)
        {
            var branch = new BranchMaster
            {

                BranchName = branchMasterEntity.BranchName,
                CollegeId = branchMasterEntity.CollegeId,
                CreatedBy = branchMasterEntity.CreatedBy,
                CreatedDate = DateTime.Now
            };
            _unitOfWork.MstBranchMasterRepository.Insert(branch);
            _unitOfWork.Save();

            return branchMasterEntity;
        }

        public IEnumerable<BranchMasterEntity> GetAllBranch()
        {
            var branch = _context.BranchMasters.ToList();
            List<BranchMasterEntity> lstBranch = Mapping(branch);
            return lstBranch;
        }

        public bool UpdateBranch(BranchMasterEntity branchMasterEntity)
        {
            var success = false;
            if (branchMasterEntity != null)
            {
                var branch = _unitOfWork.MstBranchMasterRepository.GetByID(branchMasterEntity.Id);
                if (branch != null)
                {


                    branch.BranchName = branchMasterEntity.BranchName;
                    branch.CollegeId = branchMasterEntity.CollegeId;
                    branch.ModifyBy = branchMasterEntity.ModifyBy;
                    branch.ModifiedDate = DateTime.Now;


                    _unitOfWork.MstBranchMasterRepository.Update(branch);
                    _unitOfWork.Save();
                }

            }
            return success;
        }

        public List<BranchMasterEntity> Mapping(List<BranchMaster> deal)
        {
            List<BranchMasterEntity> lstMstBranch = new List<BranchMasterEntity>();
            foreach (var item in deal)
            {
                BranchMasterEntity objBranch = new BranchMasterEntity();
                objBranch.Id = item.Id;
                objBranch.BranchName = item.BranchName;
                objBranch.CollegeId = item.CollegeId;
                objBranch.CreatedBy = item.CreatedBy;
                objBranch.CreatedDate = item.CreatedDate;
                objBranch.ModifyBy = item.ModifyBy;
                objBranch.ModifiedDate = item.ModifiedDate;

                CollegeMaster collegeMaster = item.CollegeMaster;
                if (collegeMaster != null)
                {
                    CollegeMasterEntity objCollege = new CollegeMasterEntity();
                    objCollege.Id = collegeMaster.Id;
                    objCollege.CollegeName = collegeMaster.CollegeName;
                    objCollege.Address = collegeMaster.Address;

                    objBranch.CollegeMaster = objCollege;
                }
                

                lstMstBranch.Add(objBranch);
            }
            return lstMstBranch;
        }
    }
}
