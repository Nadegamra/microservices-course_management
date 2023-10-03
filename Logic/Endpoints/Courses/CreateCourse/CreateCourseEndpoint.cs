using CourseManagement.Data;
using CourseManagement.Data.Models;
using CourseManagement.IntegrationEvents.Events;
using FastEndpoints;
using Infrastructure.EventBus.Generic;

namespace CourseManagement.Logic.Endpoints.Courses.CreateCourse
{
    public class CreateCourseEndpoint : Endpoint<CreateCourseRequest, CreateCourseResponse, CreateCourseMapper>
    {
        public override void Configure()
        {
            Post("courses");
            Roles("ADMIN", "CREATOR");
        }

        private readonly CourseDbContext courseDbContext;
        private readonly Infrastructure.EventBus.Generic.IEventBus eventBus;

        public CreateCourseEndpoint(CourseDbContext courseDbContext, Infrastructure.EventBus.Generic.IEventBus eventBus)
        {
            this.courseDbContext = courseDbContext;
            this.eventBus = eventBus;
        }

        public override async Task HandleAsync(CreateCourseRequest req, CancellationToken ct)
        {
            Course course = Map.ToEntity(req);

            var res = courseDbContext.Courses.Add(course);
            courseDbContext.SaveChanges();

            Response = Map.FromEntity(res.Entity);

            eventBus.Publish(new CourseCreatedIntegrationEvent()
            {
                Id = Response.Id,
                UserId = Response.UserId
            });

            await SendOkAsync(Response);
        }
    }
}
