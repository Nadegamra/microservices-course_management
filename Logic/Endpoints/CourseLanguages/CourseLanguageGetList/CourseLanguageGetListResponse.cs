using CourseManagement.Data.Models;

namespace CourseManagement.Logic.Endpoints.CourseLanguages.CourseLanguageGetList
{
    public class CourseLanguageGetListResponse
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}