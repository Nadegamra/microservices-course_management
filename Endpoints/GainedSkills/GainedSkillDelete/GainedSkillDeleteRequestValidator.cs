using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Endpoints.GainedSkills.GainedSkillDelete
{
    public class GainedSkillDeleteRequestValidator: Validator<GainedSkillDeleteRequest>
    {
        public GainedSkillDeleteRequestValidator()
        {
            RuleFor(x=>x.Id).GreaterThanOrEqualTo(1);
            RuleFor(x=>x.UserId).GreaterThanOrEqualTo(1);
        }
    }
}
