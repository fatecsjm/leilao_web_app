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
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MinValue { get; set; }

        public virtual ArtWork ArtWork { get; set; }
        public virtual AuctionState AuctionState { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
    }
}