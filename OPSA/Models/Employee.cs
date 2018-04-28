using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OPSA.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public int Tenure { get; set; }

        public DateTime StartDate { get; set; }

        public string Position { get; set; }

        public string Branch { get; set; }

    }
}