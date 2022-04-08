using MaturityDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityRepo
{
    public interface ILogin
    {
        int ValidateUser(Register e);
        public List<Register> GetAllUser();
        public Register GetUserById(int id);
        public void AddUser(Register e);
        public void UpdateUser(Register e);
        public void DeleteUser(int id);
    }
}
