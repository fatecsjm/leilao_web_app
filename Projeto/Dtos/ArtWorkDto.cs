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

        [Required]
        public int Artist_Id { get; set; }

        [Required]
        public int Finality_Id { get; set; }

        [Required]
        public int Category_Id { get; set; }



        [Required]
        public Artist Artist { get; set; }

        [Required]
        public FinalityDto Finality { get; set; }

        [Required]
        public CategoryDto Category { get; set; }

    }

}