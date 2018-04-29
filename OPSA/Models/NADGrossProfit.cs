using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//TODO: Add attributes
namespace OPSA.Models
{
    public class NADGrossProfit
    {
        [Key]
        public int NADId { get; set; }
        public int EmloyeeId { get; set; }
        public float BiWeeklyGP { get; set; }
        public float YTDDirectHireGP { get; set; }
        public float YTDGPCombined { get; set; }
        public float GPTarget { get; set; }
        public float PercentGP { get; set; }
    }
}