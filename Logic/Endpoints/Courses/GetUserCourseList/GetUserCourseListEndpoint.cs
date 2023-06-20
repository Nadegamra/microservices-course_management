﻿using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Logic.Endpoints.Courses.GetUserCourseList
{
    public class GetUserCourseListEndpoint : EndpointExtended<GetUserCourseListRequest, GetUserCourseListResponse, GetUserCourseListMapper>
    {
        public override void Configure()
        {
            ConfigureEndpoint("myCourseList");
        }

        private readonly CourseDbContext courseDbContext;

        public GetUserCourseListEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(GetUserCourseListRequest req, CancellationToken ct)
        {
            Course[] courses = courseDbContext.Courses.Include(x => x.Requirements).Include(x => x.GainedSkills).Include(x => x.Languages).Include(x => x.Subtitles).Where(x => x.UserId == req.UserId && !x.IsDeleted).ToArray();
            Response = Map.FromEntity(courses);
            await SendOkAsync(Response, ct);
        }
    }
}