using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Models
{
    public class Price
    {
        [Key, Column(Order =1)]
        public DateTime DateHour { get; set; }


        //public int value { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{}")]
        public Decimal Value { get; set; }

        [Key]
        public virtual ArtWork ArtWork { get; set; }
    }
}