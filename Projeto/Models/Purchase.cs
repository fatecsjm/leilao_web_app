using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }

        [Required]
        public DateTime DateHour { get; set; }

        [Required]
        public virtual ICollection<ArtWork> ArtWork { get; set; }

        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }
        //public virtual Address AddressUser { get; set; }

        [Required]
        public virtual Address Address { get; set; }

        [Required]
        public virtual PaymentMethod PaymentMethod { get; set; }

        [Required]
        public virtual State State { get; set; }
    }
}