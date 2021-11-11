using System;
using System.ComponentModel.DataAnnotations;

namespace AssignmentOne_CYCC.Models
{
	public class Students
	{
		[Key]
		public int Id { get; set; }

		[Required, StringLength(200), Display(Name = "First Name")]
		public string FName { get; set; }

		[Required, StringLength(400), Display(Name = "Last Name")]
		public string LName { get; set; }

		public string FullName {
			get {
				return FName + " " + LName;
			}
		}

		[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Date of Birth")]
		public DateTime DateOfBirth { get; set; }

		public int Age {
			get {
				// https://stackoverflow.com/questions/9/how-do-i-calculate-someones-age-based-on-a-datetime-type-birthday
				//DateTime now = DateTime.Today;
				//int age = now.Year - DateOfBirth.Year;
				//if (now < DateOfBirth.AddYears(age)) {
				//	age--;
				//}
				//return age;
				return (int.Parse(DateTime.Now.ToString("yyyyMMdd")) - int.Parse(DateOfBirth.ToString("yyyyMMdd"))) / 10000;
			} set { }
		}

        [Required]
		public UserGender Gender { get; set; }

		[Required, StringLength(200), Display(Name = "Parent/Guardian name")]
		public string GuardianName { get; set; }

		[Required, DataType(DataType.EmailAddress), Display(Name = "Payment Contact Email Address")]
		public string Email { get; set; }

		[DataType(DataType.PhoneNumber), Display(Name = "Phone Number")]
		public int PhoneNumber { get; set; }

		// Link to lesson
	}
}
