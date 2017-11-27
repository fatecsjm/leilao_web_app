using Projeto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Dtos
{
    public class ApplicationUserDto
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }
        

    }

}