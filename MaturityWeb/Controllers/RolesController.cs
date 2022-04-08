using MaturityDAL.Models;
using MaturityRepo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaturityWeb.Controllers
{
    public class RolesController : Controller
    {
        IRole obj;
        public RolesController(IRole ob)
        {
            obj = ob;
        }
        public IActionResult Index()
        {
            List<Role> result = obj.GetAllRole();
            return View(result);
        }
        public IActionResult Create(int id)
        {
            Role r = obj.GetRoleById(id);
            return View(r);
        }
        [HttpPost]
        [ActionName("Add")]
        public IActionResult Create(Role r)
        {
            obj.AddRole(r);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            Role r = obj.GetRoleById(id);
            return View(r);
        }
        public IActionResult Edit(int id)
        {
            Role r = obj.GetRoleById(id);
            return View(r);
        }
        [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditDetails(Role r)
        {
            obj.UpdateRole(r);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Role r = obj.GetRoleById(id);
            return View(r);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteRole(int id)
        {
            obj.DeleteRole(id);
            return RedirectToAction("Index");
        }
        
    }
}
