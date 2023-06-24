using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;
using Infrastructure.Routes;

namespace CourseManagement.Logic.Endpoints.Skills.CreateSkill
{
    public class CreateSkillEndpoint : EndpointExtended<CreateSkillRequest, CreateSkillResponse, CreateSkillMapper>
    {
        public override void Configure()
        {
            ConfigureEndpoint("createSkill");
        }

        private readonly CourseDbContext courseDbContext;

        public CreateSkillEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(CreateSkillRequest req, CancellationToken ct)
        {
            if (courseDbContext.Skills.Where(x => x.Name == req.Name).Any())
            {
                await SendErrorsAsync(400, ct);
            }

            Skill skill = Map.ToEntity(req);

            var res = courseDbContext.Skills.Add(skill);
            courseDbContext.SaveChanges();

            Response = Map.FromEntity(res.Entity);
            await SendOkAsync(Response, ct);
        }
    }
}
