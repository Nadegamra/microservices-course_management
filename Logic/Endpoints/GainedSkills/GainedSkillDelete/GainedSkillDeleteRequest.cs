using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.GainedSkills.GainedSkillDelete
{
    public class GainedSkillDeleteRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int Id { get; set; }
    }
}
