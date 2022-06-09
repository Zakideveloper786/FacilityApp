
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static FacilityApp.Core.Statics;

namespace FacilityApp.Models
{
    public class Parking
    {
        [Key]
        public int ParkingId { get; set; }
        [DisplayName("Tenant Name")]
        public int TenantId { get; set; }

        [DisplayName("Parking Number")]
        public string ParkingNumber { get; set; }
        [DisplayName("Plate Number ")]
        public string PlateNumber { get; set; }
        [DisplayName("Start Date ")]
        public DateTime? StartDate { get; set; }
        [DisplayName("End Date ")]
        public DateTime? EndDate { get; set; } 

        public string? ImagePath { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public RecordState Status { get; set; }


        public string CreatedBy { get; set; } = "System";

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; } 

        public DateTime? UpdatedDate { get; set; } 

    }
}
