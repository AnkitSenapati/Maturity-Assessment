using MaturityDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityRepo
{
    public interface ISurvey
    {
        public List<Survey> GetAllSurvey();
        public Survey GetSurveyById(int id);
        public void AddSurvey(Survey s);
        public void UpdateSurvey(Survey s);
        public void DeleteSurvey(int id);
    }
}
