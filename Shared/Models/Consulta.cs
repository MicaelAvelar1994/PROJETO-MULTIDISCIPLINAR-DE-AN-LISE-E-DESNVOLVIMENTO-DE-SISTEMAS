using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Consulta
    {
        public int ConsultaId { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
		// Relacionamentos
		[JsonIgnore]
		public virtual Paciente? Paciente { get; set; }
		[JsonIgnore]
		public virtual Medico? Medico { get; set; }
    }
}
