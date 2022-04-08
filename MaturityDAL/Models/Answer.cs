using System;
using System.Collections.Generic;

#nullable disable

namespace MaturityDAL.Models
{
    public partial class Answer
    {
        public Answer()
        {
            UserSurveys = new HashSet<UserSurvey>();
        }

        public int AnswerId { get; set; }
        public int? QuestionId { get; set; }
        public int Weightage { get; set; }
        public string AnswerName { get; set; }

        public virtual Question Question { get; set; }
        public virtual ICollection<UserSurvey> UserSurveys { get; set; }
    }
}
