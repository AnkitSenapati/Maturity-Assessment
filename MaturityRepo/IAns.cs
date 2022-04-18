using MaturityDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityRepo
{
    public interface IAns
    {
        public List<Answer> GetAllAns();
        public Answer GetAnsById(int id);
        public void AddAns(Answer a);
        public void UpdateAns(Answer a);
        public void DeleteAns(int id);
    }
}
