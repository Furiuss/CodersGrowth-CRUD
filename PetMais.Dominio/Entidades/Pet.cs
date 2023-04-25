using LinqToDB.Mapping;
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
		[PrimaryKey, Identity]
		public int Id { get; set; }
		[NotNull]
		public string Nome { get; set; }
		[NotNull]
		public TipoPet Tipo { get; set; }
		[NotNull]
		public CorPet Cor { get; set;}
		[NotNull]
		public SexoPet Sexo { get; set; }
		[NotNull]
		public DateTime DataDeNascimento { get; set; }
		[NotNull]
		public DateTime DataDeCadastro { get; set; }

		public Pet(string nome, TipoPet tipo, CorPet cor, SexoPet sexo, DateTime dataDeNascimento)
		{
			Nome = nome;
			Tipo = tipo;
			Cor = cor;
			Sexo = sexo;
			DataDeNascimento = dataDeNascimento;
		}

		public Pet() { }
	}
}
