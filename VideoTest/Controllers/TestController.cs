using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VideoTest.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index(EmployeeData employeeData)
        {
            return View();
        }

    }
}