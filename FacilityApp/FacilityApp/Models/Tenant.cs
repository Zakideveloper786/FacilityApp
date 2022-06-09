
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static FacilityApp.Core.Statics;

namespace FacilityApp.Models
{
    public class Tenant
    {
        [Key]
        public int TenantId { get; set; }
        [DisplayName("Tenant Name")]
        public string Name { get; set; }
        [DisplayName("Mobile No")]
        public string MobileNo { get; set; }
        public string Password { get; set; }
        [DisplayName("Email ID")]
        public string EmailId { get; set; }
        [DisplayName("Address")]
        public string? Address { get; set; }
        [DisplayName("BuildingName")]
        public int? BuildingId { get; set; }

        [DisplayName("Flat Type")]
        public int? FlatTypeId { get; set; }


        [DisplayName("Flat No")]
        public string FlatNo { get; set; }

        [DisplayName("Start  Tenancy Date")]
        public DateTime?  StartDate { get; set; }

        [DisplayName("End Tenancy Date")]
        public DateTime? EndDate { get; set; }

        public RecordState Status { get; set; }

        public string CreatedBy { get; set; } = "System";

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; } 

        public DateTime? UpdatedDate { get; set; } 

    }
}
