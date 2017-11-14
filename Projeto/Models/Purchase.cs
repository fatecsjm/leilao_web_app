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

        public DateTime DateHour { get; set; }

        public virtual ICollection<ArtWork> ArtWork { get; set; }
        public virtual Address AddressUser { get; set; }
        public virtual Address Address { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual State State { get; set; }
    }
}