namespace CourseManagement.Logic.Endpoints.Skills.GetSkill
{
    public class GetSkillResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RouteDTO[] Routes { get; set; }
    }
}
