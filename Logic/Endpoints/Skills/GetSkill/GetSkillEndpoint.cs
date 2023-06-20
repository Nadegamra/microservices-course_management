﻿using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Skills.GetSkill
{
    public class GetSkillEndpoint: EndpointExtended<GetSkillRequest, GetSkillResponse,GetSkillMapper>
    {
        public override void Configure()
        {
            ConfigureEndpoint("getSkill");
        }

        private readonly CourseDbContext courseDbContext;

        public GetSkillEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(GetSkillRequest req, CancellationToken ct)
        {
            Skill? skill = courseDbContext.Skills.Where(x=>x.Id == req.Id).FirstOrDefault();
            if (skill == null)
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            Response = Map.FromEntity(skill);
            await SendOkAsync(Response, ct);
        }
    }
}