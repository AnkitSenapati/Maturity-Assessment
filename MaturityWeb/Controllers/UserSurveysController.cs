using MaturityDAL.Models;
using MaturityRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaturityWeb.Controllers
{
    public class UserSurveysController : Controller
    {
        MaturityAssessmentContext _context;
        IUserSurvey obj;
        ISurvey obj2;
        public UserSurveysController(IUserSurvey ob, ISurvey ob2)
        {
            obj = ob;
            obj2 = ob2;
            _context = new MaturityAssessmentContext();
        }
        public IActionResult Index()
        {
            List<UserSurvey> result = obj.GetAllUserSurvey();
            return View(result);
        }

        public IActionResult Create()
        {
            ViewData["SurveyId"] = new SelectList(_context.Surveys, "SurveyId", "SurveyName");
            ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionName");
            ViewData["AnswerId"] = new SelectList(_context.Answers, "AnswerId", "AnswerName");
            ViewData["ProjectMemberId"] = new SelectList(_context.ProjectMembers, "ProjectMemberId", "ProjectMemberId");

            return View();
        }
        [HttpPost]
        public IActionResult Create(UserSurvey us)
        {
            obj.AddUserSurvey(us);
            return RedirectToAction("Home","Projects");
        }
        public IActionResult Details(int id)
        {
            UserSurvey us = obj.GetUserSurveyById(id);
            return View(us);
        }
        public IActionResult Edit(int id)
        {
            ViewData["SurveyId"] = new SelectList(_context.Surveys, "SurveyId", "SurveyName");
            ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionName");
            ViewData["AnswerId"] = new SelectList(_context.Answers, "AnswerId", "AnswerName");
            ViewData["ProjectMemberId"] = new SelectList(_context.ProjectMembers, "ProjectMemberId", "ProjectMemberId");
            UserSurvey us = obj.GetUserSurveyById(id);
            return View(us);
        }
        [HttpPost]
        public IActionResult EditDetails(UserSurvey us)
        {
            obj.UpdateUserSurvey(us);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            UserSurvey us = obj.GetUserSurveyById(id);
            return View(us);
        }
        [HttpPost]
        public IActionResult DeleteFunc(int id)
        {
            obj.DeleteUserSurvey(id);
            return RedirectToAction("Index");
        }
        public IActionResult Home()
        {
            List<ProjectMember> member = _context.ProjectMembers.ToList();
            List<UserSurvey> usrvey = _context.UserSurveys.ToList();
            var fname = _context.Projects.Where(p => p.Function.FunctionName.Equals("Development")).ToList();
            List<Survey> surv = _context.Surveys.ToList();

            var multipledata = from u in usrvey
                               join s in surv on u.SurveyId equals s.SurveyId
                               join m in member on u.ProjectMemberId equals m.ProjectMemberId into table1
                               from m in table1.Distinct()
                               join p in fname on m.ProjectId equals p.ProjectId into table2
                               from p in table2.Distinct()
                               select new UserSurveyClass { userdetails = u, memberdetails = m, projectdetails = p, 
                                    surveydetails = s };
            return View(multipledata);
        }
        public IActionResult Development()
        {
            List<ProjectMember> member = _context.ProjectMembers.ToList();
            List<UserSurvey> usrvey = _context.UserSurveys.ToList();
            var fname = _context.Projects.Where(p => p.Function.FunctionName.Equals("Development")).ToList();
            List<Survey> surv = _context.Surveys.ToList();

            var multipledata = from u in usrvey
                               join s in surv on u.SurveyId equals s.SurveyId
                               join m in member on u.ProjectMemberId equals m.ProjectMemberId into table1
                               from m in table1.Distinct()
                               join p in fname on m.ProjectId equals p.ProjectId into table2
                               from p in table2.Distinct()
                               select new UserSurveyClass
                               {
                                   userdetails = u,
                                   memberdetails = m,
                                   projectdetails = p,
                                   surveydetails = s
                               };
            return View(multipledata);
        }
        public IActionResult Testing()
        {
            List<ProjectMember> member = _context.ProjectMembers.ToList();
            List<UserSurvey> usrvey = _context.UserSurveys.ToList();
            var fname = _context.Projects.Where(p => p.Function.FunctionName.Equals("Testing")).ToList();
            List<Survey> surv = _context.Surveys.ToList();

            var multipledata = from u in usrvey
                               join s in surv on u.SurveyId equals s.SurveyId
                               join m in member on u.ProjectMemberId equals m.ProjectMemberId into table1
                               from m in table1.Distinct()
                               join p in fname on m.ProjectId equals p.ProjectId into table2
                               from p in table2.Distinct()
                               select new UserSurveyClass
                               {
                                   userdetails = u,
                                   memberdetails = m,
                                   projectdetails = p,
                                   surveydetails = s
                               };
            return View(multipledata);
        }
        public IActionResult Business()
        {
            List<ProjectMember> member = _context.ProjectMembers.ToList();
            List<UserSurvey> usrvey = _context.UserSurveys.ToList();
            var fname = _context.Projects.Where(p => p.Function.FunctionName.Equals("Business")).ToList();
            List<Survey> surv = _context.Surveys.ToList();

            var multipledata = from u in usrvey
                               join s in surv on u.SurveyId equals s.SurveyId
                               join m in member on u.ProjectMemberId equals m.ProjectMemberId into table1
                               from m in table1.Distinct()
                               join p in fname on m.ProjectId equals p.ProjectId into table2
                               from p in table2.Distinct()
                               select new UserSurveyClass
                               {
                                   userdetails = u,
                                   memberdetails = m,
                                   projectdetails = p,
                                   surveydetails = s
                               };
            return View(multipledata);
        }
        public IActionResult Consulting()
        {
            List<ProjectMember> member = _context.ProjectMembers.ToList();
            List<UserSurvey> usrvey = _context.UserSurveys.ToList();
            var fname = _context.Projects.Where(p => p.Function.FunctionName.Equals("Consulting")).ToList();
            List<Survey> surv = _context.Surveys.ToList();

            var multipledata = from u in usrvey
                               join s in surv on u.SurveyId equals s.SurveyId
                               join m in member on u.ProjectMemberId equals m.ProjectMemberId into table1
                               from m in table1.Distinct()
                               join p in fname on m.ProjectId equals p.ProjectId into table2
                               from p in table2.Distinct()
                               select new UserSurveyClass
                               {
                                   userdetails = u,
                                   memberdetails = m,
                                   projectdetails = p,
                                   surveydetails = s
                               };
            return View(multipledata);
        }
        public IActionResult SurveyPage()
        {
            List<Survey> result = obj2.GetAllSurvey();
            return View(result);
        }
        public IActionResult UserHome()
        {
            return View();
        }
    }
}
