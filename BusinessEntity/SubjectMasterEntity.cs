using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class SubjectMasterEntity
    {
        public int Id { get; set; }
        public string SubjectNo { get; set; }
        public int BranchId { get; set; }
        public int DepartmentId { get; set; }
        public int SectionId { get; set; }
        public string SubjectName { get; set; }
        public int? EntryBy { get; set; }
        public int? StandardId { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }

        public virtual StandardMasterEntity StandardMaster { get; set; }
        public virtual SectionEntity  Section { get; set; }
        public virtual BranchMasterEntity BranchMaster { get; set; }
        public virtual DeparmentMasterEntity DeparmentMaster { get; set; }
    }
}
