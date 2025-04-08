using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StepsMVC.Models;
using StepsMVC.ViewModels;

namespace StepsMVC.Controllers
{
    public class TraineeController : Controller
    {
        AssignmentG1mvcContext context = new AssignmentG1mvcContext();
        public IActionResult Index()
        {
            var Trainees = context.Trainees.ToList();

            return View("Index", Trainees);
        }


        //Trainee/Result?id=1&&cid=3
        public IActionResult Result(int id,int cId)
        {
            var trainee = context.Trainees.FirstOrDefault(t=>t.Id == id); // returen Trainee obj to get Name
            //TraineeName = trainee.Name
            var traineeCourses = context.CrsResults.Where(cr=>cr.TraineeId == id);
            bool courseIsFound = false;
            foreach(var item in traineeCourses)
            {
                if(item.CourseId == cId)
                {
                    courseIsFound = true;
                }
            }
            var course = context.Courses.FirstOrDefault(c=>c.Id == cId);
            //CourseName = course.Name

            var MinimumDegree = course.MinDegree; // get Minimum Degree for Compare Pass or Fail
            
            var CrsResultObj = context.CrsResults.FirstOrDefault(c=>c.Id == cId);
            //Degree => CrsResultObj.Degree

            var Status = CrsResultObj.Degree > MinimumDegree;
            //Status Pass = No Table

            TraineeResultDegreeStatusViewModel viewModel = new TraineeResultDegreeStatusViewModel();
            viewModel.TraineeName = trainee.Name;
            if (courseIsFound)
            {
                viewModel.CourseName = course.Name;
            }
            else
            {
                viewModel.CourseName = "Course Not Founded";
            }
            viewModel.Degree = course.Degree;
            if(Status == true)
            {
                viewModel.Status = "Pass";
                viewModel.StyleColor = "bg-success";
            }

            return View("Result", viewModel);
            
        }








    }
}
