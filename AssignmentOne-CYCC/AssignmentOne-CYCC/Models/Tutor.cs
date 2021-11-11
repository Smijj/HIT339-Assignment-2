using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentOne_CYCC.Models
{
    public class Tutor
    {
        public int Id { get; set; }
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
        [DataType(DataType.PhoneNumber), Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }
    }
}
