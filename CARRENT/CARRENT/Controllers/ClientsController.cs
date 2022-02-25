using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CARRENT.Models;

namespace CARRENT.Controllers
{
    public class ClientsController : Controller
    {
        LocationVoitures db = new LocationVoitures();
        // GET: Clients
        public ActionResult Index()
        {
            using(db)
            {
                return View(db.Clients.ToList());
            }
        }
        public ActionResult Register()
        {
            return View(new Client());
        }
        [HttpPost]
        public ActionResult Register(Client client)
        {
            if(ModelState.IsValid)
            {
                using(db)
                {
                    client.CINFichier.SaveAs(@"C:\Users\ACER\Desktop\DOTNETCAR\CARRENTRepository\CARRENT\CARRENT\Images\" + client.CINFichier.FileName);
                    client.CheminImageCIN = client.CINFichier.FileName;

                    client.PermisFichier.SaveAs(@"C:\Users\ACER\Desktop\DOTNETCAR\CARRENTRepository\CARRENT\CARRENT\Images\" + client.PermisFichier.FileName);
                    client.CheminImagePermis = client.PermisFichier.FileName;


                    db.Clients.Add(client);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = client.NomComplet + " a été inscrit(e) avec succès";
            }
            return View(client);
        }
        public ActionResult Login()
        {
            return View(new Client());
        }
        [HttpPost]
        public ActionResult Login(Client client)
        {
            using(db)
            {
                var cl = db.Clients.Single(c => c.AdresseMail == client.AdresseMail && c.MotDePasse == client.MotDePasse);
                if(cl!=null)
                {
                    Session["CLID"] = cl.CLID.ToString();
                    //this.SharedSession["CLID"] = cl.CLID.ToString();
                    Session["AdresseMail"] = cl.AdresseMail.ToString();
                    //this.SharedSession["AdresseMail"] = cl.AdresseMail.ToString();
                    Session["NomComplet"] = cl.NomComplet.ToString();
                    //this.SharedSession["NomComplet"] = cl.NomComplet.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Adresse Mail ou Mot de Passe invalide");
                }
            }
            return View(client);
        }
        public ActionResult LoggedIn()
        {
            if(Session["CLID"]!=null)
            {
                return View(new Client());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }
        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
            //if (ModelState.IsValid)
            //{
            client.CINFichier.SaveAs(@"C:\Users\ACER\Desktop\DOTNETCAR\CARRENTRepository\CARRENT\CARRENT\Images\" + client.CINFichier.FileName);
            client.CheminImageCIN = client.CINFichier.FileName;

            client.PermisFichier.SaveAs(@"C:\Users\ACER\Desktop\DOTNETCAR\CARRENTRepository\CARRENT\CARRENT\Images\" + client.PermisFichier.FileName);
            client.CheminImagePermis = client.PermisFichier.FileName;

            db.Entry(client).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            //}
            //return View(client);
        }
        // GET: Clients/Delete/5
        /*public ActionResult Delete(int id)
        {
            return View();
        }*/

        // GET: Clients/Delete/5
        //[HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }
        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}