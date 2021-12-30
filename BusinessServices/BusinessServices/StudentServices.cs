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
    public class StudentServices : IStudentServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();

        public StudentServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public StudentEntity CreateStudent(StudentEntity studentEntity)
        {
            var student = new Student
            {

                    URNNo = studentEntity.URNNo,
                    RollNo = studentEntity.RollNo,
                    CollegeId = studentEntity.CollegeId,
                    SectionId = studentEntity.SectionId,
                    BranchId = studentEntity.BranchId,
                    DepartmentId = studentEntity.DepartmentId,
                    AcademicYearId = studentEntity.AcademicYearId,
                    Gender = studentEntity.Gender,
                    AadharNo = studentEntity.AadharNo,
                    FirstName = studentEntity.FirstName,
                    MiddleName = studentEntity.MiddleName,
                    LastName = studentEntity.LastName,
                    GrandFatherName = studentEntity.GrandFatherName,
                    MotherName = studentEntity.MotherName,
                    ContactNo = studentEntity.ContactNo,
                    EmailId = studentEntity.EmailId,
                    Religion = studentEntity.Religion,
                    Caste = studentEntity.Caste,
                    Nationality = studentEntity.Nationality,
                    DOB = studentEntity.DOB,
                    Village = studentEntity.Village,
                    Taluka = studentEntity.Taluka,
                    DistrictId = studentEntity.DistrictId,
                    StateId = studentEntity.StateId,
                    CountryId = studentEntity.CountryId,
                    Pincode = studentEntity.Pincode,
                    StandardId = studentEntity.StandardId,
                    DivisionId = studentEntity.DivisionId,
                    YearId = studentEntity.YearId,
                    Photo = studentEntity.Photo,
                    Flag = studentEntity.Flag,
                    ModifyBy = studentEntity.ModifyBy,
                    ModifyDate = studentEntity.ModifyDate,
                    EntryBy = studentEntity.EntryBy,
                    EntryDate = DateTime.Now
           };
            _unitOfWork.MstStudentRepository.Insert(student);
            _unitOfWork.Save();

            return studentEntity;
        }

        public IEnumerable<StudentEntity> GetAllStudent()
        {
            var students = _context.Students.ToList();
            List<StudentEntity> lstStudent = Mapping(students);
            return lstStudent;
        }

        public bool UpdateStudent(StudentEntity studentEntity)
        {
            var success = false;
            if (studentEntity != null)
            {
                var student = _unitOfWork.MstStudentRepository.GetByID(studentEntity.Id);
                if (student != null)
                {


                    student.Id = studentEntity.Id;
                    student.URNNo = studentEntity.URNNo;
                    student.RollNo = studentEntity.RollNo;
                    student.CollegeId = studentEntity.CollegeId;
                    student.SectionId = studentEntity.SectionId;
                    student.BranchId = studentEntity.BranchId;
                    student.DepartmentId = studentEntity.DepartmentId;
                    student.AcademicYearId = studentEntity.AcademicYearId;
                    student.Gender = studentEntity.Gender;
                    student.AadharNo = studentEntity.AadharNo;
                    student.FirstName = studentEntity.FirstName;
                    student.MiddleName = studentEntity.MiddleName;
                    student.LastName = studentEntity.LastName;
                    student.GrandFatherName = studentEntity.GrandFatherName;
                    student.MotherName = studentEntity.MotherName;
                    student.ContactNo = studentEntity.ContactNo;
                    student.EmailId = studentEntity.EmailId;
                    student.Religion = studentEntity.Religion;
                    student.Caste = studentEntity.Caste;
                    student.Nationality = studentEntity.Nationality;
                    student.DOB = studentEntity.DOB;
                    student.Village = studentEntity.Village;
                    student.Taluka = studentEntity.Taluka;
                    student.DistrictId = studentEntity.DistrictId;
                    student.StateId = studentEntity.StateId;
                    student.CountryId = studentEntity.CountryId;
                    student.Pincode = studentEntity.Pincode;
                    student.StandardId = studentEntity.StandardId;
                    student.DivisionId = studentEntity.DivisionId;
                    student.YearId = studentEntity.YearId;
                    student.Photo = studentEntity.Photo;
                    student.Flag = studentEntity.Flag;
                    student.ModifyBy = studentEntity.ModifyBy;
                    student.ModifyDate = DateTime.Now;
                    


                    _unitOfWork.MstStudentRepository.Update(student);
                    _unitOfWork.Save();
                }

            }
            return success;
        }

        public List<StudentEntity> Mapping(List<Student> deal)
        {
            List<StudentEntity> lstStudent = new List<StudentEntity>();
            foreach (var item in deal)
            {
                StudentEntity objStudent = new StudentEntity();
                objStudent.Id = item.Id;
                objStudent.URNNo = item.URNNo;
                objStudent.RollNo = item.RollNo;
                objStudent.CollegeId = item.CollegeId;
                objStudent.SectionId = item.SectionId;
                objStudent.BranchId = item.BranchId;
                objStudent.DepartmentId = item.DepartmentId;
                objStudent.AcademicYearId = item.AcademicYearId;
                objStudent.Gender = item.Gender;
                objStudent.AadharNo = item.AadharNo;
                objStudent.StudentName = item.FirstName + " " + item.LastName;
                objStudent.FirstName = item.FirstName;
                objStudent.MiddleName = item.MiddleName;
                objStudent.LastName = item.LastName;
                objStudent.GrandFatherName = item.GrandFatherName;
                objStudent.MotherName = item.MotherName;
                objStudent.ContactNo = item.ContactNo;
                objStudent.EmailId = item.EmailId;
                objStudent.Religion = item.Religion;
                objStudent.Caste = item.Caste;
                objStudent.Nationality = item.Nationality;
                objStudent.DOB = item.DOB;
                objStudent.Village = item.Village;
                objStudent.Taluka = item.Taluka;
                objStudent.DistrictId = item.DistrictId;
                objStudent.StateId = item.StateId;
                objStudent.CountryId = item.CountryId;
                objStudent.Pincode = item.Pincode;
                objStudent.StandardId = item.StandardId;
                objStudent.DivisionId = item.DivisionId;
                objStudent.YearId = item.YearId;
                objStudent.Photo = item.Photo;
                objStudent.Flag = item.Flag;
                objStudent.ModifyBy = item.ModifyBy;
                objStudent.ModifyDate = item.ModifyDate;
                objStudent.EntryBy = item.EntryBy;
                objStudent.EntryDate = item.EntryDate;


                lstStudent.Add(objStudent);
            }
            return lstStudent;
        }
    }
}
