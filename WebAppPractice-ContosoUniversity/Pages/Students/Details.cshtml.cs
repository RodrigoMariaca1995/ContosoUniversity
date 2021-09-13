using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppPractice_ContosoUniversity.Data;
using WebAppPractice_ContosoUniversity.Models;

namespace WebAppPractice_ContosoUniversity.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly WebAppPractice_ContosoUniversity.Data.SchoolContext _context;

        public DetailsModel(WebAppPractice_ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students
                    .Include(s => s.Enrollments) //The Include and ThenInclude methods cause the context to load the Student.Enrollments navigation property, and within each enrollment the Enrollment.Course navigation property. 
                    .ThenInclude(e => e.Course)
                    .AsNoTracking() //The AsNoTracking method improves performance in scenarios where the entities returned are not updated in the current context.
                    .FirstOrDefaultAsync(m => m.ID == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
