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
	public class MedicosController : ControllerBase
	{
		private readonly AppDbContext _context;

		public MedicosController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Medico>>> Get()
		{
			return await _context.Medicos
				.Include(m => m.Consultas)
				.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Medico>> Get(int id)
		{
			var medico = await _context.Medicos
				.Include(m => m.Consultas)
				.FirstOrDefaultAsync(m => m.MedicoId == id);

			if (medico == null)
				return NotFound();

			return medico;
		}

		[HttpPost]
		public async Task<ActionResult<Medico>> Post([FromBody] Medico medico)
		{
			_context.Medicos.Add(medico);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(Get), new { id = medico.MedicoId }, medico);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Medico medico)
		{
			if (id != medico.MedicoId)
				return BadRequest("ID da URL não bate com o do objeto enviado.");

			_context.Entry(medico).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MedicoExists(id))
					return NotFound();

				throw;
			}

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var medico = await _context.Medicos.FindAsync(id);

			if (medico == null)
				return NotFound();

			_context.Medicos.Remove(medico);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool MedicoExists(int id)
		{
			return _context.Medicos.Any(m => m.MedicoId == id);
		}
	}
}
