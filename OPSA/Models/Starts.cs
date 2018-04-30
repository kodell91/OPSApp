using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OPSA.Models
{
    public class FourWeekRockStars
    {

        //public class Ranking
        //{
        //    [Key]
        //    public int RankingKey { get; set; }

        //    public int RankDifference { get; set; }

        //    public int PreviousRank { get; set; }

        //    public int PositionRank { get; set; }

        //    public float Score { get; set; }
        //}

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

        //public class Activity
        //{
        //    [Key]
        //    public int ActivityId { get; set; }

        //    public int Prescreens { get; set; }

        //    public int Sendouts { get; set; }

        //    public int ClientVisits { get; set; }

        //    public int NewPositions { get; set; }

        //    public int PercentExpectations { get; set; }
        //}
    }
}