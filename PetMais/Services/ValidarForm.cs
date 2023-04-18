using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetMais.Services
{
	public class ValidarForm
	{
		public static void ValidacaoDosCampos(Pet pet)
		{
			string erros = "";								

			if (CampoNaoPodeEstarVazio(pet.Sexo.ToString()))
			{
				erros += "O campo sexo precisa ser selecionado\n";
			}
			if (CampoNaoPodeEstarVazio(pet.Cor.ToString()))
			{
				erros += "O campo cor precisa ser selecionado\n";
			}
			if (CampoNaoPodeEstarVazio(pet.Tipo.ToString()))
			{
				erros += "O campo tipo precisa ser selecionado\n";
			}
			if (Minimo2LetrasEMAximo20Letras(pet.Nome))
			{
				erros += "O nome tem que ter entre 2 e 20 letras\n";
			}
			if (NomeNaoPodeConterNumeroOuCaractereEspecial(pet.Nome))
			{
				erros += "O nome não pode conter números ou caracteres especiais\n";
			}
			if (DataDeNascimentoNaoPodeSerFuturaADataAtual(pet.DataDeNascimento))
			{
				erros += "Data de nascimento não pode ser futura\n";
			}
			if (IdadeNaoPodeUltrapassar150Anos(pet.DataDeNascimento))
			{
				erros += "Idade do pet não pode ultrapassar 150 anos\n";
			}

			if (erros.Length > 1)
			{
				throw new MensagensDeErros(erros);
			}
		}

		private static bool CampoNaoPodeEstarVazio(string cb)
		{
			if (cb == "SELECIONAR" || cb == null)
			{
				return true;
			}

			return false;
		}

		private static bool Minimo2LetrasEMAximo20Letras(string texto)
		{
			if (texto.Length < 2 || texto.Length > 20)
			{
				return true;
			}

			return false;
		}

		private static bool NomeNaoPodeConterNumeroOuCaractereEspecial(string texto)
		{
			Regex regex = new Regex(@"^[a-zA-Z\s]+$");
			if(!regex.IsMatch(texto))
			{
				return true;
			}
			return false;
		}

		private static bool DataDeNascimentoNaoPodeSerFuturaADataAtual(DateTime dataNascimento)
		{
			if (dataNascimento > DateTime.Now)
			{
				return true;
			}

			return false;
		}

		private static bool IdadeNaoPodeUltrapassar150Anos(DateTime dataNascimento)
		{
			int dataAtual = DateTime.Now.Year;
			int nascimento = dataNascimento.Year;
			int idade = dataAtual - nascimento;

			if (idade > 150)
			{
				return true;
			}

			return false;
		}
	}
}
