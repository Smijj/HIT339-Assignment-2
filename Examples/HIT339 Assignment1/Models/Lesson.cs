using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIT339_Assignment1.Models
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student"), Display(Name = "Student")]
        public int studentID { get; set; }

        [ForeignKey("Instrument"), Display(Name = "Instrument")]
        public int instrumentID { get; set; }

        [ForeignKey("Tutor"), Display(Name = "Tutor")]
        public int tutorID { get; set; }

        [Required]
        public Terms Term { get; set; }
       
        /*[Required, DataType(DataType.Date)]
        public DateTime Year { get; set; }*/

        [Required, DataType(DataType.DateTime), Display(Name = "Date & Time")]
        public DateTime dateTime { get; set; }

        [ForeignKey("Duration"), Display(Name = "Duration")]
        public int durationID { get; set; }

        [Display(Name = "Paid")]
        public bool isPaid { get; set; }



        [Display(Name = "Student")]
        public virtual Student student { get; set; }
        [Display(Name = "Instrument")]
        public virtual Instrument instrument { get; set; }
        [Display(Name = "Tutor")]
        public virtual Tutor tutor { get; set; }
        [Display(Name = "Duration")]
        public virtual Duration duration { get; set; }

        /*[Display(Name = "Letter")]
        public virtual Letter letter { get; set; }*/
    }
}
