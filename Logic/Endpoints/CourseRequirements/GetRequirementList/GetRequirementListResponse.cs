using CourseManagement.Data.Models;

namespace CourseManagement.Logic.Endpoints.CourseRequirements.GetRequirementList
{
    public class GetRequirementListResponse
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int? SkillId { get; set; }
        public Skill? Skill { get; set; }
        public string? CustomDescription { get; set; }
    }
}