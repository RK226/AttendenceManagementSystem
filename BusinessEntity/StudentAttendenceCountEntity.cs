using System;
using BusinessEntity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessEntity
{
    public class StudentAttendenceCountEntity
    {
        public int Id { get; set; }
        public int AcademicYearId { get; set; }
        public int DeparmentId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int CollegelId { get; set; }
        public int June { get; set; }
        public int July { get; set; }
        public int August { get; set; }
        public int September { get; set; }
        public int October { get; set; }
        public int November { get; set; }
        public int December { get; set; }
        public int January { get; set; }
        public int February { get; set; }
        public int March { get; set; }
        public int April { get; set; }
        public int May { get; set; }
        public int EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public int Modifyby { get; set; }
        public DateTime ModifyDate { get; set; }

        public virtual AcedemicYearMasterEntity AcedemicYearMaster { get; set; }
        public virtual CollegeMasterEntity CollegeMaster { get; set; }
        public virtual DeparmentMasterEntity DeparmentMaster { get; set; }
        public virtual StudentEntity Student { get; set; }
        public virtual SubjectMasterEntity Subject { get; set; }



    }
}
