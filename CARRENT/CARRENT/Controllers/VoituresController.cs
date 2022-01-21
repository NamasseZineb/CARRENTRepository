using CARRENT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace CARRENT.Controllers
{
    public class VoituresController : Controller
    {
        LocationVoitures db = new LocationVoitures();

        public ActionResult Index()
        {
            return View(db.Voitures.ToList());
        }
        // GET: Voitures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voi = db.Voitures.Find(id);
            if (voi == null)
            {
                return HttpNotFound();
            }
            return View(voi);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "numéroimmattriculation,DateMiseCirculation,TypeCarburant,PrixLocationJournalier,ImageFichier,Modele,Categorie", Exclude = "CheminImage")] Voiture voiture )
        {
            /*if (!ModelState.IsValid) return View();*/

            voiture.ImageFichier.SaveAs(@"C:\Users\ACER\Desktop\DOTNETCAR\CARRENTRepository\CARRENT\CARRENT\Images\" + voiture.ImageFichier.FileName);
            voiture.CheminImage = voiture.ImageFichier.FileName;

            db.Voitures.Add(voiture);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        // GET: Voitures/Edit/
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voi = db.Voitures.Find(id);
            if (voi == null)
            {
                return HttpNotFound();
            }
            return View(voi);
        }
        // POST: Voitures/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numéroimmattriculation,DateMiseCirculation,TypeCarburant,PrixLocationJournalier,ImageFichier,Modele,Categorie", Exclude = "CheminImage")] Voiture voi)
        {
            //if (ModelState.IsValid)
            //{
                db.Entry(voi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            //}
            //return View(voi);
        }

        // GET: Modeles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // GET: Voitures/Delete/5
       /* [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voi = db.Voitures.Find(id);
            if (voi == null)
            {
                return HttpNotFound();
            }
            return View(voi);
        }*/
        // POST: Modeles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voiture voi = db.Voitures.Find(id);
            db.Voitures.Remove(voi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}