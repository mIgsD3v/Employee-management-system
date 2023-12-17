namespace IPT102PROJECT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Admin
    {
        [Key]

      
        public int EmployeeID { get; set; }

        
        [Required(ErrorMessage ="Email is required")]
        [StringLength(50)]

        public string Email { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
