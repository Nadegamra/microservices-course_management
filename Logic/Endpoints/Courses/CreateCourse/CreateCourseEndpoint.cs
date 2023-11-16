using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using CourseManagement.IntegrationEvents.Events;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Courses.CreateCourse
{
    public class CreateCourseEndpoint : Endpoint<CreateCourseRequest, CreateCourseResponse, CreateCourseMapper>
    {
        public override void Configure()
        {
            Post("courses");
            Roles("CREATOR");
        }

        private readonly IRepository<Course> repository;
        private readonly Infrastructure.EventBus.Generic.IEventBus eventBus;

        public CreateCourseEndpoint(Infrastructure.EventBus.Generic.IEventBus eventBus, IRepository<Course> repository)
        {
            this.eventBus = eventBus;
            this.repository = repository;
        }

        public override async Task HandleAsync(CreateCourseRequest req, CancellationToken ct)
        {
            Course course = Map.ToEntity(req);

            var res = repository.Add(course);

            Response = Map.FromEntity(res);

            eventBus.Publish(new CourseCreatedIntegrationEvent()
            {
                Id = Response.Id,
                UserId = Response.UserId
            });

            await SendCreatedAtAsync($"courses/{res.Id}", null, Response, false, ct);
        }
    }
}
