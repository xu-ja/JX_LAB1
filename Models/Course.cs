using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JX_LAB1.Models
{
    public class Course
    {

        public List<string> EnrolledStudents { get; set; } = new List<string>();

        [Required(ErrorMessage = "Please enter a course code")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public double NumOfCredits { get; set; }

        public void AddEnrolledStudent(string studentNum)
        {
            EnrolledStudents.Add(studentNum);
        }

        public void DropEnrolledStudent(string studentNum)
        {
            foreach (string sNum in EnrolledStudents)
            {
                if (sNum.Equals(studentNum))
                {
                    EnrolledStudents.Remove(sNum);
                    break;
                }
            }
        }
    }
}
