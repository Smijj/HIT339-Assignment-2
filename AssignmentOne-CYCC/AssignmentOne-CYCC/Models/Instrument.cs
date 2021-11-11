using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentOne_CYCC.Models
{
    public class Instrument
    {
        public int Id { get; set; }
        [Display(Name = "Instrument Name"), Required]
        public string Name { get; set; }
        [Display(Name = "Instrument Family"), Required]
        public string Family { get; set; }
    }
}
