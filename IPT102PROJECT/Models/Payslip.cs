namespace IPT102PROJECT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payslip")]
    public partial class Payslip
    {
        [Key]
        public int EmployeeID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? Month { get; set; }

        public double Basic { get; set; }

        public double Tax { get; set; }

        public double Total { get; set; }
    }
}
