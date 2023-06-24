using Infrastructure.Routes;

namespace CourseManagement.Logic.Endpoints.Skills.GetSkillList
{
    public class GetSkillListResponse : BaseResponse
    {
        public GetSkillListItem[] Items { get; set; }
    }
}
