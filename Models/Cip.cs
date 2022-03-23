using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;

namespace Models
{
    public class Cip
    {
        [Key]
        public int ID{get; set;}

        [Required]
        [RegularExpression("^(?:m|M|z|Z)$")]
        public string polZ{get; set;}
        [Required]
        public int brGodina{get; set;}
        [Required]
        [RegularExpression("^(?:macka|Macka|pas|Pas)$")]
        public string vrstaZ{get; set;}

    }
}