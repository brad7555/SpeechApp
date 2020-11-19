using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMySpeech.Models
{
    public class Entry
    {
       public HttpPostedFileBase fileUpload { get; set; }
       public int Relaxation { get; set; }
        public int Tension { get; set; }
        public string Comments { get; set; }


    }
}