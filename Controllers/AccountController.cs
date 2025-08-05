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

        //  Account -> Rota Principal 
        [HttpGet]
        public IActionResult Login()
        {
            return View(); // procura Views/Account/Login.cshtml
        }



        //  Account/AddUser -> Rota para Adicionar usuário 
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] User user) // http://localhoast:5008/AddUser
        {
            bool sucess = await _userService.AddUser(user);

            if (sucess)
            {
                Console.WriteLine("User Criado");
                Console.WriteLine($"Nome: {user.Name} , Password: {user.Password}");
                return View("AddUser");
            }
            else
            {
                ViewBag.MensagemErro = "Erro ao cadastrar usuário.";
                return View("Login"); // mostra novamente a tela de login com mensagem
            }

        }


        // Account/exists -> usa VerifyUser
        [HttpPost("Account/Exists")]
        public async Task<IActionResult> Exists([FromBody] User user)
        {
            bool isTrue = await _userService.VerifyUser(user);

            if (isTrue)
            {
                Console.WriteLine($"Usuario {user.Name} Autorizado");
                return Ok();
            }
            else
            {
                Console.WriteLine("Acesso Negado");
                return Unauthorized();
            }
        }


    }
}