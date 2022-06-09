
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static FacilityApp.Core.Statics;

namespace FacilityApp.Models
{
    public class Maintenance
    {
        [Key]
        public int MaintananceId { get; set; }
        [DisplayName("Tenant Name")]
        public int TenantId { get; set; }

        [DisplayName("Issue Type")]
        public int IssueTypeId { get; set; }
        [DisplayName("Issue Details  ")]

        public string IssueDetails { get; set; }
        [DisplayName("Assigned To")]
        public int? UserId { get; set; }

        public string? ImagePath { get; set; }
        public RecordState Status { get; set; }

        public string CreatedBy { get; set; } = "System";

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; } 

        public DateTime? UpdatedDate { get; set; } 

    }
}
