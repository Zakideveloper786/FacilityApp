
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static FacilityApp.Core.Statics;

namespace FacilityApp.Models
{
    public class Frequency
    {
        [Key]
        public int FrequencyId { get; set; }
        public string Name { get; set; }


        public RecordState Status { get; set; }

        public int CreatedBy { get; set; } = 1;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
       

    }
}
