using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.GetUserCourseList
{
    public class GetUserCourseListMapper: ResponseMapper<GetUserCourseListResponse[], Course[]>
    {
        public override GetUserCourseListResponse[] FromEntity(Course[] e)
        {
            return e.Select(x => new GetUserCourseListResponse
            {
                Id = x.Id,
                CertificatePrice = x.CertificatePrice,
                CoursePrice = x.CoursePrice,
                Description = x.Description,
                GrantsCertificate = x.GrantsCertificate,
                LengthInDays = x.LengthInDays,
                Name = x.Name,
                UserId = x.UserId,
                IsHidden = x.IsHidden,
            }).ToArray();
        }
    }
}
