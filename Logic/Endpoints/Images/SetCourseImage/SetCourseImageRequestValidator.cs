using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Logic.Endpoints.Images.AddCourseImage
{
    public class SetCourseImageRequestValidator: Validator<SetCourseImageRequest>
    {
        public SetCourseImageRequestValidator()
        {
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(1);
            RuleFor(x=>x.CourseId).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Image).Cascade(CascadeMode.Stop).NotEmpty().Must(IsAllowedSize);
        }

        private static bool IsAllowedSize(IFormFile file)
            => file.Length is >= 100 and <= 10485760;
    }
}
