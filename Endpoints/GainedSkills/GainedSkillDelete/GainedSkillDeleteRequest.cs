using FastEndpoints;

namespace CourseManagement.Endpoints.GainedSkills.GainedSkillDelete
{
    public class GainedSkillDeleteRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public int Id { get; set; }
    }
}
