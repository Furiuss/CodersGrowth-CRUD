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
		public List<Pet> Pets { get; set; } = new List<Pet>();

		public void AdicionarPet(Pet pet)
		{
			int idGerado;
			DateTime dataDeCadastro = DateTime.Now;

			if (Pets.Count > 0)
			{
				idGerado = Pets.Max(pet => pet.Id) + 1;		
			}
			else
			{
				idGerado = 1;
			}

			pet.Id = idGerado;
			pet.DataDeCadastro = dataDeCadastro;
			Pets.Add(pet);
		}

		public void EditarPet(Pet pet)
		{
			int indice = Pets.FindIndex(i => i.Id == pet.Id);
			if (indice > -1)
			{
				Pets[indice] = pet;
			}
		}

		public Pet PegarPetPeloId(int id)
		{
			Pet pet = Pets.Find(i => i.Id == id);

			if (pet == null)
			{
				return null;
			}

			return pet;
		}

		public List<Pet> MostrarPets()
		{
			return Pets;
		}
	}
}
