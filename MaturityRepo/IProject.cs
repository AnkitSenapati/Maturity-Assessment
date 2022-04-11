using MaturityDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityRepo
{
    public interface IProject
    {
        public List<Project> GetAllProj();
        public Project GetProjById(int id);
        public void AddProj(Project e);
        public void UpdateProj(Project e);
        public void DeleteProj(int id);
    }
}
