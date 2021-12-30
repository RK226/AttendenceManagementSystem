using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class StudentAttendenceEntity
    {
        public int CollegeID { get; set; }
        public int StudentID { get; set; }
        public int SubjectId { get; set; }
        public int StandardID { get; set; }
        public int DivisionID { get; set; }
        public int EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public bool Flag { get; set; }
        public int Status { get; set; }
        public string Remark { get; set; }

        public virtual StandardMasterEntity StandardMaster { get; set; }
        public virtual CollegeMasterEntity CollegeMaster { get; set; }
        public virtual DivisionMasterEntity DivisionMaster { get; set; }
        public virtual StudentEntity Student { get; set; }
        public virtual SubjectMasterEntity Subject { get; set; }
    }
}
