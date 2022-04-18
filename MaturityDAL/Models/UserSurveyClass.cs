using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityDAL.Models
{
    public class UserSurveyClass
    {
        public Project projectdetails { get; set; }
        public UserSurvey userdetails { get; set; }
        public ProjectMember memberdetails { get; set; }
        public Function functiondetails { get; set; }

        public Survey surveydetails { get; set; }

    }
}
