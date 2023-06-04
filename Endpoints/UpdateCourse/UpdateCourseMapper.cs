using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.UpdateCourse
{
    public class UpdateCourseMapper : Mapper<UpdateCourseRequest, UpdateCourseResponse, Course>
    {
        public override UpdateCourseResponse FromEntity(Course e)
        {
            return new UpdateCourseResponse()
            {
                CertificatePrice = e.CertificatePrice,
                CoursePrice = e.CoursePrice,
                Description = e.Description,
                GrantsCertificate = e.GrantsCertificate,
                Id = e.Id,
                IsHidden = e.IsHidden,
                LengthInDays = e.LengthInDays,
                Name = e.Name,
            };
        }

        public override Course UpdateEntity(UpdateCourseRequest r, Course e)
        {
            e.CertificatePrice = r.CertificatePrice;
            e.CoursePrice = r.CoursePrice;
            e.Description = r.Description;
            e.GrantsCertificate = r.GrantsCertificate;
            e.LengthInDays = r.LengthInDays;
            e.Name = r.Name;
            e.IsHidden = r.IsHidden;
            return e;
        }
    }
}
