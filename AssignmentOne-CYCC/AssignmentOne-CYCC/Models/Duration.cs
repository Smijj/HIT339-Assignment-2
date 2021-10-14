using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentOne_CYCC.Models
{
    public class Duration
    {
        public int Id { get; set; }
        [Display(Name = "Duration (Min)", Description = "Time of lesson in minutes")]
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
