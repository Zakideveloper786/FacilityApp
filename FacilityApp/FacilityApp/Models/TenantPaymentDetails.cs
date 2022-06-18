
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace FacilityApp.Models
{
    public class TenantPaymentDetails
    {
        [Key]
        public int TenantPaymentDetailsId { get; set; }
        [DisplayName("Payment Type")]
        public int? PaymentTypeId { get; set; }
        [DisplayName("Cheque No")]

        public int ChequeNo { get; set; }
        [DisplayName("Payment Clearence")]

        public bool PaymentClearence { get; set; }
        [DisplayName("Reason")]

        public string? Reason { get; set; }
        [DisplayName("Notification Sent")]

        public bool NotificationSent { get; set; }

        [DisplayName("Reminders")]

        public int Reminders { get; set; }

        [DisplayName("Tenant Name")]

        public int? TenantId { get; set; }




        public int?CreatedBy { get; set; } = 1;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int? UpdatedBy { get; set; } = 1;

        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

    }
}
