using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlMySpeech.Models.ViewModels
{
    public class AudioWithRatings
    {
        public string Name { get; set; }
        
        [StringLength(100)]
        public string FilePath { get; set; }
        public int Tension { get; set; }

        public int Relaxation { get; set; }

        public string Comments { get; set; }
        public int ID { get; set; }
    }
}