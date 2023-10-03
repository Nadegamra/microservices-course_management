namespace CourseManagement.Logic.Endpoints.Skills.GetSkillList
{
    public class GetSkillListRequest
    {
        public required int Skip { get; set; } = 0;
        public required int Take { get; set; } = 10;
    }
}