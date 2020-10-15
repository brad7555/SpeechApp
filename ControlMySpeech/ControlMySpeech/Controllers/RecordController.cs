using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlMySpeech.Models; 

namespace ControlMySpeech.Controllers
{
    public class RecordController : Controller
    {
        private RecordingDBEntities db = new RecordingDBEntities();
        // GET: Record
        [HttpGet]
        public ActionResult Index()
        {
            //Grabbing the entire contents of the AudioFiles DB to display 
            List<AudioFile> audiolist = new List<AudioFile>();
            var count = db.AudioFiles.Count();
            var list = db.AudioFiles.ToList();
            return View(list);
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase fileUpload)
        {
            /*Getting all of the necessary info from the users audio file*/
            string name = Path.GetFileName(fileUpload.FileName);
            int fileSize = fileUpload.ContentLength;
            fileUpload.SaveAs(Server.MapPath("~/AudioFileUpload/" + name));

            //Creating new AudioFile to be filled and added to the DB
            AudioFile audiofile = new AudioFile();
            audiofile.Name = name;
            audiofile.FileSize = fileSize;
            audiofile.FilePath = "~/AudioFileUpload/" + name;

            //Adds the populated AudioFile to the DB and saves the changes 
            db.AudioFiles.Add(audiofile);
            db.SaveChanges(); 


            return RedirectToAction("Index"); 
        }
        public ActionResult Add()
        {
            return View(); 
        }
    }
}