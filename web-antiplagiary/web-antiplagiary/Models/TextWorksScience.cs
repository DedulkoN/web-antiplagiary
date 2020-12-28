namespace web_antiplagiary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TextWorksScience")]
    public partial class TextWorksScience
    {
        [Key]
        public int idParagraph { get; set; }

        [StringLength(440)]
        public string TextWorks { get; set; }
    }
}
