using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//TPPC In this context stands for Top Performers and Platinum Club members, and this Model builds data to take from the respective sheet
namespace OPSA.Models
{
    public class TPPCGrossProfit
    {
        [Key]
        public int TPPCId { get; set; }
        //public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public double NewGPRanking { get; set; }
        public double BiWeekGP { get; set; }
        public double YTDContractGP { get; set; }
        public double YTDDirectHireGP { get; set; }
        public double AdditionDHAllocation { get; set; }
        public double TotalGP { get; set; }
        public double QualifyingTotalGP { get; set; }
        public double TotalGPTarget { get; set; }
        public double PercentTotalGP { get; set; }
        public double NewContractGP { get; set; }
        public double QualifyingNewGP { get; set; }
        public double NewGPTarget { get; set; }
        public double PercentNewGP { get; set; }

    }
}