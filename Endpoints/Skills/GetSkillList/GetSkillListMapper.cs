﻿using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.Skills.GetSkillList
{
    public class GetSkillListMapper: ResponseMapper<List<GetSkillListResponse>, List<Skill>>
    {
        public override List<GetSkillListResponse> FromEntity(List<Skill> e)
        {
            return e.Select(x => new GetSkillListResponse
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name
            }).ToList();
        }
    }
}
