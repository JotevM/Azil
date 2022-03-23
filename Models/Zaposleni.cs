using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;

namespace Models
{
    public class Zaposleni
    {
        [Key]
        public int ID{get; set;}
        [Required]
        [MaxLength(50)]
        public string ime{get; set;}
        [Required]
        [MaxLength(50)]
        public string prezime{get; set;}
        [Required]
        [MaxLength(50)]
        public string adresa{get; set;}
        [Required]
        [RegularExpression("^[0-9]*$")]
        public long jmbg{get; set;}
        public Azil Azil{get; set;}
        public List<Zivotinja> Zivotinje{get; set;}
        
    }
}
  