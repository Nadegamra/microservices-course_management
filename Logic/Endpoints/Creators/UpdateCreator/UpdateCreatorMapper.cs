using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Creators.UpdateCreator
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
