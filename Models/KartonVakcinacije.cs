using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System;

namespace Models
{
    public class KartonVakcinacije
    {
        [Key]
        public int ID{get; set;}
        [Required]
        [MaxLength(50)]
        public string nazivVakcine{get; set;}
        [Required]
        public DateTime datumVakcinacije{get; set;}

        
    }
}