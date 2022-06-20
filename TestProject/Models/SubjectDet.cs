namespace TestProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubjectDet")]
    public partial class SubjectDet
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string SubjectName { get; set; }

        public int? SubjectMasId { get; set; }

        public virtual SubjectMa SubjectMa { get; set; }
    }
}
