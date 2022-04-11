using MaturityDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityRepo
{
    public class ProjRepo : IProject
    {
        private readonly MaturityAssessmentContext _context;
        public ProjRepo(MaturityAssessmentContext context)
        {
            _context = context;
        }
        public void AddProj(Project p)
        {
            _context.Projects.Include(i => i.Function);
            _context.Projects.Add(p);
            _context.SaveChanges();
        }

        public void DeleteProj(int id)
        {
            Project ExistingProj = _context.Projects.Where(a => a.ProjectId == id).Include(c => c.Function).FirstOrDefault();
            _context.Projects.Remove(ExistingProj);
            _context.SaveChanges();
        }

        public List<Project> GetAllProj()
        {
            List<Project> proj = _context.Projects.Include(c => c.Function).ToList();

            return proj;
        }

        public Project GetProjById(int id)
        {
            Project p = _context.Projects.Where(a => a.ProjectId == id).Include(c => c.Function).FirstOrDefault();

            return p;
        }

        public void UpdateProj(Project p)
        {
            _context.Projects.Update(p);
            _context.SaveChanges();
        }
    }
}
