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
    public class QuesController : Controller
    {
        MaturityAssessmentContext _context;
        IQues obj;
        public QuesController(IQues ob)
        {
            obj = ob;
            _context = new MaturityAssessmentContext();
        }
        public IActionResult Index()
        {
            List<Question> result = obj.GetAllQues();
            return View(result);
        }

        public IActionResult Create()
        {
            ViewData["FunctionId"] = new SelectList(_context.Functions, "FunctionId", "FunctionName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Question q)
        {
            obj.AddQues(q);
            return RedirectToAction("Home","Projects");
        }
        public IActionResult Details(int id)
        {
            Question p = obj.GetQuesById(id);
            return View(p);
        }
        public IActionResult Edit(int id)
        {
            ViewData["FunctionId"] = new SelectList(_context.Functions, "FunctionId", "FunctionName");
            Question p = obj.GetQuesById(id);
            return View(p);
        }
        [HttpPost]
        public IActionResult EditDetails(Question q)
        {
            obj.UpdateQues(q);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Question q = obj.GetQuesById(id);
            return View(q);
        }
        [HttpPost]
        public IActionResult DeleteFunc(int id)
        {
            obj.DeleteQues(id);
            return RedirectToAction("Index");
        }
    }
}
