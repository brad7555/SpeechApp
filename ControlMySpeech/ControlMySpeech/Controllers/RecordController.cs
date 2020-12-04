using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlMySpeech.Models;
using ControlMySpeech.Models.ViewModels; 

namespace ControlMySpeech.Controllers
{
    public class RecordController : Controller
    {
        private SpeechContext db = new SpeechContext();
        // GET: Record
        [HttpGet]
        public ActionResult Index()
        {
            //Grabbing the entire contents of the AudioFiles DB to display 
           /* List<AudioFile> audiolist = new List<AudioFile>();
            var count = db.AudioFiles.Count();
            var list = db.AudioFiles.ToList();*/

            var audio = db.AudioFiles.Join(db.Ratings, a => a.ID, r => r.AudioID, (a, r) => new { a, r }).Select(m => new AudioWithRatings
            {
                Name = m.a.Name,
                FilePath = m.a.FilePath,
                Tension = m.r.Tension,
                Relaxation = m.r.Relaxation,
                Comments = m.r.Comments,
                ID = m.a.ID
            });

            return View(audio.ToList());
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase fileUpload)
        {
            if (fileUpload == null)
            {
                return RedirectToAction("Index");
            }
            /*Getting all of the necessary info from the users audio file*/
            string name = Path.GetFileName(fileUpload.FileName);
            
            int fileSize = fileUpload.ContentLength;

            //Create bool var to control if the saving continues
            bool check = false;


            //Checking to see if file name already exists in table 
            List<AudioFile> ad = db.AudioFiles.Where(s => s.Name.Contains(name)).ToList();

            if (ad.Count == 0)
            {
                check = true; 
            }
            


            if (check == true)
            {
                //Creating new AudioFile to be filled and added to the DB
                fileUpload.SaveAs(Server.MapPath("~/AudioFileUpload/" + name)); //Adding the file to the filesystem
                AudioFile audiofile = new AudioFile();
                audiofile.Name = name;
                audiofile.FileSize = fileSize;
                audiofile.FilePath = "~/AudioFileUpload/" + name;

                //Adds the populated AudioFile to the DB and saves the changes 
                db.AudioFiles.Add(audiofile);
                db.SaveChanges();
                int d = audiofile.ID; 
                return RedirectToAction("Ratings", new { id = d}); 

            }
            return RedirectToAction("Index");


           



        }
        public ActionResult Ratings(string id)
        {
            string sd = "Before";
            char f = sd[1]; 

            ViewBag.ID = id; 
            return View(); 
        }
        public ActionResult SaveRatings(string Comments)
        {
            /*Grabbing the data that is being sent through the URL*/
            int id = Int32.Parse(Request.QueryString["AudioID"]);
            int tension =Int32.Parse(Request.QueryString["tension"]);
            int relax =Int32.Parse(Request.QueryString["relax"]);
            //Creating an instance of a 'Ratings' Object
            Rating rating = new Rating();
            //Populating the new rating object with needed data
            rating.AudioID = id;
            rating.Comments = Comments;
            rating.Relaxation = relax;
            rating.Tension = tension;
            

            //Saving the instance to the DB
            db.Ratings.Add(rating);
            db.SaveChanges();




            return RedirectToAction("Index");
        }


        public ActionResult DeleteFile()
        {
            //Grabbing the ID from the URL that was sent via Ajax 
            int id = Int32.Parse(Request.QueryString["ID"]);
           //Matching the AudioFile to the corresponding one from the DB 
            List<AudioFile> ad = db.AudioFiles.Where(a => a.ID.Equals(id)).ToList();


            //Crafting the path to the file within the system to be deleted
            string fullPath = Request.MapPath(ad[0].FilePath); 
            //Checking to see if file exists within the system
            if (System.IO.File.Exists(fullPath))
            {
                //If the file exists, then it is deleted
                System.IO.File.Delete(fullPath); 
            }
            //Deleting the correspodning comments
            List<Rating> rat = db.Ratings.Where(r => r.AudioID.Equals(id)).ToList();
            db.Ratings.Remove(rat[0]);
            db.SaveChanges(); 

            //Removing the instance from the DB, and saving the changes
            db.AudioFiles.Remove(ad[0]);
            db.SaveChanges(); 


            return Json(true); 
        }
        public ActionResult Add()
        {
            return View(); 
        }
    }
}