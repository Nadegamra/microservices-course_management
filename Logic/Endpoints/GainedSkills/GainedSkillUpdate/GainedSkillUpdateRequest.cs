﻿using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.GainedSkills.GainedSkillUpdate
{
    public class GainedSkillUpdateRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int Id { get; set; }
        public required string CustomDescription { get; set; }
    }
}
