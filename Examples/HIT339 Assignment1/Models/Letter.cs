using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIT339_Assignment1.Models {

    

    public class Letter {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student"), Display(Name = "Student")]
        public int StudentId { get; set; }

        [Display(Name = "Comment")]
        [DataType(DataType.MultilineText)]
        public string comment { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string email { get; set; }

        [Display(Name = "Bank Name")]
        public string bankName { get; set; }

        [Display(Name = "Account Name")]
        public string accountName { get; set; }

        [Display(Name = "BSB")]
        //[MaxLength(6)]
        public int bsb { get; set; }

        [Display(Name = "Account Number")]
        public int accountNumber { get; set; }

        [Required]
        [Display(Name = "Current Term")]
        //[MaxLength(30)]
        public Terms currentTerm { get; set; }

        [Display(Name = "Current Semester")]
        public int currentSemester { 
            get {
                int semester;

                if (currentTerm == Terms.Term1 || currentTerm == Terms.Term2)
                    semester = 1;
                else if (currentTerm == Terms.Term3 || currentTerm == Terms.Term4)
                    semester = 2;
                else
                    return 0;
                
                return semester;
            }
        }

        [Display(Name = "Current Year")]
        //[MinLength(4), MaxLength(4)]
        public int currentYear { get; set; }

        [Display(Name = "Term Start Date")]
        public DateTime termStartDate { get; set; }


        public string Reference {
            get {
                if (student != null)
                    return currentYear + student.LastName + Id;
                return currentYear + "-" + Id;
            }
        }

        [Display(Name = "Student")]
        public virtual Student student { get; set; }
        /*[Display(Name = "Lessons")]
        public virtual ICollection<Lesson> lessons { get; set; }*/

    }
}
