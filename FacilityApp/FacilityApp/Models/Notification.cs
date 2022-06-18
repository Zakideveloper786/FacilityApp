
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace FacilityApp.Models
{
    public class Notification

    {
        [Key]
        public int NotificationId { get; set; }

        [DisplayName("Tenant Name")]

        public int? TenantId { get; set; }

        [DisplayName("Message Mode")]

        public string? MessageMode { get; set; }



        [DisplayName("Message Body")]

        public string? MessageBody { get; set; }




        public int?CreatedBy { get; set; } = 1;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int? UpdatedBy { get; set; } = 1;

        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

    }
}
