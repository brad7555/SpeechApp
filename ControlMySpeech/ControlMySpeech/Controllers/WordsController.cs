using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControlMySpeech.Models;
using Newtonsoft.Json;

namespace ControlMySpeech.Views
{
    public class WordsController : Controller
    {
        private SpeechContext db = new SpeechContext();

        // GET: Words
        public ActionResult Index()
        {
            return View(db.Words.ToList());
        }
        public ActionResult Sentence()
        {
            return View();
        }
        public ActionResult Generate()
        {
            char letter = Char.Parse(Request.QueryString["Letter"]);
            int num = Int32.Parse(Request.QueryString["num"]); 

            /*Separating all of the types of words so the sentence can be built*/
            List<Word> verb = db.Words.Where(v => v.Type.Equals("Verb")).ToList(); 
            List<Word> noun = db.Words.Where(n => n.Type.Equals("Noun")).ToList();
            List<Word> adjective = db.Words.Where(a => a.Type.Equals("Adjective")).ToList();
            List<Word> adverb = db.Words.Where(ad => ad.Type.Equals("Adverb")).ToList();
            List<Word> prep = db.Words.Where(p => p.Type.Equals("Preposition")).ToList();
            List<Word> Pro = db.Words.Where(pr => pr.Type.Equals("Pronoun")).ToList();

            //Sorting the lists by intended letter
            List<Word> verb1 = verb.Where(a => a.Word1[0].Equals(letter)).ToList();
            List<Word> noun1 = noun.Where(a => a.Word1[0].Equals(letter)).ToList();
            List<Word> adjective1 = adjective.Where(a => a.Word1[0].Equals(letter)).ToList();
            List<Word> adverb1 = adverb.Where(a => a.Word1[0].Equals(letter)).ToList();
            List<Word> prep1 = prep.Where(a => a.Word1[0].Equals(letter)).ToList();
            



            List<string> sentences = new List<string>();
            Random rnd = new Random();
            for (int i = 0; i < num; i++) {
                //Generating Random numbers to choose words at random. Numbers are capped by the specific
                //word list size (listName.count())
                
                int randVerb = rnd.Next(0, verb1.Count());
                int randNoun1 = rnd.Next(0, noun1.Count());
                int randNoun2 = rnd.Next(0, noun1.Count());
                int randAdj = rnd.Next(0, adjective1.Count());
                int randAdverb = rnd.Next(0, adverb1.Count());
                int randPrep = rnd.Next(0, prep1.Count());
                int randPro1 = rnd.Next(0, Pro.Count());
                int randPro2 = rnd.Next(0, Pro.Count());

                //Constructing the sentence
                string first = Pro[randPro1].Word1 +" " + adjective1[randAdj].Word1 +" "+ noun1[randNoun1].Word1 + " " + 
                    verb1[randVerb].Word1 + " " + adverb1[randAdverb].Word1 + " " + prep[randPrep].Word1 + " " +Pro[randPro2].Word1 + " "+ noun1[randNoun2].Word1;
                //Adding the sentence to the list
                sentences.Add(first);
                
            }
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(sentences),
                ContentType = "application/json",
                ContentEncoding = System.Text.Encoding.UTF8
            }
            ; 

        }

        // GET: Words/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Word word = db.Words.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        // GET: Words/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Words/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WID,Word1,Type,Rating")] Word word)
        {
            if (ModelState.IsValid)
            {
                db.Words.Add(word);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(word);
        }

        // GET: Words/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Word word = db.Words.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        // POST: Words/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WID,Word1,Type,Rating")] Word word)
        {
            if (ModelState.IsValid)
            {
                db.Entry(word).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(word);
        }

        // GET: Words/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Word word = db.Words.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        // POST: Words/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Word word = db.Words.Find(id);
            db.Words.Remove(word);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
