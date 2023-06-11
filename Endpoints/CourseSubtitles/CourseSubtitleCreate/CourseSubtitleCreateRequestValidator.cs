using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Endpoints.CourseSubtitles.CourseSubtitleCreate
{
    public class CourseSubtitleCreateRequestValidator:Validator<CourseSubtitleCreateRequest>
    {
        public CourseSubtitleCreateRequestValidator()
        {
            RuleFor(x => x.CourseId).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Language).IsInEnum();
        }
    }
}
