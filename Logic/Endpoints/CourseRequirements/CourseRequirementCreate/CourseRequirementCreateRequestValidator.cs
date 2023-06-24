using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Logic.Endpoints.CourseRequirements.CourseRequirementCreate
{
    public class CourseRequirementCreateRequestValidator : Validator<CourseRequirementCreateRequest>
    {
        public CourseRequirementCreateRequestValidator()
        {
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(1);
            RuleFor(x => x.CourseId).GreaterThanOrEqualTo(1);
        }
    }
}
