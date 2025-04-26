using Homework_15.Models;
using Homework_15.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Homework_15.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var students = StudentRepository.GetStudents();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            StudentRepository.Add(student);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            StudentRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var student = StudentRepository.Details(id);
            return View(student);
        }
    }
}