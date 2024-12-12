using Microsoft.AspNetCore.Mvc;
using HelpDevs.Data;
using HelpDevs.Models;

[ApiController]
[Route("api/[controller]")] //Rota base: /api/users

public class UsersController : ControllerBase{

    [HttpPost] 
    public IActionResult PostUsers([FromBody] User user)
    {
      Conexao c = new();
      UserSQL pessoa = new(c.GetConnectionString());
      pessoa.Cadastrar(user.Name, user.Password);
      return Ok();
    }
}