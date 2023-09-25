using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Logic.Endpoints.CourseSubtitles.CourseSubtitleCreate
{
    public class CourseSubtitleCreateRequestValidator : Validator<CourseSubtitleCreateRequest>
    {
        public CourseSubtitleCreateRequestValidator()
        {
            RuleFor(x => x.CourseId).GreaterThanOrEqualTo(1);
            RuleFor(x => x.LanguageId).GreaterThanOrEqualTo(1);
        }
    }
}
