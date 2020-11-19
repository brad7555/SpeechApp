namespace ControlMySpeech.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SpeechContext : DbContext
    {
        public SpeechContext()
            : base("name=SpeechContext")
        {
        }

        public virtual DbSet<AudioFile> AudioFiles { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AudioFile>()
                .HasMany(e => e.Ratings)
                .WithRequired(e => e.AudioFile)
                .HasForeignKey(e => e.AudioID);
        }
    }
}
