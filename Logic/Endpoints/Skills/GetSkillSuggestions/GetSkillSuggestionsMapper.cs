using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Skills.GetSkillSuggestions
{
    public class GetSkillSuggestionsMapper : ResponseMapper<GetSkillSuggestionsResponse[], Skill[]>
    {
        public override GetSkillSuggestionsResponse[] FromEntity(Skill[] e)
        {
            return e.Select(x => new GetSkillSuggestionsResponse { Name = x.Name, Id = x.Id }).ToArray();
        }
    }
}