using MaturityDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityRepo
{
    public interface IUserSurvey
    {
        public List<UserSurvey> GetAllUserSurvey();
        public UserSurvey GetUserSurveyById(int id);
        public void AddUserSurvey(UserSurvey us);
        public void UpdateUserSurvey(UserSurvey us);
        public void DeleteUserSurvey(int id);
    }
}
