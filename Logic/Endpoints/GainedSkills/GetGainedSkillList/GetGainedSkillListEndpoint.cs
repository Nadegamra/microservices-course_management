using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.GainedSkills.GetGainedSkillList
{
    public class GetGainedSkillListEndpoint : Endpoint<GetGainedSkillListRequest, List<GetGainedSkillListResponse>, GetGainedSkillListMapper>
    {
        public override void Configure()
        {
            Get("courses/{courseId}/gained");
        }

        private readonly IRepository<GainedSkill> repository;

        public GetGainedSkillListEndpoint(IRepository<GainedSkill> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleAsync(GetGainedSkillListRequest req, CancellationToken ct)
        {
            List<GainedSkill> gainedSkills = repository.GetAll().Where(x => x.CourseId == req.CourseId).ToList();
            Response = Map.FromEntity(gainedSkills);
            await SendOkAsync(Response, ct);
        }
    }
}