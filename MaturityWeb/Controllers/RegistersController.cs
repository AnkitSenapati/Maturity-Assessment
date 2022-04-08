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
        [ActionName("Add")]
        public IActionResult Add(Register e)
        {
            bool contains = _context.Registers.Any(x => x.Email == e.Email);
            if (!contains)
            {
                obj.AddUser(e);
                return RedirectToAction("LoginUser");
            }
            ModelState.AddModelError("", "Email already Exists");
            return View();
            
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
        [ActionName("Edit")]
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
        [ActionName("Delete")]
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
            int value = obj.ValidateUser(model);
            if (value == 1)
            {
                return Redirect("~/Registers/Index");
            }
            ModelState.AddModelError("", "Email or Password is Invalid");
            return View();
        }
    }
}
