using PetMais.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Services
{
	public class ListaDePets
	{
		public static List<Pet> ListaPets { get; set; }

		public ListaDePets()
		{
			ListaPets = new List<Pet>();
			ListaPets.AddRange(new[]
			{
				new Pet(1, "Junior", "Gato", "Preto", SexoPet.MASCULINO, DateTime.Now, DateTime.Now),
				new Pet(2, "Max", "Cachorro", "Caramelo", SexoPet.MASCULINO, DateTime.Now, DateTime.Now),
				new Pet(3, "Judite", "Cachorro", "Branco", SexoPet.FEMININO, DateTime.Now, DateTime.Now)
			});
		}

		public static void AddPet(Pet pet)
		{
			int id = gerarId();
			DateTime dataAtual = DateTime.Now;

			ListaPets.AddRange(new[]
			{
				new Pet(id, pet.Nome, pet.Cor, pet.Tipo, pet.Sexo, pet.DataDeNascimento, dataAtual)
			}); ;
		}

		private static int gerarId()
		{
			var lastItem = ListaPets.Last();
			return lastItem.Id + 1;
		}

		public static List<Pet> mostrarListaDePets()
		{
			return ListaPets;
		}
	}
}
