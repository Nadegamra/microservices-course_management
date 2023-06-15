using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Skills.GetSkillList
{
    public class GetSkillListEndpoint: EndpointExtended<EmptyRequest, GetSkillListResponse, GetSkillListMapper>
    {
        public override void Configure()
        {
            ConfigureEndpoint("getSkillList");
        }

        private readonly CourseDbContext courseDbContext;

        public GetSkillListEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
        {
            List<Skill> skills = courseDbContext.Skills.ToList();
            Response = Map.FromEntity(skills);
            await SendOkAsync(Response, ct);
        }
    }
}
