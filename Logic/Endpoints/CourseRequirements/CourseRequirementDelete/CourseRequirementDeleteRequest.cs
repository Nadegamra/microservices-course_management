﻿using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseRequirements.CourseRequirementDelete
{
    public class CourseRequirementDeleteRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int Id { get; set; }
    }
}
