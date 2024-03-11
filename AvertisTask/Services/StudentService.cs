using AvertisTask.Models;
using AvertisTask.Repositories;
using System.Reflection.Metadata;

namespace AvertisTask.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository repo;
        public StudentService(IStudentRepository repo)
        {
            this.repo = repo;
            
        }
        public int AddStudentRecord(Student student)
        {
            return repo.AddStudentRecord(student);
        }
        public IEnumerable<Student> GetStudents()
        {
            return repo.GetStudents();
        }

        public Student GetStudentById(int id)
        {
            return repo.GetStudentById(id);
        }

        public IEnumerable<Student> GetStudentByClass(string className)
        {
            return repo.GetStudentByClass(className);
        }

        public string FindFeesRecord(int id)
        {
            return repo.FindFeesRecord(id);
        }

        public string SearchResult(int id)
        {
            return repo.SearchResult(id);
        }

        public byte[] ConvertPdf(string result)
        {

         
            return repo.ConvertPdf(result);
        }

        public IEnumerable<Student> GetStudentsByName(string name)
        {
            return repo.GetStudentsByName(name);
        }

        public int DeleteRecord(int id)
        {
            return repo.DeleteRecord(id);

        }
    }
}
