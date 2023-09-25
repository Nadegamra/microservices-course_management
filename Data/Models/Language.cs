using System.ComponentModel.DataAnnotations;

namespace CourseManagement.Data.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}