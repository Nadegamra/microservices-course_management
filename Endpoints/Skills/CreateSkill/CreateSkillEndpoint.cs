using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.Skills.CreateSkill
{
    public class CreateSkillEndpoint: Endpoint<CreateSkillRequest, CreateSkillResponse, CreateSkillMapper>
    {
        public override void Configure()
        {
            Post("skills");
            Roles("ADMIN");
        }

        private readonly CourseDbContext courseDbContext;

        public CreateSkillEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(CreateSkillRequest req, CancellationToken ct)
        {
            if(courseDbContext.Skills.Where(x=>x.Name == req.Name).Any())
            {
                await SendErrorsAsync(418, ct);
            }

            Skill skill = Map.ToEntity(req);

            var res = courseDbContext.Skills.Add(skill);
            courseDbContext.SaveChanges();

            Response = Map.FromEntity(res.Entity);
            await SendOkAsync(Response, ct);
        }
    }
}
