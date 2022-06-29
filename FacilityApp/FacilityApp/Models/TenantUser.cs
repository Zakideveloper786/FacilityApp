using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static FacilityApp.Core.Statics;

namespace FacilityApp.Models
{
    public class TenantUser
    {
      
        [Key]
        public int TenantUserId { get; set; }
        

        public string UserName { get; set; }

        public string Password { get; set; }

        public int? BuildingId { get; set; }

        public RecordState Status { get; set; }

        public int CreatedBy { get; set; } = 1;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

    }
}
