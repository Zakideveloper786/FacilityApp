
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static FacilityApp.Core.Statics;

namespace FacilityApp.Models
{
    public class IssueType
    {
        [Key]
        public int IssueTypeId { get; set; }
        public string Name { get; set; }


        public RecordState Status { get; set; }

        public string CreatedBy { get; set; } = "System";

        public DateTime CreatedDate { get; set; } = DateTime.Now;
       

    }
}
