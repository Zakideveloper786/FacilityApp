using System.ComponentModel;
using static FacilityApp.Core.Statics;

namespace FacilityApp.ViewModels
{
    public class MaintenanceVM
    {

        public int MaintananceId { get; set; }
        [DisplayName("Tenant Name")]
        public string TenantName { get; set; }

        [DisplayName("Issue Type")]
        public string IssueType  { get; set; }
        [DisplayName("Contact Person Name  ")]

        public string IssueDetails { get; set; }
        [DisplayName("Assigned To")]
        public string UserName { get; set; }

        public string? ImagePath { get; set; }
        public string Status { get; set; }

    }
}
