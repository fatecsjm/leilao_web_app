using Projeto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Dtos
{
    public class BidDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateHour { get; set; }

        //public int value { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{}")]
        public Decimal Value { get; set; }

        public virtual ApplicationUserDto ApplicationUser { get; set; }

        public virtual AuctionDto Auction { get; set; }
    }

}