using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Logic.Endpoints.Creators.UpdateCreator
{
    public class UpdateCreatorRequestValidator: Validator<UpdateCreatorRequest>
    {
        public UpdateCreatorRequestValidator()
        {
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(1);
        }
    }
}
