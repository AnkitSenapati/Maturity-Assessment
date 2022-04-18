using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaturityWeb.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DevelopmentReport()
        {
            return View();
        }
        public IActionResult TestingReport()
        {
            return View();
        }
        public IActionResult BusinessReport()
        {
            return View();
        }
        public IActionResult ConsultingReport()
        {
            return View();
        }
    }
}
