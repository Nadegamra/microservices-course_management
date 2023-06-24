using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.GainedSkills.GainedSkillCreate
{
    public class GainedSkillCreateEndpoint : Endpoint<GainedSkillCreateRequest, GainedSkillCreateResponse, GainedSkillCreateMapper>
    {
        public override void Configure()
        {
            Post("courses/{courseId}/gained");
            Roles("ADMIN", "CREATOR");
        }

        private readonly CourseDbContext courseDbContext;

        public GainedSkillCreateEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(GainedSkillCreateRequest req, CancellationToken ct)
        {
            if (!courseDbContext.Courses.Where(x => x.Id == req.CourseId && x.UserId == req.UserId).Any() ||
                courseDbContext.GainedSkills.Where(x => req.SkillId != null && x.SkillId == req.SkillId && x.CourseId == req.CourseId).Any()
                || (req.SkillId != null && req.CustomDescription != null))
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            GainedSkill gainedSkill = Map.ToEntity(req);
            var res = courseDbContext.GainedSkills.Add(gainedSkill);
            courseDbContext.SaveChanges();

            Response = Map.FromEntity(res.Entity);
            await SendOkAsync(Response, ct);
        }
    }
}
