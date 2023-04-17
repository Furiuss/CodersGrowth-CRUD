using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetMais.Services
{
	public static class ValidarForm
	{

		public static void ValidacaoDosCampos(Pet pet)
		{
			CampoDeTextoNaoPodeEstarVazio(pet.Nome, "nome");
			Minimo2LetrasEMAximo20Letras(pet.Nome);
			NomeNaoPodeConterNumeroOuCaractereEspecial(pet.Nome);
			DataDeNascimentoNaoPodeSerFuturaADataAtual(pet.DataDeNascimento);
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

		private static void NomeNaoPodeConterNumeroOuCaractereEspecial(string texto)
		{
			Regex regex = new Regex(@"^[a-zA-Z\s]+$");
			if(!regex.IsMatch(texto))
			{
				throw new MensagensDeErros("O nome não pode conter números ou caracteres especiais");
			}
		}

		private static void DataDeNascimentoNaoPodeSerFuturaADataAtual(DateTime dataNascimento)
		{
			if (dataNascimento > DateTime.Now)
			{
				throw new MensagensDeErros("Data de nascimento não pode ser futura");
			}
		}
	}
}
