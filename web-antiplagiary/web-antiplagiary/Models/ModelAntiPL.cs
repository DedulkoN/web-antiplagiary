namespace web_antiplagiary.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelAntiPL : DbContext
    {
        public ModelAntiPL()
            : base("name=ModelAntiPLCOnnectedString")
        {
        }

        public virtual DbSet<Specialty> Specialty { get; set; }
        public virtual DbSet<TextWorks> TextWorks { get; set; }
        public virtual DbSet<TextWorksDiploms> TextWorksDiploms { get; set; }
        public virtual DbSet<TextWorksMagisters> TextWorksMagisters { get; set; }
        public virtual DbSet<TextWorksScience> TextWorksScience { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialty>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TextWorks>()
                .Property(e => e.TextWorks1)
                .IsUnicode(false);

            modelBuilder.Entity<TextWorksDiploms>()
                .Property(e => e.TextWorks)
                .IsUnicode(false);

            modelBuilder.Entity<TextWorksMagisters>()
                .Property(e => e.TextWorks)
                .IsUnicode(false);

            modelBuilder.Entity<TextWorksScience>()
                .Property(e => e.TextWorks)
                .IsUnicode(false);
        }
    }
}
