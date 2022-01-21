using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntities
{
    public class BranchMasterEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Branch Name")]
        public string BranchName { get; set; }
        [Required(ErrorMessage = "Please Select College")]
        public int CollegeId { get; set; }
        public int?  CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual CollegeMasterEntity CollegeMaster { get; set; }
    }
}
