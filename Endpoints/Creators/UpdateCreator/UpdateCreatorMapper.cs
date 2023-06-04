using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.Creators.UpdateCreator
{
    public class UpdateCreatorMapper: Mapper<UpdateCreatorRequest, EmptyResponse, Creator>
    {
        public override Creator UpdateEntity(UpdateCreatorRequest r, Creator e)
        {
            e.Bio = r.Bio;
            e.Website = r.Website;
            return e;
        }
    }
}
