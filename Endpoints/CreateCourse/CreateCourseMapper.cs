using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.CreateCourse
{
    public class CreateCourseMapper: Mapper<CreateCourseRequest, CreateCourseResponse,Course>
    {
        public override CreateCourseResponse FromEntity(Course e)
        {
            return new CreateCourseResponse
            {
                Id = e.Id,
                CertificatePrice = e.CertificatePrice,
                CoursePrice = e.CoursePrice,
                Description = e.Description,
                GrantsCertificate = e.GrantsCertificate,
                LengthInDays = e.LengthInDays,
                Name = e.Name,
                UserId = e.UserId,
                
            };
        }

        public override Course ToEntity(CreateCourseRequest r)
        {
            return new Course
            {
                CertificatePrice = r.CertificatePrice,
                CoursePrice = r.CoursePrice,
                Description = r.Description,
                GrantsCertificate = r.GrantsCertificate,
                LengthInDays = r.LengthInDays,
                Name = r.Name,
                UserId = r.UserId,
                IsDeleted = false,
                IsHidden = false,
            };
        }
    }
}
