using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class CollegeMasterEntity
    {
        public int Id { get; set; }
        public string CollegeName { get; set; }
        public string Address { get; set; }
        public string Taluka { get; set; }
        public long DistrictId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public long PinCode { get; set; }
        public string ContactNo { get; set; }
        public string University { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public int? EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }
        public long? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CollegeStartTime { get; set; }
        public string CollegeEndTime { get; set; }

        public virtual DistrictMasterEntity DistrictMaster { get; set; }
        public virtual StateMasterEntity StateMaster { get; set; }

    }
}
