using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagement.Data.Models
{
    public class CourseSubtitle
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
