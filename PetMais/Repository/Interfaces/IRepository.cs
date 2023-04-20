using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Repository.Interfaces
{
	public interface IRepository
	{
		public List<Pet> PegarListaDePets();
		public Pet PegarPetPeloId(int id);
		public void AdicionarPet(Pet pet);
		public void RemoverPet(int id);
		public void EditarPet(Pet petEditado);
	}
}
