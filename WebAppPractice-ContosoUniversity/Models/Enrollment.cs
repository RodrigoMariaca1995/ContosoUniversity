using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppPractice_ContosoUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        
        public int CourseID { get; set; } //Enrollment is associated with only one course so the property contains a single Course entity
       
        public int StudentID { get; set; } //Enrollment is associated with only one student so the property contains a single Student entity
        
        
        [DisplayFormat(NullDisplayText = "No grade")] //Displays "No grade" when a NULL is assigned
        public Grade? Grade { get; set; } // the ? indicates that it can be NULL

        public Course Course { get; set; }
       
        public Student Student { get; set; }
    }
}
