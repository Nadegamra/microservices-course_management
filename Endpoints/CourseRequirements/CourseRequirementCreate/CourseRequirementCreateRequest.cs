using CourseManagement.Models;
using FastEndpoints;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagement.Endpoints.CourseRequirements.CourseRequirementCreate
{
    public class CourseRequirementCreateRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int? SkillId { get; set; }
        public string? CustomDescription { get; set; }
    }
}
