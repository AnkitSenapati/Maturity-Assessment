using MaturityDAL.Models;
using MaturityRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaturityWeb.Controllers
{
    public class AnswersController : Controller
    {
        MaturityAssessmentContext _context;
        IAns obj;
        public AnswersController(IAns ob)
        {
            obj = ob;
            _context = new MaturityAssessmentContext();
        }
        public IActionResult Index()
        {
            List<Answer> result = obj.GetAllAns();
            return View(result);
        }

        public IActionResult Create()
        {
            ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Answer a)
        {
            obj.AddAns(a);
            return RedirectToAction("Home","Projects");
        }
        public IActionResult Details(int id)
        {
            Answer p = obj.GetAnsById(id);
            return View(p);
        }
        public IActionResult Edit(int id)
        {
            ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionName");
            Answer a = obj.GetAnsById(id);
            return View(a);
        }
        [HttpPost]
        public IActionResult EditDetails(Answer a)
        {
            obj.UpdateAns(a);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Answer a = obj.GetAnsById(id);
            return View(a);
        }
        [HttpPost]
        public IActionResult DeleteFunc(int id)
        {
            obj.DeleteAns(id);
            return RedirectToAction("Index");
        }
    }
}
