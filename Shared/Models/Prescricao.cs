using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Shared.Models
{
	public class Prescricao
	{
		public int PrescricaoId {get;set; }
		public int PacienteId { get; set; }
		public int MedicoId { get; set; }
		public string Conteudo { get; set; }
		public DateTime DataEntrada { get; set; }


		[JsonIgnore]
		public virtual Paciente? Paciente { get; set; }

		[JsonIgnore]
		public virtual Medico? Medico { get; set; }
	}
}
