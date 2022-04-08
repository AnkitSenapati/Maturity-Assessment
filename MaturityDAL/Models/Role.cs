using System;
using System.Collections.Generic;

#nullable disable

namespace MaturityDAL.Models
{
    public partial class Role
    {
        public Role()
        {
            Registers = new HashSet<Register>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Register> Registers { get; set; }
    }
}
