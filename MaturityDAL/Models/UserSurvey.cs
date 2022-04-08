using System;
using System.Collections.Generic;

#nullable disable

namespace MaturityDAL.Models
{
    public partial class UserSurvey
    {
        public int UserSurveyId { get; set; }
        public int? SurveyId { get; set; }
        public int? QuestionId { get; set; }
        public int? AnswerId { get; set; }
        public int? ProjectMemberId { get; set; }

        public virtual Answer Answer { get; set; }
        public virtual ProjectMember ProjectMember { get; set; }
        public virtual Question Question { get; set; }
        public virtual Survey Survey { get; set; }
    }
}
