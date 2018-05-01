using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OPSA.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [DisplayName("Name")]
        public string EmployeeName { get; set; }

        [DisplayName("Tenure (Months)")]
        public int Tenure { get; set; }

        //TODO: Change to better date format
        [DisplayName("Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime StartDate { get; set; }

        public string Position { get; set; }

        public string Branch { get; set; }

    }
}