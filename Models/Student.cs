using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JX_LAB1.Models
{
    public class Student
    {
        public List<string> SelectedCourses { get; set; } = new List<string>();

        [Required(ErrorMessage = "Please enter a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a student name")]
        public string StudentNumber { get; set; }

        public void AddSelectedCourse(string course)
        {
            SelectedCourses.Add(course);
        }

        public void DropSelectedCourse(string course)
        {
            foreach (string c in SelectedCourses)
            {
                if (c.Equals(course))
                {
                    SelectedCourses.Remove(c);
                    break;
                }
            }
        }
    }
}
