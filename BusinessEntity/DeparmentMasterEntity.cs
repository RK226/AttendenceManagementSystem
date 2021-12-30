using BusinessEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessEntities
{
    public class DeparmentMasterEntity
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public int? CollegeId { get; set; }
        public int? SectionId { get; set; }
        public int? BranchId { get; set; }
        public int? EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }

        //[NotMapped]
        //public string CollegeName { get; set; }
        //public string SectionName { get; set; }
        //public string BranchName { get; set; }

        public virtual CollegeMasterEntity CollegeMaster { get; set; }
        public virtual BranchMasterEntity BranchMaster { get; set; }
        public virtual SectionEntity SectionMaster { get; set; }
    }
}
