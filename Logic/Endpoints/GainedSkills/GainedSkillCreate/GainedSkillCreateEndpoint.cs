using CourseManagement.Data;
using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.GainedSkills.GainedSkillCreate
{
    public class GainedSkillCreateEndpoint : Endpoint<GainedSkillCreateRequest, GainedSkillCreateResponse, GainedSkillCreateMapper>
    {
        public override void Configure()
        {
            Post("courses/{courseId}/gained");
            Roles("CREATOR");
        }

        private readonly IRepository<Course> courseRepository;
        private readonly IRepository<GainedSkill> gainedSkillsRepository;

        public GainedSkillCreateEndpoint(IRepository<Course> courseRepository, IRepository<GainedSkill> gainedSkillsRepository)
        {
            this.courseRepository = courseRepository;
            this.gainedSkillsRepository = gainedSkillsRepository;
        }

        public override async Task HandleAsync(GainedSkillCreateRequest req, CancellationToken ct)
        {
            if (!courseRepository.GetAll().Where(x => x.Id == req.CourseId && x.UserId == req.UserId).Any() ||
                gainedSkillsRepository.GetAll().Where(x => req.SkillId != null && x.SkillId == req.SkillId && x.CourseId == req.CourseId).Any()
                || (req.SkillId != null && req.CustomDescription != null && req.CustomDescription != ""))
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            GainedSkill gainedSkill = Map.ToEntity(req);
            var res = gainedSkillsRepository.Add(gainedSkill);

            Response = Map.FromEntity(gainedSkillsRepository.Get(res.Id));
            await SendOkAsync(Response, ct);
        }
    }
}
