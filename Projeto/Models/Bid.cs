﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Models
{
    public class Bid
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

        [Key]
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Key]
        public virtual Auction Auction { get; set; }
    }
}