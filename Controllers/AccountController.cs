using HelpDevs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HelpDevs.Data;

namespace HelpDevs.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(); // procura Views/Account/Login.cshtml
        }

        [HttpPost]

        public async Task<IActionResult> AddUser(User user)
        {
            bool sucess = await _userService.AddUser(user);

            if (sucess)
            {
                Console.WriteLine("User Criado");
                Console.WriteLine($"Nome: {user.Name} , Password: {user.Password}");
                return Ok();
            }
            else
            {
                ViewBag.MensagemErro = "Erro ao cadastrar usuário.";
                return View("Login"); // mostra novamente a tela de login com mensagem
            }

        }


    }
}