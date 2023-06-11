namespace CourseManagement.Endpoints.GainedSkills.GainedSkillUpdate
{
    public class GainedSkillUpdateResponse
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int? SkillId { get; set; }
        public string? CustomDescription { get; set; }
    }
}
