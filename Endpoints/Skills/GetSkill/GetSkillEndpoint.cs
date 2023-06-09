using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.Skills.GetSkill
{
    public class GetSkillEndpoint: Endpoint<GetSkillRequest, GetSkillResponse,GetSkillMapper>
    {
        public override void Configure()
        {
            Get("skills/{id}");
            AllowAnonymous();
        }

        private readonly CourseDbContext courseDbContext;

        public GetSkillEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(GetSkillRequest req, CancellationToken ct)
        {
            Skill? skill = courseDbContext.Skills.Where(x=>x.Id == req.Id).FirstOrDefault();
            if (skill == null)
            {
                await SendErrorsAsync(418, ct);
                return;
            }

            Response = Map.FromEntity(skill);
            await SendOkAsync(Response, ct);
        }
    }
}
