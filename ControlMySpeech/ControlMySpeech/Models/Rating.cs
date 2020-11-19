namespace ControlMySpeech.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rating
    {
        [Key]
        public int RID { get; set; }

        public int Tension { get; set; }

        public int Relaxation { get; set; }

        public string Comments { get; set; }

        public int AudioID { get; set; }

        public virtual AudioFile AudioFile { get; set; }
    }
}
