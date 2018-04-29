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
        public int EmployeeId { get; set; }
        public int NewGPRanking { get; set; }
        public int YTDContractGP { get; set; }
        public int YTDDirectHireGP { get; set; }
        public int AdditionDHAllocation { get; set; }
        public int TotalGP { get; set; }
        public int QualifyingTotalGP { get; set; }
        public int NewContractGP { get; set; }
        public int QualifyingNewGP { get; set; }
        public int NewGPTarget { get; set; }
        public float PercentNewGP { get; set; }

    }
}