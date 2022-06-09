
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static FacilityApp.Core.Statics;

namespace FacilityApp.Models
{
    public class Lead
    {
        [Key]
        public int LeadId { get; set; }
        [DisplayName("Lead Name")]
        public string Name { get; set; }
        [DisplayName("Mobile No")]
        public string MobileNo { get; set; }
        [DisplayName("Email ID")]
        public string EmailId { get; set; }
        [DisplayName("Lead Source")]
        public string? LeadSource { get; set; }


        [DisplayName("Lead Status")]
        public string? LeadStatus { get; set; }
        [DisplayName("BuildingName")]
        public string BuildingId { get; set; }



        public RecordState Status { get; set; }

        public string CreatedBy { get; set; } = "System";

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; } 

        public DateTime? UpdatedDate { get; set; } 

    }
}
