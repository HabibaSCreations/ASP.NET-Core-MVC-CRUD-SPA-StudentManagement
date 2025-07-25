using Microsoft.EntityFrameworkCore;

namespace CoreMasterDetailsCRUD.Models
{
    public static class ModelBuilderExtention
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, CourseName = "C#" },
                new Course { CourseId = 2, CourseName = "J2EE" },
                new Course { CourseId = 3, CourseName = "NT" }
           );

        }
    }
}
