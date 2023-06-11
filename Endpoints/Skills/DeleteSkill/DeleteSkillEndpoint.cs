using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.Skills.RemoveSkill
{
    public class DeleteSkillEndpoint: Endpoint<DeleteSkillRequest>
    {
        public override void Configure()
        {
            Delete("skills/{Id}");
            Roles("ADMIN");
        }

        private readonly CourseDbContext courseDbContext;

        public DeleteSkillEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(DeleteSkillRequest req, CancellationToken ct)
        {
            Skill? skill = courseDbContext.Skills.Where(x=>x.Id == req.Id).FirstOrDefault();
            if(skill == null)
            {
                await SendErrorsAsync(418, ct);
                return;
            }

            courseDbContext.Skills.Remove(skill);
            courseDbContext.SaveChanges();
            await SendOkAsync(ct);
        }
    }
}
