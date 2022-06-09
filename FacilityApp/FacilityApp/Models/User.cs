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
        public string Password { get; set; }

        [DisplayName("Email ID ")]
        [EmailAddress]
        public string? EmailID { get; set; }
        [DisplayName("MobileNumber ")]
        public string? MobileNo { get; set; }
        [DisplayName("Designation ")]
        public string?  Designation { get; set; }

        public int?  RoleId { get; set; }

        public RecordState Status { get; set; }

        public string CreatedBy { get; set; } = "System";

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

    }
}
