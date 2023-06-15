using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Logic.Endpoints.GainedSkills.GainedSkillCreate
{
    public class GainedSkillCreateRequestValidator: Validator<GainedSkillCreateRequest>
    {
        public GainedSkillCreateRequestValidator()
        {
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(1);
            RuleFor(x=>x.CourseId).GreaterThanOrEqualTo(1);
        }
    }
}
