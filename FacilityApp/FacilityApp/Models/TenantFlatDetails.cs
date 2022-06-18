
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace FacilityApp.Models
{
    public class TenantFlatDetails
    {
        [Key]
        public int TenantFlatDetailsId { get; set; }
        public int TenantId { get; set; }

        [Required]
        [DisplayName("Buliding / Apartment Name")]

        public int BuildingId { get; set; }


        [Required]
        [DisplayName("Location ")]

        public string? Location { get; set; }
        [Required]
        [DisplayName("Occupied Flat No ")]

        public int FlatId { get; set; }
        [DisplayName("Flat Type")]

        public int? FlatTypeId { get; set; }

        [DisplayName("Parking Required")]

        public bool IsParking { get; set; }

        //[DisplayName("Facility App Required")]

        //public bool isFacilityApp { get; set; }

        [DisplayName("Tenancy Start Date")]
        [DataType(DataType.Date)]
        public DateTime? TenancyStartDate { get; set; }
        [DisplayName("Tenancy EndDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]

        public DateTime? TenancyEndDate { get; set; }
        [DisplayName("Tenancy RenewalDate")]
        [DataType(DataType.Date)]
        public DateTime? RenewalDate { get; set; }
        [DisplayName("Total Years Of Occupency")]

        public int? TotalYears { get; set; }


        //Tenancy

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
        public string ParkingSlotFloor { get; set; }
        [DisplayName("Parking Slot No")]
        public string ParkingSlotNo { get; set; }
        [DisplayName("Parking Key Provided")]
        public bool ParkingKeyProvided { get; set; }


        public int? CreatedBy { get; set; } = 1;



        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int? UpdatedBy { get; set; } = 1;

        public DateTime? UpdatedDate { get; set; }


    }
}














