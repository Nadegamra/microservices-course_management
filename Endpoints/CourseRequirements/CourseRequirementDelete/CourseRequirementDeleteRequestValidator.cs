using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Endpoints.CourseRequirements.CourseRequirementDelete
{
    public class CourseRequirementDeleteRequestValidator: Validator<CourseRequirementDeleteRequest>
    {
        public CourseRequirementDeleteRequestValidator()
        {
            RuleFor(x=>x.UserId).GreaterThanOrEqualTo(1);
            RuleFor(x=>x.CourseId).GreaterThanOrEqualTo(1);
            RuleFor(x=>x.Id).GreaterThanOrEqualTo(1);
        }
    }
}
