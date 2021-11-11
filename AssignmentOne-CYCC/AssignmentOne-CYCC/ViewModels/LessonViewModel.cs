using AssignmentOne_CYCC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentOne_CYCC.ViewModels
{
	public class LessonViewModel
	{
        public int Id { get; set; }

        [ForeignKey("Students"), Display(Name = "Student")]
        public int StudentId { get; set; }
        public virtual Students Students { get; set; }

        [ForeignKey("Instrument"), Display(Name = "Instrument")]
        public int InstrumentId { get; set; }
        public virtual Instrument Instrument { get; set; }

        [ForeignKey("Tutor"), Display(Name = "Tutor")]
        public int TutorId { get; set; }
        public virtual Tutor Tutor { get; set; }

        [ForeignKey("Duration"), Display(Name = "Duration")]
        public int DurationId { get; set; }
        public virtual Duration Duration { get; set; }

        [Display(Name = "Term"), RegularExpression("^[1-4]$", ErrorMessage = "Please enter a valid term number: 1,2,3,4")]
        public Terms term { get; set; }

        [Display(Name = "Lesson Date & Time")]
        public DateTime LessonTime { get; set; }
    }
}
