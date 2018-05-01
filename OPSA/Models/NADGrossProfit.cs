using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [DisplayName("Name")]
        public string EmployeeName { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DisplayName("Bi-Weekly Gross Profit")]
        public double BiWeeklyGP { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DisplayName("YTD Direct Hire GP")]
        [NotMapped]
        public double YTDDirectHireGP { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DisplayName("YTD GP (Optomi + Provalus)")]
        public double YTDGPCombined { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DisplayName("GP Target")]
        public double GPTarget { get; set; }

        [DisplayFormat(DataFormatString = "{0:##%}")]
        [DisplayName("% GP")]
        public double PercentGP { get; set; }
    }
}