using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
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

        private readonly IRepository<Course> courseRepository;
        private readonly IRepository<GainedSkill> gainedSkillsRepository;

        public GainedSkillUpdateEndpoint(IRepository<Course> courseRepository, IRepository<GainedSkill> gainedSkillsRepository)
        {
            this.courseRepository = courseRepository;
            this.gainedSkillsRepository = gainedSkillsRepository;
        }

        public override async Task HandleAsync(GainedSkillUpdateRequest req, CancellationToken ct)
        {
            GainedSkill? skill = gainedSkillsRepository.GetAll().Where(x => x.Id == req.Id && x.SkillId == null).FirstOrDefault();
            if (skill == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }
            bool isNotOwner = !courseRepository.GetAll().Where(x => x.Id == skill.CourseId && x.UserId == req.UserId).Any();
            if (isNotOwner)
            {
                await SendUnauthorizedAsync(ct);
                return;
            }

            skill = Map.UpdateEntity(req, skill);
            var res = gainedSkillsRepository.Update(skill);
            Response = Map.FromEntity(res);
            await SendOkAsync(Response, ct);
        }
    }
}
