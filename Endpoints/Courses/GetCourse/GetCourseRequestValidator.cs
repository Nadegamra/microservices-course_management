﻿using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Endpoints.Courses.GetCourse
{
    public class GetCourseRequestValidator : Validator<GetCourseRequest>
    {
        public GetCourseRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
        }
    }
}
