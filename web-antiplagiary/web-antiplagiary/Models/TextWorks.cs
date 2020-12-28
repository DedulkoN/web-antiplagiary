namespace web_antiplagiary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TextWorks
    {
        [Key]
        public int idParagraph { get; set; }

        [Column("TextWorks")]
        [StringLength(430)]
        public string TextWorks1 { get; set; }
    }
}
