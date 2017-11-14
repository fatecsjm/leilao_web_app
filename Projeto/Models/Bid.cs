using System;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Models
{
    public class Bid
    {
        [Key]
        public DateTime date_hour { get; set; }
        public int value { get; set; }

        [Key]
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Key]
        public virtual Auction Auction { get; set; }
    }
}