using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGHSS.Context;
using Shared.Models;

namespace SGHSS.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class PacientesController : ControllerBase
	{
		private readonly AppDbContext _context;

		public PacientesController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Paciente>>> Get()
		{
			return await _context.Pacientes.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Paciente>> Get(int id)
		{
			var paciente = await _context.Pacientes.FindAsync(id);

			if (paciente == null)
				return NotFound();

			return paciente;
		}

		[HttpPost]
		public async Task<ActionResult<Paciente>> Post([FromBody] Paciente paciente)
		{
			_context.Pacientes.Add(paciente);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(Get), new { id = paciente.PacienteId }, paciente);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Paciente paciente)
		{
			if (id != paciente.PacienteId)
				return BadRequest("ID da URL difere do corpo da requisição");

			_context.Entry(paciente).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PacienteExists(id))
					return NotFound();

				throw;
			}

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var paciente = await _context.Pacientes.FindAsync(id);

			if (paciente == null)
				return NotFound();

			_context.Pacientes.Remove(paciente);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool PacienteExists(int id)
		{
			return _context.Pacientes.Any(e => e.PacienteId == id);
		}
	}
}
