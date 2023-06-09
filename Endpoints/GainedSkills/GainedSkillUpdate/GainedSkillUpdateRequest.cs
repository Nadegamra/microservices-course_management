using FastEndpoints;

namespace CourseManagement.Endpoints.GainedSkills.GainedSkillUpdate
{
    public class GainedSkillUpdateRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public int Id { get; set; }
        public string? CustomDescription { get; set; }
    }
}
