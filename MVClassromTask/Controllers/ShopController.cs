﻿using Microsoft.AspNetCore.Mvc;

namespace MVClassromTask.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
