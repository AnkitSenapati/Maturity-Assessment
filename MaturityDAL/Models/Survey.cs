using System;
using System.Collections.Generic;

#nullable disable

namespace MaturityDAL.Models
{
    public partial class Survey
    {
        public Survey()
        {
            UserSurveys = new HashSet<UserSurvey>();
        }

        public int SurveyId { get; set; }
        public string SurveyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<UserSurvey> UserSurveys { get; set; }
    }
}
