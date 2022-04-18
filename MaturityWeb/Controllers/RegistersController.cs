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
    public class RegistersController : Controller
    {
        MaturityAssessmentContext _context;
        ILogin obj;
        public RegistersController(ILogin ob)
        {
            obj = ob;
            _context  =  new MaturityAssessmentContext();
        }
        public IActionResult Index()
        {
            List<Register> result = obj.GetAllUser();
            return View(result);
        }
        public IActionResult Add()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles,  "RoleId",  "RoleName");
            
            return View();
        }
        [HttpPost]
        public IActionResult Add(Register e)
        {
            obj.AddUser(e);
            return RedirectToAction("LoginUser");
        }
        public IActionResult Details(int id)
        {
            Register e = obj.GetUserById(id);
            return View(e);
        }
        public IActionResult Edit(int id)
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName");
            Register e = obj.GetUserById(id);
            return View(e);
        }
        [HttpPost]
        public IActionResult EditDetails(Register e)
        {
            obj.UpdateUser(e);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Register e = obj.GetUserById(id);
            return View(e);
        }
        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            obj.DeleteUser(id);
            return RedirectToAction("Index");
        }
        public IActionResult LoginUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginUser(Register model)
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName");
            var rg1 = _context.Registers.Where(e => e.Role.RoleName.Equals("Project Manager")).ToList();
            var rg2 = _context.Registers.Where(e => e.Role.RoleName.Equals("Project Member")).ToList();
            var pr1 = _context.Projects.Where(p => p.Function.FunctionName.Equals("Development")).ToList();
            var pr2 = _context.Projects.Where(p => p.Function.FunctionName.Equals("Testing")).ToList();
            var pr3 = _context.Projects.Where(p => p.Function.FunctionName.Equals("Business")).ToList();
            var pr4 = _context.Projects.Where(p => p.Function.FunctionName.Equals("Consulting")).ToList();
            var mem = _context.ProjectMembers.ToList(); 


            if (obj.ValidateUser(model))
            {
                foreach(var user in rg1)
                {
                    if(user.Email == model.Email)
                    {
                        return Redirect("~/Projects/Home");
                    }
                }
                foreach(var member in mem)
                {
                    if(member.User.Email == model.Email)
                    {
                        foreach(var proj in pr1)
                        {
                            if(member.Project.ProjectId == proj.ProjectId)
                            {
                                return Redirect("~/UserSurveys/Development");
                            }
                        }
                        foreach (var proj in pr2)
                        {
                            if (member.Project.ProjectId == proj.ProjectId)
                            {
                                return Redirect("~/UserSurveys/Testing");
                            }
                        }
                        foreach (var proj in pr3)
                        {
                            if (member.Project.ProjectId == proj.ProjectId)
                            {
                                return Redirect("~/UserSurveys/Business");
                            }
                        }
                        foreach (var proj in pr4)
                        {
                            if (member.Project.ProjectId == proj.ProjectId)
                            {
                                return Redirect("~/UserSurveys/Consulting");
                            }
                        }
                    }
                }
            }
            ModelState.AddModelError("", "Email or Password is Invalid");
            return View();
        }
    }
}
