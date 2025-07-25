using CoreMasterDetailsCRUD.Contracts;
using CoreMasterDetailsCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreMasterDetailsCRUD.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CoreMasterDetailsDbContext _db;

        public StudentRepository(CoreMasterDetailsDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Student> GetStudents()
        {
            return _db.Students.Include(s => s.Course).Include(s => s.Modules).ToList();
        }

        public void AddModuleByStudentId(int id, List<Module> modules)
        {
            if (modules != null)
            {
                foreach (var module in modules)
                {
                    module.StudentId = id;
                    module.ModuleName = module.ModuleName;
                    module.Duration = module.Duration;
                    _db.Modules.Add(module);
                }
                _db.SaveChanges();
            }

        }

        public Student AddStudent(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
            return student;

        }

        public void DeleteModuleByStudent(int id)
        {
            var modules = _db.Modules.Where(m => m.StudentId == id).ToList();
            if (modules != null)
            {
                _db.Modules.RemoveRange(modules);
                _db.SaveChanges();
            }

        }

        public Student DeleteStudent(int id)
        {
            var student = _db.Students.Find(id);
            if (student != null)
            {
                _db.Students.Remove(student);
                _db.SaveChanges();
            }
            return student;

        }

        public IEnumerable<Course> GetCourses()
        {
            return _db.Courses.ToList();
        }

        public Student GetStudent(int id)
        {
            return _db.Students
                .Include(a => a.Modules)
                .FirstOrDefault(x => x.StudentId == id);
        }

        

        public Student UpdateStudent(Student student)
        {
            _db.Entry(student).State = EntityState.Modified;
            _db.SaveChanges(); // Or return Task<int> for async
            return student;

        }
    }
}
