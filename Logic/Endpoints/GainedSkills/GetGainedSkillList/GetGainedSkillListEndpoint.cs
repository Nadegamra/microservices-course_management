using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Logic.Endpoints.GainedSkills.GetGainedSkillList
{
    public class GetGainedSkillListEndpoint : Endpoint<GetGainedSkillListRequest, List<GetGainedSkillListResponse>, GetGainedSkillListMapper>
    {
        public override void Configure()
        {
            Get("courses/{courseId}/gained");
        }

        private readonly CourseDbContext courseDbContext;

        public GetGainedSkillListEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(GetGainedSkillListRequest req, CancellationToken ct)
        {
            List<GainedSkill> gainedSkills = courseDbContext.GainedSkills.Include(x => x.Skill).Where(x => x.CourseId == req.CourseId).ToList();
            Response = Map.FromEntity(gainedSkills);
            await SendOkAsync(Response, ct);
        }
    }
}