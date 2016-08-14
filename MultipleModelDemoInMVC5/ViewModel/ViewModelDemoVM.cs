using MultipleModelDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultipleModelDemo.ViewModel
{
    public class ViewModelDemoVM
    {
        public List<Course> allCourses { get; set; }
        public List<Student> allStudents { get; set; }
        public List<Faculty> allFaculties { get; set; }
    }
}