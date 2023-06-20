using System.Text.Json.Serialization;

namespace CourseManagement.Logic
{
    public class Route
    {
        public required string Name { get; set; }
        public Method? Method { get; set; }
        public string? MethodStr { get; set; }
        public required string Path { get; set; }
        public required string[] Roles { get; set; }
        public required bool IsPublic { get; set; }
    }

    public class RouteDTO
    {
        public required string Name { get; set; }
        public string? MethodStr { get; set; }
        public required string Path { get; set; }
    }
}
