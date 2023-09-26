using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Languages.AddLanguage
{
    public class AddLanguageEndpoint : Endpoint<AddLanguageRequest, EmptyResponse, AddLanguageMapper>
    {
        public override void Configure()
        {
            Post("languages");
            Roles("ADMIN");
        }

        private readonly CourseDbContext courseDbContext;

        public AddLanguageEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(AddLanguageRequest req, CancellationToken ct)
        {
            List<Language> languages = courseDbContext.Languages.Where(x => x.Name.ToUpper() == req.Name.ToUpper()).ToList();
            if (languages.Count > 0)
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            Language newLanguage = Map.ToEntity(req);
            courseDbContext.Add(newLanguage);
            courseDbContext.SaveChanges();
        }
    }
}