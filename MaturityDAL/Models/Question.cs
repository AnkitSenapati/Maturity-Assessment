using System;
using System.Collections.Generic;

#nullable disable

namespace MaturityDAL.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            UserSurveys = new HashSet<UserSurvey>();
        }

        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        public int? FunctionId { get; set; }

        public virtual Function Function { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<UserSurvey> UserSurveys { get; set; }
    }
}
