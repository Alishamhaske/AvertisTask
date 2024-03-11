using AvertisTask.Models;
using AvertisTask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvertisTask.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService service;
        public StudentController(IStudentService service)
        {
            this.service = service;
        }


        public IActionResult Index()
        {
            var students = service.GetStudents();
            return View(students);
        }
        [HttpPost]
        public IActionResult Index(string searchClass)
        {
            var students = service.GetStudentByClass(searchClass);
            return View("Index", students);
        }


        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                int result = service.AddStudentRecord(student);
                if (result >= 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }


        public IActionResult Details(int id)
        {
            var student = service.GetStudentById(id);
            return View(student);
        }

        public IActionResult GetStudentsByClass(string className)
        {
            var students = service.GetStudentByClass(className);
            return View(students);
        }

        public IActionResult GetStudentsByName(string name)
        {
            var students = service.GetStudentByClass(name);
            return View(students);
        }

        public IActionResult FindFeesRecord(int id)
        {
            var feesRecord = service.FindFeesRecord(id);
            return View(feesRecord);
        }

        public IActionResult SearchResult(int id)
        {
            var searchResult = service.SearchResult(id);
            return Content(searchResult);
        }



        public ActionResult Delete(int id)
        {
            var student = service.GetStudentById(id);
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = service.DeleteRecord(id);
                if (result >= 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }


        public IActionResult ConvertToPdf(string result)
        {
            var pdfBytes = service.ConvertPdf(result);
            return File(pdfBytes, "application/pdf", "result.pdf");
        }


    }
}
