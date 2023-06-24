namespace CourseManagement.Logic.Endpoints.Skills.UpdateSkill
{
    public class UpdateSkillRequest
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
