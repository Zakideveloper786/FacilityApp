
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
        [DisplayName("BuildingName")]
        public int? BuildingId { get; set; }
        [DisplayName("Lead Name")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Mobile No")]
        public string? MobileNo { get; set; }
        [DisplayName("Email ID")]
        public string? EmailId { get; set; }
        [DisplayName("Coming From")]
        public string?  ComingFrom { get; set; }

        [Required]
        [DisplayName("Pupose")]
        public int? VisitingPurposeId { get; set; }

        [DisplayName("Flat No to Visit")]
        public string? FlatNo{ get; set; }

        [DisplayName("Person to Contact")]
        public string? ContactPerson { get; set; }

        [DisplayName("Visitor Check-In Time")]

        public DateTime CheckinTime { get; set; }
        [DisplayName("Visitors Check-In Time")]

        public DateTime CheckoutTime { get; set; } 


        public RecordState Status { get; set; }

        public int CreatedBy { get; set; } =1;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; } 

        public DateTime? UpdatedDate { get; set; } 

    }
}
