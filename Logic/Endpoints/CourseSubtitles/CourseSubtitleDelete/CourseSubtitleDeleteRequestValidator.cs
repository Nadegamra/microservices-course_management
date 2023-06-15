using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Logic.Endpoints.CourseSubtitles.CourseSubtitleDelete
{
    public class CourseSubtitleDeleteRequestValidator : Validator<CourseSubtitleDeleteRequest>
    {
        public CourseSubtitleDeleteRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(1);
            RuleFor(x => x.CourseId).GreaterThanOrEqualTo(1);
        }
    }
}
