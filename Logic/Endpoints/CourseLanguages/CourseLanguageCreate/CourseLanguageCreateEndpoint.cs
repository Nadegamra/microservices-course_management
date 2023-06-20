using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseLanguages.CourseLanguageCreate
{
    public class CourseLanguageCreateEndpoint: EndpointExtended<CourseLanguageCreateRequest,EmptyResponse,CourseLanguageCreateMapper>
    {
        public override void Configure()
        {
            ConfigureEndpoint("addLanguage");
        }

        private readonly CourseDbContext courseDbContext;

        public CourseLanguageCreateEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(CourseLanguageCreateRequest req, CancellationToken ct)
        {
            CourseLanguage newLanguage = Map.ToEntity(req);
            Course? course = courseDbContext.Courses.Where(x=>x.Id == newLanguage.CourseId && x.UserId == req.UserId).FirstOrDefault();
            if(course == null || courseDbContext.CourseLanguages.Where(x=>x.Language == newLanguage.Language && x.CourseId == newLanguage.CourseId).Any())
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            courseDbContext.CourseLanguages.Add(newLanguage);
            courseDbContext.SaveChanges();
            await SendOkAsync(ct);
        }
    }
}
