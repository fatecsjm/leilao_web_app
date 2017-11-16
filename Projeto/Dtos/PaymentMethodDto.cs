using Projeto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Dtos
{
    public class PaymentMethodDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        //public virtual ICollection<Purchase> Purchase { get; set; }
    }

}