using MaturityDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityRepo
{
    public interface IRole
    {
        public List<Role> GetAllRole();
        public Role GetRoleById(int id);
        public void AddRole(Role r);
        public void UpdateRole(Role r);
        public void DeleteRole(int id);
    }
}
