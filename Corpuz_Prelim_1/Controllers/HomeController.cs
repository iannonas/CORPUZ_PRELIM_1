using System.Diagnostics;
using Corpuz_Prelim_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Corpuz_Prelim_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Task 1: Variables
            string studentName = "Ian B. Corpuz";
            int score = 87;
            bool isPassed = (score >= 75);
            DateTime examDate = DateTime.Now;
            decimal tuitionFee = 15500.75m;

            ViewBag.StudentName = studentName;
            ViewBag.Score = score;
            ViewBag.IsPassed = isPassed;
            ViewBag.ExamDate = examDate;
            ViewBag.TuitionFee = tuitionFee;

            // Task 2: Control Structures
            string grade;
            string message;

            if (score >= 90)
                grade = "A";
            else if (score >= 80)
                grade = "B";
            else if (score >= 75)
                grade = "C";
            else
                grade = "F";

            message = isPassed ? "Congratulations, you passed!" : "Better luck next time.";

            ViewBag.Grade = grade;
            ViewBag.Message = message;

            // Task 3: Loops and Collections
            string[] courses = { "Web Systems", "OOP", "DBMS", "UI/UX", "Networking" };
            string courseList = string.Join(", ", courses);
            int courseCount = courses.Length;

            ViewBag.CourseList = courseList;
            ViewBag.CourseCount = courseCount;

            // Task 4: Methods
            ViewBag.NetFee = ComputeNetFee(tuitionFee, 10);

            // Bonus Task
            ViewBag.Today = DateTime.Now.ToString("MMMM dd, yyyy");

            // Task 5: Single Student
            Student student = new Student
            {
                Name = "Enzo Raquem",
                Age = 20,
                Course = "Web Systems"
            };
            ViewBag.Student = student;

            // Task 6: List of Students
            List<Student> students = new List<Student>
            {
                new Student { Name = "Kian Nolasco", Age = 20, Course = "Web Systems" },
                new Student { Name = "Alexa Mei Ardeza", Age = 21, Course = "OOP" },
                new Student { Name = "Alexa Climaco", Age = 22, Course = "DBMS" }
            };
            ViewBag.Students = students;

            return View();
        }

        private decimal ComputeNetFee(decimal tuition, decimal discountPercent)
        {
            return tuition - (tuition * discountPercent / 100);
        }
        

        public IActionResult AboutMe()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
