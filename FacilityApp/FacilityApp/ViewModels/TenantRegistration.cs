using FacilityApp.Models;
using System.ComponentModel.DataAnnotations;

namespace FacilityApp.ViewModels
{
    public class TenantRegistration
    {
        public  Tenant Tenant { get; set; }
        public TenantFlatDetails  TenantFlatDetails { get; set; }
        

    }
}
