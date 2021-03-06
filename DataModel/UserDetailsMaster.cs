//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserDetailsMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserDetailsMaster()
        {
            this.TeachersAttendences = new HashSet<TeachersAttendence>();
            this.UserCredentials = new HashSet<UserCredential>();
        }
    
        public int Id { get; set; }
        public Nullable<int> CollegeID { get; set; }
        public Nullable<int> SectionID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<int> BranchID { get; set; }
        public Nullable<long> UniqueId { get; set; }
        public Nullable<int> RoleID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> EntryBy { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<int> ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<bool> Gender { get; set; }
        public string EduQualification { get; set; }
    
        public virtual BranchMaster BranchMaster { get; set; }
        public virtual CollegeMaster CollegeMaster { get; set; }
        public virtual CountryMaster CountryMaster { get; set; }
        public virtual DeparmentMaster DeparmentMaster { get; set; }
        public virtual DistrictMaster DistrictMaster { get; set; }
        public virtual RoleMaster RoleMaster { get; set; }
        public virtual SectionMaster SectionMaster { get; set; }
        public virtual StateMaster StateMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeachersAttendence> TeachersAttendences { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCredential> UserCredentials { get; set; }
    }
}
