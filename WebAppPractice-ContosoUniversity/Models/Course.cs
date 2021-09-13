using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WebAppPractice_ContosoUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //allows the app to specify the primary key rather than having the database generate it.
        [Display(Name = "Number")]
        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0, 5)]
        public int Credits { get; set; }

        public int DepartmentID { get; set; } //FK Property

        public Department Department { get; set; } 
        public ICollection<Enrollment> Enrollments { get; set; } //A course can have many enrollments therefore this will collect all enrollements to ech CourseID
        public ICollection<Instructor> Instructors { get; set; }
    }
}
