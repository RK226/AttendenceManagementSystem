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

    public class UserDetailServices : IUserDetailServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();

        public UserDetailServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private string RandomPass()
        {
            Random pass = new Random();
            long num = Convert.ToInt64(pass.Next(0, 9999).ToString("D6"));
            return "Kskw" + num;
        }
        public UserDetailsMasterEntity CreateUserDetails(UserDetailsMasterEntity userDetailsMasterEntity)
        {
                var userDetails = new UserDetailsMaster
                {

                    CollegeID = userDetailsMasterEntity.CollegeID,
                    BranchID = userDetailsMasterEntity.BranchID,
                    SectionID = userDetailsMasterEntity.SectionID,
                    DepartmentID = userDetailsMasterEntity.DepartmentID,
                    UniqueId = userDetailsMasterEntity.UniqueId,
                    RoleID = userDetailsMasterEntity.RoleID,
                    FirstName = userDetailsMasterEntity.FirstName,
                    MiddleName = userDetailsMasterEntity.MiddleName,
                    LastName = userDetailsMasterEntity.LastName,
                    MobileNo = userDetailsMasterEntity.MobileNo,
                    EmailID = userDetailsMasterEntity.EmailID,
                    Address = userDetailsMasterEntity.Address,
                    DistrictId = userDetailsMasterEntity.DistrictId,
                    CountryId = userDetailsMasterEntity.CountryId,
                    StateId = userDetailsMasterEntity.StateId,
                    Status = userDetailsMasterEntity.Status,
                    Gender = userDetailsMasterEntity.Gender,
                    EduQualification = userDetailsMasterEntity.EduQualification,
                    EntryBy = userDetailsMasterEntity.EntryBy,
                    EntryDate = DateTime.Now

                };

               
                _unitOfWork.MstUserDetailsMasterRepository.Insert(userDetails);
                _unitOfWork.Save();
            var userCredential = new UserCredential
            {
                RoleID = userDetails.RoleID,
                UserID = userDetails.Id,
                UserName = userDetails.MobileNo,
                Password = RandomPass(),
                Flag = true,
                EmailFlag = true
               // EmailSentOn = true
            };
            _unitOfWork.MstUserCredentialMasterRepository.Insert(userCredential);
            _unitOfWork.Save();



            return userDetailsMasterEntity;
        }

        public IEnumerable<UserDetailsMasterEntity> GetAllUserDetails()
        {
            var userDetails = _context.UserDetailsMasters.ToList();
            List<UserDetailsMasterEntity> lstUserDetails = Mapping(userDetails);
            return lstUserDetails;
        }

        public bool UpdateUserDetails(UserDetailsMasterEntity userDetailsMasterEntity)
        {
            throw new NotImplementedException();
        }

        public List<UserDetailsMasterEntity> Mapping(List<UserDetailsMaster> deal)
        {
            List<UserDetailsMasterEntity> lstUserDetails = new List<UserDetailsMasterEntity>();
            foreach (var item in deal)
            {
                UserDetailsMasterEntity objUserDetailsMaster = new UserDetailsMasterEntity();
                objUserDetailsMaster.Id = item.Id;
                objUserDetailsMaster.CollegeID = item.CollegeID;
                objUserDetailsMaster.SectionID = item.SectionID;
                objUserDetailsMaster.DepartmentID = item.DepartmentID;
                objUserDetailsMaster.BranchID = item.BranchID;
                objUserDetailsMaster.UniqueId = item.UniqueId;
                objUserDetailsMaster.RoleID = item.RoleID;
                objUserDetailsMaster.FullName = item.FirstName +" "+ item.LastName;
                objUserDetailsMaster.FirstName = item.FirstName;
                objUserDetailsMaster.MiddleName = item.MiddleName;
                objUserDetailsMaster.LastName = item.LastName;
                objUserDetailsMaster.MobileNo = item.MobileNo;
                objUserDetailsMaster.EmailID = item.EmailID;
                objUserDetailsMaster.Address = item.Address;
                objUserDetailsMaster.DistrictId = item.DistrictId;
                objUserDetailsMaster.StateId = item.StateId;
                objUserDetailsMaster.CountryId = item.CountryId;
                objUserDetailsMaster.Status = item.Status;
                objUserDetailsMaster.Gender = item.Gender;
                objUserDetailsMaster.EduQualification = item.EduQualification;
                objUserDetailsMaster.ModifyDate = item.ModifyDate;

                DistrictMaster districtMaster = item.DistrictMaster;//_context.DistrictMasters.Where(x => x.Id == objUserDetailsMaster.DistrictId).FirstOrDefault();
                if (districtMaster != null)
                {
                    DistrictMasterEntity objDistrict = new DistrictMasterEntity();
                    objDistrict.Id = districtMaster.Id;
                    objDistrict.DistrictName = districtMaster.DistrictName;

                    objUserDetailsMaster.DistrictMaster = objDistrict;
                }

                DeparmentMaster deparmentMaster = item.DeparmentMaster;
                if (deparmentMaster != null)
                {
                    DeparmentMasterEntity deparmentMasterEntity = new DeparmentMasterEntity();
                    deparmentMasterEntity.Id = deparmentMaster.Id;
                    deparmentMasterEntity.DepartmentName = deparmentMaster.DepartmentName;

                    objUserDetailsMaster.DeparmentMaster = deparmentMasterEntity;
                }

                BranchMaster branchMaster = item.BranchMaster;
                if (branchMaster != null)
                {
                    BranchMasterEntity branchMasterEntity = new BranchMasterEntity();
                    branchMasterEntity.Id = branchMaster.Id;
                    branchMasterEntity.BranchName = branchMaster.BranchName;

                    objUserDetailsMaster.BranchMaster = branchMasterEntity;
                }

                StateMaster stateMaster = _context.StateMasters.Where(x => x.Id == objUserDetailsMaster.StateId).FirstOrDefault();
                if (stateMaster != null)
                {
                    StateMasterEntity stateMasterEntity = new StateMasterEntity();
                    stateMasterEntity.Id = stateMaster.Id;
                    stateMasterEntity.StateName = stateMaster.StateName;

                    objUserDetailsMaster.StateMaster = stateMasterEntity;
                }

                lstUserDetails.Add(objUserDetailsMaster);
            }
            return lstUserDetails;
        }
    }
}
