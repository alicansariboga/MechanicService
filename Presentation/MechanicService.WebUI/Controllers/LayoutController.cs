﻿using Microsoft.AspNetCore.Mvc;

namespace MechanicService.WebUI.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
