using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.GetCourseList
{
    public class GetCourseListMapper: ResponseMapper<GetCourseListResponse[], Course[]>
    {
        public override GetCourseListResponse[] FromEntity(Course[] e)
        {
            return e.Select(x => new GetCourseListResponse
            {
                Id = x.Id,
                CertificatePrice = x.CertificatePrice,
                CoursePrice = x.CoursePrice,
                Description = x.Description,
                GrantsCertificate = x.GrantsCertificate,
                LengthInDays = x.LengthInDays,
                Name = x.Name,
                UserId = x.UserId,
            }).ToArray();
        }
    }
}
