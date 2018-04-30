using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OPSA.Models
{
    public class MonthlyRecruiting
    {

        //public Employee Employee { get; set; }

        [Key]
        public int EmployeeId { get; set; }

        public String EmployeeName { get; set; }

        //public class Ranking
        //{
        //[Key]
        //public int RankingKey { get; set; }

        public double RankDifference { get; set; }

        public double PreviousRank { get; set; }

        public double CompanyRank { get; set; }

        public double PositionRank { get; set; }

        public double Score { get; set; }

        //public class Starts
        //{
        //[Key]
        //public int StartsId { get; set; }

        [DisplayName("Total Starts(4WKS)")]
        public double Total4WKStarts { get; set; }

        [DisplayName("Current Headcount")]
        public double CurrentHeadCount { get; set; }

        [DisplayName("Monthly Headcount Goal")]
        public double MonthHCGoal { get; set; }

        //public class Activity
        //{
        //    [Key]
        //    public int ActivityId { get; set; }

        public double Prescreens { get; set; }

        public double Sendouts { get; set; }

        public double ClientVisits { get; set; }

        public double NewPositions { get; set; }

        public double PercentExpectations { get; set; }

    }
}