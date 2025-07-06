using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shared.Models;
using SGHSS.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SGHSS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly AppDbContext _context;
		private readonly IConfiguration _configuration;

		public AuthController(AppDbContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
		}

		[HttpPost("login")]
		public IActionResult Login([FromBody] LoginRequest request)
		{
			var paciente = _context.Pacientes.FirstOrDefault(p => p.Email == request.Email);
			if (paciente == null || !BCrypt.Net.BCrypt.Verify(request.Password, paciente.Password))
				return Unauthorized("Credenciais inválidas.");

			var claims = new[]
			{
				new Claim(ClaimTypes.NameIdentifier, paciente.PacienteId.ToString()),
				new Claim(ClaimTypes.Name, paciente.Nome ?? ""),
				new Claim("role", "paciente")
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: _configuration["Jwt:Issuer"],
				audience: _configuration["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddHours(1),
				signingCredentials: creds
			);

			return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
		}

		[HttpPost("register")]
		public async Task<ActionResult> Register([FromBody] RegisterRequest request)
		{
			if (_context.Pacientes.Any(p => p.Email == request.Email))
				return BadRequest("Email já está em uso.");

			var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

			var paciente = new Paciente
			{
				Nome = request.Nome,
				Idade = request.Idade,
				Cpf = request.Cpf,
				Telefone = request.Telefone,
				Email = request.Email,
				Password = hashedPassword
			};

			_context.Pacientes.Add(paciente);
			await _context.SaveChangesAsync();

			return Ok("Cadastro realizado com sucesso.");
		}
	}

	public class LoginRequest
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}

	public class RegisterRequest
	{
		public string Nome { get; set; }
		public int Idade { get; set; }
		public string Cpf { get; set; }
		public string Telefone { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
