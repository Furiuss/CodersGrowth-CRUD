using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Services
{
	public sealed class ListaDePets
	{
		private static ListaDePets instancia = new ListaDePets();
		private List<Pet> Pets = new List<Pet>();

		private ListaDePets() { }

		public static ListaDePets GetInstancia()
		{
			{
				if (instancia == null)
				{
					instancia = new ListaDePets();
				}

				return instancia;
			}
		}

		public List<Pet> PegarListaDePets()
		{
			return Pets;
		}

		public Pet PegarPetPeloId(int id)
		{
			Pet pet = Pets.FirstOrDefault(i => i.Id == id);

			if (pet == null)
			{
				return null;
			}

			return pet;
		}

		public void AdicionarPet(Pet pet)
		{
			pet.Id = AutoIncrementoDeId();
			pet.DataDeCadastro = DateTime.Now;
			Pets.Add(pet);
		}

		public void RemoverPet(Pet pet)
		{
			Pets.Remove(pet);
		}

		public void EditarPet(Pet petAtual, Pet petEditado)
		{
			int indice = Pets.IndexOf(petAtual);
			Pets[indice] = petEditado;
		}

		private int AutoIncrementoDeId()
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
