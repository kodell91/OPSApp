using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [DisplayName("Name")]
        public string EmployeeName { get; set; }

        [DisplayName("Company Ranking")]
        public double NewGPRanking { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DisplayName("Bi-Weekly Gross Profit")]
        public double BiWeekGP { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DisplayName("YTD Contract GP")]
        public double YTDContractGP { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DisplayName("YTD Direct Hire GP")]
        public double YTDDirectHireGP { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DisplayName("Additional Direct Hire Allocation")]
        public double AdditionDHAllocation { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DisplayName("Total Gross Profit")]
        public double TotalGP { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DisplayName("Qualifying Total Gross Profit")]
        public double QualifyingTotalGP { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DisplayName("Total GP Target")]
        public double TotalGPTarget { get; set; }

        [DisplayFormat(DataFormatString = "{0:##%}")]
        [DisplayName("% Total GP")]
        public double PercentTotalGP { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DisplayName("New Contract GP")]
        public double NewContractGP { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DisplayName("Qualifying New Gross Profit")]
        public double QualifyingNewGP { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DisplayName("YTD Contract GP")]
        public double NewGPTarget { get; set; }

        [DisplayFormat(DataFormatString = "{0:##%}")]
        [DisplayName("% New GP")]
        public double PercentNewGP { get; set; }

    }
}