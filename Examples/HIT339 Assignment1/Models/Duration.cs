using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIT339_Assignment1.Models
{
    public class Duration
    {
        [Key]
        public int Id { get; set; }

        [Required, DataType(DataType.Duration), Display(Name = "Lesson Duration (Hrs)")]
        public int LessonDuration { get; set; }

        [Required, DataType(DataType.Currency), Display(Name = "Cost ($/hr)")]
        public int Cost { get; set; }

        public string DisplayInfo {
            get {
                return LessonDuration + "hr(s) @ $" + Cost + "/hr";
            }
        }

        public int lessonCost {
            get {
                return LessonDuration * Cost;
            }
        }

    }
}
