using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Languages.AddLanguage
{
    public class AddLanguageMapper : RequestMapper<AddLanguageRequest, Language>
    {
        public override Language ToEntity(AddLanguageRequest r)
        {
            return new Language
            {
                Name = r.Name
            };
        }
    }
}