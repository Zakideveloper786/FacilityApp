
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static FacilityApp.Core.Statics;

namespace FacilityApp.Models
{
    public class Building
    {
        [Key]
        public int BuildingId { get; set; }
        [DisplayName("Building Name")]
        public string Name { get; set; }
        [DisplayName("Building Code")]
        public string? BuildingCode { get; set; }
        [DisplayName("Contact Person   ")]
        public string? ContactPerson { get; set; }
        [DisplayName("Email ID")]
        public string? EmailId { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        public RecordState Status { get; set; }

        public int CreatedBy { get; set; } = 1;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; } 

        public DateTime? UpdatedDate { get; set; } 

    }
}
