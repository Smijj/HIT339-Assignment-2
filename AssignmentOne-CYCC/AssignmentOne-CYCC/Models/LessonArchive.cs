using System;
using System.ComponentModel.DataAnnotations;

namespace AssignmentOne_CYCC.Models
{
    public class LessonArchive
    {
        [Key]
        public int Id { get; set; } 
        public int InvoiceArchiveId { get; set; }
        public InvoiceArchive InvoiceArchive { get; set; }
        public int Year
        {
            get
            {
                return LessonTime.Year;
            }
        }
        [Display(Name = "Lesson Date & Time")]
        public DateTime LessonTime { get; set; }
        public bool Paid { get; set; }

        // ========== Duration Data ============
        public int LessonDuration { get; set; }
        [DataType(DataType.Currency), Display(Name = "Cost")]
        public float cost { get; set; }

        public string DurationCost
        {
            get
            {
                return LessonDuration + " min - $" + cost;
            }
        }
    }
}
