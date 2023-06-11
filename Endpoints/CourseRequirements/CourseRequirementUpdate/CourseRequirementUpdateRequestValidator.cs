using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Endpoints.CourseRequirements.CourseRequirementUpdate
{
    public class CourseRequirementUpdateRequestValidator: Validator<CourseRequirementUpdateRequest>
    {
        public CourseRequirementUpdateRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(1);
        }
    }
}
