using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CARRENT.Models
{
    [Table("cat")]
    public class Categorie
    {
        [Key]
        public int CID { get; set; }

        [Required]
        [StringLength(100)]
        public string taille { get; set; } //Petite, Moyenne, Grande
    }
}