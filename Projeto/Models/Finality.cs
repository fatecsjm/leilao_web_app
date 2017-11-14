using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class Finality
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ArtWork> Artwork { get; set; }
    }
}