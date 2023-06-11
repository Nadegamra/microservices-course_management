using FastEndpoints;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace CourseManagement.Endpoints.CourseRequirements.CourseRequirementCreate
{
    public class CourseRequirementCreateRequestValidator: Validator<CourseRequirementCreateRequest>
    {
        public CourseRequirementCreateRequestValidator()
        {
            RuleFor(x=>x.UserId).GreaterThanOrEqualTo(1);
            RuleFor(x=>x.CourseId).GreaterThanOrEqualTo(1);
        }
    }
}
