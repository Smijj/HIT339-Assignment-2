using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentOne_CYCC.Models
{
    public class Lesson
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

		[ForeignKey("Invoice")]
		public int? InvoiceId { get; set; }
		public Invoice? Invoice { get; set; }

		[Required, Display(Name = "Term")]
        public Terms term { get; set; }

        [Required, Display(Name = "Year")]
        public int year {
            get {
                return LessonTime.Year;
            }
        }

        [Required, Display(Name = "Lesson Date & Time")]
        public DateTime LessonTime { get; set; }

        public bool Paid { get; set; }
    }
}
