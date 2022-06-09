using System;
using System.ComponentModel.DataAnnotations;

namespace FacilityApp.Models
{
    public class UserRole
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string CreatedBy { get; set; } = "System";

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
