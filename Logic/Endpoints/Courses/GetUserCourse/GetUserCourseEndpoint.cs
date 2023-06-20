﻿using CourseManagement.Data;
using CourseManagement.Data.Models;
using CourseManagement.Logic.Endpoints;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Logic.Endpoints.Courses.GetUserCourse
{
    public class GetUserCourseEndpoint : EndpointExtended<GetUserCourseRequest, GetUserCourseResponse, GetUserCourseMapper>
    {
        public override void Configure()
        {
            ConfigureEndpoint("myCourse");
        }

        private readonly CourseDbContext courseDbContext;

        public GetUserCourseEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(GetUserCourseRequest req, CancellationToken ct)
        {
            Course? course = courseDbContext.Courses.Include(x => x.Requirements).Include(x => x.GainedSkills).Include(x => x.Languages).Include(x => x.Subtitles).Where(x => x.Id == req.Id && x.UserId == req.UserId && !x.IsDeleted).FirstOrDefault();
            if (course == null)
            {
                await SendErrorsAsync(400, ct);
                return;
            }
            Response = Map.FromEntity(course);
            await SendOkAsync(Response, ct);
        }
    }
}