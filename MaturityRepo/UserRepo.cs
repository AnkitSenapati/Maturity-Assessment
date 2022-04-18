using MaturityDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityRepo
{
    public class UserRepo : IUserSurvey
    {
        private readonly MaturityAssessmentContext _context;
        public UserRepo(MaturityAssessmentContext context)
        {
            _context = context;
        }
        public void AddUserSurvey(UserSurvey us)
        {
            _context.UserSurveys.Include(i => i.Question).Include(l => l.Answer).Include(j => j.Survey).Include(k => k.ProjectMember);
            _context.UserSurveys.Add(us);
            _context.SaveChanges();
        }

        public void DeleteUserSurvey(int id)
        {
            UserSurvey Existingsurv = _context.UserSurveys.Where(a => a.UserSurveyId == id)
                .Include(i => i.Question).Include(l => l.Answer).Include(j => j.Survey).Include(k => k.ProjectMember).FirstOrDefault();
            _context.UserSurveys.Remove(Existingsurv);
            _context.SaveChanges();
        }

        public List<UserSurvey> GetAllUserSurvey()
        {
            List<UserSurvey> usurvey = _context.UserSurveys
                .Include(i => i.Question).Include(l => l.Answer).Include(j => j.Survey).Include(k => k.ProjectMember).ToList();

            return usurvey;
        }

        public UserSurvey GetUserSurveyById(int id)
        {
            UserSurvey us = _context.UserSurveys.Where(a => a.UserSurveyId == id)
                .Include(i => i.Question).Include(l => l.Answer).Include(j => j.Survey).Include(k => k.ProjectMember).FirstOrDefault();

            return us;
        }

        public void UpdateUserSurvey(UserSurvey us)
        {
            _context.UserSurveys.Update(us);
            _context.SaveChanges();
        }
    }
}
