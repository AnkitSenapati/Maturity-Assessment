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
    public class ProjMemController : Controller
    {
        MaturityAssessmentContext _context;
        IProjMem obj;
        public ProjMemController(IProjMem ob)
        {
            obj = ob;
            _context = new MaturityAssessmentContext();
        }
        public IActionResult Index()
        {
            List<ProjectMember> result = obj.GetAllMem();
            return View(result);
        }

        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName");
            ViewData["Userid"] = new SelectList(_context.Registers, "Userid", "Email");
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProjectMember pm)
        {
            obj.AddMem(pm);
            return RedirectToAction("Home", "Projects");
        }
        public IActionResult Details(int id)
        {
            ProjectMember pm = obj.GetMemById(id);
            return View(pm);
        }
        public IActionResult Edit(int id)
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName");
            ViewData["Userid"] = new SelectList(_context.Registers, "Userid", "Email");
            ProjectMember pm = obj.GetMemById(id);
            return View(pm);
        }
        [HttpPost]
        public IActionResult EditDetails(ProjectMember pm)
        {
            obj.UpdateMem(pm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            ProjectMember pm = obj.GetMemById(id);
            return View(pm);
        }
        [HttpPost]
        public IActionResult DeleteFunc(int id)
        {
            obj.DeleteMem(id);
            return RedirectToAction("Index");
        }
    }
}
