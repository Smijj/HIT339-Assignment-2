using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public string TutorFName { get; set; }
        [Display(Name = "Last Name"), StringLength(200)]
        public string TutorLName { get; set; }
        public string TutorFullName
        {
            get
            {
                return TutorFName + " " + TutorLName;
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
        public string StudentFName { get; set; }
        [Display(Name = "Last Name")]
        public string StudentLName { get; set; }
        public string StudentFullName { get { return StudentFName + " " + StudentLName; } }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Parent/Guardian name")]
        public string GuardianName { get; set; }
        [DataType(DataType.EmailAddress), Display(Name = "Guardian email address")]
        public string GuardianEmail { get; set; }
        [DataType(DataType.PhoneNumber)]
        public int GuardianPhoneNumber { get; set; }
    }
}
