using System.ComponentModel;

namespace FacilityApp.ViewModels
{
    public class BuildingVM
    {
        public int BuildingId { get; set; }
        [DisplayName("Building Name")]
        public string Name { get; set; }
        [DisplayName("Contact Person   ")]
        public string  UserName { get; set; }
    }
}
