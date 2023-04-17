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
		public TipoPet Tipo { get; set; }
		public CorPet Cor { get; set;}
		public SexoPet Sexo { get; set; }
		public DateTime DataDeNascimento { get; set; }
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
