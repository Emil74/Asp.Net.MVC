﻿using Microsoft.AspNetCore.Mvc;

namespace Lesson8.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
