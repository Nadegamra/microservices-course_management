using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Endpoints.CourseLanguages.CourseLanguageCreate
{
    public class CourseLanguageCreateRequestValidator: Validator<CourseLanguageCreateRequest>
    {
        public CourseLanguageCreateRequestValidator()
        {
            RuleFor(x=>x.CourseId).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Language).IsInEnum();
        }
    }
}
