using AvertisTask.Models;

namespace AvertisTask.Services
{
    public interface IStudentService
    {
        int AddStudentRecord(Student student);
        IEnumerable<Student> GetStudents();

        int DeleteRecord(int id);
        IEnumerable<Student> GetStudentsByName(string name);
        Student GetStudentById(int id);
        IEnumerable<Student> GetStudentByClass(string className);
        string FindFeesRecord(int id);
        string SearchResult(int id);
        byte[] ConvertPdf(string result);
    }
}
