using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OPSA.Models
{
    public class MonthlyRecruiting
    {

        //public Employee Employee { get; set; }

        [Key]
        public int EmployeeId { get; set; }

        [DisplayName("Name")]
        public String EmployeeName { get; set; }

        //public class Ranking
        //{
        //[Key]
        //public int RankingKey { get; set; }

        [DisplayName("+/-")]
        public double RankDifference { get; set; }

        [DisplayName("Previous")]
        public double PreviousRank { get; set; }

        [DisplayName("Company Ranking")]
        public double CompanyRank { get; set; }

        [DisplayName("Position Ranking")]
        public double PositionRank { get; set; }

        [DisplayName("Score")]
        public double Score { get; set; }

        //public class Starts
        //{
        //[Key]
        //public int StartsId { get; set; }

        [DisplayName("Total Starts(4WKS)")]
        public double Total4WKStarts { get; set; }

        [DisplayName("Current Headcount")]
        public double CurrentHeadCount { get; set; }

        [DisplayName("Monthly HC Goal")]
        public double MonthHCGoal { get; set; }

        //public class Activity
        //{
        //    [Key]
        //    public int ActivityId { get; set; }

        [DisplayName("Prescreens (10)")]
        public double Prescreens { get; set; }

        [DisplayName("Send Outs (5)")]
        public double Sendouts { get; set; }

        [DisplayName("Client Visits (12)")]
        public double ClientVisits { get; set; }

        [DisplayName("New Positions (3)")]
        public double NewPositions { get; set; }

        [DisplayFormat(DataFormatString = "{0:##.##%}")]
        [DisplayName("% of Expectations")]
        public double PercentExpectations { get; set; }

    }
}