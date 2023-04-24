using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Dominio.Notifications
{
	public class MensagensDeErros : Exception
	{
		public MensagensDeErros(string message) : base(message)
		{

		}
	}
}
