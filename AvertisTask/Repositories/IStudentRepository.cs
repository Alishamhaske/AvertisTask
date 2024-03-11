using AvertisTask.Models;

namespace AvertisTask.Repositories
{
    public interface IStudentRepository
    {
        int AddStudentRecord(Student student);
        IEnumerable<Student> GetStudents();

        int DeleteRecord(int id);
        Student GetStudentById(int id);
        IEnumerable<Student> GetStudentsByName(string name);  
        IEnumerable<Student> GetStudentByClass(string className);
        string FindFeesRecord(int id);
        string SearchResult(int id);
        public byte[] ConvertPdf(string result);



    }
}
