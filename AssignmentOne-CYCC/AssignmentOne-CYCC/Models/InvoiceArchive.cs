using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssignmentOne_CYCC.Models
{
    public class InvoiceArchive
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Reference Number")]
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
        [Display(Name = "Term Start Date")]
        public DateTime TermStartDate { get; set; }

        [DataType(DataType.Date), Display(Name = "Final Payment Date")]
        public DateTime PaymentFinalDate { get; set; }

        [Display(Name = "Total Cost")]
        public float TotalCost { get; set; }

        [Display(Name = "Invoice Paid")]
        public bool InvoicePaid { get; set; }

        // ========== Student Data ============

        [Display(Name = "First Name")]
        public string StudentFName { get; set; }
        [Display(Name = "Last Name")]
        public string StudentLName { get; set; }
        [Display(Name = "Student Name")]
        public string StudentFullName { get { return StudentFName + " " + StudentLName; } }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Parent/Guardian Name")]
        public string GuardianName { get; set; }
        [DataType(DataType.EmailAddress), Display(Name = "Guardian Email Address")]
        public string GuardianEmail { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Guardian Phone Number")]
        public string GuardianPhoneNumber { get; set; }
    }
}
