using MaturityDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityRepo
{
    public class AnsRepo : IAns
    {
        private readonly MaturityAssessmentContext _context;
        public AnsRepo(MaturityAssessmentContext context)
        {
            _context = context;
        }
        public void AddAns(Answer a)
        {
            _context.Answers.Include(i => i.Question);
            _context.Answers.Add(a);
            _context.SaveChanges();
        }

        public void DeleteAns(int id)
        {
            Answer ExistingAns = _context.Answers.Where(a => a.AnswerId == id).Include(c => c.Question).FirstOrDefault();
            _context.Answers.Remove(ExistingAns);
            _context.SaveChanges();
        }

        public List<Answer> GetAllAns()
        {
            List<Answer> ans = _context.Answers.Include(c => c.Question).ToList();

            return ans;
        }

        public Answer GetAnsById(int id)
        {
            Answer a = _context.Answers.Where(a => a.AnswerId == id).Include(c => c.Question).FirstOrDefault();

            return a;
        }

        public void UpdateAns(Answer a)
        {
            _context.Answers.Update(a);
            _context.SaveChanges();
        }
    }
}
