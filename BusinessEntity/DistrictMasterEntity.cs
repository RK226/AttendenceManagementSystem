using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class DistrictMasterEntity
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual CountryMasterEntity CountryMaster { get; set; }
        public virtual StateMasterEntity StateMaster { get; set; }
    }
}
