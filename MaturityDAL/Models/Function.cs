using System;
using System.Collections.Generic;

#nullable disable

namespace MaturityDAL.Models
{
    public partial class Function
    {
        public Function()
        {
            Projects = new HashSet<Project>();
            Questions = new HashSet<Question>();
        }

        public int FunctionId { get; set; }
        public string FunctionName { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
