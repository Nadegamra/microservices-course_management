using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.Courses.GetUserCourse
{
    public class GetUserCourseMapper : ResponseMapper<GetUserCourseResponse, Course>
    {
        public override GetUserCourseResponse FromEntity(Course e)
        {
            return new GetUserCourseResponse()
            {
                Id = e.Id,
                UserId = e.UserId,
                CertificatePrice = e.CertificatePrice,
                CoursePrice = e.CoursePrice,
                Description = e.Description,
                GrantsCertificate = e.GrantsCertificate,
                LengthInDays = e.LengthInDays,
                Name = e.Name,
                IsHidden = e.IsHidden,
            };
        }
    }
}
