using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class Auction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime InitialDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int MinValue { get; set; }

        [Required]
        public virtual ArtWork ArtWork { get; set; }

        [Required]
        public virtual AuctionState AuctionState { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }
    }
}