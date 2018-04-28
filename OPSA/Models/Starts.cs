using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OPSA.Models
{
    public class Starts
    {
        [Key]
        public int StartsId { get; set; }

        [DisplayName("Total Starts(4WKS)")]
        public int Total4WKStarts { get; set; }

        [DisplayName("Current Headcount")]
        public int CurrentHeadCount { get; set; }

        [DisplayName("Monthly Headcount Goal")]
        public int MonthHCGoal { get; set; }

    }
}