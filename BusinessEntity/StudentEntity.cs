using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public long? URNNo { get; set; }
        public long? RollNo { get; set; }
        public int? CollegeId { get; set; }
        public int? SectionId { get; set; }
        public int? DepartmentId { get; set; }
        public int? AcademicYearId { get; set; }
        public bool? Gender { get; set; }
        public string AadharNo { get; set; }
        public string StudentName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string GrandFatherName { get; set; }
        public string MotherName { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public string Religion { get; set; }
        public string Caste { get; set; }
        public string Nationality { get; set; }
        public DateTime? DOB { get; set; }
        public string Village { get; set; }
        public string Taluka { get; set; }
        public int? DistrictId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public long? Pincode { get; set; }
        public int? StandardId { get; set; }
        public int? DivisionId { get; set; }
        public int? YearId { get; set; }
        public int? EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string Photo { get; set; }
        public int? Flag { get; set; }
        public int BranchId { get; set; }

        public virtual AcedemicYearMasterEntity AcedemicYearMaster { get; set; }
        public virtual CollegeMasterEntity CollegeMaster { get; set; }
        public virtual DeparmentMasterEntity DeparmentMaster { get; set; }
        public virtual StudentEntity Student { get; set; }
        public virtual DivisionMasterEntity DivisionMaster { get; set; }
        public virtual StandardMasterEntity StandardMaster { get; set; }
        public virtual SubjectMasterEntity Subject { get; set; }
        public virtual CountryMasterEntity CountryMaster { get; set; }
        public virtual DistrictMasterEntity DistrictMaster { get; set; }
        public virtual StateMasterEntity StateMasterEntity { get; set; }
        public virtual YearMasterEntity YearMaster { get; set; }
    }

    //public class Enumerations
    //{
    //    Male=1,
    //    Female=2
    //}
}
