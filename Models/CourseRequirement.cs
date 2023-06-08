using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagement.Models
{
    [PrimaryKey("CourseId", "SkillId")]
    public class CourseRequirement
    {
        public int CourseId { get; set; }
        [ForeignKey("Skill")]
        public int? SkillId { get; set; }
        public Skill Skill { get; set; }
        public string? CustomDescription { get; set; }
    }
}
