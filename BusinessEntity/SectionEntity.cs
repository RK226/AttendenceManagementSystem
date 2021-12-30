using System;

namespace BusinessEntity
{
    public class SectionEntity
    {
        public int Id { get; set; }
        public string SectionName { get; set; }
        public int? EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
