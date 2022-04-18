using MaturityDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityRepo
{
    public interface IProjMem
    {
        public List<ProjectMember> GetAllMem();
        public ProjectMember GetMemById(int id);
        public void AddMem(ProjectMember pm);
        public void UpdateMem(ProjectMember pm);
        public void DeleteMem(int id);
    }
}
