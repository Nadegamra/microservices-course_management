using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Skills.UpdateSkill
{
    public class UpdateSkillEndpoint : Endpoint<UpdateSkillRequest, UpdateSkillResponse, UpdateSkillMapper>
    {
        public override void Configure()
        {
            Put("skills/{id}");
            Roles("ADMIN");
        }

        private readonly CourseDbContext courseDbContext;

        public UpdateSkillEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(UpdateSkillRequest req, CancellationToken ct)
        {
            Skill? skill = courseDbContext.Skills.Where(x => x.Id == req.Id).FirstOrDefault();
            if (skill == null)
            {
                await SendErrorsAsync(400, ct);
                return;
            }
            if (skill.Name != req.Name && courseDbContext.Skills.Where(x => x.Name == req.Name).Any())
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            skill = Map.UpdateEntity(req, skill);
            var res = courseDbContext.Skills.Update(skill);
            courseDbContext.SaveChanges();

            Response = Map.FromEntity(res.Entity);
            await SendOkAsync(Response, ct);
        }
    }
}
