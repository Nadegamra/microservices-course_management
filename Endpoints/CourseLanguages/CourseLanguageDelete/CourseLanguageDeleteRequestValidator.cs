using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Endpoints.CourseLanguages.CourseLanguageDelete
{
    public class CourseLanguageDeleteRequestValidator: Validator<CourseLanguageDeleteRequest>
    {
        public CourseLanguageDeleteRequestValidator()
        {
            RuleFor(x=>x.Id).GreaterThanOrEqualTo(1);
            RuleFor(x=>x.UserId).GreaterThanOrEqualTo(1);
            RuleFor(x=>x.CourseId).GreaterThanOrEqualTo(1);
        }
    }
}
