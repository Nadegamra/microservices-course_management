namespace CourseManagement.Logic.Endpoints.Skills.GetSkillList
{
    public class GetSkillListRequest
    {
        public required int Skip { get; set; }
        public required int Take { get; set; }
    }
}