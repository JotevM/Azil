using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;

namespace Models
{
    public class Zivotinja
    {
        [Key]
        public int ID{get; set;}
        [Required]
        [MaxLength(50)]
        public string imeZ{get; set;}
        [Required]
        [RegularExpression("^[0-9]*$")]
        public int brKartonaVakc{get; set;}
        [Required]
        [RegularExpression("^[0-9]*$")]
        public int brCipa{get; set;}
        public Zaposleni Zaposleni{get; set;}
        [JsonIgnore]
        public Cip Cip{get; set;}
        public KartonVakcinacije KartonVakcinacije{get; set;}
        [JsonIgnore]
        public Azil Azil{get; set;}
        public Udomitelj Udomitelj{get; set;}
        

    }
}