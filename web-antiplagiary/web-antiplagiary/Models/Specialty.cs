namespace web_antiplagiary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Specialty")]
    public partial class Specialty
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short specialtyID { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }
    }
}
