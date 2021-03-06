using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AssignmentOne_CYCC.Models
{
    public class Invoice {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Student"), ForeignKey("Students")]
        public int StudentId { get; set; }
        public virtual Students Student { get; set; }

		public ICollection<Lesson> Lesson { get; set; }

        [Display(Name = "Reference Number")]
        public string ReferenceNo { 
            get
            {
                if (Student != null)
                    return Year + Student.LName + Id;
                return Year + "---" + Id;
            }
        }

        public string Comment { get; set; }
        public string Signature { get; set; }

        public string Bank { get; set; }
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }

        [Display(Name = "Account Number"), RegularExpression("^[0-9]{30,30}$", ErrorMessage = "Please enter a valid 30 digit numeric Account Number."), StringLength(30)]
        public string AccountNo { get; set; }

        [RegularExpression("^[0-9]{6,6}$", ErrorMessage = "Must be a valid six digit BSB number"), StringLength(6)]
        public string BSB { get; set; }

        [Display(Name = "Current Term")]
        public Terms Term { get; set; }

        public int displayTerm {
            get {
                return (int)Term;
            }
        }
        
        [RegularExpression("^20[0-9][0-9]$", ErrorMessage = "Please enter a valid year: 20XX.")]
        public int Year { get; set; }
        
        public int Semester {
            get {
                if (Term == Terms.Term3 || Term == Terms.Term4) {
                    return 2;
                }
                return 1;
            }
        }

        [DataType(DataType.Date), Display(Name = "Term Start Date")]
        public DateTime TermStartDate { get; set; }

        [DataType(DataType.Date), Display(Name = "Final Payment Date")]
        public DateTime PaymentFinalDate { get; set; }

        [Display(Name = "Total Cost")]
        public float TotalCost {
            get
            {
                float costs = 0;
                if (Lesson != null)
                    foreach (var item in Lesson)
                    {
                        costs += item.Duration.cost;
                    }
                return costs;
            }
        }
        public bool InvoicePaid {
            get {
                if (Lesson != null) {
				    foreach (var item in Lesson) {
                        if (!item.Paid)
                            return false;
				    }
				}
                return true;
			}
		}
    }
}

