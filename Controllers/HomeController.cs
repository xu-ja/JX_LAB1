using JX_LAB1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JX_LAB1.Controllers
{
    public class HomeController : Controller
    {

        private CoursesAndStudents CoursesAndStudents; // Model to hold all information

        public HomeController(CoursesAndStudents coursesAndStudents)
        {
            CoursesAndStudents = coursesAndStudents; // Links model to service
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCourse()
        {
            return View(new Course());
        }

        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            if (ModelState.IsValid) // Adds course if model state is valid
            {
                CoursesAndStudents.AddCourse(course);
                return RedirectToAction("AddStudent", CoursesAndStudents); // Redirects AddStudent view and passes model
            } else
            {
                return View();
            }

        }

        public IActionResult AddStudent()
        {
            return View(new Student());
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid) { // Adds student if model state is valid
                CoursesAndStudents.AddStudent(student);
                return View("EnrollStudent", CoursesAndStudents); // Redirects to EnrollStudent view and passes model 
            } else
            {
                return View();
            }
        }

        public IActionResult EnrollStudent()
        {
            return View(CoursesAndStudents);
        }

        [HttpPost]
        public IActionResult EnrollStudent(CoursesAndStudents coursesAndStudents, IFormCollection form)
        {
            // Stores variables from View to be used by this controller
            string cCode = form["courses"].ToString();
            string sNum = form["students"].ToString();

            foreach (Student s in CoursesAndStudents.Students) // Iterates through every student object
            {
                if (s.StudentNumber.Equals(sNum)) // Adds the course when matching student ID is found
                {
                    s.AddSelectedCourse(cCode);
                }
            }
            foreach (Course c in CoursesAndStudents.Courses) // Iterates through every course object
            {
                if (c.CourseCode.Equals(cCode)) // Adds the student number to course when matching student number is found
                {
                    c.AddEnrolledStudent(sNum);
                }
            }
            return View("SummaryPage", CoursesAndStudents); // Redirects to SummaryPage and passes model
        }

        public IActionResult DropStudent()
        {
            return View(CoursesAndStudents);
        }

        [HttpPost]
        public IActionResult DropStudent(CoursesAndStudents coursesAndStudents, IFormCollection form)
        {
            string sNum = form["students"].ToString(); // Stores input from view so it can be used by this controller
            ViewBag.sNum = sNum; // Passes student number to View in a ViewBag
            return View("RemoveCourse", CoursesAndStudents); // Redirects to RemoveCourse and passes model
        }

        public IActionResult RemoveCourse()
        {
            return View(CoursesAndStudents);
        }

        [HttpPost]
        public IActionResult RemoveCourse(CoursesAndStudents coursesAndStudents, IFormCollection form)
        {
            // Gets values from view to be used by this controller
            string sNum = TempData["sNum"].ToString();
            string cCode = form["courses"].ToString();
            foreach (Course c in CoursesAndStudents.Courses) // Iterates through every course in model
            {
                if (c.CourseCode.Equals(cCode)) // Drops student from course list if matching student number is found
                {
                    c.DropEnrolledStudent(sNum);
                }
            }
            foreach (Student s in CoursesAndStudents.Students) // Iterates through every student in model
            {
                if (s.StudentNumber.Equals(sNum)) // Removes course from student's course list if matching course code is found
                {
                    s.DropSelectedCourse(cCode);
                }
            }
            return View("SummaryPage", CoursesAndStudents); // Redirects to SummaryPage and passes model
        }

        public IActionResult SummaryPage()
        {
            return View(CoursesAndStudents);
        }

    }
}
