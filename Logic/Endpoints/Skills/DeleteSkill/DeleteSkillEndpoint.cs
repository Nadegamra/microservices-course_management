using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Skills.DeleteSkill
{
    public class DeleteSkillEndpoint : Endpoint<DeleteSkillRequest, DeleteSkillResponse, DeleteSkillMapper>
    {
        public override void Configure()
        {
            Delete("skills/{id}");
            Roles("ADMIN");
        }

        private readonly CourseDbContext courseDbContext;

        public DeleteSkillEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(DeleteSkillRequest req, CancellationToken ct)
        {
            Skill? skill = courseDbContext.Skills.Where(x => x.Id == req.Id).FirstOrDefault();
            if (skill == null)
            {
                await SendErrorsAsync(418, ct);
                return;
            }

            courseDbContext.Skills.Remove(skill);
            courseDbContext.SaveChanges();
            Response = Map.FromEntity(skill);
            await SendOkAsync(Response, ct);
        }
    }
}
