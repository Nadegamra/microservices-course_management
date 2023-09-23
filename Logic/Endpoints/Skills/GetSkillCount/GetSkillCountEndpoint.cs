using CourseManagement.Data;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Skills.GetSkillCount
{
    public class GetSkillCountEndpoint : Endpoint<EmptyRequest, GetSkillCountResponse>
    {
        public override void Configure()
        {
            Get("skillsCount");
            AllowAnonymous();
        }

        private readonly CourseDbContext courseDbContext;

        public GetSkillCountEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
        {
            int count = courseDbContext.Skills.Count();
            Response = new GetSkillCountResponse { Count = count };
            await SendOkAsync(Response, ct);
        }
    }
}