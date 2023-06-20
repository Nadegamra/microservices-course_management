namespace CourseManagement.Logic.Endpoints.Courses.GetUserCourseList
{
    public class GetUserCourseListResponse
    {
        public GetUserCourseListItem[] Items { get; set; }
        public RouteDTO[] Routes { get; set; }
    }
}
