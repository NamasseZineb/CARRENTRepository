using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CARRENT.Models
{
    [Table("car")]
    public class Voiture
    {
        [Key]
        public int VID { get; set; }

        [Required]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string numéroimmattriculation { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DateMiseCirculation { get; set; }

        [Required]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string TypeCarburant { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double PrixLocationJournalier { get; set; }

        [DisplayName("Upload File")]
        public string CheminImage { get; set; }

        public HttpPostedFileBase ImageFichier { get; set; }

        [ForeignKey("Modele")]
        public int MID { get; set; }
        public Modele Modele { get; set; }

        [ForeignKey("Categorie")]
        public int CID { get; set; }
        public Categorie Categorie { get; set; }
    }
}