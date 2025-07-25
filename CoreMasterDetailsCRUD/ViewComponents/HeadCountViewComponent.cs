using CoreMasterDetailsCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreMasterDetailsCRUD.ViewComponents
{
    public class HeadCountViewComponent:ViewComponent
    {
        private readonly CoreMasterDetailsDbContext _db;
        public HeadCountViewComponent(CoreMasterDetailsDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(int courseId)
        {
            var courseCounts = await _db.Students.Include(s => s.Course)
                .GroupBy(s => new { s.Course.CourseId, s.Course.CourseName })
                .Select(g => new CourseHeadCount
                {
                    CourseId = g.Key.CourseId,
                    CourseName = g.Key.CourseName,
                    Count = g.Count()
                })
                .ToListAsync();
            return View(courseCounts);
        
    }
 }
}
