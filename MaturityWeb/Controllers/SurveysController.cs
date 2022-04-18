using MaturityDAL.Models;
using MaturityRepo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaturityWeb.Controllers
{
    public class SurveysController : Controller
    {
        MaturityAssessmentContext _context;
        ISurvey obj;
        public SurveysController(ISurvey ob)
        {
            obj = ob;
            _context = new MaturityAssessmentContext();
        }
        public IActionResult Index()
        {
            List<Survey> result = obj.GetAllSurvey();
            return View(result);
        }
        public IActionResult Create(int id)
        {
            Survey s = obj.GetSurveyById(id);
            return View(s);
        }
        [HttpPost]
        public IActionResult Create(Survey s)
        {
            obj.AddSurvey(s);
            return RedirectToAction("Home","Projects");
        }
        public IActionResult Details(int id)
        {
            Survey s = obj.GetSurveyById(id);
            return View(s);
        }
        public IActionResult Edit(int id)
        {
            Survey s = obj.GetSurveyById(id);
            return View(s);
        }
        [HttpPost]
        public IActionResult EditDetails(Survey s)
        {
            obj.UpdateSurvey(s);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Survey s = obj.GetSurveyById(id);
            return View(s);
        }
        [HttpPost]
        public IActionResult DeleteRole(int id)
        {
            obj.DeleteSurvey(id);
            return RedirectToAction("Index");
        }
        public IActionResult DevelopmentSurvey()
        {
            List<Answer> ansname = _context.Answers.ToList();
            var qstname = _context.Questions.Where(f => f.Function.FunctionName.Equals("Development")).ToList();


            var result = from q in qstname
                         join a in ansname on q.QuestionId equals a.QuestionId into table1
                         from a in table1.Distinct()
                         select new SurveyClass
                         { qstndetails = q, ansdetails = a };
            return View(result);
        }
        public IActionResult TestingSurvey()
        {
            List<Answer> ansname = _context.Answers.ToList();
            var qstname = _context.Questions.Where(f => f.Function.FunctionName.Equals("Testing")).ToList();

            
            var result = from a in ansname
                         join q in qstname on a.QuestionId equals q.QuestionId into table1
                         from q in table1.Distinct()
                         select new SurveyClass
                         { qstndetails = q, ansdetails = a };
            return View(result);
        }
        public IActionResult BusinessSurvey()
        {
            List<Answer> ansname = _context.Answers.ToList();
            var qstname = _context.Questions.Where(f => f.Function.FunctionName.Equals("Business")).ToList();


            var result = from a in ansname
                         join q in qstname on a.QuestionId equals q.QuestionId into table1
                         from q in table1.Distinct()
                         select new SurveyClass
                         { qstndetails = q, ansdetails = a };
            return View(result);
        }
        public IActionResult ConsultingSurvey()
        {
            List<Answer> ansname = _context.Answers.ToList();
            var qstname = _context.Questions.Where(f => f.Function.FunctionName.Equals("Consulting")).ToList();


            var result = from a in ansname
                         join q in qstname on a.QuestionId equals q.QuestionId into table1
                         from q in table1.Distinct()
                         select new SurveyClass
                         { qstndetails = q, ansdetails = a };
            return View(result);
        }
    }
}
