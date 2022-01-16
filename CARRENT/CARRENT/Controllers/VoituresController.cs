using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CARRENT.Models;
using ProjetLocationVoitures.App_Start;

namespace CARRENT.Controllers
{
    public class VoituresController : Controller
    {
        private LocationVoitures db = new LocationVoitures();

        // GET: Voitures
        public ActionResult Index()
        {
            var voitures = db.Voitures.Include(v => v.Categorie).Include(v => v.Modele);
            return View(voitures.ToList());
        }

        // GET: Voitures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // GET: Voitures/Create
        public ActionResult Create()
        {
            ViewBag.CID = new SelectList(db.Categories, "CID", "taille");
            ViewBag.MID = new SelectList(db.Modeles, "MID", "nommarque");
            return View();
        }

        // POST: Voitures/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VID,numéroimmattriculation,DateMiseCirculation,TypeCarburant,PrixLocationJournalier,CheminImage,MID,CID")] Voiture voiture)
        {
            if (ModelState.IsValid)
            {
                db.Voitures.Add(voiture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CID = new SelectList(db.Categories, "CID", "taille", voiture.CID);
            ViewBag.MID = new SelectList(db.Modeles, "MID", "nommarque", voiture.MID);
            return View(voiture);
        }

        // GET: Voitures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            ViewBag.CID = new SelectList(db.Categories, "CID", "taille", voiture.CID);
            ViewBag.MID = new SelectList(db.Modeles, "MID", "nommarque", voiture.MID);
            return View(voiture);
        }

        // POST: Voitures/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VID,numéroimmattriculation,DateMiseCirculation,TypeCarburant,PrixLocationJournalier,CheminImage,MID,CID")] Voiture voiture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voiture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CID = new SelectList(db.Categories, "CID", "taille", voiture.CID);
            ViewBag.MID = new SelectList(db.Modeles, "MID", "nommarque", voiture.MID);
            return View(voiture);
        }

        // GET: Voitures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // POST: Voitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voiture voiture = db.Voitures.Find(id);
            db.Voitures.Remove(voiture);
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
