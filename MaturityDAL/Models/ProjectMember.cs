using System;
using System.Collections.Generic;

#nullable disable

namespace MaturityDAL.Models
{
    public partial class ProjectMember
    {
        public ProjectMember()
        {
            UserSurveys = new HashSet<UserSurvey>();
        }

        public int ProjectMemberId { get; set; }
        public int? ProjectId { get; set; }
        public int? Userid { get; set; }

        public virtual Project Project { get; set; }
        public virtual Register User { get; set; }
        public virtual ICollection<UserSurvey> UserSurveys { get; set; }
    }
}
