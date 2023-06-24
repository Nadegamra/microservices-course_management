using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.GainedSkills.GainedSkillUpdate
{
    public class GainedSkillUpdateEndpoint : Endpoint<GainedSkillUpdateRequest, GainedSkillUpdateResponse, GainedSkillUpdateMapper>
    {
        public override void Configure()
        {
            Put("courses/{courseId}/gained/{id}");
            Roles("ADMIN", "CREATOR");
        }

        private readonly CourseDbContext courseDbContext;

        public GainedSkillUpdateEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(GainedSkillUpdateRequest req, CancellationToken ct)
        {
            GainedSkill? skill = courseDbContext.GainedSkills.Where(x => x.Id == req.Id && x.SkillId == null).FirstOrDefault();
            if (skill == null || !courseDbContext.Courses.Where(x => x.Id == skill.CourseId && x.UserId == req.UserId).Any())
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            skill = Map.UpdateEntity(req, skill);
            var res = courseDbContext.Update(skill);
            courseDbContext.SaveChanges();
            Response = Map.FromEntity(res.Entity);
            await SendOkAsync(Response, ct);
        }
    }
}
