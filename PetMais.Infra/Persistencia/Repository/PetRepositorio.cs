using PetMais.Dominio.Persistencia;
using PetMais.Repository.Interfaces;
using PetMais.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Repository
{
	public class PetRepositorio : IRepository
	{
		protected List<Pet> _pets = ListaDePets.GetInstancia();

		public void AdicionarPet(Pet pet)
		{
			pet.Id = ListaDePets.AutoIncrementoDeId();
			pet.DataDeCadastro = DateTime.Now;
			_pets.Add(pet);
		}

		public void EditarPet(Pet petEditado)
		{
			Pet petAtual = PegarPetPeloId(petEditado.Id);
			int indice = _pets.IndexOf(petAtual);
			_pets[indice] = petEditado;
		}

		public List<Pet> PegarListaDePets()
		{
			return _pets;
		}

		public Pet PegarPetPeloId(int id)
		{
			Pet pet = _pets.FirstOrDefault(i => i.Id == id);

			if (pet == null)
			{
				return null;
			}

			return pet;
		}

		public void RemoverPet(int id)
		{
			Pet pet = PegarPetPeloId(id);
			_pets.Remove(pet);
		}
	}
}
