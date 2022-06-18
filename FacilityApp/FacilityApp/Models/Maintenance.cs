
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
        [DisplayName("Building Name")]
        public int BuildingId { get; set; }
        [DisplayName("Tenant Name")]
        public int TenantId { get; set; }

        [DisplayName("Issue Type")]
        public int IssueTypeId { get; set; }
        [DisplayName("Issue Details  ")]
        [MaxLength(4000)]
        public string IssueDetails { get; set; }
        [DisplayName("Assigned To")]
        public int? UserId { get; set; }

        [DisplayName("Request Status")]
        public int?  RequestStatusId { get; set; }

        public string? ImagePath { get; set; }
        public RecordState Status { get; set; }

        public int CreatedBy { get; set; } =1;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; } 

        public DateTime? UpdatedDate { get; set; } 

    }
}
