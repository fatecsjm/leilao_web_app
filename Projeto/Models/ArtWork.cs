﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class ArtWork
    {
        [Key]
        public int Id { get; set; }
        public int Purpose { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Price> Price { get; set; }
        public virtual ICollection<Purchase> Purchase { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
        public virtual ICollection<Auction> Auction { get; set; }
        public virtual Artist Artist {get;set;}
        public virtual Finality Finality { get; set; }
        public virtual Category Category { get; set; }
     
    }
}