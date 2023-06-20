using CourseManagement.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace CourseManagement.Data.Models
{
    public class CourseLanguage
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Language Language { get; set; }
    }
}
