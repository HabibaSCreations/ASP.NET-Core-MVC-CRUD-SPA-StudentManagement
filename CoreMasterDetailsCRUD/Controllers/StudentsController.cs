using CoreMasterDetailsCRUD.Contracts;
using CoreMasterDetailsCRUD.Models;
using CoreMasterDetailsCRUD.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreMasterDetailsCRUD.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _repo;
        private readonly IWebHostEnvironment _web;

        public StudentsController(IStudentRepository repo, IWebHostEnvironment web)
        {
            _repo = repo;
            _web = web;
        }

        public IActionResult Index()
        {
            var students = _repo.GetStudents();
            return View(students);
        }
        [HttpGet]
        public ActionResult CreatePartial()
        {
            StudentViewModel student = new StudentViewModel();
            student.Courses = _repo.GetCourses().ToList();
            student.Modules.Add(new Module() { ModuleId = 1 });
            return PartialView("_CreateStudentPartial", student);
        }
        [HttpPost]

        [ValidateAntiForgeryToken]
        public JsonResult CreateStudent(StudentViewModel vobj)
        {
            if (!ModelState.IsValid)
            {
                // Get the validation errors
                var errors = ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .ToDictionary(k => k.Key, v => v.Value.Errors.Select(e => e.ErrorMessage).ToArray());

               
                foreach (var error in errors)
                {
                    System.Diagnostics.Debug.WriteLine($"Property: {error.Key}, Errors: {string.Join(", ", error.Value)}");
                }

                vobj.Courses = _repo.GetCourses().ToList();
                return Json(new { success = false, errors = errors });
            }
            Student student = new Student
            {
                StudentName = vobj.StudentName,
                AdmissionDate = vobj.AdmissionDate,
                MobileNo = vobj.MobileNo,
                CourseId = vobj.CourseId,
                IsEnrolled = vobj.IsEnrolled,
                Modules = vobj.Modules
            };

            if (vobj.ProfileFile != null)
            {
                string uniqueFileName = GetFileName(vobj.ProfileFile);
                student.ImageUrl = uniqueFileName;
            }
            else
            {
                student.ImageUrl = "noimage.png";
            }

           _repo.AddStudent(student);
            try
            {
               return Json(new { success = true, redirectUrl = Url.Action("Index") });
            }
            catch (Exception ex)
            {
                vobj.Courses = _repo.GetCourses().ToList();
                return Json(new { success = false });
            }
        }
        private string GetFileName(IFormFile profileFile)
        {
            string uniqueFileName = null;
            if (profileFile != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(profileFile.FileName); ;
                var uploadFolder = Path.Combine(_web.WebRootPath, "images");
                var filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    profileFile.CopyToAsync(fileStream);
                }
            }
            return uniqueFileName;
        }

        [HttpPost]
        public JsonResult DeleteStudent(int id)
        {
            Student student = _repo.GetStudent(id);
            if (student != null)
            {
                _repo.DeleteModuleByStudent(id);
                _repo.DeleteStudent(id);
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Student not found." });
        }
        [HttpGet]
        public ActionResult EditPartial(int id)
        {
            var student = _repo.GetStudent(id);
            var vObj = new StudentViewModel
            {
                StudentName = student.StudentName,
                StudentId = student.StudentId,
                AdmissionDate = student.AdmissionDate,
                MobileNo = student.MobileNo,
                CourseId = student.CourseId,
                IsEnrolled = student.IsEnrolled,
                ImageUrl = student.ImageUrl,
                Modules = student.Modules.ToList(),
                Courses = _repo.GetCourses().ToList()
            };
            return PartialView("_EditStudentPartial", vObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EditStudent(StudentViewModel vobj, string OldImageUrl)
        {
            if (!ModelState.IsValid)
            {
                vobj.Courses = _repo.GetCourses().ToList();
                return Json(new { success = false });
            }
            Student obj = _repo.GetStudent(vobj.StudentId);
            if (obj != null)
            {
                obj.StudentName = vobj.StudentName;
                obj.CourseId = vobj.CourseId;
                obj.MobileNo = vobj.MobileNo;
                obj.IsEnrolled = vobj.IsEnrolled;
                obj.AdmissionDate = vobj.AdmissionDate;
                if (vobj.ProfileFile != null)
                {
                    string uniqueFileName = GetFileName(vobj.ProfileFile);
                    obj.ImageUrl = uniqueFileName;
                }
                else
                {
                    obj.ImageUrl = OldImageUrl;
                }
                _repo.DeleteModuleByStudent(vobj.StudentId);
                _repo.AddModuleByStudentId(vobj.StudentId, vobj.Modules);
                _repo.UpdateStudent(obj);
                try
                {
                   
                    return Json(new { success = true, redirectUrl = Url.Action("Index") });
                }
                catch (Exception ex)
                {

                    vobj.Courses = _repo.GetCourses().ToList();
                    return Json(new { success = false });
                }
            }
            return Json(new { success = false, errors = new[] { "Student not found." } });
        }
    }
}
