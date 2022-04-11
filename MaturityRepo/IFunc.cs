using MaturityDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityRepo
{
    public interface IFunc
    {
        public List<Function> GetAllFunc();
        public Function GetFuncById(int id);
        public void AddFunc(Function e);
        public void UpdateFunc(Function e);
        public void DeleteFunc(int id);
    }
}
