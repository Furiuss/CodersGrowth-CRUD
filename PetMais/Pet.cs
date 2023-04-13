using PetMais.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace PetMais
{
	public class Pet
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Tipo { get; set; }
		public string Cor { get; set;}
		public SexoPet Sexo { get; set; }
		public DateTime DataDeNascimento { get; set; }
		public DateTime HorarioDeCadastro { get; set; }
	}
}
