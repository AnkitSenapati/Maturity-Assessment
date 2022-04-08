using System;
using System.Collections.Generic;

#nullable disable

namespace MaturityDAL.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectMembers = new HashSet<ProjectMember>();
        }

        public string ProjectName { get; set; }
        public int ProjectId { get; set; }
        public string ProjectDesc { get; set; }
        public int? FunctionId { get; set; }

        public virtual Function Function { get; set; }
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
    }
}
