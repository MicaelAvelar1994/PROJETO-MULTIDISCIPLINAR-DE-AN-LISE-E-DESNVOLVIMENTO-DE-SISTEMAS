using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Medico
    {
        public int MedicoId { get; set; }
        public string? Nome { get; set; }
        public string? Especialidade { get; set; }
        public string? CRM { get; set; }
		// Relacionamentos
		[JsonIgnore]
		public virtual ICollection<Consulta>? Consultas { get; set; } = new List<Consulta>();
    }
}
