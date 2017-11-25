using Projeto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Dtos
{
    public class ArtWorkDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        public string Description { get; set; }

        public string Image { get; set; }

        //aqui vai dar problema?
        public Price Price { get; set; }

        [Required]
        public Artist Artist { get; set; }

        [Required]
        public Finality Finality { get; set; }

        [Required]
        public Category Category { get; set; }

    }

}