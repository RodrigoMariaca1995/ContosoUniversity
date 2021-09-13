using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppPractice_ContosoUniversity.Data;
using WebAppPractice_ContosoUniversity.Models;

namespace WebAppPractice_ContosoUniversity.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly WebAppPractice_ContosoUniversity.Data.SchoolContext _context;

        public IndexModel(WebAppPractice_ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Course> Courses { get;set; }

        public async Task OnGetAsync()
        {
            Courses = await _context.Courses
                .Include(c => c.Department).AsNoTracking().ToListAsync(); //AsNoTraking() improves performance because the entities returned are not tracked
        }
    }
}
