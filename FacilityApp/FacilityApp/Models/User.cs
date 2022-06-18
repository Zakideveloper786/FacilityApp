using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static FacilityApp.Core.Statics;

namespace FacilityApp.Models
{
    public class User
    {
      
        [Key]
        public int UserId { get; set; }
        [Required]
        [DisplayName("Full Name ")]
        public string Name { get; set; }

        [DisplayName("User Name ")]

        public string UserName { get; set; }

        public string Password { get; set; }

        [DisplayName("Email ID ")]
        [EmailAddress]
        public string? EmailID { get; set; }
        [DisplayName("MobileNumber ")]
        public string? MobileNo { get; set; }
        [DisplayName("Tenant Name ")]
        public int?  TenantId { get; set; }

        [DisplayName("User Type ")]
        public int?  RoleId { get; set; }
        [DisplayName("Building Name ")]
        public int? BuildingId { get; set; }

        public RecordState Status { get; set; }

        public int CreatedBy { get; set; } = 1;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

    }
}
