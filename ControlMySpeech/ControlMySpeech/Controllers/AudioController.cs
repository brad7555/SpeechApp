using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlMySpeech.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO; 

namespace ControlMySpeech.Controllers
{
    public class AudioController : Controller
    {
        private SpeechContext db = new SpeechContext(); 
        // GET: Audio
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UploadAudio()
        {
            List<AudioFile> audiolist = new List<AudioFile>();
            var count = db.AudioFiles.Count();
            var list = db.AudioFiles; 
            for(int i = 0; i < count; i++)
            {

            }




            return View(audiolist); 
        }
    }
}