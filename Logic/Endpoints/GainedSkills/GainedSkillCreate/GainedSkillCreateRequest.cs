using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.GainedSkills.GainedSkillCreate
{
    public class GainedSkillCreateRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int? SkillId { get; set; }
        public string? CustomDescription { get; set; }
    }
}
