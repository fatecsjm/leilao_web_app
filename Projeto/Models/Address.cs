using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string ZipCode { get; set; }
        public int AddressNumber { get; set; }
        public DateTime Date { get; set; }

        [Key]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; } 
    }
}