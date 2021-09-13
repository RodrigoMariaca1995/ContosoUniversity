using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//used to display data in instructor index page
namespace WebAppPractice_ContosoUniversity.Models.SchoolViewModels
{
    public class InstructorIndexData
    {
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
