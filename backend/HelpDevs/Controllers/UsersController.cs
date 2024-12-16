using Microsoft.AspNetCore.Mvc;
using HelpDevs.Data;
using HelpDevs.Models;
using Microsoft.AspNetCore.Http.HttpResults;

[ApiController]
[Route("api/[controller]")]

public class UsersController : ControllerBase
{

  [HttpPost("create")] // /api/users/create
  public IActionResult PostUsers([FromBody] User user)
  {
    Conexao c = new();
    c.TestarConexao();
    UserSQL pessoa = new(c.GetConnectionString());
    pessoa.Cadastrar(user.Name, user.Password);
    return Ok();
  }

  [HttpPost("verify")] //POST: /api/users/verify
  public IActionResult VerificaUserApi([FromBody] User user)
  {
   try
    {
        Conexao conexaoStr = new();
        conexaoStr.TestarConexao();
        UserSQL userSQL = new(conexaoStr.GetConnectionString());
        if (userSQL.VerificaUser(user.Name, user.Password))
        {
          Console.WriteLine("User found");
          return Ok();
        }
        else
        {
          Console.WriteLine(user.Name + " - " + user.Password);
            return NotFound(new { message = "Invalid username or password." });
        }
    }
    catch (Exception ex)
    {
        return StatusCode(500, new { message = "An error occurred", details = ex.Message });
    }
  }
}