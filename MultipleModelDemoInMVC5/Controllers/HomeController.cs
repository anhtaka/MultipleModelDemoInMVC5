using MultipleModelDemo.Models;
using MultipleModelDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultipleModelDemo.Controllers
{
    public class HomeController : Controller
    {
        Repository _repository = new Repository();    
        
        public ActionResult ViewDataDemo()
        {
            ViewData["Courses"] = _repository.GetCourses();
            ViewData["Students"] = _repository.GetStudents();
            ViewData["Faculties"] = _repository.GetFaculties();
            return View();
        }  

        public ActionResult ViewBagDemo()
        {
            ViewBag.Courses = _repository.GetCourses();
            ViewBag.Students = _repository.GetStudents();
            ViewBag.Faculties = _repository.GetFaculties();

            return View();
        }

        public ActionResult TupleDemo()
        {
            var allModels = new Tuple<List<Course>, List<Faculty>, List<Student>>
                (_repository.GetCourses(), _repository.GetFaculties(), _repository.GetStudents()) { };

            return View(allModels);
        }

        public ActionResult ViewModelDemo()
        {
            ViewModelDemoVM vm = new ViewModelDemoVM();
            vm.allCourses = _repository.GetCourses();
            vm.allFaculties = _repository.GetFaculties();
            vm.allStudents = _repository.GetStudents();

            return View(vm);
        }

        # region PartialView Demo

        public ActionResult PartialViewDemo()
        {
            List<Course> allCourse = _repository.GetCourses();
            return View(allCourse);
        }

        public ActionResult StudentsToPVDemo(string courseName)
        {
            IEnumerable<Course> allCourses = _repository.GetCourses();
            var selectedCourseId = (from c in allCourses where c.CourseName == courseName select c.CourseId).FirstOrDefault();

            IEnumerable<Student> allStudents = _repository.GetStudents();
            var studentsInCourse = allStudents.Where(s => s.EnrolledCourses.Any(c => c.CourseId == selectedCourseId)).ToList();

            return PartialView("StudentPV", studentsInCourse);
        }

        public ActionResult FacultiesToPVDemo(string courseName)
        {
            IEnumerable<Course> allCourses = _repository.GetCourses();
            var selectedCourseId = (from c in allCourses where c.CourseName == courseName select c.CourseId).FirstOrDefault();

            IEnumerable<Faculty> allFaculties = _repository.GetFaculties();
            var facultiesForCourse = allFaculties.Where(f => f.AllotedCourses.Any(c => c.CourseId == selectedCourseId)).ToList();

            return PartialView("FacultyPV", facultiesForCourse);
        }

        # endregion

        # region TempData Demo

        public ActionResult TempDataDemo()
        {
            // TempData demo uses repository to get List<courses> only one time
            // for subsequent request to get List<courses> it will use TempData
            TempData["Courses"] = _repository.GetCourses();

            // This will keep Courses data untill next request is served
            TempData.Keep("Courses");
            return View();
        }

        public ActionResult FacultiesToTempDataDemo(string courseName)
        {
            var allCourses = TempData["Courses"] as IEnumerable<Course>;

            // Since there are two AJAX call on TempDataPage
            // So we keep to keep Courses data for the next one
            TempData.Keep("Courses");
            var selectedCourseId = (from c in allCourses where c.CourseName == courseName select c.CourseId).FirstOrDefault();

            IEnumerable<Faculty> allFaculties = _repository.GetFaculties();
            var facultiesForCourse = allFaculties.Where(f => f.AllotedCourses.Any(c => c.CourseId == selectedCourseId)).ToList();

            return PartialView("FacultyPV", facultiesForCourse);
        }

        public ActionResult StudentsToTempDataDemo(string courseName)
        {
            var allCourses = TempData["Courses"] as IEnumerable<Course>;

            // If there is change in course again...it may cause more AJAX calls
            // So we need to keep Courses data
            TempData.Keep("Courses");

            var selectedCourseId = (from c in allCourses where c.CourseName == courseName select c.CourseId).FirstOrDefault();

            IEnumerable<Student> allStudents = _repository.GetStudents();
            var studentsInCourse = allStudents.Where(s => s.EnrolledCourses.Any(c => c.CourseId == selectedCourseId)).ToList();

            return PartialView("StudentPV", studentsInCourse);
        }

        # endregion
   
    }
}