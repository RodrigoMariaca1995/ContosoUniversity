using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPractice_ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")] //max character = 50
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")] //First letter must be capital and all must be letters only
        public string LastName { get; set; }
        
        
        [Required]
        [StringLength(50)]
        [Column("FirstName")] //used to map the name of the FirstMidName property to "FirstName" in the database.
        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string FirstMidName { get; set; }
       
        
        [DataType(DataType.Date)] //sets the data to date only instead of date and time
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] //used to explicitly specify the date format.
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        
        
        [Display(Name = "Full Name")]
        public string FullName //full name can't be set so there's only get
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public ICollection<Enrollment> Enrollments { get; set; }
        //Student is in a relationship with Enrollment so to obtain the enrolment data for a student, an Enrollment property must be used.
        //The Enrollments property is defined as ICollection<Enrollment> because there may be multiple related Enrollment entities.
    }
}
        

