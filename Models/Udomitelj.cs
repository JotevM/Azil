using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;

namespace Models
{
    public class Udomitelj
    {
        [Key]
        public int ID{get; set;}
        [Required]
        [MaxLength(50)]
        public string imeU{get; set;}
        [Required]
        [MaxLength(50)]
        public string prezimeU{get; set;}
        [Required]
        [MaxLength(50)]
        public string adresaU{get; set;}
        [Required]
        [RegularExpression("^[0-9]*$")]
        public string brTelefonaU{get; set;}
        [Required]
        [RegularExpression("^[0-9]*$")]
        public long brLicneKarte{get; set;}
        [Required]
        [RegularExpression("^[0-9]*$")]
        public long JMBG{get; set;}
        public List<Zivotinja> Zivotinje{get; set;}

    }
}