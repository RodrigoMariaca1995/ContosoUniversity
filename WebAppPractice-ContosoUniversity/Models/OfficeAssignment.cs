﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPractice_ContosoUniversity.Models
{
    public class OfficeAssignment
    {
        [Key] //used to identify a property as the primary key (PK) when the property name is something other than classnameID or ID.
        public int InstructorID { get; set; }
        
        
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }


        public Instructor Instructor { get; set; } //Navigation Property
    }
}
