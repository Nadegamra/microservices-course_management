using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Logic.Endpoints.GainedSkills.GainedSkillUpdate
{
    public class GainedSkillUpdateRequestValidator: Validator<GainedSkillUpdateRequest>
    {
        public GainedSkillUpdateRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(1);
        }
    }
}
