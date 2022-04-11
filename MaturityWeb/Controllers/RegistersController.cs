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
            Register rg1 = _context.Registers.FirstOrDefault(e => e.Role.RoleName.Equals("Project Manager"));
            Register rg2 = _context.Registers.FirstOrDefault(e => e.Role.RoleName.Equals("Project Member"));
            if (obj.ValidateUser(model))
            {
                if (model.Email == rg1.Email)
                {
                    return Redirect("~/Projects/Home");
                }
                else if(model.Email == rg2.Email)
                {
                    return Redirect("~/Projects/UserHome");
                }
            }
            ModelState.AddModelError("", "Email or Password is Invalid");
            return View();
        }
    }
}
