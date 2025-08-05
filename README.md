# HelpDevs - Sistema de Login

Este projeto é uma aplicação web simples de login, desenvolvida com **ASP.NET Core MVC** e **MySQL**, com o objetivo de praticar autenticação de usuários e estruturação de um backend funcional.

## 🔧 Tecnologias Utilizadas

- C#
- ASP.NET Core MVC
- MySQL
- MySqlConnector (via NuGet)
- Bootstrap 5 (para estilização)
- Postman (para testes de API)
- Git e GitHub (controle de versão)

## 🚀 Funcionalidades

- Tela de login estilizada com Bootstrap
- Verificação de credenciais com banco de dados MySQL
- Boas práticas com serviços (camada Service)
- Uso de `async`/`await` para operações assíncronas
- Estrutura com injeção de dependência

## 📁 Estrutura do Projeto

/Controllers
UserController.cs
/Models
User.cs
/Services
UserService.cs
Views/
Login.cshtml
Program.cs
appsettings.json

arduino
Copy
Edit

## 🧪 Como testar o login com Postman

1. Selecione o método `POST`
2. Use a URL: `http://localhost:5000/Account/exists`
3. No Body (JSON), envie:

json
{
  "name": "usuario",
  "password": "senha"
}
Se o usuário existir, a resposta será 200 OK. Caso contrário, a view de login será retornada.

🛠️ Como rodar o projeto
Configure a string de conexão no appsettings.json

Execute o projeto no Visual Studio ou via terminal com:

bash
Copy
Edit
dotnet run
Acesse a aplicação em http://localhost:5000

💡 Próximos Passos
Implementar registro de usuários

Criar sistema de sessão/autenticação completa

Melhorar segurança (hash de senhas)

Criar testes automatizados

🤝 Contribuição
Este projeto foi desenvolvido para fins de estudo. Fique à vontade para sugerir melhorias ou abrir pull requests.
