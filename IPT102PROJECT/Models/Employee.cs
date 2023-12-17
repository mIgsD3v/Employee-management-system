namespace IPT102PROJECT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int EmployeeID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Position { get; set; }

        [StringLength(250)]
        public string Cityaddress { get; set; }

        public int? Cellphonenumber { get; set; }

        [StringLength(250)]
        public string Department { get; set; }
    }
}
