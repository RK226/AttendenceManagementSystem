using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class UserDetailsMasterEntity
    {
        public int Id { get; set; }
        public int CollegeID { get; set; }
        public int SectionID { get; set; }
        public int DepartmentID { get; set; }
        public int BranchID { get; set; }
        public long  UniqueId { get; set; }
        public int RoleID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
        public int DistrictId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public bool Status { get; set; }
        public int EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public int ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public int Gender { get; set; }
        public int EduQualification { get; set; }

        public virtual AcedemicYearMasterEntity AcedemicYearMaster { get; set; }
        public virtual CollegeMasterEntity CollegeMaster { get; set; }
        public virtual DeparmentMasterEntity DeparmentMaster { get; set; }
        public virtual BranchMasterEntity BranchMaster { get; set; }
        public virtual SectionEntity Section { get; set; }
        public virtual CountryMasterEntity CountryMaster { get; set; }
        public virtual DistrictMasterEntity DistrictMaster { get; set; }
        public virtual StateMasterEntity StateMasterEntity { get; set; }
        public virtual YearMasterEntity YearMaster { get; set; }
    }
}
