using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace Shared.Models
{
    public class Paciente
    {
        public int PacienteId { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }

		[JsonIgnore]
		public virtual ICollection<Consulta>? Consultas { get; set; } = new List<Consulta>();
	}
}
