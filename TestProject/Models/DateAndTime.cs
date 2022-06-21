namespace TestProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DateAndTime")]
    public partial class DateAndTime
    {
        public int Id { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
    }
}
