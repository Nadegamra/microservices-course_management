using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Logic.Endpoints.Creators.Profile
{
    public class ProfileRequestValidator: Validator<ProfileRequest>
    {
        public ProfileRequestValidator()
        {
            RuleFor(x=>x.UserId).GreaterThanOrEqualTo(1);
        }
    }
}
