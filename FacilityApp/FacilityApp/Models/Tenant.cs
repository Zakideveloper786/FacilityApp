
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DisplayName("Email ID")]
        public string? EmailId { get; set; }
        [DisplayName("Address")]
        public string? Address { get; set; }
        [DisplayName("Emirates ID")]
        public string? EmiratedId { get; set; }
        [DisplayName("PassPort No")]
        public string? PassportNo { get; set; }
        [DisplayName("No of Family Members")]
        public int? FamilyCount { get; set; }
        [DisplayName("Facility App Required")]
        public bool? FaciltyAppAccess { get; set; }


        // Flat



        // Payment details

        //[DisplayName("Payment Type")]
        //public int? PaymentTypeId { get; set; }
        //[DisplayName("Cheque No")]

        //public int ChequeNo { get; set; }
        //[DisplayName("Payment Clearence")]

        //public bool PaymentClearence { get; set; }
        //[DisplayName("Reason")]

        //public string? Reason { get; set; }
        //[DisplayName("Notification Sent")]

        //public bool NotificationSent { get; set; }

        //[DisplayName("Reminders")]

        //public int Reminders { get; set; }

        public int?CreatedBy { get; set; } = 1;



        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int? UpdatedBy { get; set; } = 1;

        public DateTime? UpdatedDate { get; set; } 

    }
}
