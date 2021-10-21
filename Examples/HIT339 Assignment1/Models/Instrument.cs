using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIT339_Assignment1.Models
{
    public class Instrument
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Instrument Name")]
        public string InstrumentName { get; set; }

    }
}
