using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.Courses.GetCourse
{
    public class GetCourseMapper : ResponseMapper<GetCourseResponse, Course>
    {
        public override GetCourseResponse FromEntity(Course e)
        {
            return new GetCourseResponse
            {
                Id = e.Id,
                UserId = e.UserId,
                CertificatePrice = e.CertificatePrice,
                CoursePrice = e.CoursePrice,
                Description = e.Description,
                GrantsCertificate = e.GrantsCertificate,
                LengthInDays = e.LengthInDays,
                Name = e.Name,
            };
        }
    }
}
