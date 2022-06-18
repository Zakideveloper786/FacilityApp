
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace FacilityApp.Models
{
    public class TenancyDetails
    {
        [Key]
        public int TenancyDetailsId { get; set; }



        [DisplayName("Rent Amount")]

        public decimal? RentAmount { get; set; }
        [DisplayName("Maintanance Cost")]

        public decimal? MaintananceCost { get; set; }
        [DisplayName("ParkingAmount")]


        public decimal? ParkingAmount { get; set; }
        [DisplayName("TotalAmount")]

        public decimal? TotalAmount { get; set; }
        [DisplayName("Cheque / Cash Frequency")]

        public int? FrequencyId { get; set; }
        [DisplayName("Amount to be Paid")]
        public decimal? AmountToPay { get; set; }
        [DisplayName("SEWA Status")]
        public int? SEWAStatusId { get; set; }
        [DisplayName("SEWA No")]
        public string? SEWANo { get; set; }
        [DisplayName("Parking Slot Floor")]
        public string ParkingSlotFloor        { get; set; }
        [DisplayName("Parking Slot No")]
        public string ParkingSlotNo { get; set; }
        [DisplayName("Parking Key Provided")]
        public bool ParkingKeyProvided        { get; set; }
        [DisplayName("Tenant Name")]

        public int? TenantId { get; set; }

        public int?CreatedBy { get; set; } = 1;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int? UpdatedBy { get; set; } = 1;

        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

    }
}
