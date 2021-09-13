using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppPractice_ContosoUniversity.Models.SchoolViewModels;

namespace WebAppPractice_ContosoUniversity.Pages.Courses
{
    public class IndexSelectModel : PageModel
    {
        private readonly WebAppPractice_ContosoUniversity.Data.SchoolContext _context;

        public IndexSelectModel(WebAppPractice_ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        #region snippet_RevisedIndexMethod
        public IList<CourseViewModel> CourseVM { get; set; }

        public async Task OnGetAsync( ) //The OnGetAsync method loads related data with the Include method. The Select method is an alternative that loads only the related data needed. 
        {
            CourseVM = await _context.Courses
            .Select(p => new CourseViewModel //Loads related data with the Select method
            {
                CourseID = p.CourseID,
                Title = p.Title,
                Credits = p.Credits,
                DepartmentName = p.Department.Name
            }).ToListAsync();
        }
        #endregion
    }
}
