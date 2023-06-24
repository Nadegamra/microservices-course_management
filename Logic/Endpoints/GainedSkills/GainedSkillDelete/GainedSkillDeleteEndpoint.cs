using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.GainedSkills.GainedSkillDelete
{
    public class GainedSkillDeleteEndpoint : Endpoint<GainedSkillDeleteRequest>
    {
        public override void Configure()
        {
            Delete("courses/{courseId}/gained/{id}");
            Roles("ADMIN", "CREATOR");
        }

        private readonly CourseDbContext courseDbContext;

        public GainedSkillDeleteEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(GainedSkillDeleteRequest req, CancellationToken ct)
        {
            GainedSkill? skill = courseDbContext.GainedSkills.Where(x => x.Id == req.Id).FirstOrDefault();
            if (skill == null || !courseDbContext.Courses.Where(x => x.Id == skill.CourseId && x.UserId == req.UserId).Any())
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            courseDbContext.GainedSkills.Remove(skill);
            courseDbContext.SaveChanges();
            await SendOkAsync(ct);
        }
    }
}
