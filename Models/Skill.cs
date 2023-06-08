using System.ComponentModel.DataAnnotations;

namespace CourseManagement.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
