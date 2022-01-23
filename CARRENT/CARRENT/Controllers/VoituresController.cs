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
            ViewData["cats"] = new SelectList(db.Categories.ToList(), "CID", "taille");
            var modeles = db.Modeles.ToList();
            List<SelectListItem> ListeModeles = new List<SelectListItem>();
            foreach (var m in modeles)
            {
                ListeModeles.Add(new SelectListItem
                {
                    Value = m.MID.ToString(),
                    Text = m.nommarque + " " + m.numérosérie
                });
            }
            ViewData["modeles"] = modeles;
            return View(db.Voitures.ToList());
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
            ViewData["cats"] = new SelectList(db.Categories.ToList(), "CID", "taille");
            var modeles = db.Modeles.ToList();
            List<SelectListItem> ListeModeles = new List<SelectListItem>();
            foreach (var m in modeles)
            {
                ListeModeles.Add(new SelectListItem
                {
                    Value = m.MID.ToString(),
                    Text = m.nommarque + " " + m.numérosérie
                });
            }
            ViewData["modeles"] = modeles;
            return View(voiture);
        }
        public ActionResult Create()
        {
            ViewData["cats"] = new SelectList(db.Categories.ToList(), "CID", "taille");
            var modeles = db.Modeles.ToList();
            List<SelectListItem> ListeModeles = new List<SelectListItem>();
            foreach(var m in modeles)
            {
                ListeModeles.Add(new SelectListItem
                {
                    Value = m.MID.ToString(),
                    Text = m.nommarque + " " + m.numérosérie
                });
            }
            ViewData["modeles"] = modeles;
            

            return View(new Voiture());
            /*var hospName = db.Hospitals.ToList();
            List<SelectListItem> listhosp = new List<SelectListItem>();

            foreach (var item in hospName)
            {
                listhosp.Add(new SelectListItem
                {
                    Text = item.hospital_name,
                    Value =
                          item.hospital_id.ToString()
                });
            }
            // ViewBag.hospitalname = hospName;  error here 

            ViewBag.hospitalname = listhosp;
            return View();*/
        }

        [HttpPost]
        public ActionResult Create(Voiture voiture)
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
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            ViewData["cats"] = new SelectList(db.Categories.ToList(), "CID", "taille");
            var modeles = db.Modeles.ToList();
            List<SelectListItem> ListeModeles = new List<SelectListItem>();
            foreach (var m in modeles)
            {
                ListeModeles.Add(new SelectListItem
                {
                    Value = m.MID.ToString(),
                    Text = m.nommarque + " " + m.numérosérie
                });
            }
            ViewData["modeles"] = modeles;
            return View(voiture);
        }
        // POST: Voitures/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Voiture voiture)
        {
            //if (ModelState.IsValid)
            //{
                voiture.ImageFichier.SaveAs(@"C:\Users\ACER\Desktop\DOTNETCAR\CARRENTRepository\CARRENT\CARRENT\Images\" + voiture.ImageFichier.FileName);
                voiture.CheminImage = voiture.ImageFichier.FileName;
                db.Entry(voiture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            //}
            //return View(voiture);
        }

        // GET: Modeles/Delete/5
        /*public ActionResult Delete(int id)
        {
            return View();
        }*/

        // GET: Voitures/Delete/5
        //[HttpPost]
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
            ViewData["cats"] = new SelectList(db.Categories.ToList(), "CID", "taille");
            var modeles = db.Modeles.ToList();
            List<SelectListItem> ListeModeles = new List<SelectListItem>();
            foreach (var m in modeles)
            {
                ListeModeles.Add(new SelectListItem
                {
                    Value = m.MID.ToString(),
                    Text = m.nommarque + " " + m.numérosérie
                });
            }
            ViewData["modeles"] = modeles;
            return View(voiture);
        }
        // POST: Modeles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voiture voiture = db.Voitures.Find(id);
            db.Voitures.Remove(voiture);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}