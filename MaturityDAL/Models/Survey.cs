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
        
        [Required(ErrorMessage = "Survey Name can not be null")]
        public int SurveyId { get; set; }
        public string SurveyName { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public virtual ICollection<UserSurvey> UserSurveys { get; set; }
    }
}
