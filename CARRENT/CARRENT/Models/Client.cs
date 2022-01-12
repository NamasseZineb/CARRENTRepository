using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CARRENT.Models
{
    [Table("cl")]
    public class Client
    {
        [Key]
        public int CLID { get; set; }

        [Required] // ==> NOT NULL
        [MinLength(4), MaxLength(100)]
        public string NomComplet { get; set; }

        [Required]
        [MaxLength(100)]
        [Index(IsUnique = true)]
        [EmailAddress]
        public string AdresseMail { get; set; }

        [Required]
        [MaxLength(100)]

        public string MotDePasse { get; set; }

        [Display(Name = "numéro téléphone:")]
        [Required(ErrorMessage = "Un numéro de téléphone est nécessaire.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Numéro de téléphone invalide.")]
        public string NuméroTéléphone { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DateNaissance { get; set; }

        [DisplayName("Upload File")]
        public string CheminImageCIN { get; set; }

        public HttpPostedFileBase CINFichier { get; set; }

        [DisplayName("Upload File")]
        public string CheminImagePermis { get; set; }

        public HttpPostedFileBase PermisFichier { get; set; }
    }
}