using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//TODO: Add display names
namespace OPSA.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }
        public int Prescreens { get; set; }
        public int Sendouts { get; set; }
        public int ClientVisits { get; set; }
        public int NewPositions { get; set; }
        public int PercentExpectations { get; set; }
    }
}