using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPractice_ContosoUniversity.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")] //used to change SQL data type mapping. The Budget column is defined using the SQL Server money type in the database
        public decimal Budget { get; set; }

        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        
        public int? InstructorID { get; set; } //is nullable

        [Timestamp] //identifies the column as a concurrency tracking column. 
        public byte[] ConcurrencyToken { get; set; }


        public Instructor Administrator { get; set; } //Navigation Property
        
        public ICollection<Course> Courses { get; set; }
    }
}
