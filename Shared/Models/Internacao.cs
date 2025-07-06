using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Models
{
	public class Internacao
	{
		public int InternacaoId { get; set; }
		public int PacienteId { get; set; }
		public int LeitoNumero {get; set;}
		public DateTime DataEntrada {get;set;}
		public DateTime DataSaida { get; set; }
		public bool ativa {get; set;}

		[JsonIgnore]
		public virtual Paciente? Paciente { get; set; }
	}
}
