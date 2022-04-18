using MaturityDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityRepo
{
    public class SurveyRepo : ISurvey
    {
        private readonly MaturityAssessmentContext _context;
        public SurveyRepo()
        {
            _context = new MaturityAssessmentContext();
        }
        public void AddSurvey(Survey s)
        {
            _context.Surveys.Add(s);
            _context.SaveChanges();
        }

        public void DeleteSurvey(int id)
        {
            Survey ExistingSurvey = _context.Surveys.Where(a => a.SurveyId == id).FirstOrDefault();
            _context.Surveys.Remove(ExistingSurvey);
            _context.SaveChanges();
        }

        public List<Survey> GetAllSurvey()
        {
            List<Survey> survey = _context.Surveys.ToList();

            return survey;
        }

        public Survey GetSurveyById(int id)
        {
            Survey s = _context.Surveys.Where(a => a.SurveyId == id).FirstOrDefault();

            return s;
        }

        public void UpdateSurvey(Survey s)
        {
            _context.Surveys.Update(s);
            _context.SaveChanges();
        }
    }
}
