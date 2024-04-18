using Microsoft.AspNetCore.Mvc;
using SimpleApp.Models;

namespace SimpleApp.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            var students = LocalDatabase.GetStudents();

            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        { 
            if (!ModelState.IsValid) return View();

            LocalDatabase.AddStudent(student);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var student = LocalDatabase.GetStudentByID(id);

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (!ModelState.IsValid) return View();

            if (!LocalDatabase.TryUpdateStudent(student)) return View();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            if (!LocalDatabase.TryDeleteStudentByID(id)) return View();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteAll()
        {
            LocalDatabase.DeleteAllStudents();

            return RedirectToAction(nameof(Index));
        }
    }
}
