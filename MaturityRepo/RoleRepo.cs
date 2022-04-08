using MaturityDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityRepo
{
    public class RoleRepo : IRole
    {
        public int RoleId;
        public string RoleName;
        private readonly MaturityAssessmentContext _context;
        public RoleRepo()
        {
            _context = new MaturityAssessmentContext();
        }
        public void AddRole(Role r)
        {
            _context.Roles.Add(r);
            _context.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            Role ExistingRole = _context.Roles.Where(a => a.RoleId == id).FirstOrDefault();
            _context.Roles.Remove(ExistingRole);
            _context.SaveChanges();
        }

        public List<Role> GetAllRole()
        {
            List<Role> roles = _context.Roles.ToList();

            return roles;
        }

        public Role GetRoleById(int id)
        {
            Role r = _context.Roles.Where(a => a.RoleId == id).FirstOrDefault();

            return r;
        }

        public void UpdateRole(Role r)
        {
            _context.Roles.Update(r);
            _context.SaveChanges();
        }
    }
}
