using MaturityDAL.Models;
using MaturityRepo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaturityWeb.Controllers

{
    public class FunctionsController : Controller
    {
        MaturityAssessmentContext _context;
        IFunc obj;
        public FunctionsController(IFunc ob)
        {
            obj = ob;
            _context = new MaturityAssessmentContext();
        }
        public IActionResult Index()
        {
            List<Function> result = obj.GetAllFunc();
            return View(result);
        }
        public IActionResult Create(int id)
        {
            Function r = obj.GetFuncById(id);
            return View(r);
        }
        [HttpPost]
        [ActionName("Add")]
        public IActionResult Create(Function f)
        {
            obj.AddFunc(f);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            Function f = obj.GetFuncById(id);
            return View(f);
        }
        public IActionResult Edit(int id)
        {
            Function f = obj.GetFuncById(id);
            return View(f);
        }
        [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditDetails(Function f)
        {
            obj.UpdateFunc(f);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Function f = obj.GetFuncById(id);
            return View(f);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteFunc(int id)
        {
            obj.DeleteFunc(id);
            return RedirectToAction("Index");
        }
    }
}
