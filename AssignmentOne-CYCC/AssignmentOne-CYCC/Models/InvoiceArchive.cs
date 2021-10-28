using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentOne_CYCC.Models
{
    public class InvoiceArchive
    {
        [Key]
        public int Id { get; set; }
        public string ReferenceNo { get; set; }
        public string Comment { get; set; }
        public string Signature { get; set; }
        public string Bank { get; set; }
        public string AccountName { get; set; }
        [Display(Name = "Account Number")]
        public string AccountNo { get; set; }
        public string BSB { get; set; }
        public int Term { get; set; }
        public int Year { get; set; }
        public int Semester
        {
            get
            {
                if (Term > 2)
                {
                    return 2;
                }
                return 1;
            }
        }
        [DataType(DataType.Date)]
        public DateTime TermStartDate { get; set; }
        [DataType(DataType.Date), Display(Name = "Final Payment Date")]
        public DateTime PaymentFinalDate { get; set; }
        public float TotalCost { get; set; }
        public bool InvoicePaied { get; set; }

        // ========== Lesson Data ============

        public ICollection<LessonArchive> lessonArchives { get; set; }

        // ========== Tutor Data ============

        [Display(Name = "First Name"), StringLength(200)]
        public string fName { get; set; }
        [Display(Name = "Last Name"), StringLength(200)]
        public string lName { get; set; }
        public string fullName
        {
            get
            {
                return fName + " " + lName;
            }
        }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        // ========== Instrument Data ============

        public string Name { get; set; }
        [Display(Name = "Instrument Family")]
        public string Family { get; set; }

        // ========== Student Data ============

        [Display(Name = "First Name")]
        public string FName { get; set; }
        [Display(Name = "Last Name")]
        public string LName { get; set; }
        public string FullName { get { return FName + " " + LName; } }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Parent/Guardian name")]
        public string GuardianName { get; set; }
        [DataType(DataType.EmailAddress), Display(Name = "Gardian email address")]
        public string GuardianEmail { get; set; }
        [DataType(DataType.PhoneNumber)]
        public int GuardianPhoneNumber { get; set; }
    }
    public class LessonArchive
    {
        [Key]
        public int Id;
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
