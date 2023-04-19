using PetMais.Repository.Interfaces;
using PetMais.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Repository
{
	class Repositorio : IRepository
	{
		protected List<Pet> Pets = ListaDePets.GetInstancia();

		public void AdicionarPet(Pet pet)
		{
			pet.Id = ListaDePets.AutoIncrementoDeId();
			pet.DataDeCadastro = DateTime.Now;
			Pets.Add(pet);
		}

		public void EditarPet(Pet petEditado)
		{
			Pet petAtual = PegarPetPeloId(petEditado.Id);
			int indice = Pets.IndexOf(petAtual);
			Pets[indice] = petEditado;
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

		public void RemoverPet(Pet pet)
		{
			Pets.Remove(pet);
		}
	}
}
