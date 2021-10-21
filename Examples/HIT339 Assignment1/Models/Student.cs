using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIT339_Assignment1.Models
{

    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name"), Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name"), Required]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName {
            get { return FirstName + " " + LastName; }
        }

        [Required, DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public UserGender Gender { get; set; }

        [Required, Display(Name = "Guardian Name")]
        public string GuardianName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public int CalculateAge() {
            int age = DateTime.Today.Year - DOB.Year;

            // For leap years we need this
            if (DOB > DateTime.Today.AddYears(-age))
                age--;

            return age;
        }
    }
}