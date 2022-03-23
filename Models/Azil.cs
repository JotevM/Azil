using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models
{
    public class Azil
    {
        [Key]
        public int ID{get; set;}
        [Required]
        [MaxLength(50)]
        public string naziv{get; set;}
        [Required]
        [RegularExpression("^[0-9]*$")]
        public string kontaktTelefon{get; set;}
        [Required]
        [MaxLength(50)]
        public string email{get; set;}
        [Required]
        [Range(9,18)]
        public int brZaposlenih{get; set;}
        [Required]
        [Range(10,50)]
        public int brZivotinja{get; set;}
        [JsonIgnore]
        public List<Zaposleni> Zaposlenii{get; set;}
        public List<Zivotinja> zivotinje{get; set;}
        
    }
}