using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class DivisionMasterEntity
    {
        public int Id { get; set; }
        public string DivisionName { get; set; }
        public bool? Status { get; set; }
        public long? EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }
        public long? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
