
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static FacilityApp.Core.Statics;

namespace FacilityApp.Models
{
    public class FlatType
    {
        [Key]
        public int FlatTypeId { get; set; }
        public string Name { get; set; }


        public RecordState Status { get; set; }

        public string CreatedBy { get; set; } = "System";

        public DateTime CreatedDate { get; set; } = DateTime.Now;
       

    }
}
