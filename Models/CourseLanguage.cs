using CourseManagement.Enums;
using System.ComponentModel.DataAnnotations;

namespace CourseManagement.Models
{
    public class CourseLanguage
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Language Language { get; set; }
    }
}
