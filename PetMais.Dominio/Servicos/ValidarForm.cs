using PetMais.Dominio.Notificacoes;
using PetMais.Dominio.Notifications;
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
				erros += MensagensDeExcecoes.CampoNaoPodeEstarVazioMensagem("sexo") + "\n";
			}
			if (CampoNaoPodeEstarVazio(pet.Cor.ToString()))
			{
				erros += MensagensDeExcecoes.CampoNaoPodeEstarVazioMensagem("cor") + "\n";
			}
			if (CampoNaoPodeEstarVazio(pet.Tipo.ToString()))
			{
				erros += MensagensDeExcecoes.CampoNaoPodeEstarVazioMensagem("tipo") + "\n";
			}
			if (Minimo2LetrasEMAximo20Letras(pet.Nome))
			{
				erros += MensagensDeExcecoes.MINIMO_2_LETRAS_MAXIMO_20 + "\n";
			}
			if (NomeNaoPodeConterNumeroOuCaractereEspecial(pet.Nome))
			{
				erros += MensagensDeExcecoes.O_NOME_NAO_PODE_TER_NUMEROS_E_ESPECIAIS + "\n";
			}
			if (DataDeNascimentoNaoPodeSerFuturaADataAtual(pet.DataDeNascimento))
			{
				erros += MensagensDeExcecoes.DATA_DE_NASCIMENTO_NAO_PODE_SER_FUTURA + "\n";
			}
			if (IdadeNaoPodeUltrapassar150Anos(pet.DataDeNascimento))
			{
				erros += MensagensDeExcecoes.IDADE_NAO_ULTRAPASSA_150_ANOS + "\n";
			}

			if (erros.Length > 1)
			{
				throw new MensagensDeErros(erros);
			}
		}

		private static bool CampoNaoPodeEstarVazio(string cb)
		{
			if (cb == "SELECIONAR")
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
