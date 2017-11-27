using Projeto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Dtos
{
    public class AuctionDto
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
        public virtual ArtWorkDto ArtWork { get; set; }

        [Required]
        public virtual AuctionStateDto AuctionState { get; set; }

    }
}