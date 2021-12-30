using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntity
{
    public class CountryMasterEntity
    {
        public int Id { get; set; }

        //[Required]
        public string CountryName { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifiedDate { get; set; }


    }
    //[MetadataType(typeof(CountryMasterEntity))]
    // public partial class CountryMaster
    //{

    //}
}
