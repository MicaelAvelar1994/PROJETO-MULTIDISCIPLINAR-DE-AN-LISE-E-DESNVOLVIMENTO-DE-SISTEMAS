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
	public class ConsultasController : ControllerBase
	{
		private readonly AppDbContext _context;

		public ConsultasController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Consulta>>> Get()
		{
			return await _context.Consultas
				.Include(c => c.Paciente)
				.Include(c => c.Medico)
				.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Consulta>> Get(int id)
		{
			var consulta = await _context.Consultas
				.Include(c => c.Paciente)
				.Include(c => c.Medico)
				.FirstOrDefaultAsync(c => c.ConsultaId == id);

			if (consulta == null)
				return NotFound();

			return consulta;
		}

		[HttpPost]
		public async Task<ActionResult<Consulta>> Post([FromBody] Consulta consulta)
		{
			_context.Consultas.Add(consulta);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(Get), new { id = consulta.ConsultaId }, consulta);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Consulta consulta)
		{
			if (id != consulta.ConsultaId)
				return BadRequest("ID da URL difere do objeto enviado.");

			_context.Entry(consulta).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ConsultaExists(id))
					return NotFound();

				throw;
			}

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var consulta = await _context.Consultas.FindAsync(id);

			if (consulta == null)
				return NotFound();

			_context.Consultas.Remove(consulta);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool ConsultaExists(int id)
		{
			return _context.Consultas.Any(c => c.ConsultaId == id);
		}
	}
}
