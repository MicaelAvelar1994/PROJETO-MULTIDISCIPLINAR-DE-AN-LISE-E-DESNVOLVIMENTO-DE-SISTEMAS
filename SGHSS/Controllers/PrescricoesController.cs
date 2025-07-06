using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGHSS.Context;
using Shared.Models;

namespace SGHSS.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class PrescricoesController : ControllerBase
	{
		private readonly AppDbContext _context;

		public PrescricoesController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Prescricao>>> GetPrescricoes()
		{
			return await _context.Prescricoes
				.Include(p => p.Paciente)
				.Include(p => p.Medico)
				.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Prescricao>> GetPrescricao(int id)
		{
			var prescricao = await _context.Prescricoes
				.Include(p => p.Paciente)
				.Include(p => p.Medico)
				.FirstOrDefaultAsync(p => p.PrescricaoId == id);

			if (prescricao == null)
				return NotFound();

			return prescricao;
		}

		[HttpPost]
		public async Task<ActionResult<Prescricao>> PostPrescricao(Prescricao prescricao)
		{
			_context.Prescricoes.Add(prescricao);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetPrescricao), new { id = prescricao.PrescricaoId }, prescricao);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutPrescricao(int id, Prescricao prescricao)
		{
			if (id != prescricao.PrescricaoId)
				return BadRequest();

			_context.Entry(prescricao).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PrescricaoExists(id))
					return NotFound();
				else
					throw;
			}

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePrescricao(int id)
		{
			var prescricao = await _context.Prescricoes.FindAsync(id);
			if (prescricao == null)
				return NotFound();

			_context.Prescricoes.Remove(prescricao);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool PrescricaoExists(int id)
		{
			return _context.Prescricoes.Any(e => e.PrescricaoId == id);
		}
	}
}
