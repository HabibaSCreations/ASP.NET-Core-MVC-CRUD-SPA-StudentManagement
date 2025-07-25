using CoreMasterDetailsCRUD.Models;

namespace CoreMasterDetailsCRUD.Contracts
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(int id);
        Student UpdateStudent(Student student);
        Student AddStudent(Student student);
        Student DeleteStudent(int id);
        IEnumerable<Course> GetCourses();
        void DeleteModuleByStudent(int id);
        void AddModuleByStudentId(int id, List<Module> modules);

    }
}
