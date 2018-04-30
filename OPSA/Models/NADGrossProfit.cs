using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
//TODO: Add attributes
namespace OPSA.Models
{

    public class NADGrossProfit
    {
        [Key]
        public int NADId { get; set; }
        public string EmployeeName { get; set; }
        public double BiWeeklyGP { get; set; }
        public double YTDDirectHireGP { get; set; }
        public double YTDGPCombined { get; set; }
        public double GPTarget { get; set; }
        public double PercentGP { get; set; }
    }
}