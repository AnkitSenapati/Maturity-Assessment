using MaturityDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityRepo
{
    public class ProjMemRepo : IProjMem
    {
        private readonly MaturityAssessmentContext _context;
        public ProjMemRepo(MaturityAssessmentContext context)
        {
            _context = context;
        }
        public void AddMem(ProjectMember pm)
        {
            _context.ProjectMembers.Include(i => i.Project);
            _context.ProjectMembers.Include(j => j.User);
            _context.ProjectMembers.Add(pm);
            _context.SaveChanges();
        }

        public void DeleteMem(int id)
        {
            ProjectMember ExistingMem = _context.ProjectMembers.Where(a => a.ProjectMemberId == id)
                .Include(c => c.Project).Include(j => j.User).FirstOrDefault();
            _context.ProjectMembers.Remove(ExistingMem);
            _context.SaveChanges();
        }

        public List<ProjectMember> GetAllMem()
        {
            List<ProjectMember> mem = _context.ProjectMembers.Include(c => c.Project).Include(j => j.User).ToList();

            return mem;
        }

        public ProjectMember GetMemById(int id)
        {
            ProjectMember pm = _context.ProjectMembers.Where(a => a.ProjectMemberId == id).Include(c => c.Project)
                .Include(j => j.User).FirstOrDefault();

            return pm;
        }


        public void UpdateMem(ProjectMember pm)
        {
            _context.ProjectMembers.Update(pm);
            _context.SaveChanges();
        }
    }
}
