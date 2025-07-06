using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace SGHSS.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Paciente> Pacientes { get; set; }
		public DbSet<Medico> Medicos { get; set; }
		public DbSet<Consulta> Consultas { get; set; }
		public DbSet<Internacao> Internacoes { get; set; }
		public DbSet<Prescricao> Prescricoes { get; set; }
	}
}
