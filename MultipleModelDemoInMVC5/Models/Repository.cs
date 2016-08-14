using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultipleModelDemo.Models
{
    public class Repository
    {
        public List<Course> GetCourses()
        {
            return new List<Course> { 
                            new Course () {  CourseId = 1, CourseName = "Chemistry"}, 
                            new Course () {  CourseId = 2, CourseName = "Physics"},
                            new Course () {  CourseId = 3, CourseName = "Math" },
                            new Course () {  CourseId = 4, CourseName = "Computer Science" }
    };
        }
        public List<Faculty> GetFaculties()
        {
            return new List<Faculty> {                 
                            new Faculty () {  FacultyId = 1, FacultyName= "Prakash",
                                AllotedCourses = new List<Course> 
                                {new Course () { CourseId = 1, CourseName = "Chemistry"},
                                                 new Course () { CourseId = 2, CourseName = "Physics"},
                                                 new Course () { CourseId = 3, CourseName = "Math"},
                            }}, 
                            new Faculty () {  FacultyId = 2, FacultyName= "Ponty" ,
                                AllotedCourses = new List<Course> 
                                {new Course () { CourseId = 2, CourseName = "Physics"},
                                                 new Course () { CourseId = 4, CourseName = "Computer Science"}
                            }},
                            new Faculty () {  FacultyId = 3, FacultyName= "Methu", 
                                AllotedCourses = new List<Course> 
                                {new Course () { CourseId = 3, CourseName = "Math"},
                                                 new Course () { CourseId = 4, CourseName = "Computer Science"}
                            }}
    };
        }
        public List<Student> GetStudents()
        {
            List<Student> result = new List<Student> { 
                                        new Student () { EnrollmentNo = 1, StudentName= "Jim", 
                                            EnrolledCourses = new List<Course> 
                                            { new Course () { CourseId = 1, CourseName = "Chemistry"},
                                                              new Course () { CourseId = 2, CourseName = "Physics"},
                                                              new Course () { CourseId = 4, CourseName = "Computer Science"}
                                        }},
        
                                        new Student () {  EnrollmentNo = 2, StudentName= "Joli",
                                            EnrolledCourses = new List<Course> 
                                            { new Course () { CourseId = 2, CourseName = "Physics"} ,
                                                              new Course () 
                                                              { CourseId = 4, CourseName = "Computer Science"}
                                        }},
        
                                        new Student () {  EnrollmentNo = 3, StudentName= "Mortin",
                                            EnrolledCourses = new List<Course>
                                            {  new Course () { CourseId = 3, CourseName = "Math"},
                                                               new Course () { CourseId = 4, CourseName = "Computer Science"}
                                        }}
                                };

            return result;
        }
    }
}