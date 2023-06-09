using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.Skills.GetSkillList
{
    public class GetSkillListEndpoint: EndpointWithoutRequest<List<GetSkillListResponse>, GetSkillListMapper>
    {
        public override void Configure()
        {
            Get("skills");
            AllowAnonymous();
        }

        private readonly CourseDbContext courseDbContext;

        public GetSkillListEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            List<Skill> skills = courseDbContext.Skills.ToList();
            Response = Map.FromEntity(skills);
            await SendOkAsync(Response, ct);
        }
    }
}
