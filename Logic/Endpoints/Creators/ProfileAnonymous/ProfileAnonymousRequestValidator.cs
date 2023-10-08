using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Logic.Endpoints.Creators.ProfileAnonymous
{
    public class ProfileAnonymousRequestValidator : Validator<ProfileAnonymousRequest>
    {
        public ProfileAnonymousRequestValidator()
        {
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(1);
        }
    }
}