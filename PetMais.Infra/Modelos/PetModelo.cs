using LinqToDB;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Infra.Modelos
{
	[Table(Name = "Pet")]
	public class PetModelo
	{
		[PrimaryKey, Identity]
		public int Id { get; set; }
		[Column, NotNull]
		public string Nome { get; set; }
		[Column, NotNull]
		public string Tipo { get; set; }
		[Column, NotNull]
		public string Sexo { get; set; }
		[Column, NotNull]
		public DateTime DataDeNascimento { get; set; }
		[Column, NotNull]
		public DateTime DataDeCadastro { get; set; }
	}
}
