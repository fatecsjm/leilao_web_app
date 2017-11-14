using System;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Models
{
    public class ShoppingCart
    { 
        public int Id { get; set; }
        [Key]
        public virtual ArtWork Artwork { get; set; }
        [Key]
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Required]
        public DateTime InsertionDate { get; set; }
    }
}