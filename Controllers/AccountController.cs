using HelpDevs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HelpDevs.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View(); // procura Views/Account/Login.cshtml
        }
    }
}