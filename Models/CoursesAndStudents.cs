using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JX_LAB1.Models
{
    public class CoursesAndStudents
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Course> Courses { get; set; } = new List<Course>();

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void AddCourse(Course course)
        {
            Courses.Add(course);
        }
    }
}
