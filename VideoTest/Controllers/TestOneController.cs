using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VideoTest.Controllers
{
    public class TestOneController : Controller
    {
        public IActionResult Index(EmployeeDataOne employeeDataOne)
        {
            return View();
        }
    }
}