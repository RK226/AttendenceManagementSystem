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
    
    public partial class SubjectMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubjectMaster()
        {
            this.StudentAttendences = new HashSet<StudentAttendence>();
            this.StudentAttendenceCounts = new HashSet<StudentAttendenceCount>();
        }
    
        public int Id { get; set; }
        public string SubjectNo { get; set; }
        public int BranchId { get; set; }
        public int DepartmentId { get; set; }
        public int SectionId { get; set; }
        public string SubjectName { get; set; }
        public Nullable<int> EntryBy { get; set; }
        public Nullable<int> StandardId { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<int> ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
    
        public virtual BranchMaster BranchMaster { get; set; }
        public virtual DeparmentMaster DeparmentMaster { get; set; }
        public virtual SectionMaster SectionMaster { get; set; }
        public virtual StandardMaster StandardMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentAttendence> StudentAttendences { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentAttendenceCount> StudentAttendenceCounts { get; set; }
    }
}
