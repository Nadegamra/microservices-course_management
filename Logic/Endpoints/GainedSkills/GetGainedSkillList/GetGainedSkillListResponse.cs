using CourseManagement.Data.Models;

namespace CourseManagement.Logic.Endpoints.GainedSkills.GetGainedSkillList
{
    public class GetGainedSkillListResponse
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int? SkillId { get; set; }
        public Skill? Skill { get; set; }
        public string? CustomDescription { get; set; }
    }
}