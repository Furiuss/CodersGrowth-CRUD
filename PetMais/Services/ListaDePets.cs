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

		public static int AutoIncrementoDeId()
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
