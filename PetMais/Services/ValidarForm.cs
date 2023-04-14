using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Services
{
	public static class ValidarForm
	{

		public static void ValidacaoDosCampos(Pet pet)
		{
			CampoDeTextoNaoPodeEstarVazio(pet.Nome, "nome");
			Minimo2LetrasEMAximo20Letras(pet.Nome);
		}

		private static void CampoDeTextoNaoPodeEstarVazio(string texto, string campo)
		{
			if (texto == "")
			{
				throw new MensagensDeErros($"O campo {campo} não pode ficar vazio");
			}
		}

		private static void Minimo2LetrasEMAximo20Letras(string texto)
		{
			if (texto.Length < 2 || texto.Length > 20)
			{
				throw new MensagensDeErros($"O nome tem que ter entre 2 e 20 letras");
			}
		}

		private static void NomeNaoPodeSerNumero(string texto)
		{
			if (texto.Length < 2 || texto.Length > 20)
			{
				throw new MensagensDeErros($"O nome tem que ter entre 2 e 20 letras");
			}
		}
	}
}
