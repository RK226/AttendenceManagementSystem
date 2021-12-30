using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class PeriodMasterEntity
    {
        public int Id { get; set; }
        public int CollegeId { get; set; }
        public int DepartmentId { get; set; }
        public int SectionId { get; set; }
        public long Period { get; set; }
        public bool Session { get; set; }
        public string Sessions { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public int EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public int ModifyBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual CollegeMasterEntity CollegeMaster { get; set; }
        public virtual DeparmentMasterEntity DeparmentMaster { get; set; }
        public virtual SectionEntity Section { get; set; }


    }
}
