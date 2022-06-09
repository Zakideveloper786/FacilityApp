
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
        [DisplayName("Contact Person Name  ")]
        public string ContactName { get; set; }
        [DisplayName("Email ID")]
        public string? EmailId { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        public RecordState Status { get; set; }

        public string CreatedBy { get; set; } = "System";

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; } 

        public DateTime? UpdatedDate { get; set; } 

    }
}
