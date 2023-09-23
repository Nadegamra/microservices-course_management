using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagement.Logic.Endpoints.Skills.GetSkillSuggestions
{
    public class GetSkillSuggestionsRequest
    {
        [FromQuery(Name = "name")]
        public string Name { get; set; }
    }
}