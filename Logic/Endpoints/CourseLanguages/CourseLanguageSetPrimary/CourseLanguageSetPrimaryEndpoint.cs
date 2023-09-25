using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseLanguages.CourseLanguageSetPrimary
{
    public class CourseLanguageSetPrimaryEndpoint : Endpoint<CourseLanguageSetPrimaryRequest>
    {
        public override void Configure()
        {
            Put("courses/{courseId}/languages/{id}");
            Roles("ADMIN", "CREATOR");
        }

        private readonly CourseDbContext courseDbContext;

        public CourseLanguageSetPrimaryEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(CourseLanguageSetPrimaryRequest req, CancellationToken ct)
        {
            List<CourseLanguage> languages = courseDbContext.CourseLanguages.Where(x => x.CourseId == req.CourseId).ToList();
            foreach (var language in languages)
            {
                if (language.Id != req.Id)
                {
                    language.IsPrimary = false;
                }
                else
                {
                    language.IsPrimary = true;
                }
                courseDbContext.CourseLanguages.Update(language);
            }
            courseDbContext.SaveChanges();
            await SendOkAsync(ct);
        }
    }
}