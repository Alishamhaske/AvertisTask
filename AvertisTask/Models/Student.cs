using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvertisTask.Models
{
    [Table("student")]
    public class Student
    { 

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? ClassName { get; set; }
        [Required]
        public string? FeesRecord { get; set; }
        [Required]
        public string? AcademicResults { get; set; }

    }
}
