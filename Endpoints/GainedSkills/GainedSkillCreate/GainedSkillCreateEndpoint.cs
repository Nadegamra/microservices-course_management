using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.GainedSkills.GainedSkillCreate
{
    public class GainedSkillCreateEndpoint : Endpoint<GainedSkillCreateRequest, GainedSkillCreateResponse, GainedSkillCreateMapper>
    {
        public override void Configure()
        {
            Post("courses/gained/{CourseId}");
        }

        private readonly CourseDbContext courseDbContext;

        public GainedSkillCreateEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(GainedSkillCreateRequest req, CancellationToken ct)
        {
            if (!courseDbContext.Courses.Where(x => x.Id == req.CourseId && x.UserId == req.UserId).Any() ||
                courseDbContext.GainedSkills.Where(x => req.SkillId != null && x.SkillId == req.SkillId && x.CourseId == req.CourseId).Any())
            {
                await SendErrorsAsync(418, ct);
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
