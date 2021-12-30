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
    public class CollegeMasterServices : ICollegeMasterServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();

        public CollegeMasterServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CollegeMasterEntity CreateCollege(CollegeMasterEntity collegeMasterEntity)
        {
            var college = new CollegeMaster
            {


                    
                    CollegeName = collegeMasterEntity.CollegeName,
                    Address = collegeMasterEntity.Address,
                    Taluka = collegeMasterEntity.Taluka,
                    DistrictId = collegeMasterEntity.DistrictId,
                    StateId = collegeMasterEntity.StateId,
                    PinCode = collegeMasterEntity.PinCode,
                    ContactNo = collegeMasterEntity.ContactNo,
                    University = collegeMasterEntity.University,
                    Email = collegeMasterEntity.Email,
                    Status = collegeMasterEntity.Status,
                    CollegeStartTime = collegeMasterEntity.CollegeStartTime,
                    CollegeEndTime = collegeMasterEntity.CollegeEndTime,
                    EntryBy = collegeMasterEntity.EntryBy,
                    EntryDate = DateTime.Now
             };
            _unitOfWork.MstCollegeMasterRepository.Insert(college);
            _unitOfWork.Save();

            return collegeMasterEntity;
        }

        public IEnumerable<CollegeMasterEntity> GetAllCollege()
        {
            var college = _context.CollegeMasters.ToList();
            List<CollegeMasterEntity> lstCollege = Mapping(college);
            return lstCollege;
        }

        public bool UpdateCollege(CollegeMasterEntity collegeMasterEntity)
        {
            var success = false;
            if (collegeMasterEntity != null)
            {
                var college = _unitOfWork.MstCollegeMasterRepository.GetByID(collegeMasterEntity.Id);
                if (college != null)
                {


                    college.CollegeName = collegeMasterEntity.CollegeName;
                    college.Address = collegeMasterEntity.Address;
                    college.Taluka = collegeMasterEntity.Taluka;
                    college.DistrictId = collegeMasterEntity.DistrictId;
                    college.StateId = collegeMasterEntity.StateId;
                    college.PinCode = collegeMasterEntity.PinCode;
                    college.ContactNo = collegeMasterEntity.ContactNo;
                    college.University = collegeMasterEntity.University;
                    college.Email = collegeMasterEntity.Email;
                    college.Status = collegeMasterEntity.Status;
                    college.CollegeStartTime = collegeMasterEntity.CollegeStartTime;
                    college.CollegeEndTime = collegeMasterEntity.CollegeEndTime;
                    college.ModifyBy = collegeMasterEntity.ModifyBy;
                    college.ModifyDate = DateTime.Now;


                    _unitOfWork.MstCollegeMasterRepository.Update(college);
                    _unitOfWork.Save();
                }

            }
            return success;
        }

        public List<CollegeMasterEntity> Mapping(List<CollegeMaster> deal)
        {
            List<CollegeMasterEntity> lstMstCollege = new List<CollegeMasterEntity>();
            foreach (var item in deal)
            {
                CollegeMasterEntity objCollege = new CollegeMasterEntity();
                objCollege.Id = item.Id;
                objCollege.CollegeName = item.CollegeName;
                objCollege.Address = item.Address;
                objCollege.Taluka = item.Taluka;
                objCollege.DistrictId = item.DistrictId;
                objCollege.StateId = item.StateId;
                objCollege.PinCode = item.PinCode;
                objCollege.ContactNo = item.ContactNo;
                objCollege.University = item.University;
                objCollege.Email = item.Email;
                objCollege.Status = item.Status;
                objCollege.CollegeStartTime = item.CollegeStartTime;
                objCollege.CollegeEndTime = item.CollegeEndTime;
                objCollege.EntryBy = item.EntryBy;
                objCollege.EntryDate = item.EntryDate;
                objCollege.ModifyBy = item.ModifyBy;
                objCollege.ModifyDate = item.ModifyDate;

                DistrictMaster districtMaster = _context.DistrictMasters.Where(x => x.Id == objCollege.DistrictId).FirstOrDefault();
                if (districtMaster != null){
                    DistrictMasterEntity objDistrict = new DistrictMasterEntity();
                    objDistrict.Id = districtMaster.Id;
                    objDistrict.DistrictName = districtMaster.DistrictName;

                    objCollege.DistrictMaster = objDistrict;
                }
               

                StateMaster stateMaster = _context.StateMasters.Where(x => x.Id == objCollege.StateId).FirstOrDefault();
                if (stateMaster != null)
                {
                    StateMasterEntity stateMasterEntity = new StateMasterEntity();
                    stateMasterEntity.Id = stateMaster.Id;
                    stateMasterEntity.StateName = stateMaster.StateName;

                    objCollege.StateMaster = stateMasterEntity;
                }

                lstMstCollege.Add(objCollege);
            }
            return lstMstCollege;
        }

    }
}
