namespace CourseManagement.Endpoints.GainedSkills.GainedSkillCreate
{
    public class GainedSkillCreateResponse
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int? SkillId { get; set; }
        public string? CustomDescription { get; set; }
    }
}
