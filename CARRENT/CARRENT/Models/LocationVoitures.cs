using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CARRENT.Models;

namespace CARRENT.Models
{
    public class LocationVoitures : DbContext
    {
        public LocationVoitures() : base("name=LocationVoitures")
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Voiture> Voitures { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Modele> Modeles { get; set; }

    }
}