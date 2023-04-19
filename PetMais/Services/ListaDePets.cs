using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Services
{
	public sealed class ListaDePets
	{
		private static List<Pet> Pets;

		private ListaDePets() { }

		public static List<Pet> GetInstancia()
		{
			{
				if (Pets == null)
				{
					Pets = new List<Pet>();
				}

				return Pets;
			}
		}

		public static List<Pet> PegarListaDePets()
		{
			return Pets;
		}

		public static Pet PegarPetPeloId(int id)
		{
			Pet pet = Pets.FirstOrDefault(i => i.Id == id);

			if (pet == null)
			{
				return null;
			}

			return pet;
		}

		public static void AdicionarPet(Pet pet)
		{
			pet.Id = AutoIncrementoDeId();
			pet.DataDeCadastro = DateTime.Now;
			Pets.Add(pet);
		}

		public static void RemoverPet(Pet pet)
		{
			Pets.Remove(pet);
		}

		public static void EditarPet(Pet petEditado)
		{
			Pet petAtual = PegarPetPeloId(petEditado.Id);
			int indice = Pets.IndexOf(petAtual);
			Pets[indice] = petEditado;
		}

		private static int AutoIncrementoDeId()
		{
			if (Pets.Count > 0)
			{
				return Pets.Max(pet => pet.Id) + 1;
			}
			else
			{
				return 1;
			}
		}
	}
}
