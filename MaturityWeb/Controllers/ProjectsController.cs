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
    public class ProjectsController : Controller
    {
        MaturityAssessmentContext _context;
        IProject obj;
        public ProjectsController(IProject ob)
        {
            obj = ob;
            _context = new MaturityAssessmentContext();
        }
        public IActionResult Index()
        {
            List<Project> result = obj.GetAllProj();
            return View(result);
        }

        public IActionResult Create()
        {
            ViewData["FunctionId"] = new SelectList(_context.Functions, "FunctionId", "FunctionName");
            return View();
        }
        [HttpPost]
        [ActionName("Add")]
        public IActionResult Create(Project p)
        {
            obj.AddProj(p);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            Project p = obj.GetProjById(id);
            return View(p);
        }
        public IActionResult Edit(int id)
        {
            ViewData["FunctionId"] = new SelectList(_context.Functions, "FunctionId", "FunctionName");
            Project p = obj.GetProjById(id);
            return View(p);
        }
        [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditDetails(Project p)
        {
            obj.UpdateProj(p);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Project p = obj.GetProjById(id);
            return View(p);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteFunc(int id)
        {
            obj.DeleteProj(id);
            return RedirectToAction("Index");
        }
        public IActionResult Home()
        {
            List<Project> result = obj.GetAllProj();
            return View(result);
        }
        public IActionResult UserHome()
        {
            return View();
        }
    }
}
