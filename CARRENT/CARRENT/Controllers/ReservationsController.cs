using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CARRENT.Models;

namespace CARRENT.Controllers
{
    public class ReservationsController : Controller
    {
        private LocationVoitures db = new LocationVoitures();

        // GET: Reservations
        public ActionResult Index()
        {
            var reservations = db.Reservations.Include(r => r.Client).Include(r => r.Voiture);
            return View(reservations.ToList());
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            var clients = db.Clients.ToList();
            List<SelectListItem> ListeClients = new List<SelectListItem>();
            foreach (var m in clients)
            {
                ListeClients.Add(new SelectListItem
                {
                    Value = m.CLID.ToString(),
                    Text = m.CLID.ToString()
                });
            }
            ViewData["clients"] = clients;
            var voitures = db.Voitures.ToList();
            List<SelectListItem> ListeVoitures = new List<SelectListItem>();
            foreach (var m in voitures)
            {
                ListeVoitures.Add(new SelectListItem
                {
                    Value = m.VID.ToString(),
                    Text = m.VID.ToString()
                });
            }
            ViewData["voitures"] = voitures;
            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            ViewBag.CLID = new SelectList(db.Clients, "CLID", "CLID");
            ViewBag.VID = new SelectList(db.Voitures, "VID", "numéroimmattriculation");
            return View(new Reservation());
        }

        // POST: Reservations/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                //if(Session["CLID"]==null)
                    //return RedirectToAction("Login", "Clients");
                //else
                //{
                    /*List<Voiture> voiture = this.SharedSession["voitures"] as List<Voiture>;
                for (int i = 0; i < voiture.Count; i++)
                {
                    if (reservation.typelocation == "longue")
                        reservation.PrixLocationFinal = voiture[i].PrixLocationJournalier * 0.6 * 30;
                    else if (reservation.typelocation == "courte")
                        reservation.PrixLocationFinal = voiture[i].PrixLocationJournalier;
                }*/
                    if (reservation.DateDebutLocation > reservation.DateFinLocation)
                        ModelState.AddModelError("", "La date de début doit précéder la date de fin");
                    db.Reservations.Add(reservation);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                //}
            }

            ViewBag.CLID = new SelectList(db.Clients, "CLID", "CLID", reservation.CLID);
            ViewBag.VID = new SelectList(db.Voitures, "VID", "numéroimmattriculation", reservation.VID);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLID = new SelectList(db.Clients, "CLID", "CLID", reservation.CLID);
            ViewBag.VID = new SelectList(db.Voitures, "VID", "numéroimmattriculation", reservation.VID);
            var clients = db.Clients.ToList();
            List<SelectListItem> ListeClients = new List<SelectListItem>();
            foreach (var m in clients)
            {
                ListeClients.Add(new SelectListItem
                {
                    Value = m.CLID.ToString(),
                    Text = m.CLID.ToString()
                });
            }
            ViewData["clients"] = clients;
            var voitures = db.Voitures.ToList();
            List<SelectListItem> ListeVoitures = new List<SelectListItem>();
            foreach (var m in voitures)
            {
                ListeVoitures.Add(new SelectListItem
                {
                    Value = m.VID.ToString(),
                    Text = m.VID.ToString()
                });
            }
            ViewData["voitures"] = voitures;
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                if (reservation.DateDebutLocation > reservation.DateFinLocation)
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLID = new SelectList(db.Clients, "CLID", "NomComplet", reservation.CLID);
            ViewBag.VID = new SelectList(db.Voitures, "VID", "numéroimmattriculation", reservation.VID);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            var clients = db.Clients.ToList();
            List<SelectListItem> ListeClients = new List<SelectListItem>();
            foreach (var m in clients)
            {
                ListeClients.Add(new SelectListItem
                {
                    Value = m.CLID.ToString(),
                    Text = m.CLID.ToString()
                });
            }
            ViewData["clients"] = clients;
            var voitures = db.Voitures.ToList();
            List<SelectListItem> ListeVoitures = new List<SelectListItem>();
            foreach (var m in voitures)
            {
                ListeVoitures.Add(new SelectListItem
                {
                    Value = m.VID.ToString(),
                    Text = m.VID.ToString()
                });
            }
            ViewData["voitures"] = voitures;
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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
