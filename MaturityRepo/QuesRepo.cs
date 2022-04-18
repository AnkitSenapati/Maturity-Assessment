using MaturityDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityRepo
{
    public class QuesRepo : IQues
    {
        private readonly MaturityAssessmentContext _context;
        public QuesRepo(MaturityAssessmentContext context)
        {
            _context = context;
        }
        public void AddQues(Question q)
        {
            _context.Questions.Include(i => i.Function);
            _context.Questions.Add(q);
            _context.SaveChanges();
        }

        public void DeleteQues(int id)
        {
            Question ExistingQues = _context.Questions.Where(a => a.QuestionId == id).Include(c => c.Function).FirstOrDefault();
            _context.Questions.Remove(ExistingQues);
            _context.SaveChanges();
        }

        public List<Question> GetAllQues()
        {
            List<Question> ques = _context.Questions.Include(c => c.Function).ToList();

            return ques;
        }

        public Question GetQuesById(int id)
        {
            Question q = _context.Questions.Where(a => a.QuestionId == id).Include(c => c.Function).FirstOrDefault();

            return q;
        }

        public void UpdateQues(Question q)
        {
            _context.Questions.Update(q);
            _context.SaveChanges();
        }
    }
}
