namespace CourseManagement.Logic.Endpoints.Skills.GetSkillList
{
    public class GetSkillListResponse
    {
        public GetSkillListItem[] Items { get; set; }
        public RouteDTO[] Routes { get; set; }
    }
}
