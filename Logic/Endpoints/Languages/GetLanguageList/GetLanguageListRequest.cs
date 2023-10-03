using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.Logic.Endpoints.Languages.GetLanguageList
{
    public class GetLanguageListRequest
    {
        public required int Skip { get; set; } = 0;
        public required int Take { get; set; } = 10;
    }
}