using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CARRENT.Models
{
    [Table("reserv")]
    public class Reservation
    {
        [Key]
        public int RID { get; set; }

        [Required]
        [StringLength(100)]
        public string typelocation { get; set; } //Courte ou Longue

        [Required]
        [Column(TypeName = "date")]
        public DateTime DateDebutLocation { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DateFinLocation { get; set; }

        [ForeignKey("Client")]
        public int CLID { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Voiture")]
        public int VID { get; set; }
        public Voiture Voiture { get; set; }
    }
}