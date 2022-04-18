using MaturityDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityRepo
{
    public interface IQues
    {
        public List<Question> GetAllQues();
        public Question GetQuesById(int id);
        public void AddQues(Question q);
        public void UpdateQues(Question q);
        public void DeleteQues(int id);
    }
}
