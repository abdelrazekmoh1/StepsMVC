using Microsoft.AspNetCore.Mvc;
using StepsMVC.Models;

namespace StepsMVC.Controllers
{
    public class InstructorController : Controller
    {
        AssignmentG1mvcContext context = new AssignmentG1mvcContext();
        public IActionResult Index()
        {
            var Instructors = context.Instructors.ToList();

            return View("Index", Instructors);
        }


        public IActionResult Details(int id)
        {
            var Instructor = context.Instructors.FirstOrDefault(i=>i.Id == id);

            return View("Details", Instructor);
        }




    }
}
