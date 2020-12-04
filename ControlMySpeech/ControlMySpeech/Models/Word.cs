namespace ControlMySpeech.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Word
    {
        [Key]
        public int WID { get; set; }

        [Column("Word")]
        [Required]
        public string Word1 { get; set; }

        [Required]
        public string Type { get; set; }

        public int Rating { get; set; }
    }
}
