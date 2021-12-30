using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class TeachersAttendenceEntity
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int SectionId { get; set; }
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }
        public int EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public int ModifyBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual UserCredentialEntity UserCredential { get; set; }
        public virtual UserDetailsMasterEntity UserDetailsMaster { get; set; }
        public virtual SectionEntity Section { get; set; }
        public virtual BranchMasterEntity BranchMaster { get; set; }
        public virtual DeparmentMasterEntity DeparmentMaster { get; set; }
    }
}
