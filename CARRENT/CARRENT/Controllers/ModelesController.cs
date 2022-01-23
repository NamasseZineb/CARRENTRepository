using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CARRENT.Models;

namespace CARRENT.Controllers
{
    public class ModelesController : Controller
    {
        LocationVoitures db = new LocationVoitures();
        // GET: Modeles
        public ActionResult Index()
        {
            return View(db.Modeles.ToList());
        }

        // GET: Modeles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modele mod = db.Modeles.Find(id);
            if (mod == null)
            {
                return HttpNotFound();
            }
            return View(mod);
        }

        // GET: Modeles/Create
        public ActionResult Create()
        {
            return View(new Modele());
        }

        // POST: Modeles/Create
        [HttpPost]
        public ActionResult Create(Modele mod)
        {
            if (ModelState.IsValid)
            {
                db.Modeles.Add(mod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mod);
        }

        // GET: Modeles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modele mod = db.Modeles.Find(id);
            if (mod == null)
            {
                return HttpNotFound();
            }
            return View(mod);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Modele mod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mod);
        }

        // GET: Modeles/Delete/5
        /*public ActionResult Delete(int id)
        {
            return View();
        }*/

        // GET: Modeles/Delete/5
        //[HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modele mod = db.Modeles.Find(id);
            if (mod == null)
            {
                return HttpNotFound();
            }
            return View(mod);
        }
        // POST: Modeles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modele mod = db.Modeles.Find(id);
            db.Modeles.Remove(mod);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
