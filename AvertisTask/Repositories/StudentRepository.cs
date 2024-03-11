using AvertisTask.Data;
using AvertisTask.Models;
using Microsoft.EntityFrameworkCore;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace AvertisTask.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        ApplicationDbContext db;
        public StudentRepository(ApplicationDbContext db)
        {
            this.db = db;
            
        }

        public int AddStudentRecord(Student student)
        {
            db.Students.Add(student);
            int result = db.SaveChanges();
            return result;
        }
        public IEnumerable<Student> GetStudents()
        {
            return db.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            var result = db.Students.Where(x => x.Id == id).SingleOrDefault();
            return result;
        }

        public IEnumerable<Student> GetStudentByClass(string className)
        {
            var model = from s in db.Students
                        where s.ClassName.Contains(className) || s.Name.Contains(className) 
                      select s;
            return model;
        
        }
      



        public string FindFeesRecord(int id)
        {
            var student = db.Students.FirstOrDefault(s => s.Id == id);
            return student?.FeesRecord;
        }

        public string SearchResult(int id)
        {
            var student = db.Students.FirstOrDefault(s => s.Id == id);
            return student?.AcademicResults;
        }

        public IEnumerable<Student> GetStudentsByName(string name)
        {
            var model = from s in db.Students
                        where s.ClassName.Contains(name) || s.Name.Contains(name)
                        select s;
            return model;
        }

        public byte[] ConvertPdf(string result)
        {
           
            using (MemoryStream stream = new MemoryStream())
            {

                StreamWriter writer = new StreamWriter(stream);
                writer.Write(result);
                writer.Flush();
                return stream.ToArray();
            }
            
          
        }

        public int DeleteRecord(int id)
        {
            int res = 0;
            var result = db.Students.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                db.Students.Remove(result);
                res = db.SaveChanges();
            }
            return res;
        }
    }





}

