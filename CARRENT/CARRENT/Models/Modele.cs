using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CARRENT.Models
{
    [Table("model")]
    public class Modele
    {
        [Key]
        public int MID { get; set; }

        [Required]
        [StringLength(100)]
        public string nommarque { get; set; }

        [Required]
        [StringLength(100)]
        //[Index(IsUnique = true)]
        public string numérosérie { get; set; }
    }
}