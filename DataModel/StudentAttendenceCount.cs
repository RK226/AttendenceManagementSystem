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
    
    public partial class StudentAttendenceCount
    {
        public int Id { get; set; }
        public int AcademicYearId { get; set; }
        public int DeparmentId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int CollegelId { get; set; }
        public Nullable<int> June { get; set; }
        public int July { get; set; }
        public Nullable<int> August { get; set; }
        public Nullable<int> September { get; set; }
        public Nullable<int> October { get; set; }
        public Nullable<int> November { get; set; }
        public Nullable<int> December { get; set; }
        public Nullable<int> January { get; set; }
        public Nullable<int> February { get; set; }
        public Nullable<int> March { get; set; }
        public Nullable<int> April { get; set; }
        public Nullable<int> May { get; set; }
        public Nullable<int> EntryBy { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<int> Modifyby { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
    
        public virtual AcedemicYearMaster AcedemicYearMaster { get; set; }
        public virtual CollegeMaster CollegeMaster { get; set; }
        public virtual DeparmentMaster DeparmentMaster { get; set; }
        public virtual Student Student { get; set; }
        public virtual SubjectMaster SubjectMaster { get; set; }
    }
}
