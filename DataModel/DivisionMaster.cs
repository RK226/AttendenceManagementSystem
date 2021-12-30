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
    
    public partial class DivisionMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DivisionMaster()
        {
            this.Students = new HashSet<Student>();
            this.StudentAttendences = new HashSet<StudentAttendence>();
        }
    
        public int Id { get; set; }
        public string DivisionName { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<long> EntryBy { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<long> ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentAttendence> StudentAttendences { get; set; }
    }
}
