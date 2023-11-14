using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Logic.Endpoints.CourseLanguages.CourseLanguageGetList
{
    public class CourseLanguageGetListEndpoint : Endpoint<CourseLanguageGetListRequest, List<CourseLanguageGetListResponse>, CourseLanguageGetListMapper>
    {
        public override void Configure()
        {
            Get("courses/{courseId}/languages");
            AllowAnonymous();
        }

        private readonly IRepository<CourseLanguage> repository;

        public CourseLanguageGetListEndpoint(IRepository<CourseLanguage> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleAsync(CourseLanguageGetListRequest req, CancellationToken ct)
        {
            List<CourseLanguage> courseLanguages = repository.GetAll().Include(x => x.Language).Where(x => x.CourseId == req.CourseId).ToList();
            Response = Map.FromEntity(courseLanguages);
            await SendOkAsync(Response, ct);
        }
    }
}