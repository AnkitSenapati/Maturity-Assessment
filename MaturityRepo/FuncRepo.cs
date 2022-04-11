using MaturityDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityRepo
{
    public class FuncRepo : IFunc
    {
        private readonly MaturityAssessmentContext _context;
        public FuncRepo(MaturityAssessmentContext context)
        {
            _context = context;
        }
        public void AddFunc(Function f)
        {
            _context.Functions.Add(f);
            _context.SaveChanges();
        }

        public void DeleteFunc(int id)
        {
            Function ExistingFunc = _context.Functions.Where(a => a.FunctionId == id).FirstOrDefault();
            _context.Functions.Remove(ExistingFunc);
            _context.SaveChanges();
        }

        public List<Function> GetAllFunc()
        {
            List<Function> functions = _context.Functions.ToList();

            return functions;
        }

        public Function GetFuncById(int id)
        {
            Function f = _context.Functions.Where(a => a.FunctionId == id).FirstOrDefault();

            return f;
        }

        public void UpdateFunc(Function f)
        {
            _context.Functions.Update(f);
            _context.SaveChanges();
        }
    }
}
