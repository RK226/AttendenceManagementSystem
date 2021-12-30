using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntities
{
    public class BranchMasterEntity
    {
        public int Id { get; set; }

        [Required]
        public string BranchName { get; set; }
        [Required]
        public int CollegeId { get; set; }
        public int?  CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual CollegeMasterEntity CollegeMaster { get; set; }
    }
}
